<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ include file="WEB-INF/jspf/portalContext.jspf" %>
<!DOCTYPE html>
<html lang="es" class="light">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Dental Leon - Historial Clínico</title>
  <!-- CORREGIDO: Se añadió el "?" para activar los componentes de Tailwind -->
  <script src="https://cdn.tailwindcss.com?plugins=forms"></script>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <!-- CORREGIDOS: Signos "?" agregados en las rutas de Google Fonts -->
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
          <p class="text-xs font-semibold uppercase text-muted">Portal del cliente</p>
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
      <a class="flex items-center gap-3 rounded-lg bg-softBlue px-3 py-3 text-sm font-bold text-navy" href="historial.jsp">
        <span class="material-symbols-outlined">history</span> Historial clínico
      </a>
      <a class="flex items-center gap-3 rounded-lg px-3 py-3 text-sm font-semibold text-muted hover:bg-canvas" href="pagos.jsp">
        <span class="material-symbols-outlined">payments</span> Pagos
      </a>
    </nav>

    <!-- CORREGIDO: Botón reemplazado por un enlace directo a citas.jsp -->
    <div class="border-t border-line p-4">
      <a href="${pageContext.request.contextPath}/citas.jsp"
         class="flex w-full items-center justify-between rounded-lg bg-navy px-4 py-3 text-sm font-bold text-white hover:bg-[#143a5d]">
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
      <div class="grid gap-4 md:grid-cols-4">
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Última atención</p>
          <p class="mt-2 text-lg font-extrabold text-navy">12/10/2023</p>
          <p class="mt-1 text-sm font-semibold text-muted">Evaluación clínica</p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Diagnósticos activos</p>
          <p class="mt-2 text-3xl font-extrabold text-danger"><%= portal.getClinicalRecords().size() %></p>
          <p class="mt-1 text-sm font-semibold text-muted">1 prioridad alta</p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Tratamientos</p>
          <p class="mt-2 text-3xl font-extrabold text-teal"><%= portal.getClinicalRecords().stream().filter(r -> r.getTratamiento() != null && !r.getTratamiento().isBlank()).count() %></p>
          <p class="mt-1 text-sm font-semibold text-muted">5 completados</p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Próximo control</p>
          <p class="mt-2 text-lg font-extrabold text-navy"><%= nextAppointment != null ? shortDateFormatter.format(nextAppointment.getInicio()) + " · " + timeFormatter.format(nextAppointment.getInicio()) : "Sin cita" %></p>
          <p class="mt-1 text-sm font-semibold text-muted">Endodoncia 16</p>
        </article>
      </div>

      <section class="grid gap-6 lg:grid-cols-[1fr_360px]">
        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-5 flex flex-wrap items-center justify-between gap-3 border-b border-line pb-4">
            <div>
              <h3 class="text-xl font-extrabold text-navy">Resumen clínico</h3>
              <p class="text-sm text-muted">Información principal registrada en la historia odontológica.</p>
            </div>
            <span class="rounded-full bg-mint px-3 py-1 text-xs font-bold text-teal">Actualizado</span>
          </div>
          <div class="grid gap-4 md:grid-cols-2">
            <div class="rounded-lg bg-canvas p-4">
              <p class="text-xs font-extrabold uppercase text-muted">Alergias</p>
              <p class="mt-2 font-extrabold text-navy">Ninguna registrada</p>
              <p class="mt-1 text-sm text-muted">Sin reacciones medicamentosas reportadas.</p>
            </div>
            <div class="rounded-lg bg-canvas p-4">
              <p class="text-xs font-extrabold uppercase text-muted">Antecedentes relevantes</p>
              <p class="mt-2 font-extrabold text-navy">Sensibilidad dental</p>
              <p class="mt-1 text-sm text-muted">Sensibilidad al frío en sector superior izquierdo.</p>
            </div>
            <div class="rounded-lg bg-canvas p-4">
              <p class="text-xs font-extrabold uppercase text-muted">Medicaciones</p>
              <p class="mt-2 font-extrabold text-navy">No registradas</p>
              <p class="mt-1 text-sm text-muted">Sin medicación permanente declarada.</p>
            </div>
            <div class="rounded-lg bg-canvas p-4">
              <p class="text-xs font-extrabold uppercase text-muted">Observación general</p>
              <p class="mt-2 font-extrabold text-navy">Requiere radiografía</p>
              <p class="mt-1 text-sm text-muted">Se recomienda periapical antes de iniciar endodoncia.</p>
            </div>
          </div>
        </article>

        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-4 flex items-center justify-between border-b border-line pb-3">
            <h3 class="text-lg font-extrabold text-navy">Doctor responsable</h3>
            <span class="material-symbols-outlined text-teal">stethoscope</span>
          </div>
          <div class="flex items-center gap-3">
            <div class="grid h-12 w-12 place-items-center rounded-full bg-softBlue text-base font-extrabold text-navy">CR</div>
            <div>
              <p class="font-extrabold text-navy">Dr. Carlos Ramos</p>
              <p class="text-sm text-muted">Odontología integral</p>
            </div>
          </div>
          <div class="mt-5 rounded-lg bg-canvas p-4 text-sm text-muted">
            El plan actual prioriza el tratamiento de la pieza 16 y el control radiográfico posterior para confirmar evolución.
          </div>
        </article>
      </section>

      <section class="rounded-xl border border-line bg-panel p-5 shadow-soft">
        <div class="mb-5 flex flex-wrap items-center justify-between gap-3 border-b border-line pb-4">
          <div>
            <h3 class="text-xl font-extrabold text-navy">Línea de tiempo clínica</h3>
            <p class="text-sm text-muted">Atenciones, diagnósticos y tratamientos registrados.</p>
          </div>
          <a class="inline-flex items-center gap-2 rounded-lg border border-line px-3 py-2 text-sm font-bold text-ink hover:bg-canvas" href="odontograma.jsp">
            <span class="material-symbols-outlined text-[18px]">clinical_notes</span> Ver odontograma
          </a>
        </div>

        <ol class="space-y-4">
          <% if (portal.getClinicalRecords().isEmpty()) { %>
          <li class="rounded-lg border border-line p-4 text-sm text-muted">No hay atenciones ni anotaciones clínicas registradas para este paciente.</li>
          <% } else { for (ClinicalRecord record : portal.getClinicalRecords()) { %>
          <li class="grid gap-4 rounded-lg border border-line p-4 md:grid-cols-[150px_1fr_160px]">
            <div>
              <p class="text-xs font-extrabold uppercase text-muted"><%= record.getFecha() != null ? dateFormatter.format(record.getFecha()) : "Sin fecha" %></p>
              <p class="mt-1 font-extrabold text-navy">Dental Leon</p>
            </div>
            <div>
              <p class="font-extrabold text-danger"><%= safeText(record.getDiagnostico(), "Anotación clínica") %></p>
              <p class="mt-1 text-sm text-muted"><%= safeText(record.getObservaciones(), safeText(record.getTratamiento(), "Sin observaciones adicionales")) %></p>
            </div>
            <span class="h-fit rounded-full bg-softBlue px-3 py-1 text-center text-xs font-bold text-navy"><%= safeText(record.getTratamiento(), "Seguimiento") %></span>
          </li>
          <% }} %>
        </ol>
      </section>

      <section class="grid gap-6 lg:grid-cols-2">
        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <h3 class="mb-4 border-b border-line pb-3 text-lg font-extrabold text-navy">Tratamientos activos</h3>
          <div class="space-y-3 text-sm">
            <div class="rounded-lg bg-canvas p-4">
              <div class="flex items-center justify-between gap-3">
                <p class="font-extrabold text-danger">Endodoncia pieza 16</p>
                <span class="rounded-full bg-white px-2 py-1 text-xs font-bold text-danger">Pendiente</span>
              </div>
              <p class="mt-1 text-muted">Programada para la siguiente cita.</p>
            </div>
            <div class="rounded-lg bg-canvas p-4">
              <div class="flex items-center justify-between gap-3">
                <p class="font-extrabold text-teal">Control radiográfico</p>
                <span class="rounded-full bg-white px-2 py-1 text-xs font-bold text-teal">Seguimiento</span>
              </div>
              <p class="mt-1 text-muted">Evaluar evolución posterior al tratamiento.</p>
            </div>
          </div>
        </article>

        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <h3 class="mb-4 border-b border-line pb-3 text-lg font-extrabold text-navy">Notas clínicas</h3>
          <div class="space-y-3 text-sm">
            <p class="rounded-lg bg-canvas p-4 text-muted">Mantener higiene con cepillo de cerdas suaves y evitar masticar alimentos duros del lado afectado.</p>
            <p class="rounded-lg bg-canvas p-4 text-muted">Si aparece dolor espontáneo o inflamación, comunicarse con la clínica antes de la cita programada.</p>
          </div>
        </article>
      </section>
    </section>
  </main>
</div>
</body>
</html>