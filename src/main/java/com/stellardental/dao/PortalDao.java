package com.stellardental.dao;

import com.stellardental.config.Conexion;
import com.stellardental.model.Appointment;
import com.stellardental.model.ClinicalRecord;
import com.stellardental.model.Patient;
import com.stellardental.model.Payment;
import com.stellardental.model.PortalData;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class PortalDao {
    private final PatientDao patientDao = new PatientDao();

    public PortalData loadForUser(Long patientId, String email) throws SQLException {
        try (Connection connection = Conexion.getConnection()) {
            PortalData data = new PortalData();
            Optional<Patient> patient = patientId == null
                    ? patientDao.findByEmail(connection, email)
                    : patientDao.findById(connection, patientId);

            if (patient.isEmpty()) {
                return data;
            }

            data.setPatient(patient.get());
            long id = patient.get().getId();
            data.setNextAppointment(findNextAppointment(connection, id));
            data.setClinicalRecords(findClinicalRecords(connection, id));
            data.setPayments(findPayments(connection, id));
            data.setTotalPagado(sumPayments(data.getPayments(), false));
            data.setSaldoPendiente(sumPayments(data.getPayments(), true));
            loadOdontogram(connection, id, data);
            return data;
        }
    }

    private Appointment findNextAppointment(Connection connection, long patientId) throws SQLException {
        String sql = """
                SELECT c.id_cita, c.fecha_hora_inicio, c.fecha_hora_fin, c.motivo, c.estado,
                       COALESCE(u.nombre || ' ' || u.apellido, u.nombres || ' ' || u.apellidos, 'Doctor asignado') AS doctor
                FROM citas c
                LEFT JOIN usuarios u ON u.id_usuario = c.id_doctor OR u.id = c.id_doctor
                WHERE c.id_paciente = ? AND COALESCE(c.estado, '') <> 'CANCELADA'
                ORDER BY c.fecha_hora_inicio ASC
                LIMIT 1
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, patientId);
            try (ResultSet result = statement.executeQuery()) {
                if (result.next()) {
                    return new Appointment(
                            result.getLong("id_cita"),
                            toLocalDateTime(result.getTimestamp("fecha_hora_inicio")),
                            toLocalDateTime(result.getTimestamp("fecha_hora_fin")),
                            result.getString("motivo"),
                            result.getString("estado"),
                            result.getString("doctor")
                    );
                }
            }
        }
        return null;
    }

    private List<ClinicalRecord> findClinicalRecords(Connection connection, long patientId) throws SQLException {
        List<ClinicalRecord> records = new ArrayList<>();
        String sql = """
                SELECT fecha_registro, diagnostico, tratamiento, observaciones
                FROM historiales_clinicos
                WHERE id_paciente = ?
                ORDER BY fecha_registro DESC
                LIMIT 10
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, patientId);
            try (ResultSet result = statement.executeQuery()) {
                while (result.next()) {
                    records.add(new ClinicalRecord(
                            toLocalDateTime(result.getTimestamp("fecha_registro")),
                            result.getString("diagnostico"),
                            result.getString("tratamiento"),
                            result.getString("observaciones")
                    ));
                }
            }
        }
        return records;
    }

    private List<Payment> findPayments(Connection connection, long patientId) throws SQLException {
        List<Payment> payments = new ArrayList<>();
        String sql = """
                SELECT fecha_pago, fecha_vencimiento, metodo_pago, estado, monto, monto_pendiente, observaciones, COALESCE(es_deuda, false) AS es_deuda
                FROM pagos
                WHERE id_paciente = ?
                ORDER BY COALESCE(fecha_pago, fecha_vencimiento) DESC NULLS LAST, id DESC
                LIMIT 20
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, patientId);
            try (ResultSet result = statement.executeQuery()) {
                while (result.next()) {
                    payments.add(new Payment(
                            toLocalDateTime(result.getTimestamp("fecha_pago")),
                            toLocalDateTime(result.getTimestamp("fecha_vencimiento")),
                            result.getString("metodo_pago"),
                            result.getString("estado"),
                            result.getBigDecimal("monto"),
                            result.getBigDecimal("monto_pendiente"),
                            result.getString("observaciones"),
                            result.getBoolean("es_deuda")
                    ));
                }
            }
        }
        return payments;
    }

    private void loadOdontogram(Connection connection, long patientId, PortalData data) throws SQLException {
        String sql = """
                SELECT o.id_odontograma, o.observaciones_generales,
                       (SELECT count(*) FROM odontograma_detalle d WHERE d.id_odontograma = o.id_odontograma) AS hallazgos
                FROM odontogramas o
                WHERE o.id_paciente = ?
                ORDER BY COALESCE(o.fecha_actualizacion, o.fecha_ultima_actualizacion) DESC NULLS LAST
                LIMIT 1
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, patientId);
            try (ResultSet result = statement.executeQuery()) {
                if (result.next()) {
                    data.setOdontogramObservations(result.getString("observaciones_generales"));
                    data.setOdontogramFindings(result.getInt("hallazgos"));
                }
            }
        }
    }

    private BigDecimal sumPayments(List<Payment> payments, boolean debtOnly) {
        return payments.stream()
                .filter(payment -> debtOnly == payment.isDeuda())
                .map(payment -> {
                    BigDecimal value = debtOnly ? payment.getMontoPendiente() : payment.getMonto();
                    return value == null ? BigDecimal.ZERO : value;
                })
                .reduce(BigDecimal.ZERO, BigDecimal::add);
    }

    private java.time.LocalDateTime toLocalDateTime(Timestamp timestamp) {
        return timestamp == null ? null : timestamp.toLocalDateTime();
    }
}
