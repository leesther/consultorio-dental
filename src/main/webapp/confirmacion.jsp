<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cita Confirmada | Dental Leon</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/header.css">
    <link rel="stylesheet" href="${pageContext.request.contextPath}/css/confirmacion.css">
</head>
<body>
<div class="page-container">
    <jsp:include page="header.jsp"/>

    <main class="main-content">
        <div class="confirmation-wrapper">
            <div class="confirmation-icon">&#10003;</div>

            <h1 class="confirmation-title">¡Cita Agendada!</h1>
            <p class="confirmation-subtitle">
                Gracias por elegir la Clínica Dental Leon. Tu horario ha sido bloqueado en el sistema con éxito.
            </p>

            <div class="confirmation-data">
                <p><strong>Número de cita:</strong> ${appointmentId}</p>
                <p><strong>Nombre:</strong> ${fullName}</p>
                <p><strong>DNI:</strong> ${idNumber}</p>
                <p><strong>Teléfono:</strong> ${phone}</p>
                <p><strong>Fecha Elegida:</strong> ${appointmentDate}</p>
                <p><strong>Horario Reservado:</strong> ${appointmentTime}</p>
                <p><strong>Sede de Atención:</strong> Av. Lima 1094, VMT</p>
            </div>

            <!--  Redirección al flujo de activación intermedia para crear contraseña -->
            <a href="${pageContext.request.contextPath}/verificar_correo.jsp" class="back-btn" style="background-color: #007b8f; color: white; border: none; padding: 12px 24px; text-decoration: none; border-radius: 6px; display: inline-block; font-weight: bold;">
                Activar mi Cuenta e Ingresar &rarr;
            </a>

            <p style="margin-top: 15px; font-size: 13px; color: #617084;">
                ¿Prefieres hacerlo después? <a href="${pageContext.request.contextPath}/index.jsp" style="color: #0b2a45; font-weight: bold; text-decoration: underline;">Volver al Inicio</a>
            </p>
        </div>
    </main>

    <jsp:include page="footer.jsp"/>
</div>
</body>
</html>