package com.stellardental.servlet;

import com.stellardental.config.Conexion;
import org.mindrot.jbcrypt.BCrypt; // ¡IMPORTANTE: Importamos BCrypt!

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet(name = "ActivarCuentaServlet", urlPatterns = {"/ActivarCuentaServlet"})
public class ActivarCuentaServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");

        String email = request.getParameter("email");
        String password = request.getParameter("password");
        String confirmPassword = request.getParameter("confirmPassword");

        // 1. Validar que las contraseñas coincidan
        if (password == null || !password.equals(confirmPassword)) {
            request.setAttribute("errorMessage", "Las contraseñas no coinciden. Inténtalo de nuevo.");
            request.setAttribute("activarEmail", email);
            request.getRequestDispatcher("crear_password.jsp").forward(request, response);
            return;
        }

        try (Connection connection = Conexion.getConnection()) {
            long idPaciente = 0;
            String nombreCompleto = "";

            // 2. Obtener datos del paciente registrado
            String sqlPaciente = "SELECT id, nombre, apellido FROM pacientes WHERE email = ?";
            try (PreparedStatement ps = connection.prepareStatement(sqlPaciente)) {
                ps.setString(1, email.trim());
                try (ResultSet rs = ps.executeQuery()) {
                    if (rs.next()) {
                        idPaciente = rs.getLong("id");
                        String pNombre = rs.getString("nombre") != null ? rs.getString("nombre") : "";
                        String pApellido = rs.getString("apellido") != null ? rs.getString("apellido") : "";
                        nombreCompleto = (pNombre + " " + pApellido).trim();

                        if (nombreCompleto.isEmpty()) {
                            nombreCompleto = "Paciente Registrado";
                        }
                    }
                }
            }

            // 3. Extraer Nombre y Apellido individuales para las restricciones de la BD
            String nombreSolo = "";
            String apellidoSolo = "";
            int espacioIndex = nombreCompleto.indexOf(" ");

            if (espacioIndex != -1) {
                nombreSolo = nombreCompleto.substring(0, espacioIndex);
                apellidoSolo = nombreCompleto.substring(espacioIndex + 1);
            } else {
                nombreSolo = nombreCompleto;
                apellidoSolo = "Perez";
            }

            // CORRECCIÓN CRÍTICA: Encriptar la contraseña usando BCrypt antes de guardar
            // BCrypt.gensalt(12) genera una sal segura con un factor de costo de 12
            String passwordEncriptada = BCrypt.hashpw(password, BCrypt.gensalt(12));

            // 4. Insertar las credenciales rellenando todas las columnas de la tabla usuarios
            String sqlInsertUsuario = """
                INSERT INTO usuarios (
                    id, id_usuario, nombre, nombres, apellido, apellidos, 
                    email, clave_hash, password_hash, id_rol, activo, fecha_creacion
                )
                VALUES (
                    nextval('usuarios_id_seq'), nextval('usuarios_id_seq'), ?, ?, ?, ?, 
                    ?, ?, ?, 2, true, CURRENT_TIMESTAMP
                )
            """;

            try (PreparedStatement psInsert = connection.prepareStatement(sqlInsertUsuario)) {
                psInsert.setString(1, nombreCompleto);
                psInsert.setString(2, nombreSolo);
                psInsert.setString(3, apellidoSolo);
                psInsert.setString(4, apellidoSolo);
                psInsert.setString(5, email.trim());
                psInsert.setString(6, passwordEncriptada); // clave_hash (Ahora seguro con BCrypt)
                psInsert.setString(7, passwordEncriptada); // password_hash (Ahora seguro con BCrypt)
                psInsert.executeUpdate();
            }

            // 5. LOGIN AUTOMÁTICO: Inicializar la sesión HTTP con los tokens requeridos
            HttpSession session = request.getSession(true);
            session.setAttribute("usuarioId", idPaciente);
            session.setAttribute("patientId", idPaciente);
            session.setAttribute("usuarioNombre", nombreCompleto);
            session.setAttribute("usuarioEmail", email.trim());
            session.setAttribute("usuarioRolId", 2L);

            // Redirección directa al dashboard limpio
            response.sendRedirect(request.getContextPath() + "/dashboard.jsp");

        } catch (SQLException e) {
            e.printStackTrace();
            request.setAttribute("errorMessage", "Error al escribir en la base de datos: " + e.getMessage());
            request.setAttribute("activarEmail", email);
            request.getRequestDispatcher("crear_password.jsp").forward(request, response);
        }
    }
}