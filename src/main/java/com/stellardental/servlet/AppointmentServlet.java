package com.stellardental.servlet;

import com.stellardental.config.Conexion;
import com.stellardental.dao.AppointmentDao;
import com.stellardental.dao.PatientDao;
import com.stellardental.dao.UserDao;
import com.stellardental.model.Patient;

import java.io.IOException;
import java.sql.Connection;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet(name = "AppointmentServlet", urlPatterns = {"/AppointmentServlet"})
public class AppointmentServlet extends HttpServlet {
    private final PatientDao patientDao = new PatientDao();
    private final AppointmentDao appointmentDao = new AppointmentDao();
    private final UserDao userDao = new UserDao();

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");

        String fullName = request.getParameter("fullName");
        String idNumber = request.getParameter("idNumber");
        String age = request.getParameter("age");
        String phone = request.getParameter("phone");
        String email = request.getParameter("email");
        String appointmentDate = request.getParameter("appointmentDate");
        String appointmentTime = request.getParameter("appointmentTime");

        if (isBlank(fullName) || isBlank(idNumber) || isBlank(age) || isBlank(phone)
                || isBlank(email) || isBlank(appointmentDate) || isBlank(appointmentTime)) {
            request.setAttribute("errorMessage", "Por favor, complete todos los campos obligatorios.");
            request.getRequestDispatcher("index.jsp").forward(request, response);
            return;
        }

        try (Connection connection = Conexion.getConnection()) {
            connection.setAutoCommit(false);
            try {
                Patient patient = patientDao.findOrCreate(
                        connection,
                        fullName.trim(),
                        idNumber.trim(),
                        age.trim(),
                        phone.trim(),
                        email.trim()
                );
                long doctorId = userDao.findDefaultDoctorId(connection);
                LocalDateTime start = parseAppointmentStart(appointmentDate, appointmentTime);
                long appointmentId = appointmentDao.createAppointment(
                        connection,
                        patient.getId(),
                        doctorId,
                        "Consulta dental",
                        "Solicitud registrada desde la pagina principal",
                        start
                );
                connection.commit();

                request.getSession(true).setAttribute("patientId", patient.getId());
                request.setAttribute("appointmentId", appointmentId);
                request.setAttribute("fullName", patient.getNombreCompleto());
                request.setAttribute("idNumber", idNumber.trim());
                request.setAttribute("age", age.trim());
                request.setAttribute("phone", phone.trim());
                request.setAttribute("email", email.trim());
                request.setAttribute("appointmentDate", appointmentDate.trim());
                request.setAttribute("appointmentTime", appointmentTime.trim());

                request.getRequestDispatcher("confirmacion.jsp").forward(request, response);
            } catch (Exception e) {
                connection.rollback();
                throw e;
            }
        } catch (Exception e) {
            e.printStackTrace();
            request.setAttribute("errorMessage", "No pudimos registrar la cita. Intentelo nuevamente.");
            request.getRequestDispatcher("index.jsp").forward(request, response);
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.sendRedirect(request.getContextPath() + "/index.jsp");
    }

    private LocalDateTime parseAppointmentStart(String date, String time) {
        LocalDate localDate = LocalDate.parse(date);
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("hh:mm a", Locale.US);
        LocalTime localTime = LocalTime.parse(time.toUpperCase(Locale.US), formatter);
        return LocalDateTime.of(localDate, localTime);
    }

    private boolean isBlank(String value) {
        return value == null || value.trim().isEmpty();
    }
}
