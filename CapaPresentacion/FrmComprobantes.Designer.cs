namespace CapaPresentacion
{
    partial class FrmComprobantes
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbTipo;
        private ComboBox cmbPago;
        private TextBox txtRazonSocial;
        private TextBox txtRUC;
        private Button btnGenerar;
        private Button btnVistaPrevia;
        private Button btnExportarPDF;
        private Button btnAnular;
        private Button btnLimpiar;
        private DataGridView dgvComprobantes;
        private Label labelTipo;
        private Label labelRazonSocial;
        private Label labelRUC;
        private Label labelPago;
        private GroupBox groupBoxForm;
        private GroupBox groupBoxAcciones;
        private Panel panelTop;
        private DataGridViewTextBoxColumn colIdComprobante;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colRazonSocial;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPaciente;
        private DataGridViewTextBoxColumn colFecha;

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
            panelTop = new Panel();
            groupBoxForm = new GroupBox();
            btnLimpiar = new Button();
            btnGenerar = new Button();
            cmbPago = new ComboBox();
            labelPago = new Label();
            txtRUC = new TextBox();
            labelRUC = new Label();
            txtRazonSocial = new TextBox();
            labelRazonSocial = new Label();
            cmbTipo = new ComboBox();
            labelTipo = new Label();
            groupBoxAcciones = new GroupBox();
            btnAnular = new Button();
            btnExportarPDF = new Button();
            btnVistaPrevia = new Button();
            dgvComprobantes = new DataGridView();
            colIdComprobante = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colNumero = new DataGridViewTextBoxColumn();
            colRazonSocial = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colPaciente = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            groupBoxForm.SuspendLayout();
            groupBoxAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComprobantes).BeginInit();
            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(0, 102, 204);
            panelTop.Controls.Add(new Label
            {
                Text = "COMPROBANTES (FACTURA / BOLETA)",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            });
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;

            // 
            // groupBoxForm
            // 
            groupBoxForm.Controls.Add(btnLimpiar);
            groupBoxForm.Controls.Add(btnGenerar);
            groupBoxForm.Controls.Add(cmbPago);
            groupBoxForm.Controls.Add(labelPago);
            groupBoxForm.Controls.Add(txtRUC);
            groupBoxForm.Controls.Add(labelRUC);
            groupBoxForm.Controls.Add(txtRazonSocial);
            groupBoxForm.Controls.Add(labelRazonSocial);
            groupBoxForm.Controls.Add(cmbTipo);
            groupBoxForm.Controls.Add(labelTipo);
            groupBoxForm.Location = new Point(12, 70);
            groupBoxForm.Name = "groupBoxForm";
            groupBoxForm.Size = new Size(500, 250);
            groupBoxForm.Text = "Datos del Comprobante";
            groupBoxForm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(12, 205);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 35);
            btnLimpiar.Text = "🧹 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(40, 167, 69);
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(372, 205);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(110, 35);
            btnGenerar.Text = "✔ Generar";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;

            // 
            // cmbPago
            // 
            cmbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPago.Font = new Font("Segoe UI", 9F);
            cmbPago.Location = new Point(140, 155);
            cmbPago.Name = "cmbPago";
            cmbPago.Size = new Size(340, 28);

            // 
            // labelPago
            // 
            labelPago.Font = new Font("Segoe UI", 9F);
            labelPago.Location = new Point(12, 158);
            labelPago.Name = "labelPago";
            labelPago.Size = new Size(120, 23);
            labelPago.Text = "Pago Asociado:";

            // 
            // txtRUC
            // 
            txtRUC.Font = new Font("Segoe UI", 9F);
            txtRUC.Location = new Point(140, 110);
            txtRUC.Name = "txtRUC";
            txtRUC.Size = new Size(200, 27);

            // 
            // labelRUC
            // 
            labelRUC.Font = new Font("Segoe UI", 9F);
            labelRUC.Location = new Point(12, 113);
            labelRUC.Name = "labelRUC";
            labelRUC.Size = new Size(120, 23);
            labelRUC.Text = "RUC:";

            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Segoe UI", 9F);
            txtRazonSocial.Location = new Point(140, 70);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(340, 27);

            // 
            // labelRazonSocial
            // 
            labelRazonSocial.Font = new Font("Segoe UI", 9F);
            labelRazonSocial.Location = new Point(12, 73);
            labelRazonSocial.Name = "labelRazonSocial";
            labelRazonSocial.Size = new Size(120, 23);
            labelRazonSocial.Text = "Razón Social:";

            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 9F);
            cmbTipo.Items.AddRange(new object[] { "Factura", "Boleta" });
            cmbTipo.Location = new Point(140, 30);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 28);

            // 
            // labelTipo
            // 
            labelTipo.Font = new Font("Segoe UI", 9F);
            labelTipo.Location = new Point(12, 33);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(120, 23);
            labelTipo.Text = "Tipo:";

            // 
            // groupBoxAcciones
            // 
            groupBoxAcciones.Controls.Add(btnAnular);
            groupBoxAcciones.Controls.Add(btnExportarPDF);
            groupBoxAcciones.Controls.Add(btnVistaPrevia);
            groupBoxAcciones.Location = new Point(12, 330);
            groupBoxAcciones.Name = "groupBoxAcciones";
            groupBoxAcciones.Size = new Size(500, 70);
            groupBoxAcciones.Text = "Acciones";
            groupBoxAcciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // 
            // btnAnular
            // 
            btnAnular.BackColor = Color.FromArgb(220, 53, 69);
            btnAnular.FlatStyle = FlatStyle.Flat;
            btnAnular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnular.ForeColor = Color.White;
            btnAnular.Location = new Point(354, 25);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(130, 32);
            btnAnular.Text = "❌ Anular";
            btnAnular.UseVisualStyleBackColor = false;
            btnAnular.Click += btnAnular_Click;

            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(255, 193, 7);
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarPDF.ForeColor = Color.Black;
            btnExportarPDF.Location = new Point(188, 25);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(130, 32);
            btnExportarPDF.Text = "📄 Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;

            // 
            // btnVistaPrevia
            // 
            btnVistaPrevia.BackColor = Color.FromArgb(0, 123, 255);
            btnVistaPrevia.FlatStyle = FlatStyle.Flat;
            btnVistaPrevia.Font = new Font("Segoe UI", 9F);
            btnVistaPrevia.ForeColor = Color.White;
            btnVistaPrevia.Location = new Point(18, 25);
            btnVistaPrevia.Name = "btnVistaPrevia";
            btnVistaPrevia.Size = new Size(130, 32);
            btnVistaPrevia.Text = "👁 Vista Previa";
            btnVistaPrevia.UseVisualStyleBackColor = false;
            btnVistaPrevia.Click += btnVistaPrevia_Click;

            // 
            // dgvComprobantes
            // 
            dgvComprobantes.AllowUserToAddRows = false;
            dgvComprobantes.AllowUserToDeleteRows = false;
            dgvComprobantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComprobantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComprobantes.Columns.AddRange(new DataGridViewColumn[] {
                colIdComprobante,
                colTipo,
                colNumero,
                colRazonSocial,
                colTotal,
                colEstado,
                colPaciente,
                colFecha
            });
            dgvComprobantes.Location = new Point(518, 70);
            dgvComprobantes.Name = "dgvComprobantes";
            dgvComprobantes.ReadOnly = true;
            dgvComprobantes.RowHeadersWidth = 51;
            dgvComprobantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComprobantes.Size = new Size(800, 610);
            dgvComprobantes.SelectionChanged += dgvComprobantes_SelectionChanged;

            // 
            // colIdComprobante
            // 
            colIdComprobante.DataPropertyName = "IdComprobante";
            colIdComprobante.HeaderText = "ID";
            colIdComprobante.Name = "colIdComprobante";
            colIdComprobante.Width = 50;

            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "TipoComprobante";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.Width = 80;

            // 
            // colNumero
            // 
            colNumero.DataPropertyName = "NumeroComprobante";
            colNumero.HeaderText = "N° Comprobante";
            colNumero.Name = "colNumero";
            colNumero.Width = 140;

            // 
            // colRazonSocial
            // 
            colRazonSocial.DataPropertyName = "RazonSocial";
            colRazonSocial.HeaderText = "Razón Social";
            colRazonSocial.Name = "colRazonSocial";
            colRazonSocial.Width = 200;

            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "Total";
            colTotal.HeaderText = "Total (S/)";
            colTotal.Name = "colTotal";
            colTotal.DefaultCellStyle.Format = "N2";
            colTotal.Width = 100;

            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.Width = 80;

            // 
            // colPaciente
            // 
            colPaciente.DataPropertyName = "PacienteNombre";
            colPaciente.HeaderText = "Paciente";
            colPaciente.Name = "colPaciente";
            colPaciente.Width = 180;

            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaEmision";
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colFecha.Width = 120;

            // 
            // FrmComprobantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1330, 700);
            Controls.Add(dgvComprobantes);
            Controls.Add(groupBoxAcciones);
            Controls.Add(groupBoxForm);
            Controls.Add(panelTop);
            Name = "FrmComprobantes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comprobantes - Proyecto Dental";
            Load += FrmComprobantes_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            groupBoxForm.ResumeLayout(false);
            groupBoxForm.PerformLayout();
            groupBoxAcciones.ResumeLayout(false);
            groupBoxAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComprobantes).EndInit();
            ResumeLayout(false);
        }
    }
}