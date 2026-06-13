<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="es">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Libro de Reclamaciones | Dental Leon</title>
        <link rel="stylesheet" href="${pageContext.request.contextPath}/css/styles.css">
        <link rel="stylesheet" href="${pageContext.request.contextPath}/css/reclamaciones.css">
    </head>
    <body>
        <jsp:include page="header.jsp"/>

        <main class="rec-main">
            <div class="rec-container">
                <div class="rec-header">
                    <div class="rec-header-icon">
                        <svg xmlns="http://www.w3.org/2000/svg" width="28" height="28" viewBox="0 0 24 24" fill="none" stroke="#4db8ff" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M4 19.5A2.5 2.5 0 0 1 6.5 17H20"/>
                            <path d="M6.5 2H20v20H6.5A2.5 2.5 0 0 1 4 19.5v-15A2.5 2.5 0 0 1 6.5 2z"/>
                        </svg>
                    </div>
                    <div>
                        <p class="rec-label">TRANSPARENCIA</p>
                        <h1 class="rec-title">Libro de Reclamaciones</h1>
                        <p class="rec-subtitle">Completa el formulario para registrar tu queja o reclamo.</p>
                    </div>
                </div>
                <form class="rec-form" action="ReclamacionesServlet" method="post">

                    <!-- Datos personales -->
                    <div class="rec-section">
                        <div class="rec-section-title">
                            <span class="rec-step">1</span>
                            Datos de quien presenta el reclamo
                        </div>

                        <div class="rec-grid">

                            <div class="rec-group">
                                <label class="rec-label-field">Tipo de Documento</label>
                                <select name="tipoDocumento" class="rec-input" required>
                                    <option value="" disabled selected>Seleccionar</option>
                                    <option value="DNI">DNI</option>
                                    <option value="CE">C.E.</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">N° de Documento</label>
                                <input type="text" name="nroDocumento" class="rec-input"
                                       placeholder="Ej: 12345678" required
                                       oninput="this.value=this.value.replace(/[^0-9]/g,'')">
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Primer Nombre</label>
                                <input type="text" name="primerNombre" class="rec-input"
                                       placeholder="Ej: Juan" required>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Segundo Nombre</label>
                                <input type="text" name="segundoNombre" class="rec-input"
                                       placeholder="Ej: Carlos">
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Apellido Paterno</label>
                                <input type="text" name="apellidoPaterno" class="rec-input"
                                       placeholder="Ej: García" required>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Apellido Materno</label>
                                <input type="text" name="apellidoMaterno" class="rec-input"
                                       placeholder="Ej: López" required>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Tipo de Respuesta</label>
                                <select name="tipoRespuesta" class="rec-input" required
                                        onchange="toggleRespuesta(this.value)">
                                    <option value="" disabled selected>Seleccionar</option>
                                    <option value="EMAIL">Correo Electrónico</option>
                                    <option value="DOMICILIO">Dirección Domiciliaria</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Teléfono</label>
                                <input type="tel" name="telefono" class="rec-input"
                                       placeholder="Ej: 999999999" maxlength="9"
                                       oninput="this.value=this.value.replace(/[^0-9]/g,'')" required>
                            </div>

                            <div class="rec-group rec-full" id="campoEmail" style="display:none;">
                                <label class="rec-label-field">Correo Electrónico</label>
                                <input type="email" name="email" class="rec-input"
                                       placeholder="correo@ejemplo.com">
                                <p class="rec-hint">Ingresa tu correo para recibir el comprobante de tu reclamo.</p>
                            </div>

                            <div class="rec-group rec-full" id="campoDireccion" style="display:none;">
                                <label class="rec-label-field">Dirección</label>
                                <input type="text" name="direccion" class="rec-input"
                                       placeholder="Ej: Av. Lima 1094">
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Departamento</label>
                                <select name="departamento" class="rec-input" id="selectDepartamento"
                                        onchange="cargarProvincias(this.value)">
                                    <option value="" disabled selected>Seleccionar</option>
                                    <option value="AMAZONAS">AMAZONAS</option>
                                    <option value="ANCASH">ANCASH</option>
                                    <option value="APURIMAC">APURIMAC</option>
                                    <option value="AREQUIPA">AREQUIPA</option>
                                    <option value="AYACUCHO">AYACUCHO</option>
                                    <option value="CAJAMARCA">CAJAMARCA</option>
                                    <option value="CUSCO">CUSCO</option>
                                    <option value="HUANCAVELICA">HUANCAVELICA</option>
                                    <option value="HUANUCO">HUANUCO</option>
                                    <option value="ICA">ICA</option>
                                    <option value="JUNIN">JUNIN</option>
                                    <option value="LA LIBERTAD">LA LIBERTAD</option>
                                    <option value="LAMBAYEQUE">LAMBAYEQUE</option>
                                    <option value="LIMA">LIMA</option>
                                    <option value="LORETO">LORETO</option>
                                    <option value="MADRE DE DIOS">MADRE DE DIOS</option>
                                    <option value="MOQUEGUA">MOQUEGUA</option>
                                    <option value="PASCO">PASCO</option>
                                    <option value="PIURA">PIURA</option>
                                    <option value="PUNO">PUNO</option>
                                    <option value="SAN MARTIN">SAN MARTIN</option>
                                    <option value="TACNA">TACNA</option>
                                    <option value="TUMBES">TUMBES</option>
                                    <option value="UCAYALI">UCAYALI</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Provincia</label>
                                <select name="provincia" class="rec-input" id="selectProvincia"
                                        onchange="cargarDistritos(this.value)">
                                    <option value="" disabled selected>Seleccionar departamento primero</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Distrito</label>
                                <select name="distrito" class="rec-input" id="selectDistrito">
                                    <option value="" disabled selected>Seleccionar provincia primero</option>
                                </select>
                            </div>

                            <div class="rec-group rec-full">
                                <div class="rec-checkbox-group">
                                    <input type="checkbox" id="menorEdad" name="menorEdad" class="rec-checkbox">
                                    <label for="menorEdad" class="rec-checkbox-label">Menor de edad</label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <!-- Información general -->
                    <div class="rec-section">
                        <div class="rec-section-title">
                            <span class="rec-step">2</span>
                            Información general
                        </div>

                        <div class="rec-grid">

                            <div class="rec-group rec-full">
             <label class="rec-label-field">Sede de atención</label>
             <input type="text" class="rec-input"
                     value="Av. Lima 1094, Villa María del Triunfo 15822"
                    readonly style="background-color: #f1f5f9; color: #6b7280;">
                </div>

                            <div class="rec-group">
                                <label class="rec-label-field">N° de Atención / Cita</label>
                                <input type="text" name="ordenCompra" class="rec-input"
                                       placeholder="Ej: 123456789">
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Monto Reclamado S/</label>
                                <input type="number" name="montoReclamado" class="rec-input"
                                       placeholder="0.00" min="0" step="0.01">
                            </div>

                            <div class="rec-group rec-full">
                                <label class="rec-label-field">Tipo de bien o servicio</label>
                                <div class="rec-radio-group">
                                    <label class="rec-radio-label">
                                        <input type="radio" name="tipoBien" value="PRODUCTO"> Producto
                                    </label>
                                    <label class="rec-radio-label">
                                        <input type="radio" name="tipoBien" value="SERVICIO"> Servicio
                                    </label>
                                </div>
                            </div>

                            <div class="rec-group rec-full">
                                <label class="rec-label-field">Descripción del servicio o producto</label>
                                <input type="text" name="descripcionProducto" class="rec-input"
                                       placeholder="Ej: Limpieza dental, Implante, Blanqueamiento...">
                            </div>

                        </div>
                    </div>

                    <!-- Detalle del reclamo -->
                    <div class="rec-section">
                        <div class="rec-section-title">
                            <span class="rec-step">3</span>
                            Detalle de su reclamo
                        </div>

                        <div class="rec-grid">

                            <div class="rec-group rec-full">
                                <label class="rec-label-field">Tipo</label>
                                <div class="rec-radio-group">
                                    <label class="rec-radio-label">
                                        <input type="radio" name="tipoReclamo" value="RECLAMO" required> Reclamo
                                    </label>
                                    <label class="rec-radio-label">
                                        <input type="radio" name="tipoReclamo" value="QUEJA"> Queja
                                    </label>
                                </div>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Motivo</label>
                                <select name="motivo" class="rec-input" required
                                        onchange="cargarSubmotivos(this.value)">
                                    <option value="" disabled selected>Seleccionar</option>
                                    <option value="ATENCION">ATENCIÓN AL PACIENTE</option>
                                    <option value="COBROS">COBROS - FACTURACIÓN</option>
                                    <option value="CANCELACION">CANCELACIÓN DE CITA</option>
                                    <option value="DEMORA">DEMORA EN ATENCIÓN</option>
                                    <option value="GARANTIA">GARANTÍA DE TRATAMIENTO</option>
                                    <option value="HIGIENE">HIGIENE Y BIOSEGURIDAD</option>
                                    <option value="RESULTADO">RESULTADO DEL TRATAMIENTO</option>
                                    <option value="REEMBOLSO">REEMBOLSO</option>
                                    <option value="OTRO">OTRO</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Submotivo</label>
                                <select name="submotivo" class="rec-input" id="selectSubmotivo">
                                    <option value="" disabled selected>Seleccionar motivo primero</option>
                                </select>
                            </div>

                            <div class="rec-group">
                                <label class="rec-label-field">Fecha de atención</label>
                                <input type="date" name="fechaComunicacion" class="rec-input" required>
                            </div>

                            <div class="rec-group rec-full">
                                <label class="rec-label-field">Detalle del reclamo</label>
                                <textarea name="detalleReclamo" class="rec-textarea"
                                          placeholder="Describe detalladamente tu reclamo o queja..." required></textarea>
                            </div>

                            <div class="rec-group rec-full">
                                <label class="rec-label-field">Pedido / Solución esperada</label>
                                <textarea name="pedido" class="rec-textarea"
                                          placeholder="¿Qué solución esperas"></textarea>
                            </div>

                        </div>
                    </div>

                    <div class="rec-actions">
                        <button type="submit" class="rec-submit-btn">
                            Enviar Reclamo
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <line x1="5" y1="12" x2="19" y2="12"/>
                                <polyline points="12 5 19 12 12 19"/>
                            </svg>
                        </button>
                        <p class="rec-privacy">
                            Al enviar este formulario aceptas nuestra
                            <a href="#" class="rec-privacy-link">Política de Privacidad</a>.
                        </p>
                    </div>

                </form>
            </div>
        </main>

        <jsp:include page="footer.jsp"/>

        <script src="${pageContext.request.contextPath}/js/reclamaciones.js"></script>
    </body>
</html>