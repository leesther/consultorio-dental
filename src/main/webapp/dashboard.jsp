<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%><%@ include file="WEB-INF/jspf/portalContext.jspf" %>
<!DOCTYPE html>
<html lang="es" class="light">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Dental Leon - Dashboard</title>
  <script src="https://cdn.tailwindcss.com?plugins=forms"></script>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
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
      <a class="flex items-center gap-3 rounded-lg bg-softBlue px-3 py-3 text-sm font-bold text-navy" href="dashboard.jsp">
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
      <% if (currentPatient == null) { %>
      <div class="rounded-lg border border-[#f5cbb1] bg-[#fff5f0] p-4 text-sm font-semibold text-danger">No hay paciente vinculado a esta sesi&oacute;n. Agenda una cita desde la p&aacute;gina principal para crear el paciente y ver datos cl&iacute;nicos reales.</div>      <% } %>
      <div class="grid gap-4 md:grid-cols-4">
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Próxima cita</p>
          <p class="mt-2 text-2xl font-extrabold text-teal"><%= nextAppointment != null ? shortDateFormatter.format(nextAppointment.getInicio()) : "Sin cita" %></p>
          <p class="mt-1 text-sm font-semibold text-muted"><%= nextAppointment != null ? timeFormatter.format(nextAppointment.getInicio()) + " · " + safeText(nextAppointment.getDoctor(), "Doctor") : "Agenda pendiente" %></p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Tratamiento actual</p>
          <p class="mt-2 text-lg font-extrabold text-danger"><%= portal.getClinicalRecords().isEmpty() ? "Sin tratamientos" : safeText(portal.getClinicalRecords().get(0).getTratamiento(), "Tratamiento pendiente") %></p>
          <p class="mt-1 text-sm font-semibold text-muted">Prioridad alta</p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Saldo pendiente</p>
          <p class="mt-2 text-3xl font-extrabold text-navy"><%= money(portal.getSaldoPendiente()) %></p>
          <p class="mt-1 text-sm font-semibold text-muted"><%= portal.getPayments().isEmpty() ? "Sin pagos registrados" : "Cuenta conectada a pagos" %></p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Última atención</p>
          <p class="mt-2 text-lg font-extrabold text-navy">12/10/2023</p>
          <p class="mt-1 text-sm font-semibold text-muted">Evaluación clínica</p>
        </article>
      </div>

      <section class="grid gap-6 lg:grid-cols-[1.2fr_0.8fr]">
        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-5 flex flex-wrap items-center justify-between gap-3 border-b border-line pb-4">
            <div>
              <h3 class="text-xl font-extrabold text-navy">Siguiente cita</h3>
              <p class="text-sm text-muted"><%= nextAppointment != null ? safeText(nextAppointment.getMotivo(), "Cita programada") : "No hay citas programadas." %></p>
            </div>
            <span class="rounded-full bg-[#fff3d7] px-3 py-1 text-xs font-bold text-[#875400]">Confirmada</span>
          </div>

          <div class="grid gap-4 md:grid-cols-[180px_1fr]">
            <div class="rounded-lg bg-navy p-5 text-white">
              <p class="text-sm font-bold uppercase text-white/70"><%= nextAppointment != null ? dayFormatter.format(nextAppointment.getInicio()) : "--" %></p>
              <p class="mt-3 text-5xl font-extrabold"><%= nextAppointment != null ? String.valueOf(nextAppointment.getInicio().getDayOfMonth()) : "--" %></p>
              <p class="mt-1 text-lg font-bold"><%= nextAppointment != null ? monthFormatter.format(nextAppointment.getInicio()) : "Sin fecha" %></p>
              <p class="mt-4 rounded-lg bg-white/10 px-3 py-2 text-center text-sm font-extrabold"><%= nextAppointment != null ? timeFormatter.format(nextAppointment.getInicio()) : "--" %></p>
            </div>
            <div class="space-y-4">
              <div class="grid gap-3 sm:grid-cols-2">
                <div class="rounded-lg bg-canvas p-4">
                  <p class="text-xs font-extrabold uppercase text-muted">Doctor</p>
                  <p class="mt-1 font-extrabold text-navy"><%= nextAppointment != null ? safeText(nextAppointment.getDoctor(), "Doctor asignado") : "Sin asignar" %></p>
                </div>
                <div class="rounded-lg bg-canvas p-4">
                  <p class="text-xs font-extrabold uppercase text-muted">Duración estimada</p>
                  <p class="mt-1 font-extrabold text-navy">70 minutos</p>
                </div>
              </div>
              <div class="rounded-lg bg-canvas p-4">
                <p class="text-xs font-extrabold uppercase text-muted">Indicaciones previas</p>
                <p class="mt-2 text-sm text-muted">Llegar 10 minutos antes, traer radiografía si ya fue tomada y evitar alimentos muy fríos antes de la consulta.</p>
              </div>
            </div>
          </div>
        </article>

        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-4 flex items-center justify-between border-b border-line pb-3">
            <h3 class="text-lg font-extrabold text-navy">Notas del doctor</h3>
            <span class="material-symbols-outlined text-teal">clinical_notes</span>
          </div>
          <div class="space-y-4 text-sm">
            <div class="rounded-lg bg-canvas p-4">
              <p class="font-bold text-navy">Sensibilidad reportada</p>
              <p class="mt-1 text-muted">La paciente refiere sensibilidad al frío en el sector superior izquierdo. Se recomienda evaluación radiográfica antes del procedimiento.</p>
            </div>
            <div class="rounded-lg bg-canvas p-4">
              <p class="font-bold text-navy">Cuidado en casa</p>
              <p class="mt-1 text-muted">Mantener higiene con cepillo de cerdas suaves y evitar masticar alimentos duros del lado afectado hasta la próxima cita.</p>
            </div>
          </div>
        </article>
      </section>

      <section class="grid gap-6 lg:grid-cols-[1fr_360px]">
        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-5 flex flex-wrap items-center justify-between gap-3 border-b border-line pb-4">
            <div>
              <h3 class="text-xl font-extrabold text-navy">Plan de tratamiento</h3>
              <a class="text-sm font-bold text-teal hover:underline" href="historial.jsp">Ver historial</a>
            </div>
            <div class="space-y-4">
              <div>
                <div class="mb-2 flex items-center justify-between text-sm">
                  <span class="font-bold text-ink">Progreso general</span>
                  <span class="font-extrabold text-teal">45%</span>
                </div>
                <div class="h-3 overflow-hidden rounded-full bg-canvas">
                  <div class="h-full w-[45%] rounded-full bg-teal"></div>
                </div>
              </div>
              <div class="grid gap-3 md:grid-cols-3">
                <div class="rounded-lg border border-line p-4">
                  <p class="text-xs font-extrabold uppercase text-muted">Pendiente</p>
                  <p class="mt-2 font-extrabold text-danger">Endodoncia 16</p>
                </div>
                <div class="rounded-lg border border-line p-4">
                  <p class="text-xs font-extrabold uppercase text-muted">En seguimiento</p>
                  <p class="mt-2 font-extrabold text-teal">Control radiográfico</p>
                </div>
                <div class="rounded-lg border border-line p-4">
                  <p class="text-xs font-extrabold uppercase text-muted">Completado</p>
                  <p class="mt-2 font-extrabold text-navy">Profilaxis</p>
                </div>
              </div>
            </div>
        </article>

        <article class="rounded-xl border border-line bg-panel p-5 shadow-soft">
          <div class="mb-4 flex items-center justify-between border-b border-line pb-3">
            <h3 class="text-lg font-extrabold text-navy">Pagos</h3>
            <a class="text-sm font-bold text-teal hover:underline" href="pagos.jsp">Detail</a>
          </div>
          <dl class="space-y-3 text-sm">
            <div class="flex justify-between"><dt class="text-muted">Presupuesto</dt><dd class="font-extrabold">S/ 980</dd></div>
            <div class="flex justify-between"><dt class="text-muted">Pagado</dt><dd class="font-extrabold text-teal"><%= money(portal.getTotalPagado()) %></dd></div>
            <div class="flex justify-between border-t border-line pt-3"><dt class="text-muted">Saldo</dt><dd class="font-extrabold text-danger"><%= money(portal.getSaldoPendiente()) %></dd></div>
          </dl>
        </article>
      </section>

      <section class="rounded-xl border border-line bg-panel p-5 shadow-soft">
        <h3 class="mb-4 border-b border-line pb-3 text-lg font-extrabold text-navy">Actividad reciente</h3>
        <ol class="grid gap-4 text-sm md:grid-cols-3">
          <li class="rounded-lg bg-canvas p-4">
            <p class="font-bold">Caries registrada en pieza 16</p>
            <p class="mt-1 text-muted">Hoy · Dr. Ramos</p>
          </li>
          <li class="rounded-lg bg-canvas p-4">
            <p class="font-bold">Presupuesto actualizado</p>
            <p class="mt-1 text-muted">12/10/2023 · Administración</p>
          </li>
          <li class="rounded-lg bg-canvas p-4">
            <p class="font-bold">Control de profilaxis completado</p>
            <p class="mt-1 text-muted">04/09/2023 · Dra. Vega</p>
          </li>
        </ol>
      </section>
    </section>
  </main>
</div>
</body>
</html>