package com.stellardental.servlet;

import com.stellardental.config.Conexion;
import com.stellardental.dao.UserDao;
import com.stellardental.model.AppUser;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Optional;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet(name = "LoginServlet", urlPatterns = {"/LoginServlet"})
public class LoginServlet extends HttpServlet {
    private final UserDao userDao = new UserDao();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");

        String email = request.getParameter("email");
        String password = request.getParameter("password");

        if (email == null || password == null || email.trim().isEmpty() || password.trim().isEmpty()) {
            response.sendRedirect(request.getContextPath() + "/login.jsp?error=1");
            return;
        }

        try {
            Optional<AppUser> authenticatedUser = userDao.authenticate(email, password);
            if (authenticatedUser.isPresent()) {
                AppUser user = authenticatedUser.get();
                HttpSession session = request.getSession(true);

                // Guardamos los datos base del usuario logueado
                session.setAttribute("usuarioId", user.getId());
                session.setAttribute("usuarioNombre", user.getNombreCompleto());
                session.setAttribute("usuarioEmail", user.getEmail());
                session.setAttribute("usuarioRolId", user.getRolId());

                // UNIFICACIÓN ESTRATÉGICA: Si es un Paciente (Rol ID = 2),
                // buscamos su id real en la tabla 'pacientes' para activar el portal del cliente
                if (user.getRolId() == 2) {
                    long patientId = obtenerPatientIdPorEmail(user.getEmail());
                    if (patientId > 0) {
                        session.setAttribute("patientId", patientId);
                    }
                }

                response.sendRedirect(request.getContextPath() + "/dashboard.jsp");
                return;
            }

            response.sendRedirect(request.getContextPath() + "/login.jsp?error=1");
        } catch (SQLException e) {
            e.printStackTrace();
            response.sendRedirect(request.getContextPath() + "/login.jsp?error=2");
        }
    }

    // Método auxiliar para buscar el ID de paciente cruzando su correo electrónico
    private long obtenerPatientIdPorEmail(String email) {
        String sql = "SELECT id FROM pacientes WHERE email = ?";
        try (Connection conn = Conexion.getConnection();
             PreparedStatement ps = conn.prepareStatement(sql)) {
            ps.setString(1, email.trim());
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    return rs.getLong("id");
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return 0;
    }
}