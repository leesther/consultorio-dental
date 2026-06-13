<%-- Fragmento reutilizable: Footer --%>
<footer class="footer">
    <div class="footer-top">

        <!-- Logo y descripción -->
        <div class="footer-brand">
            <div class="footer-logo-row">
                <div class="footer-logo-icon">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="#4db8ff" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <path d="M12 2C8 2 5 5 5 9c0 5 7 13 7 13s7-8 7-13c0-4-3-7-7-7z"/>
                    </svg>
                </div>
                <span class="footer-logo-text">Dental Leon</span>
            </div>
            <p class="footer-brand-desc">
                Redefiniendo la odontología moderna a través de la excelencia clínica y el diseño centrado en el paciente.
            </p>
            <div class="footer-social">
                <a href="#" class="footer-social-btn">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <circle cx="12" cy="12" r="10"/>
                        <line x1="2" y1="12" x2="22" y2="12"/>
                        <path d="M12 2a15.3 15.3 0 0 1 4 10 15.3 15.3 0 0 1-4 10 15.3 15.3 0 0 1-4-10 15.3 15.3 0 0 1 4-10z"/>
                    </svg>
                </a>
                <a href="#" class="footer-social-btn">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <path d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"/>
                        <polyline points="22,6 12,13 2,6"/>
                    </svg>
                </a>
            </div>
        </div>

        <!-- Servicios -->
        <div class="footer-col">
            <h4 class="footer-col-title">SERVICIOS</h4>
            <ul class="footer-col-list">
                <li><a href="#" class="footer-col-link">Implantes Dentales</a></li>
                <li><a href="#" class="footer-col-link">Carillas Dentales</a></li>
                <li><a href="#" class="footer-col-link">Blanqueamiento Dental</a></li>
                <li><a href="#" class="footer-col-link">Ortodoncia Invisible</a></li>
            </ul>
        </div>

        <!-- Clínica -->
        <div class="footer-col">
            <h4 class="footer-col-title">CLÍNICA</h4>
            <ul class="footer-col-list">
                <li><a href="#" class="footer-col-link">Nuestros Médicos</a></li>
                <li><a href="login.jsp" class="footer-col-link">Portal del Paciente</a></li>
                <li><a href="#" class="footer-col-link">Financing</a></li>
            </ul>
        </div>

        <!-- Visítanos -->
        <div class="footer-col">
            <h4 class="footer-col-title">VISÍTANOS</h4>
            <p class="footer-address">Av. Lima 1094, Villa María del Triunfo 15822</p>
            <p class="footer-phone">(+51) 123-456-154</p>
            <a href="https://maps.app.goo.gl/7g8PVj3gvSRkDjtF8" target="_blank" rel="noopener noreferrer" class="footer-directions-btn">Obtener Dirección</a>
        </div>

    </div>

    <!-- Libro de reclamaciones -->
    <div class="footer-middle">
        <a href="${pageContext.request.contextPath}/reclamaciones.jsp" class="footer-reclamaciones">
            <div class="footer-reclamaciones-icon">
                <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" viewBox="0 0 24 24" fill="none" stroke="#4db8ff" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <path d="M4 19.5A2.5 2.5 0 0 1 6.5 17H20"/>
                    <path d="M6.5 2H20v20H6.5A2.5 2.5 0 0 1 4 19.5v-15A2.5 2.5 0 0 1 6.5 2z"/>
                </svg>
            </div>
            <div class="footer-reclamaciones-text">
                <span class="footer-reclamaciones-label">TRANSPARENCIA</span>
                <span class="footer-reclamaciones-title">Libro de Reclamaciones</span>
            </div>
            <!-- Se eliminó el símbolo de pregunta de aquí adentro -->
            <span class="footer-reclamaciones-arrow"></span>
        </a>
    </div>

    <!-- Copyright -->
    <div class="footer-bottom">
        <p class="footer-copyright">© 2026 DENTAL LEON. CONSTRUIDO PARA LA EXCELENCIA PROFESIONAL.</p>
        <div class="footer-bottom-links">
            <a href="#" class="footer-bottom-link">PRIVACIDAD</a>
            <a href="#" class="footer-bottom-link">TÉRMINOS</a>
        </div>
    </div>

</footer>