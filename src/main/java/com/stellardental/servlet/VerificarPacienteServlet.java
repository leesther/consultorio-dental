package com.stellardental.servlet;

import com.stellardental.config.Conexion;
import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet(name = "VerificarPacienteServlet", urlPatterns = {"/VerificarPacienteServlet"})
public class VerificarPacienteServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");

        String email = request.getParameter("email");

        if (email == null || email.isBlank()) {
            request.setAttribute("errorMessage", "Por favor, ingrese un correo válido.");
            request.getRequestDispatcher("verificar_correo.jsp").forward(request, response);
            return;
        }

        try (Connection connection = Conexion.getConnection()) {
            // Buscamos si existe en la tabla pacientes con la que probamos antes
            String sql = "SELECT nombre, apellido FROM pacientes WHERE email = ?";

            try (PreparedStatement ps = connection.prepareStatement(sql)) {
                ps.setString(1, email.trim());

                try (ResultSet rs = ps.executeQuery()) {
                    if (rs.next()) {
                        // ¡Excelente! Es un paciente registrado. Lo mandamos a crear su contraseña.
                        request.setAttribute("activarEmail", email.trim());
                        request.setAttribute("pacienteNombre", rs.getString("nombre") + " " + rs.getString("apellido"));
                        request.getRequestDispatcher("crear_password.jsp").forward(request, response);
                    } else {
                        // No existe en la base de datos
                        request.setAttribute("errorMessage", "El correo no coincide con ningún paciente. Asegúrate de escribir el mismo correo con el que agendaste tu cita.");
                        request.getRequestDispatcher("verificar_correo.jsp").forward(request, response);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            request.setAttribute("errorMessage", "Error al conectar con la base de datos de Dental Leon.");
            request.getRequestDispatcher("verificar_correo.jsp").forward(request, response);
        }
    }
}