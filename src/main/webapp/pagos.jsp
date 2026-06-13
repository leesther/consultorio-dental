<%@page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ include file="WEB-INF/jspf/portalContext.jspf" %>
<!DOCTYPE html>
<html lang="es" class="light">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Dental Leon - Control de Pagos</title>
  <script src="https://cdn.tailwindcss.com?plugins=forms"></script>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link rel="stylesheet" href="${pageContext.request.contextPath}/css/odontograma.css">
  <link rel="stylesheet" href="${pageContext.request.contextPath}/css/pagos.css">
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
    /* Estilos básicos para la tabla simulada con Tailwind */
    .table-app th { padding: 12px 16px; font-weight: 700; color: #0b2a45; border-bottom: 2px solid #d8e0ea; }
    .table-app td { padding: 16px; border-bottom: 1px solid #d8e0ea; }
    .badge { display: inline-block; padding: 4px 8px; font-size: 12px; font-weight: 700; rounded-radius: 9999px; border-radius: 50px; }
    .badge-danger { background-color: #fce8e6; color: #c4382d; }
    .badge-success { background-color: #d9f2ea; color: #007b8f; }
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
      <a class="flex items-center gap-3 rounded-lg bg-softBlue px-3 py-3 text-sm font-bold text-navy" href="pagos.jsp">
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
          <p class="text-xs font-bold uppercase text-muted">Total Presupuestado</p>
          <p class="mt-2 text-3xl font-extrabold text-navy"><%= money(portal.getTotalPagado().add(portal.getSaldoPendiente())) %></p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Total Pagado</p>
          <p class="mt-2 text-3xl font-extrabold text-teal"><%= money(portal.getTotalPagado()) %></p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Saldo Pendiente</p>
          <p class="mt-2 text-3xl font-extrabold text-danger"><%= money(portal.getSaldoPendiente()) %></p>
        </article>
        <article class="rounded-lg border border-line bg-panel p-4 shadow-soft">
          <p class="text-xs font-bold uppercase text-muted">Estado de cuenta</p>
          <p class="mt-2 text-lg font-extrabold text-danger"><%= portal.getSaldoPendiente().signum() > 0 ? "Pendiente de cobro" : "Al día" %></p>
        </article>
      </div>

      <div class="grid gap-6 lg:grid-cols-[1fr_360px]">

        <section class="rounded-xl border border-line bg-panel shadow-soft">
          <div class="flex flex-wrap items-center justify-between gap-3 border-b border-line px-5 py-4">
            <div>
              <h3 class="text-xl font-extrabold text-navy">Historial de Pagos</h3>
              <p class="text-sm text-muted">Registro detallado de comprobantes y amortizaciones emitidas.</p>
            </div>
            <div class="flex flex-wrap gap-2">
              <button class="inline-flex items-center gap-2 rounded-lg border border-line px-3 py-2 text-sm font-bold text-ink hover:bg-canvas">
                <span class="material-symbols-outlined text-[18px]">download</span> Descargar Todo
              </button>
            </div>
          </div>

          <div class="overflow-x-auto p-5">
            <table class="table-app w-full text-sm text-left">
              <thead>
              <tr>
                <th>Fecha</th>
                <th>Concepto / Tratamiento</th>
                <th>Método</th>
                <th>Monto</th>
                <th>Estado</th>
                <th class="text-center">Acción</th>
              </tr>
              </thead>
              <tbody>
              <% if (portal.getPayments().isEmpty()) { %>
              <tr>
                <td colspan="6" class="text-center text-muted py-4">No hay pagos registrados para este paciente.</td>
              </tr>
              <% } else { for (Payment payment : portal.getPayments()) { %>
              <tr>
                <td class="font-medium"><%= payment.getFechaPago() != null ? dateFormatter.format(payment.getFechaPago()) : (payment.getFechaVencimiento() != null ? dateFormatter.format(payment.getFechaVencimiento()) : "Pendiente") %></td>
                <td>
                  <p class="font-bold text-navy"><%= safeText(payment.getObservaciones(), payment.isDeuda() ? "Deuda registrada" : "Pago registrado") %></p>
                  <p class="text-xs text-muted">Registro conectado a Supabase</p>
                </td>
                <td><%= safeText(payment.getMetodo(), "--") %></td>
                <td class="font-bold text-ink"><%= money(payment.getMonto()) %></td>
                <td><span class='badge <%= payment.isDeuda() ? "badge-danger" : "badge-success" %>'><%= safeText(payment.getEstado(), payment.isDeuda() ? "Por pagar" : "Completado") %></span></td>
                <td class="text-center"><span class="text-xs font-bold text-muted">BD</span></td>
              </tr>
              <% }} %>
              </tbody>
            </table>
          </div>
        </section>

        <aside class="space-y-4">
          <div class="rounded-lg border border-line p-4 bg-white shadow-soft">
            <p class="text-xs font-extrabold uppercase text-muted">Financiamiento Aprobado</p>
            <p class="mt-2 text-lg font-extrabold text-navy">Línea de Crédito Directa</p>
            <p class="mt-1 text-sm text-muted">El paciente cuenta con facilidades de abono fraccionado sin intereses.</p>
            <div class="h-px bg-line my-3"></div>
            <div class="flex justify-between text-sm py-1">
              <span class="text-muted">Cuotas pactadas</span>
              <span class="font-bold text-navy">3 partes</span>
            </div>
            <div class="flex justify-between text-sm py-1">
              <span class="text-muted">Cuotas liquidadas</span>
              <span class="font-bold text-teal">2 partes</span>
            </div>
          </div>

          <div class="rounded-lg border border-line p-4 bg-white shadow-soft">
            <div class="mb-3 flex items-center justify-between">
              <p class="text-xs font-extrabold uppercase text-muted">Alertas Financieras</p>
              <span class="rounded-full bg-[#fff3d7] px-2 py-1 text-xs font-bold text-[#875400]">1 Alerta</span>
            </div>
            <div class="rounded-lg bg-canvas p-3 text-sm">
              <p class="font-bold text-danger">Saldo vencido inminente</p>
              <p class="text-muted mt-1">Se sugiere liquidar el monto de S/ 980 antes del 18/10 para evitar la pausa del tratamiento de endodoncia en curso.</p>
            </div>
          </div>
        </aside>

      </div>
    </section>
  </main>
</div>
</body>
</html>