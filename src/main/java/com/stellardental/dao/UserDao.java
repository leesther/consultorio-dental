package com.stellardental.dao;

import com.stellardental.config.Conexion;
import com.stellardental.model.AppUser;
import org.mindrot.jbcrypt.BCrypt;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Optional;

public class UserDao {
    public Optional<AppUser> authenticate(String email, String password) throws SQLException {
        String sql = """
                SELECT id_usuario, nombre, apellido, nombres, apellidos, email, id_rol, password_hash, clave_hash
                FROM usuarios
                WHERE lower(email) = lower(?) AND activo = true
                LIMIT 1
                """;

        try (Connection connection = Conexion.getConnection();
             PreparedStatement statement = connection.prepareStatement(sql)) {
            statement.setString(1, email.trim());

            try (ResultSet result = statement.executeQuery()) {
                if (!result.next()) {
                    return Optional.empty();
                }

                String hash = nonBlank(result.getString("password_hash"), result.getString("clave_hash"));
                if (hash == null || !BCrypt.checkpw(password, hash)) {
                    return Optional.empty();
                }

                return Optional.of(new AppUser(
                        result.getLong("id_usuario"),
                        nonBlank(result.getString("nombre"), result.getString("nombres")),
                        nonBlank(result.getString("apellido"), result.getString("apellidos")),
                        result.getString("email"),
                        result.getInt("id_rol")
                ));
            }
        }
    }

    public long findDefaultDoctorId(Connection connection) throws SQLException {
        String sql = """
                SELECT id_usuario
                FROM usuarios
                WHERE activo = true
                ORDER BY CASE WHEN id_rol = 2 THEN 0 ELSE 1 END, id_usuario
                LIMIT 1
                """;

        try (PreparedStatement statement = connection.prepareStatement(sql);
             ResultSet result = statement.executeQuery()) {
            if (result.next()) {
                return result.getLong("id_usuario");
            }
        }
        throw new SQLException("No hay usuarios activos para asignar la cita.");
    }

    private String nonBlank(String preferred, String fallback) {
        if (preferred != null && !preferred.isBlank()) {
            return preferred;
        }
        return fallback;
    }
}
