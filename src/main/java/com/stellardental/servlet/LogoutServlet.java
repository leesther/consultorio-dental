package com.stellardental.controller;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet("/LogoutServlet")
public class LogoutServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        // 1. Obtener la sesión actual si existe
        HttpSession session = request.getSession(false);

        if (session != null) {
            // 2. Limpiar todos los datos guardados en memoria (DNI, email, objetos, etc.)
            session.removeAttribute("patientId");
            session.removeAttribute("usuarioEmail");
            session.removeAttribute("usuarioNombre");

            // 3. Destruir por completo la sesión en el servidor Tomcat
            session.invalidate();
        }

        // 4. Redirigir al usuario al index.jsp de la página pública
        response.sendRedirect(request.getContextPath() + "/index.jsp");
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Redirigir peticiones POST al mismo flujo por seguridad
        doGet(request, response);
    }
}