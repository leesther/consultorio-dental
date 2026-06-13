package com.stellardental.dao;

import com.stellardental.model.Patient;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.Optional;

public class PatientDao {
    public Optional<Patient> findByEmail(Connection connection, String email) throws SQLException {
        if (email == null || email.isBlank()) {
            return Optional.empty();
        }

        String sql = """
                SELECT id_paciente, nombre, apellido, nombres, apellidos, dni, email, telefono
                FROM pacientes
                WHERE lower(email) = lower(?)
                LIMIT 1
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setString(1, email.trim());
            try (ResultSet result = statement.executeQuery()) {
                if (result.next()) {
                    return Optional.of(map(result));
                }
            }
        }
        return Optional.empty();
    }

    public Optional<Patient> findById(Connection connection, long id) throws SQLException {
        String sql = """
                SELECT id_paciente, nombre, apellido, nombres, apellidos, dni, email, telefono
                FROM pacientes
                WHERE id_paciente = ? OR id = ?
                LIMIT 1
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, id);
            statement.setLong(2, id);
            try (ResultSet result = statement.executeQuery()) {
                if (result.next()) {
                    return Optional.of(map(result));
                }
            }
        }
        return Optional.empty();
    }

    public Patient findOrCreate(Connection connection, String fullName, String dni, String age, String phone, String email) throws SQLException {
        Optional<Patient> existing = findByEmail(connection, email);
        if (existing.isPresent()) {
            return existing.get();
        }

        long id = nextValue(connection, "pacientes_id_paciente_seq");
        String[] nameParts = splitName(fullName);
        LocalDate birthDate = approximateBirthDate(age);
        String sql = """
                INSERT INTO pacientes
                    (id, id_paciente, nombre, apellido, nombres, apellidos, dni, email, telefono, fecha_nacimiento)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setLong(1, id);
            statement.setLong(2, id);
            statement.setString(3, nameParts[0]);
            statement.setString(4, nameParts[1]);
            statement.setString(5, nameParts[0]);
            statement.setString(6, nameParts[1]);
            statement.setString(7, dni);
            statement.setString(8, email);
            statement.setString(9, phone);
            if (birthDate == null) {
                statement.setNull(10, java.sql.Types.DATE);
            } else {
                statement.setDate(10, Date.valueOf(birthDate));
            }
            statement.executeUpdate();
        }

        return new Patient(id, nameParts[0], nameParts[1], dni, email, phone);
    }

    private Patient map(ResultSet result) throws SQLException {
        String nombre = nonBlank(result.getString("nombre"), result.getString("nombres"));
        String apellido = nonBlank(result.getString("apellido"), result.getString("apellidos"));
        return new Patient(
                result.getLong("id_paciente"),
                nombre,
                apellido,
                result.getString("dni"),
                result.getString("email"),
                result.getString("telefono")
        );
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

    private String[] splitName(String fullName) {
        String clean = fullName == null ? "" : fullName.trim().replaceAll("\\s+", " ");
        if (clean.isBlank()) {
            return new String[]{"Paciente", ""};
        }
        String[] parts = clean.split(" ", 2);
        return new String[]{parts[0], parts.length > 1 ? parts[1] : ""};
    }

    private LocalDate approximateBirthDate(String age) {
        try {
            int years = Integer.parseInt(age);
            return LocalDate.now().minusYears(years);
        } catch (NumberFormatException ignored) {
            return null;
        }
    }

    private String nonBlank(String preferred, String fallback) {
        if (preferred != null && !preferred.isBlank()) {
            return preferred;
        }
        return fallback;
    }
}
