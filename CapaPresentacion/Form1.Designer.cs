namespace CapaPresentacion
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnFinanzas;
        private Button btnDashboard;
        private Button btnPagos;
        private Button btnMovimientos;
        private Button btnComprobantes;
        private Button btnPacientes;
        private Button btnExportar;
        private Label lblWelcome;
        private PictureBox picLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlSidebar = new Panel();
            picLogo = new PictureBox();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnFinanzas = new Button();
            btnDashboard = new Button();
            btnPagos = new Button();
            btnMovimientos = new Button();
            btnComprobantes = new Button();
            btnPacientes = new Button();
            btnExportar = new Button();
            pnlHeader = new Panel();
            lblWelcome = new Label();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            // pnlSidebar
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 46);
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(lblTitle);
            pnlSidebar.Controls.Add(lblSubtitle);
            pnlSidebar.Controls.Add(btnFinanzas);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnPagos);
            pnlSidebar.Controls.Add(btnMovimientos);
            pnlSidebar.Controls.Add(btnComprobantes);
            pnlSidebar.Controls.Add(btnPacientes);
            pnlSidebar.Controls.Add(btnExportar);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 720);
            pnlSidebar.TabIndex = 0;

            // picLogo
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(75, 25);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(80, 80);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 8;
            picLogo.TabStop = false;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 115);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(170, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Clínica Dental Leon";

            // lblSubtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.FromArgb(160, 160, 180);
            lblSubtitle.Location = new Point(32, 146);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(165, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sistema de Gestión Clínica";

            // btnFinanzas
            btnFinanzas.FlatAppearance.BorderSize = 0;
            btnFinanzas.FlatStyle = FlatStyle.Flat;
            btnFinanzas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFinanzas.ForeColor = Color.White;
            btnFinanzas.Location = new Point(15, 185);
            btnFinanzas.Name = "btnFinanzas";
            btnFinanzas.Size = new Size(200, 45);
            btnFinanzas.TabIndex = 10;
            btnFinanzas.Text = "💰  Finanzas  ▶";
            btnFinanzas.TextAlign = ContentAlignment.MiddleLeft;
            btnFinanzas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinanzas.UseVisualStyleBackColor = true;
            btnFinanzas.Click += btnFinanzas_Click;
            btnFinanzas.MouseEnter += Btn_MouseEnter;
            btnFinanzas.MouseLeave += Btn_MouseLeave;

            // btnDashboard
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(35, 240);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(180, 40);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "📊  Dashboard";
            btnDashboard.Visible = false;
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            btnDashboard.MouseEnter += Btn_MouseEnter;
            btnDashboard.MouseLeave += Btn_MouseLeave;

            // btnPagos
            btnPagos.FlatAppearance.BorderSize = 0;
            btnPagos.FlatStyle = FlatStyle.Flat;
            btnPagos.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnPagos.ForeColor = Color.White;
            btnPagos.Location = new Point(35, 290);
            btnPagos.Name = "btnPagos";
            btnPagos.Size = new Size(180, 40);
            btnPagos.TabIndex = 1;
            btnPagos.Text = "💳  Pagos";
            btnPagos.Visible = false;
            btnPagos.TextAlign = ContentAlignment.MiddleLeft;
            btnPagos.UseVisualStyleBackColor = true;
            btnPagos.Click += btnPagos_Click;
            btnPagos.MouseEnter += Btn_MouseEnter;
            btnPagos.MouseLeave += Btn_MouseLeave;

            // btnMovimientos
            btnMovimientos.FlatAppearance.BorderSize = 0;
            btnMovimientos.FlatStyle = FlatStyle.Flat;
            btnMovimientos.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnMovimientos.ForeColor = Color.White;
            btnMovimientos.Location = new Point(35, 340);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Size = new Size(180, 40);
            btnMovimientos.TabIndex = 2;
            btnMovimientos.Text = "📈  Movimientos";
            btnMovimientos.Visible = false;
            btnMovimientos.TextAlign = ContentAlignment.MiddleLeft;
            btnMovimientos.UseVisualStyleBackColor = true;
            btnMovimientos.Click += btnMovimientos_Click;
            btnMovimientos.MouseEnter += Btn_MouseEnter;
            btnMovimientos.MouseLeave += Btn_MouseLeave;

            // btnComprobantes
            btnComprobantes.FlatAppearance.BorderSize = 0;
            btnComprobantes.FlatStyle = FlatStyle.Flat;
            btnComprobantes.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnComprobantes.ForeColor = Color.White;
            btnComprobantes.Location = new Point(35, 390);
            btnComprobantes.Name = "btnComprobantes";
            btnComprobantes.Size = new Size(180, 40);
            btnComprobantes.TabIndex = 3;
            btnComprobantes.Text = "🧾  Comprobantes";
            btnComprobantes.Visible = false;
            btnComprobantes.TextAlign = ContentAlignment.MiddleLeft;
            btnComprobantes.UseVisualStyleBackColor = true;
            btnComprobantes.Click += btnComprobantes_Click;
            btnComprobantes.MouseEnter += Btn_MouseEnter;
            btnComprobantes.MouseLeave += Btn_MouseLeave;

            // btnPacientes
            btnPacientes.FlatAppearance.BorderSize = 0;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnPacientes.ForeColor = Color.White;
            btnPacientes.Location = new Point(15, 240);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(200, 45);
            btnPacientes.TabIndex = 4;
            btnPacientes.Text = "👥  Pacientes";
            btnPacientes.TextAlign = ContentAlignment.MiddleLeft;
            btnPacientes.UseVisualStyleBackColor = true;
            btnPacientes.Click += btnPacientes_Click;
            btnPacientes.MouseEnter += Btn_MouseEnter;
            btnPacientes.MouseLeave += Btn_MouseLeave;

            // btnExportar
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(15, 295);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(200, 45);
            btnExportar.TabIndex = 5;
            btnExportar.Text = "📤  Exportar";
            btnExportar.TextAlign = ContentAlignment.MiddleLeft;
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            btnExportar.MouseEnter += Btn_MouseEnter;
            btnExportar.MouseLeave += Btn_MouseLeave;

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(245, 246, 250);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(230, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1030, 60);
            pnlHeader.TabIndex = 1;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblWelcome.ForeColor = Color.FromArgb(50, 50, 70);
            lblWelcome.Location = new Point(30, 17);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(280, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "👋 Bienvenido a Clínica Dental Leon";

            // pnlContent
            pnlContent.BackColor = Color.FromArgb(245, 246, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(230, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1030, 660);
            pnlContent.TabIndex = 2;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(1260, 720);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clínica Dental Leon - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
    }
}