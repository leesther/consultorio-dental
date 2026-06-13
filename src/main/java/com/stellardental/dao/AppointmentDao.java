package com.stellardental.dao;

import com.stellardental.config.Conexion;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.time.LocalDateTime;

public class AppointmentDao {
    private final UserDao userDao = new UserDao();

    public long createAppointment(long patientId, String motivo, String detalles, LocalDateTime inicio, long requestedByUserId) throws SQLException {
        try (Connection connection = Conexion.getConnection()) {
            long assignedUserId = requestedByUserId > 0 ? requestedByUserId : userDao.findDefaultDoctorId(connection);
            return createAppointment(connection, patientId, assignedUserId, motivo, detalles, inicio);
        }
    }

    public long createAppointment(Connection connection, long patientId, long userId, String motivo, String detalles, LocalDateTime inicio) throws SQLException {
        long id = nextValue(connection, "citas_id_cita_seq");
        LocalDateTime fin = inicio.plusMinutes(60);
        String fullMotivo = detalles == null || detalles.isBlank()
                ? motivo
                : motivo + " - " + detalles.trim();

        String sql = """
                INSERT INTO citas
                    (id, id_cita, id_paciente, id_doctor, id_usuario, fecha_inicio, fecha_fin,
                     fecha_hora_inicio, fecha_hora_fin, motivo, estado)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 'PROGRAMADA')
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, id);
            statement.setLong(2, id);
            statement.setLong(3, patientId);
            statement.setLong(4, userId);
            statement.setLong(5, userId);
            statement.setTimestamp(6, Timestamp.valueOf(inicio));
            statement.setTimestamp(7, Timestamp.valueOf(fin));
            statement.setTimestamp(8, Timestamp.valueOf(inicio));
            statement.setTimestamp(9, Timestamp.valueOf(fin));
            statement.setString(10, fullMotivo);
            statement.executeUpdate();
        }

        return id;
    }

    private long nextValue(Connection connection, String sequence) throws SQLException {
        try (PreparedStatement statement = connection.prepareStatement("SELECT nextval(?)")) {
            statement.setString(1, sequence);
            try (ResultSet result = statement.executeQuery()) {
                result.next();
                return result.getLong(1);
            }
        }
    }
}
