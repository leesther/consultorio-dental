package com.stellardental.controller;

import com.stellardental.dao.AppointmentDao;
import java.io.IOException;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet("/AgendarCitaPreferencialServlet")
public class AgendarCitaPreferencialServlet extends HttpServlet {

    private final AppointmentDao appointmentDao = new AppointmentDao();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        // Evitar distorsión de tildes en los detalles clínicos
        request.setCharacterEncoding("UTF-8");

        try {
            String patientIdStr = request.getParameter("patientId");
            String motivo = request.getParameter("motivo");
            String detalles = request.getParameter("detalles");
            String horarioRaw = request.getParameter("horario"); // Recibe: "YYYY-MM-DD_HH:MM:SS"

            if (patientIdStr == null || patientIdStr.isBlank() || horarioRaw == null) {
                response.sendRedirect(request.getContextPath() + "/citas.jsp?status=error");
                return;
            }
            long patientId = Long.parseLong(patientIdStr);

            // Fraccionar el valor del radio button para extraer fecha y hora por separado
            String[] partesHorario = horarioRaw.split("_");
            String fechaPart = partesHorario[0]; // "YYYY-MM-DD"
            String horaPart = partesHorario[1];  // "HH:MM:SS"

            LocalDate fecha = LocalDate.parse(fechaPart);
            LocalTime hora = LocalTime.parse(horaPart);
            LocalDateTime inicio = LocalDateTime.of(fecha, hora);

            // Pasamos 0 como ID de doctor para activar la regla de tu DAO:
            // "userDao.findDefaultDoctorId(connection)" asignando automáticamente al Dr. Ramos
            long requestedByUserId = 0;

            // Invocamos TU AppointmentDao nativo de PostgreSQL
            long idCitaGenerada = appointmentDao.createAppointment(patientId, motivo, detalles, inicio, requestedByUserId);

            if (idCitaGenerada > 0) {
                // Éxito total
                response.sendRedirect(request.getContextPath() + "/citas.jsp?status=success");
            } else {
                response.sendRedirect(request.getContextPath() + "/citas.jsp?status=error");
            }

        } catch (Exception e) {
            e.printStackTrace();
            response.sendRedirect(request.getContextPath() + "/citas.jsp?status=error");
        }
    }
}