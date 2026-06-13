<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Asignar Contraseña | Dental Leon</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/header.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/login.css">
</head>
<body>
<%
    request.setAttribute("paginaActiva", "login");
    String emailValidado = (String) request.getAttribute("activarEmail");
    String nombrePaciente = (String) request.getAttribute("pacienteNombre");
%>

<jsp:include page="header.jsp"/>

<main class="login-page">
    <section class="hero-section">
        <div class="hero-container" style="justify-content: center;">

            <div class="login-section" style="max-width: 480px; width: 100%;">
                <div class="login-card">
                    <div class="login-header">
                        <h2 class="login-title">¡Hola, <%= (nombrePaciente != null) ? nombrePaciente : "Paciente" %>!</h2>
                        <p class="login-subtitle">Crea la contraseña para tu cuenta de acceso seguro.</p>
                    </div>

                    <% if (request.getAttribute("errorMessage") != null) { %>
                    <div class="login-error" role="alert">
                        <%= request.getAttribute("errorMessage") %>
                    </div>
                    <% } %>

                    <form class="login-form" action="${pageContext.request.contextPath}/ActivarCuentaServlet" method="post">
                        <input type="hidden" name="email" value="<%= emailValidado %>">

                        <div class="form-fields">
                            <div class="form-group">
                                <label class="form-label" style="opacity: 0.7;">Tu Correo Verificado</label>
                                <input type="text" class="form-input" value="<%= emailValidado %>" disabled style="background-color: #f1f5f9; cursor: not-allowed;">
                            </div>

                            <div class="form-group">
                                <label for="password" class="form-label">Nueva Contraseña</label>
                                <input type="password" id="password" name="password" class="form-input" placeholder="Mínimo 6 caracteres" minlength="6" required>
                            </div>

                            <div class="form-group">
                                <label for="confirmPassword" class="form-label">Confirmar Contraseña</label>
                                <input type="password" id="confirmPassword" name="confirmPassword" class="form-input" placeholder="Repite tu contraseña" minlength="6" required>
                            </div>

                            <button type="submit" class="btn-signin">Activar Cuenta e Ingresar</button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</main>

<jsp:include page="footer.jsp"/>
</body>
</html>