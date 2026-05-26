namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private Form? formularioActivo = null;
        private Button? botonActivo = null;
        private readonly Color colorActivo = Color.FromArgb(88, 101, 242);
        private readonly Color colorNormal = Color.Transparent;
        private bool finanzasExpandido = false;

        public Form1()
        {
            InitializeComponent();
            PersonalizarDiseno();
        }

        private void PersonalizarDiseno()
        {
            // Inicializar botones con color normal
            btnFinanzas.BackColor = colorNormal;
            btnDashboard.BackColor = colorNormal;
            btnPagos.BackColor = colorNormal;
            btnMovimientos.BackColor = colorNormal;
            btnComprobantes.BackColor = colorNormal;
            btnPacientes.BackColor = colorNormal;
            btnExportar.BackColor = colorNormal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargar Dashboard por defecto
            lblWelcome.Text = "📊 Dashboard";
            btnDashboard.PerformClick();
        }

        // ============================================================
        // MÉTODO GENÉRICO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        // ============================================================
        private void AbrirFormulario(Form formularioHijo, Button botonMenu)
        {
            // Cerrar formulario actual si existe
            formularioActivo?.Close();

            // Actualizar estilo de botones
            if (botonActivo != null)
                botonActivo.BackColor = colorNormal;

            botonActivo = botonMenu;
            botonActivo.BackColor = colorActivo;

            // Configurar formulario hijo
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Insertar en el panel de contenido
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(formularioHijo);
            formularioHijo.Show();

            formularioActivo = formularioHijo;
        }

        // ============================================================
        // EFECTOS HOVER EN BOTONES DEL MENÚ
        // ============================================================
        private void Btn_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != botonActivo)
                btn.BackColor = Color.FromArgb(60, 60, 80);
        }

        private void Btn_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn != botonActivo)
                btn.BackColor = colorNormal;
        }

        // ============================================================
        // TOGGLE FINANZAS (EXPANDIR / COLAPSAR SUBMENÚS)
        // ============================================================
        private void btnFinanzas_Click(object? sender, EventArgs e)
        {
            finanzasExpandido = !finanzasExpandido;

            if (finanzasExpandido)
            {
                // Expandir: mostrar submenús y desplazar Pacientes y Exportar
                btnFinanzas.Text = "💰  Finanzas  ▼";

                btnDashboard.Visible = true;
                btnPagos.Visible = true;
                btnMovimientos.Visible = true;
                btnComprobantes.Visible = true;

                // Reposicionar Pacientes y Exportar más abajo
                btnPacientes.Location = new Point(15, 445);
                btnExportar.Location = new Point(15, 500);
            }
            else
            {
                // Colapsar: ocultar submenús y restaurar posiciones
                btnFinanzas.Text = "💰  Finanzas  ▶";

                btnDashboard.Visible = false;
                btnPagos.Visible = false;
                btnMovimientos.Visible = false;
                btnComprobantes.Visible = false;

                // Restaurar posiciones originales de Pacientes y Exportar
                btnPacientes.Location = new Point(15, 240);
                btnExportar.Location = new Point(15, 295);
            }
        }

        // ============================================================
        // HANDLERS DE NAVEGACIÓN
        // ============================================================

        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            lblWelcome.Text = "📊 Dashboard";
            AbrirFormulario(new FrmDashboard(), btnDashboard);
        }

        private void btnPagos_Click(object? sender, EventArgs e)
        {
            lblWelcome.Text = "💳 Gestión de Pagos";
            AbrirFormulario(new FrmPagos(), btnPagos);
        }

        private void btnMovimientos_Click(object? sender, EventArgs e)
        {
            lblWelcome.Text = "📈 Movimientos Financieros";
            AbrirFormulario(new FrmMovimientos(), btnMovimientos);
        }

        private void btnComprobantes_Click(object? sender, EventArgs e)
        {
            lblWelcome.Text = "🧾 Comprobantes";
            AbrirFormulario(new FrmComprobantes(), btnComprobantes);
        }

        private void btnPacientes_Click(object? sender, EventArgs e)
        {
            lblWelcome.Text = "👥 Gestión de Pacientes";
            // Validar que el formulario de pacientes existe
            try
            {
                // Usar reflection para instanciar FrmPacientes si existe
                var tipo = Type.GetType("CapaPresentacion.FrmPacientes, CapaPresentacion");
                if (tipo != null)
                {
                    var frm = (Form)Activator.CreateInstance(tipo)!;
                    AbrirFormulario(frm, btnPacientes);
                }
                else
                {
                    // Si no hay formulario de pacientes, mostrar mensaje en el panel
                    MostrarMensajeEnPanel("👥 Módulo de Pacientes", "Este módulo está en desarrollo. Próximamente podrá gestionar pacientes aquí.");
                }
            }
            catch
            {
                MostrarMensajeEnPanel("👥 Módulo de Pacientes", "Este módulo está en desarrollo. Próximamente podrá gestionar pacientes aquí.");
            }
        }

        private void btnExportar_Click(object? sender, EventArgs e)
        {
            MostrarMensajeEnPanel("📤 Exportar Datos", "Funcionalidad de exportación en desarrollo.\nPodrá exportar reportes a PDF y Excel.");
        }

        // ============================================================
        // MENSAJE TEMPORAL PARA MÓDULOS EN DESARROLLO
        // ============================================================
        private void MostrarMensajeEnPanel(string titulo, string mensaje)
        {
            formularioActivo?.Close();
            formularioActivo = null;

            pnlContent.Controls.Clear();

            var panelMensaje = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 246, 250)
            };

            var lblIcono = new Label
            {
                Text = "🚧",
                Font = new Font("Segoe UI", 48, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 46),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            var lblMensaje = new Label
            {
                Text = mensaje,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 120),
                AutoSize = true,
                MaximumSize = new Size(500, 0),
                Location = new Point(0, 0)
            };

            panelMensaje.Controls.Add(lblIcono);
            panelMensaje.Controls.Add(lblTitulo);
            panelMensaje.Controls.Add(lblMensaje);

            // Centrar vertical y horizontalmente
            panelMensaje.Resize += (s, e) =>
            {
                int totalHeight = lblIcono.Height + 20 + lblTitulo.Height + 10 + lblMensaje.Height;
                int startY = (panelMensaje.Height - totalHeight) / 2;

                lblIcono.Location = new Point((panelMensaje.Width - lblIcono.Width) / 2, startY);
                lblTitulo.Location = new Point((panelMensaje.Width - lblTitulo.Width) / 2, lblIcono.Bottom + 20);
                lblMensaje.Location = new Point((panelMensaje.Width - lblMensaje.Width) / 2, lblTitulo.Bottom + 10);
            };

            pnlContent.Controls.Add(panelMensaje);
        }
    }
}