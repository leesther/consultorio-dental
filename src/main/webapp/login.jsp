<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Portal del Paciente | Dental Leon</title>
    <meta name="description" content="Inicia sesi&oacute;n en tu portal de paciente Dental Leon.">

    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/header.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/login.css">
</head>
<body>
<%
    request.setAttribute("paginaActiva", "login");
    String error = request.getParameter("error");
%>

<jsp:include page="header.jsp"/>

<main class="login-page">
    <section class="hero-section">
        <div class="hero-container">
            <div class="content-left">
                <div class="hero-text-section">
                    <h1 class="hero-title">El cuidado de tus dientes, a un solo clic de distancia.</h1>
                    <p class="hero-description">
                        Gestiona tus citas, revisa tu historial dental y consulta tus pagos
                        desde el portal seguro de Dental Leon.
                    </p>
                </div>

                <div class="feature-cards">
                    <article class="feature-card">
                        <span class="feature-icon" aria-hidden="true">&#10003;</span>
                        <div class="feature-content">
                            <h3 class="feature-title">Portal Seguro</h3>
                            <p class="feature-text">Acceso privado para pacientes registrados.</p>
                        </div>
                    </article>

                    <article class="feature-card">
                        <span class="feature-icon" aria-hidden="true">&#8594;</span>
                        <div class="feature-content">
                            <h3 class="feature-title">Reserva R&aacute;pida</h3>
                            <p class="feature-text">Agenda tu pr&oacute;xima atenci&oacute;n en pocos pasos.</p>
                        </div>
                    </article>
                </div>

                <div class="testimonial-card">
                    <div class="testimonial-avatar" aria-hidden="true">DL</div>
                    <div class="testimonial-content">
                        <p class="testimonial-quote">
                            &quot;Tu comodidad y salud dental son nuestra m&aacute;xima prioridad.&quot;
                        </p>
                        <p class="testimonial-author">Equipo cl&iacute;nico Dental Leon</p>
                    </div>
                </div>
            </div>

            <div class="login-section">
                <div class="login-card">
                    <div class="login-header">
                        <h2 class="login-title">Bienvenido de nuevo</h2>
                        <p class="login-subtitle">Inicia sesi&oacute;n en tu cuenta Dental Leon</p>
                    </div>

                    <% if ("1".equals(error)) { %>
                    <div class="login-error" role="alert">
                        Correo o contrase&ntilde;a incorrectos.
                    </div>
                    <% } else if ("2".equals(error)) { %>
                    <div class="login-error" role="alert">
                        No pudimos conectar con el servicio. Int&eacute;ntalo nuevamente.
                    </div>
                    <% } %>

                    <form class="login-form" id="loginForm" action="${pageContext.request.contextPath}/LoginServlet" method="post">
                        <div class="form-fields">
                            <div class="form-group">
                                <label for="email" class="form-label">Correo Electr&oacute;nico</label>
                                <input type="email" id="email" name="email"
                                       class="form-input" placeholder="nombre@correo.com" required>
                            </div>

                            <div class="form-group">
                                <div class="form-label-row">
                                    <label for="password" class="form-label">Contrase&ntilde;a</label>
                                </div>
                                <input type="password" id="password" name="password"
                                       class="form-input" placeholder="&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;" required>
                                <a href="#forgot-password" class="forgot-password">&iquest;Olvidaste tu contrase&ntilde;a?</a>
                            </div>

                            <div class="checkbox-group">
                                <input type="checkbox" id="remember" name="remember" class="checkbox-input">
                                <label for="remember" class="checkbox-label">Recordar este dispositivo</label>
                            </div>

                            <button type="submit" class="btn-signin">Ingresar al Portal</button>
                        </div>

                        <div class="divider-section">
                            <span class="divider-text">O</span>
                        </div>

                        <div class="alternative-login" style="text-align: center;">
                            <p class="signup-text" style="margin-bottom: 8px;">
                                &iquest;Agendaste tu cita por la web pero no tienes contrase&ntilde;a?
                            </p>
                            <a href="${pageContext.request.contextPath}/verificar_correo.jsp" class="signup-link" style="font-weight: 700; color: #007b8f; text-decoration: underline;">
                                Activa tu cuenta aqu&iacute; &rarr;
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