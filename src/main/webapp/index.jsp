<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Reservar Cita Dental | Dental Leon</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/header.css">
</head>
<body>
<div class="page-container">
    <%
        request.setAttribute("paginaActiva", "book");
    %>
    <jsp:include page="header.jsp"/>

    <main class="main-content">
        <section class="left-column">
            <div class="intro-section">
                <h1 class="hero-title">Tu camino hacia una sonrisa perfecta comienza aquí.</h1>
            </div>

            <div class="features-section">
                <div class="features-list">
                    <article class="feature-card">
                        <img src="${pageContext.request.contextPath}/assets/images/img_icon_light_blue_900.png" class="feature-icon" alt="">
                        <div>
                            <h2 class="feature-title">Manejo seguro de datos</h2>
                            <p class="feature-description">Información protegida con confidencialidad clínica.</p>
                        </div>
                    </article>

                    <article class="feature-card">
                        <img src="${pageContext.request.contextPath}/assets/images/img_icon_light_blue_900_20x20.png" class="feature-icon" alt="">
                        <div>
                            <h2 class="feature-title">Confirmación en 24h</h2>
                            <p class="feature-description">Confirmamos tu cita en menos de 24 horas.</p>
                        </div>
                    </article>
                </div>

                <div class="facility-container">
                    <img src="${pageContext.request.contextPath}/assets/images/img_modern_dentalclinic.png" class="facility-image" alt="Clínica Dental Leon">
                </div>
            </div>
        </section>

        <section class="right-column">
            <div class="form-container">
                <p class="hero-description">
                    Llena el formulario para agendar tu consulta con uno de nuestros odontólogos.
                </p>
                <br>

                <% if (request.getAttribute("errorMessage") != null) { %>
                <div class="login-error" role="alert"><%= request.getAttribute("errorMessage") %></div>
                <% } %>

                <form class="form-content" action="${pageContext.request.contextPath}/AppointmentServlet" method="post">
                    <div class="form-fields">
                        <div class="form-row">
                            <div class="form-group">
                                <label class="form-label">Nombre Completo</label>
                                <input type="text" name="fullName" class="form-input"
                                       placeholder="Juan Pérez"
                                       minlength="3" maxlength="60"
                                       pattern="[A-Za-zÁÉÍÓÚáéíóúÑñ ]+" required>
                            </div>

                            <div class="form-group">
                                <label class="form-label">DNI</label>
                                <input type="text" name="idNumber" class="form-input"
                                       placeholder="12345678"
                                       maxlength="8" pattern="\d{8}"
                                       inputmode="numeric"
                                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" required>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group">
                                <label class="form-label">Edad</label>
                                <input type="number" name="age" class="form-input" placeholder="30"
                                       min="1" max="120" required>
                            </div>

                            <div class="form-group">
                                <label class="form-label">Teléfono</label>
                                <input type="tel" name="phone" class="form-input"
                                       placeholder="999999999"
                                       minlength="9" maxlength="9"
                                       pattern="\d{9}" inputmode="numeric"
                                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" required>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="form-label">Correo Electrónico</label>
                            <input type="email" name="email" class="form-input"
                                   placeholder="correo@ejemplo.com"
                                   maxlength="100" required>
                        </div>

                        <div class="form-row">
                            <div class="form-group">
                                <label class="form-label">Fecha Disponible</label>
                                <select name="appointmentDate" id="appointmentDate" class="form-input" required>
                                    <option value="" disabled selected>Selecciona una fecha</option>
                                    <option value="2026-06-10">Miércoles 10 de Junio</option>
                                    <option value="2026-06-11">Jueves 11 de Junio</option>
                                    <option value="2026-06-12">Viernes 12 de Junio</option>
                                </select>
                            </div>

                            <div class="form-group">
                                <label class="form-label">Horario Disponible</label>
                                <select name="appointmentTime" id="appointmentTime" class="form-input" required>
                                    <option value="" disabled selected>Selecciona la hora</option>
                                    <option value="09:00 AM">09:00 AM</option>
                                    <option value="10:00 AM">10:00 AM</option>
                                    <option value="11:00 AM">11:00 AM</option>
                                    <option value="03:30 PM">03:30 PM</option>
                                    <option value="04:30 PM">04:30 PM</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions">
                        <button type="submit" class="submit-btn">
                            Agenda tu cita
                            <img src="${pageContext.request.contextPath}/assets/images/img_arrowright.png" alt="" class="arrow-icon">
                        </button>

                        <p class="privacy-notice">
                            Al seleccionar "Agenda tu cita", confirmas que estás de acuerdo con la
                            <a href="#privacy" class="privacy-link">Política de Privacidad</a> y los
                            <a href="#terms" class="privacy-link">Términos de Servicio.</a>
                        </p>
                    </div>
                </form>
            </div>
        </section>
    </main>

    <jsp:include page="footer.jsp"/>
</div>
</body>
</html>
