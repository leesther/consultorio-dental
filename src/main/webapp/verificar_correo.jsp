<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Activar Cuenta | Dental Leon</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/header.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/login.css">
</head>
<body>
<%
    request.setAttribute("paginaActiva", "login");
%>

<jsp:include page="header.jsp"/>

<main class="login-page">
    <section class="hero-section">
        <div class="hero-container" style="justify-content: center;">

            <div class="login-section" style="max-width: 480px; width: 100%;">
                <div class="login-card">
                    <div class="login-header">
                        <h2 class="login-title">Activación de Cuenta</h2>
                        <p class="login-subtitle">Ingresa el correo con el que registraste tu cita clínica.</p>
                    </div>

                    <% if (request.getAttribute("errorMessage") != null) { %>
                    <div class="login-error" role="alert">
                        <%= request.getAttribute("errorMessage") %>
                    </div>
                    <% } %>

                    <form class="login-form" action="${pageContext.request.contextPath}/VerificarPacienteServlet" method="post">
                        <div class="form-fields">
                            <div class="form-group">
                                <label for="email" class="form-label">Correo Electrónico</label>
                                <input type="email" id="email" name="email" class="form-input" placeholder="nombre@correo.com" required>
                            </div>

                            <button type="submit" class="btn-signin">Verificar Identidad</button>
                        </div>

                        <div class="alternative-login" style="text-align: center; margin-top: 16px;">
                            <a href="${pageContext.request.contextPath}/login.jsp" class="signup-link">
                                &larr; Regresar al Login tradicional
                            </a>
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