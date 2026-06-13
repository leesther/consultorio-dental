package com.stellardental.servlet;

import com.stellardental.dao.AppointmentDao;

import java.io.IOException;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet(name = "CitaServlet", urlPatterns = {"/guardarCita.do"})
public class CitaServlet extends HttpServlet {
    private final AppointmentDao appointmentDao = new AppointmentDao();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");

        HttpSession session = request.getSession(false);
        Long patientId = session == null ? null : (Long) session.getAttribute("patientId");
        Long usuarioId = session == null ? null : (Long) session.getAttribute("usuarioId");

        if (patientId == null) {
            response.sendRedirect(request.getContextPath() + "/citas.jsp?error=patient");
            return;
        }

        String motivo = request.getParameter("motivo");
        String detalles = request.getParameter("detalles");
        String horario = request.getParameter("horario");

        if (isBlank(motivo) || isBlank(horario)) {
            response.sendRedirect(request.getContextPath() + "/citas.jsp?error=required");
            return;
        }

        try {
            LocalDateTime inicio = LocalDateTime.parse(horario, DateTimeFormatter.ofPattern("yyyy-MM-dd_HH:mm"));
            appointmentDao.createAppointment(patientId, motivo, detalles, inicio, usuarioId == null ? 0 : usuarioId);
            response.sendRedirect(request.getContextPath() + "/dashboard.jsp?cita=ok");
        } catch (SQLException e) {
            e.printStackTrace();
            response.sendRedirect(request.getContextPath() + "/citas.jsp?error=db");
        }
    }

    private boolean isBlank(String value) {
        return value == null || value.trim().isEmpty();
    }
}
