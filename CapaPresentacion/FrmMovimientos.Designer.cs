namespace CapaPresentacion
{
    partial class FrmMovimientos
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbTipo;
        private ComboBox cmbFiltroTipo;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private Button btnRegistrar;
        private Button btnFiltrar;
        private Button btnMostrarTodos;
        private Button btnLimpiar;
        private DataGridView dgvMovimientos;
        private Label lblBalance;
        private DateTimePicker dtpFecha;
        private Label labelTipo;
        private Label labelMonto;
        private Label labelDescripcion;
        private Label labelFecha;
        private Label labelFiltro;
        private GroupBox groupBoxForm;
        private GroupBox groupBoxFiltro;
        private Panel panelTop;
        private Panel panelBalance;

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
            panelBalance = new Panel();
            lblBalance = new Label();
            groupBoxForm = new GroupBox();
            btnLimpiar = new Button();
            btnRegistrar = new Button();
            dtpFecha = new DateTimePicker();
            labelFecha = new Label();
            cmbTipo = new ComboBox();
            labelTipo = new Label();
            txtMonto = new TextBox();
            labelMonto = new Label();
            txtDescripcion = new TextBox();
            labelDescripcion = new Label();
            groupBoxFiltro = new GroupBox();
            cmbFiltroTipo = new ComboBox();
            labelFiltro = new Label();
            btnFiltrar = new Button();
            btnMostrarTodos = new Button();
            dgvMovimientos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            panelBalance.SuspendLayout();
            groupBoxForm.SuspendLayout();
            groupBoxFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(0, 102, 204);
            panelTop.Controls.Add(new Label
            {
                Text = "MOVIMIENTOS (INGRESOS / EGRESOS)",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            });
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;

            // 
            // panelBalance
            // 
            panelBalance.BackColor = Color.FromArgb(40, 167, 69);
            panelBalance.Controls.Add(lblBalance);
            panelBalance.Dock = DockStyle.Top;
            panelBalance.Height = 50;
            panelBalance.Location = new Point(0, 60);

            // 
            // lblBalance
            // 
            lblBalance.Dock = DockStyle.Fill;
            lblBalance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBalance.ForeColor = Color.White;
            lblBalance.Text = "Balance: S/ 0.00";
            lblBalance.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // groupBoxForm
            // 
            groupBoxForm.Controls.Add(btnLimpiar);
            groupBoxForm.Controls.Add(btnRegistrar);
            groupBoxForm.Controls.Add(dtpFecha);
            groupBoxForm.Controls.Add(labelFecha);
            groupBoxForm.Controls.Add(cmbTipo);
            groupBoxForm.Controls.Add(labelTipo);
            groupBoxForm.Controls.Add(txtMonto);
            groupBoxForm.Controls.Add(labelMonto);
            groupBoxForm.Controls.Add(txtDescripcion);
            groupBoxForm.Controls.Add(labelDescripcion);
            groupBoxForm.Location = new Point(12, 120);
            groupBoxForm.Name = "groupBoxForm";
            groupBoxForm.Size = new Size(440, 310);
            groupBoxForm.Text = "Nuevo Movimiento";
            groupBoxForm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(12, 260);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.Text = "🧹 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(290, 260);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 35);
            btnRegistrar.Text = "✔ Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;

            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 9F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(130, 195);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 27);

            // 
            // labelFecha
            // 
            labelFecha.Font = new Font("Segoe UI", 9F);
            labelFecha.Location = new Point(12, 198);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(110, 23);
            labelFecha.Text = "Fecha:";

            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 9F);
            cmbTipo.Items.AddRange(new object[] { "Ingreso", "Egreso" });
            cmbTipo.Location = new Point(130, 25);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 28);

            // 
            // labelTipo
            // 
            labelTipo.Font = new Font("Segoe UI", 9F);
            labelTipo.Location = new Point(12, 28);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(110, 23);
            labelTipo.Text = "Tipo:";

            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 9F);
            txtMonto.Location = new Point(130, 70);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(200, 27);

            // 
            // labelMonto
            // 
            labelMonto.Font = new Font("Segoe UI", 9F);
            labelMonto.Location = new Point(12, 73);
            labelMonto.Name = "labelMonto";
            labelMonto.Size = new Size(110, 23);
            labelMonto.Text = "Monto (S/):";

            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(130, 115);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(290, 65);

            // 
            // labelDescripcion
            // 
            labelDescripcion.Font = new Font("Segoe UI", 9F);
            labelDescripcion.Location = new Point(12, 118);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(110, 23);
            labelDescripcion.Text = "Descripción:";

            // 
            // groupBoxFiltro
            // 
            groupBoxFiltro.Controls.Add(cmbFiltroTipo);
            groupBoxFiltro.Controls.Add(labelFiltro);
            groupBoxFiltro.Controls.Add(btnFiltrar);
            groupBoxFiltro.Controls.Add(btnMostrarTodos);
            groupBoxFiltro.Location = new Point(462, 120);
            groupBoxFiltro.Name = "groupBoxFiltro";
            groupBoxFiltro.Size = new Size(660, 80);
            groupBoxFiltro.Text = "Filtros";
            groupBoxFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.Font = new Font("Segoe UI", 9F);
            cmbFiltroTipo.Items.AddRange(new object[] { "Ingreso", "Egreso" });
            cmbFiltroTipo.Location = new Point(80, 30);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(200, 28);

            // 
            // labelFiltro
            // 
            labelFiltro.Font = new Font("Segoe UI", 9F);
            labelFiltro.Location = new Point(12, 33);
            labelFiltro.Name = "labelFiltro";
            labelFiltro.Size = new Size(60, 23);
            labelFiltro.Text = "Tipo:";

            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(0, 123, 255);
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 9F);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(300, 28);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(100, 32);
            btnFiltrar.Text = "🔍 Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;

            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.BackColor = Color.FromArgb(108, 117, 125);
            btnMostrarTodos.FlatStyle = FlatStyle.Flat;
            btnMostrarTodos.Font = new Font("Segoe UI", 9F);
            btnMostrarTodos.ForeColor = Color.White;
            btnMostrarTodos.Location = new Point(420, 28);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(120, 32);
            btnMostrarTodos.Text = "📋 Mostrar Todos";
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += btnMostrarTodos_Click;

            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] {
                colId,
                colTipo,
                colMonto,
                colDescripcion,
                colFecha
            });
            dgvMovimientos.Location = new Point(462, 210);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(660, 500);

            // 
            // colId
            // 
            colId.DataPropertyName = "IdMovimiento";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Width = 50;

            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "TipoMovimiento";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.Width = 80;

            // 
            // colMonto
            // 
            colMonto.DataPropertyName = "Monto";
            colMonto.HeaderText = "Monto (S/)";
            colMonto.Name = "colMonto";
            colMonto.DefaultCellStyle.Format = "N2";
            colMonto.Width = 120;

            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Width = 280;

            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaMovimiento";
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFecha.Width = 100;

            // 
            // FrmMovimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1130, 720);
            Controls.Add(dgvMovimientos);
            Controls.Add(groupBoxFiltro);
            Controls.Add(groupBoxForm);
            Controls.Add(panelBalance);
            Controls.Add(panelTop);
            Name = "FrmMovimientos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimientos - Proyecto Dental";
            Load += FrmMovimientos_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBalance.ResumeLayout(false);
            panelBalance.PerformLayout();
            groupBoxForm.ResumeLayout(false);
            groupBoxForm.PerformLayout();
            groupBoxFiltro.ResumeLayout(false);
            groupBoxFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colFecha;
    }
}