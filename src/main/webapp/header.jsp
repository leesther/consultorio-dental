<%@page contentType="text/html" pageEncoding="UTF-8"%>

<%
    String paginaActiva = (String) request.getAttribute("paginaActiva");
%>

<header class="header">
    <div class="header-content">
        <a class="logo" href="${pageContext.request.contextPath}/index.jsp" aria-label="Ir al inicio">
            <span class="logo-text">Dental Leon</span>
        </a>

        <nav class="nav-menu" aria-label="Navegación principal">
            <ul class="nav-menu-list">
                <li>
                    <a href="${pageContext.request.contextPath}/index.jsp#home"
                       class="nav-menu-item <%= "home".equals(paginaActiva) ? "active" : "" %>">
                        Home
                    </a>
                </li>
                <li>
                    <a href="${pageContext.request.contextPath}/index.jsp#services"
                       class="nav-menu-item <%= "services".equals(paginaActiva) ? "active" : "" %>">
                        Servicios
                    </a>
                </li>
                <li>
                    <a href="${pageContext.request.contextPath}/index.jsp#case-studies"
                       class="nav-menu-item <%= "cases".equals(paginaActiva) ? "active" : "" %>">
                        Casos
                    </a>
                </li>
                <li>
                    <a href="${pageContext.request.contextPath}/index.jsp#book-now"
                       class="nav-menu-item <%= "book".equals(paginaActiva) ? "active" : "" %>"
                       id="bookNowLink">
                        Reserva tu cita
                    </a>
                </li>
            </ul>
        </nav>

        <div class="header-actions">
            <a class="patient-portal-btn <%= "login".equals(paginaActiva) ? "active-portal" : "" %>"
               href="${pageContext.request.contextPath}/login.jsp">
                Portal del Paciente
            </a>
        </div>
    </div>
</header>