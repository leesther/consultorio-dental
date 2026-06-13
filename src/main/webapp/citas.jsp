<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ include file="WEB-INF/jspf/portalContext.jspf" %>
<!DOCTYPE html>
<html lang="es" class="light">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Dental Leon - Agendar Cita de Emergencia</title>
  <script src="https://cdn.tailwindcss.com?plugins=forms"></script>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link rel="stylesheet" href="${pageContext.request.contextPath}/css/citas.css">
  <!-- CORREGIDOS: Signos "?" añadidos en las rutas de Google Fonts -->
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
  <link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:wght,FILL@100..700,0..1&display=swap" rel="stylesheet" />
  <script>
    tailwind.config = {
      theme: {
        extend: {
          colors: {
            ink: "#102033",
            muted: "#617084",
            line: "#d8e0ea",
            canvas: "#f6f8fb",
            panel: "#ffffff",
            navy: "#0b2a45",
            teal: "#007b8f",
            mint: "#d9f2ea",
            amber: "#f3b344",
            danger: "#c4382d",
            softBlue: "#dbeafe"
          },
          boxShadow: {
            soft: "0 14px 40px rgba(16, 32, 51, 0.08)"
          },
          fontFamily: {
            sans: ["Inter", "sans-serif"]
          }
        }
      }
    };
  </script>
  <style>
    * { box-sizing: border-box; }
    body { font-family: Inter, sans-serif; }
    .material-symbols-outlined {
      font-variation-settings: "FILL" 0, "wght" 500, "GRAD" 0, "opsz" 24;
    }
    .app-shell { display: block; }
    .main-panel {
      margin-left: 264px;
      width: calc(100% - 264px);
    }
    @media (max-width: 900px) {
      .side-nav { position: static; width: auto; height: auto; border-right: 0; border-bottom: 1px solid #d8e0ea; }
      .main-panel { margin-left: 0; width: 100%; min-width: 0; }
    }
  </style>
</head>
<body class="min-h-screen bg-canvas text-ink">
<div class="app-shell min-h-screen">

  <aside class="side-nav fixed inset-y-0 left-0 z-30 flex h-screen w-[264px] flex-col border-r border-line bg-panel">
    <div class="px-6 pb-5 pt-6">
      <div class="flex items-center gap-3">
        <div class="grid h-11 w-11 place-items-center rounded-lg bg-navy text-white">
          <span class="material-symbols-outlined">dentistry</span>
        </div>
        <div>
          <h1 class="text-xl font-extrabold text-navy">Dental Leon</h1>
          <p class="text-xs font-semibold uppercase text-muted">Historia clínica</p>
        </div>
      </div>
    </div>

    <nav class="flex-1 space-y-1 px-3">
      <a class="flex items-center gap-3 rounded-lg px-3 py-3 text-sm font-semibold text-muted hover:bg-canvas" href="dashboard.jsp">
        <span class="material-symbols-outlined">dashboard</span> Dashboard
      </a>
      <a class="flex items-center gap-3 rounded-lg px-3 py-3 text-sm font-semibold text-muted hover:bg-canvas" href="odontograma.jsp">
        <span class="material-symbols-outlined">clinical_notes</span> Odontograma
      </a>
      <a class="flex items-center gap-3 rounded-lg px-3 py-3 text-sm font-semibold text-muted hover:bg-canvas" href="historial.jsp">
        <span class="material-symbols-outlined">history</span> Historial clínico
      </a>
      <a class="flex items-center gap-3 rounded-lg px-3 py-3 text-sm font-semibold text-muted hover:bg-canvas" href="pagos.jsp">
        <span class="material-symbols-outlined">payments</span> Pagos
      </a>
    </nav>

    <div class="border-t border-line p-4">
      <a class="flex w-full items-center justify-between rounded-lg bg-[#143a5d] px-4 py-3 text-sm font-bold text-white ring-2 ring-teal/50"
         href="${pageContext.request.contextPath}/citas.jsp">
        <span class="flex items-center gap-2"><span class="material-symbols-outlined text-[20px]">calendar_add_on</span> Agendar Cita</span>
        <span class="material-symbols-outlined text-[18px]">arrow_forward</span>
      </a>
    </div>
  </aside>

  <main class="main-panel min-h-screen overflow-x-hidden">

    <header class="sticky top-0 z-20 border-b border-line bg-panel/95 px-5 py-4 backdrop-blur">
      <div class="mx-auto flex max-w-[1440px] flex-wrap items-center justify-between gap-4">
        <div class="flex min-w-0 items-center gap-4">
          <div class="grid h-12 w-12 shrink-0 place-items-center rounded-full bg-mint text-base font-extrabold text-teal ring-2 ring-white"><%= portalInitials %></div>
          <div class="min-w-0">
            <h2 class="truncate text-2xl font-extrabold text-navy"><%= portalName %></h2>
            <p class="text-sm font-medium text-muted"><%= portalMeta %></p>
          </div>
        </div>
        <div class="flex items-center gap-2">
          <a href="${pageContext.request.contextPath}/LogoutServlet"
             class="inline-flex h-10 px-4 items-center gap-2 rounded-lg border border-danger/20 bg-panel text-danger hover:bg-[#fce8e6] transition font-bold text-sm"
             aria-label="Cerrar Sesión">
            <span class="material-symbols-outlined text-[18px]">logout</span>
            <span>Cerrar Sesión</span>
          </a>
        </div>
      </div>
    </header>

    <section class="mx-auto max-w-[1440px] space-y-6 px-5 py-6">

      <!-- ALERTAS DE ESTADO -->
      <% String status = request.getParameter("status"); %>
      <% if ("success".equals(status)) { %>
      <div class="mb-4 rounded-lg bg-mint p-4 text-sm font-bold text-teal border border-[#b2e5d5] flex items-center gap-2">
        <span class="material-symbols-outlined">check_circle</span> ¡Reserva preferencial registrada con éxito!
      </div>
      <% } else if ("error".equals(status)) { %>
      <div class="mb-4 rounded-lg bg-[#fce8e6] p-4 text-sm font-bold text-danger border border-[#f5cbb1] flex items-center gap-2">
        <span class="material-symbols-outlined">error</span> Error al procesar tu reserva clínica. Por favor, vuelve a intentarlo.
      </div>
      <% } %>

      <div class="grid gap-6 lg:grid-cols-[1fr_360px]">

        <!-- CORREGIDO: Redirección apuntando a nuestro Servlet Preferencial -->
        <form action="${pageContext.request.contextPath}/AgendarCitaPreferencialServlet" method="POST" class="rounded-xl border border-line bg-panel shadow-soft">

          <!-- AGREGADO: ID del paciente invisible tomado de la sesión -->
          <input type="hidden" name="patientId" value="<%= currentPatientId != null ? currentPatientId : "" %>" />

          <div class="border-b border-line px-5 py-4">
            <h3 class="text-xl font-extrabold text-navy">Solicitud de Cita Preferencial</h3>
            <p class="text-sm text-muted">Gestión de cupos prioritarios para tratamientos clínicos en curso.</p>
          </div>

          <div class="p-5 space-y-4">
            <div>
              <label class="label-form font-bold text-xs uppercase text-muted block mb-2" for="motivo">Motivo de la Cita / Síntomas</label>
              <select id="motivo" name="motivo" class="w-full rounded-lg border-line bg-canvas text-sm text-ink focus:border-teal focus:ring-teal" required>
                <option value="" disabled selected>Seleccione la condición clínica...</option>
                <option value="Dolor agudo / Inflamación severa">Dolor agudo / Inflamación severa</option>
                <option value="Continuación de Endodoncia (Pieza 16)">Continuación de Endodoncia (Pieza 16)</option>
                <option value="Problema con Corona / Obturación dañada">Problema con Corona / Obturación dañada</option>
                <option value="Evaluación general de urgencia">Evaluación general de urgencia</option>
              </select>
            </div>

            <div>
              <label class="label-form font-bold text-xs uppercase text-muted block mb-2" for="detalles">Notas Clínicas Adicionales (Opcional)</label>
              <textarea id="detalles" name="detalles" class="w-full rounded-lg border-line bg-canvas p-3 text-sm text-ink focus:border-teal focus:ring-teal h-24 resize-none" placeholder="Describa brevemente si presenta sensibilidad al frío/calor, dolor al masticar o algún trauma específico..."></textarea>
            </div>

            <div>
              <label class="block text-xs font-bold uppercase text-muted mb-3">Horarios Próximos Disponibles</label>
              <div class="grid gap-3 md:grid-cols-2">

                <label class="flex items-center gap-3 rounded-lg border border-line p-4 bg-canvas cursor-pointer hover:bg-slate-50 transition">
                  <input type="radio" name="horario" value="2026-06-10_09:00:00" class="text-teal focus:ring-teal" required>
                  <div class="radio-content">
                    <p class="font-bold text-navy text-sm">09:00 AM</p>
                    <p class="text-xs text-muted">Miércoles 10 de Junio</p>
                  </div>
                </label>

                <label class="flex items-center gap-3 rounded-lg border border-line p-4 bg-canvas cursor-pointer hover:bg-slate-50 transition">
                  <input type="radio" name="horario" value="2026-06-10_11:30:00" class="text-teal focus:ring-teal">
                  <div class="radio-content">
                    <p class="font-bold text-navy text-sm">11:30 AM</p>
                    <p class="text-xs text-muted">Miércoles 10 de Junio</p>
                  </div>
                </label>

                <label class="flex items-center gap-3 rounded-lg border border-line p-4 bg-canvas cursor-pointer hover:bg-slate-50 transition">
                  <input type="radio" name="horario" value="2026-06-11_15:00:00" class="text-teal focus:ring-teal">
                  <div class="radio-content">
                    <p class="font-bold text-navy text-sm">03:00 PM</p>
                    <p class="text-xs text-muted">Jueves 11 de Junio</p>
                  </div>
                </label>

                <label class="flex items-center gap-3 rounded-lg border border-line p-4 bg-canvas cursor-pointer hover:bg-slate-50 transition">
                  <input type="radio" name="horario" value="2026-06-11_16:30:00" class="text-teal focus:ring-teal">
                  <div class="radio-content">
                    <p class="font-bold text-navy text-sm">04:30 PM</p>
                    <p class="text-xs text-muted">Jueves 11 de Junio</p>
                  </div>
                </label>

              </div>
            </div>
          </div>

          <div class="border-t border-line px-5 py-4 flex justify-between items-center bg-canvas rounded-b-xl">
            <p class="text-xs text-muted font-medium">Asignación sujeta a disponibilidad de sala.</p>
            <div class="flex gap-2">
              <a href="dashboard.jsp" class="rounded-lg border border-line bg-panel px-4 py-2 text-sm font-bold text-muted hover:bg-canvas">Cancelar</a>
              <button type="submit" class="rounded-lg bg-navy px-4 py-2 text-sm font-bold text-white hover:bg-[#143a5d]">Confirmar Reserva</button>
            </div>
          </div>
        </form>

        <aside class="space-y-4">

          <div class="rounded-lg border border-[#f5cbb1] p-4 bg-[#fff5f0] shadow-soft box-emergency-border">
            <div class="flex items-start gap-3">
              <span class="material-symbols-outlined text-danger text-[26px]">emergency</span>
              <div>
                <p class="text-sm font-extrabold text-danger uppercase tracking-wide">¿Necesitas atención inmediata?</p>
                <p class="mt-2 text-sm text-ink leading-relaxed">
                  En caso desee para <strong>hoy mismo</strong> la cita, por favor comuníquese directamente a nuestra central prioritaria:
                </p>
                <p class="mt-3 text-lg font-extrabold text-danger flex items-center gap-1">
                  <span class="material-symbols-outlined text-[18px]">call</span> (01) 444-5555
                </p>
              </div>
            </div>
          </div>

          <div class="rounded-lg border border-line p-4 bg-white shadow-soft">
            <p class="text-xs font-extrabold uppercase text-muted">Tratamiento Pendiente</p>
            <p class="mt-2 text-base font-extrabold text-danger">Endodoncia Pieza 16</p>
            <p class="mt-1 text-xs text-muted">El sistema priorizará su asignación con el Dr. Ramos debido al reporte de sensibilidad registrado en su última consulta.</p>
          </div>
        </aside>

      </div>
    </section>
  </main>
</div>
</body>
</html>