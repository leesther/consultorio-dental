namespace CapaPresentacion
{
    partial class FrmPagos
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtIdPago;
        private TextBox txtMonto;
        private TextBox txtMetodo;
        private TextBox txtDescripcion;
        private ComboBox cmbPaciente;
        private ComboBox cmbFiltroPaciente;
        private Button btnRegistrar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnFiltrar;
        private Button btnMostrarTodos;
        private DataGridView dgvPagos;
        private Label labelIdPago;
        private Label labelPaciente;
        private Label labelMonto;
        private Label labelMetodo;
        private Label labelDescripcion;
        private Label labelFiltro;
        private GroupBox groupBoxForm;
        private GroupBox groupBoxFiltro;
        private Panel panelTop;

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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            groupBoxForm = new GroupBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnLimpiar = new Button();
            btnRegistrar = new Button();
            txtIdPago = new TextBox();
            labelIdPago = new Label();
            cmbPaciente = new ComboBox();
            labelPaciente = new Label();
            txtMetodo = new TextBox();
            labelMetodo = new Label();
            labelMonto = new Label();
            txtMonto = new TextBox();
            txtDescripcion = new TextBox();
            labelDescripcion = new Label();
            groupBoxFiltro = new GroupBox();
            cmbFiltroPaciente = new ComboBox();
            labelFiltro = new Label();
            btnFiltrar = new Button();
            btnMostrarTodos = new Button();
            dgvPagos = new DataGridView();
            colIdPago = new DataGridViewTextBoxColumn();
            colPaciente = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colMetodo = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colIdPaciente = new DataGridViewTextBoxColumn();
            groupBoxForm.SuspendLayout();
            groupBoxFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(0, 102, 204);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1058, 45);
            panelTop.TabIndex = 3;
            // 
            // groupBoxForm
            // 
            groupBoxForm.Controls.Add(btnEliminar);
            groupBoxForm.Controls.Add(btnEditar);
            groupBoxForm.Controls.Add(btnLimpiar);
            groupBoxForm.Controls.Add(btnRegistrar);
            groupBoxForm.Controls.Add(txtIdPago);
            groupBoxForm.Controls.Add(labelIdPago);
            groupBoxForm.Controls.Add(cmbPaciente);
            groupBoxForm.Controls.Add(labelPaciente);
            groupBoxForm.Controls.Add(txtMetodo);
            groupBoxForm.Controls.Add(labelMetodo);
            groupBoxForm.Controls.Add(labelMonto);
            groupBoxForm.Controls.Add(txtMonto);
            groupBoxForm.Controls.Add(txtDescripcion);
            groupBoxForm.Controls.Add(labelDescripcion);
            groupBoxForm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxForm.Location = new Point(10, 52);
            groupBoxForm.Margin = new Padding(3, 2, 3, 2);
            groupBoxForm.Name = "groupBoxForm";
            groupBoxForm.Padding = new Padding(3, 2, 3, 2);
            groupBoxForm.Size = new Size(446, 232);
            groupBoxForm.TabIndex = 2;
            groupBoxForm.TabStop = false;
            groupBoxForm.Text = "Datos del Pago";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(319, 195);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 26);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "🗑 Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(255, 193, 7);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.Black;
            btnEditar.Location = new Point(214, 195);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(96, 26);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(10, 195);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(96, 26);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "\U0001f9f9 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(112, 195);
            btnRegistrar.Margin = new Padding(3, 2, 3, 2);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(96, 26);
            btnRegistrar.TabIndex = 3;
            btnRegistrar.Text = "✔ Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // txtIdPago
            // 
            txtIdPago.Font = new Font("Segoe UI", 9F);
            txtIdPago.Location = new Point(122, 19);
            txtIdPago.Margin = new Padding(3, 2, 3, 2);
            txtIdPago.Name = "txtIdPago";
            txtIdPago.ReadOnly = true;
            txtIdPago.Size = new Size(106, 23);
            txtIdPago.TabIndex = 4;
            txtIdPago.TabStop = false;
            // 
            // labelIdPago
            // 
            labelIdPago.Font = new Font("Segoe UI", 9F);
            labelIdPago.Location = new Point(10, 21);
            labelIdPago.Name = "labelIdPago";
            labelIdPago.Size = new Size(105, 17);
            labelIdPago.TabIndex = 5;
            labelIdPago.Text = "ID Pago:";
            // 
            // cmbPaciente
            // 
            cmbPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaciente.Font = new Font("Segoe UI", 9F);
            cmbPaciente.Location = new Point(122, 49);
            cmbPaciente.Margin = new Padding(3, 2, 3, 2);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(256, 23);
            cmbPaciente.TabIndex = 6;
            // 
            // labelPaciente
            // 
            labelPaciente.Font = new Font("Segoe UI", 9F);
            labelPaciente.Location = new Point(10, 51);
            labelPaciente.Name = "labelPaciente";
            labelPaciente.Size = new Size(105, 17);
            labelPaciente.TabIndex = 7;
            labelPaciente.Text = "Paciente:";
            // 
            // txtMetodo
            // 
            txtMetodo.Font = new Font("Segoe UI", 9F);
            txtMetodo.Location = new Point(122, 109);
            txtMetodo.Margin = new Padding(3, 2, 3, 2);
            txtMetodo.Name = "txtMetodo";
            txtMetodo.Size = new Size(256, 23);
            txtMetodo.TabIndex = 8;
            // 
            // labelMetodo
            // 
            labelMetodo.Font = new Font("Segoe UI", 9F);
            labelMetodo.Location = new Point(10, 111);
            labelMetodo.Name = "labelMetodo";
            labelMetodo.Size = new Size(105, 17);
            labelMetodo.TabIndex = 9;
            labelMetodo.Text = "Método de Pago:";
            // 
            // labelMonto
            // 
            labelMonto.Font = new Font("Segoe UI", 9F);
            labelMonto.Location = new Point(10, 81);
            labelMonto.Name = "labelMonto";
            labelMonto.Size = new Size(105, 17);
            labelMonto.TabIndex = 10;
            labelMonto.Text = "Monto (S/):";
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 9F);
            txtMonto.Location = new Point(122, 79);
            txtMonto.Margin = new Padding(3, 2, 3, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(132, 23);
            txtMonto.TabIndex = 11;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(122, 139);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(256, 46);
            txtDescripcion.TabIndex = 12;
            // 
            // labelDescripcion
            // 
            labelDescripcion.Font = new Font("Segoe UI", 9F);
            labelDescripcion.Location = new Point(10, 141);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(105, 17);
            labelDescripcion.TabIndex = 13;
            labelDescripcion.Text = "Descripción:";
            // 
            // groupBoxFiltro
            // 
            groupBoxFiltro.Controls.Add(cmbFiltroPaciente);
            groupBoxFiltro.Controls.Add(labelFiltro);
            groupBoxFiltro.Controls.Add(btnFiltrar);
            groupBoxFiltro.Controls.Add(btnMostrarTodos);
            groupBoxFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFiltro.Location = new Point(477, 52);
            groupBoxFiltro.Margin = new Padding(3, 2, 3, 2);
            groupBoxFiltro.Name = "groupBoxFiltro";
            groupBoxFiltro.Padding = new Padding(3, 2, 3, 2);
            groupBoxFiltro.Size = new Size(569, 60);
            groupBoxFiltro.TabIndex = 1;
            groupBoxFiltro.TabStop = false;
            groupBoxFiltro.Text = "Filtros";
            // 
            // cmbFiltroPaciente
            // 
            cmbFiltroPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroPaciente.Font = new Font("Segoe UI", 9F);
            cmbFiltroPaciente.Location = new Point(88, 22);
            cmbFiltroPaciente.Margin = new Padding(3, 2, 3, 2);
            cmbFiltroPaciente.Name = "cmbFiltroPaciente";
            cmbFiltroPaciente.Size = new Size(246, 23);
            cmbFiltroPaciente.TabIndex = 0;
            // 
            // labelFiltro
            // 
            labelFiltro.Font = new Font("Segoe UI", 9F);
            labelFiltro.Location = new Point(10, 25);
            labelFiltro.Name = "labelFiltro";
            labelFiltro.Size = new Size(70, 17);
            labelFiltro.TabIndex = 1;
            labelFiltro.Text = "Paciente:";
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(0, 123, 255);
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 9F);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(350, 21);
            btnFiltrar.Margin = new Padding(3, 2, 3, 2);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(88, 24);
            btnFiltrar.TabIndex = 2;
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
            btnMostrarTodos.Location = new Point(455, 21);
            btnMostrarTodos.Margin = new Padding(3, 2, 3, 2);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(96, 24);
            btnMostrarTodos.TabIndex = 3;
            btnMostrarTodos.Text = "📋 Mostrar Todos";
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Columns.AddRange(new DataGridViewColumn[] { colIdPago, colPaciente, colMonto, colMetodo, colDescripcion, colFecha, colIdPaciente });
            dgvPagos.Location = new Point(477, 116);
            dgvPagos.Margin = new Padding(3, 2, 3, 2);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(569, 375);
            dgvPagos.TabIndex = 0;
            dgvPagos.CellClick += dgvPagos_CellClick;
            // 
            // colIdPago
            // 
            colIdPago.DataPropertyName = "IdPago";
            colIdPago.HeaderText = "ID";
            colIdPago.MinimumWidth = 6;
            colIdPago.Name = "colIdPago";
            colIdPago.ReadOnly = true;
            // 
            // colPaciente
            // 
            colPaciente.DataPropertyName = "PacienteNombre";
            colPaciente.HeaderText = "Paciente";
            colPaciente.Name = "colPaciente";
            colPaciente.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.DataPropertyName = "Monto";
            dataGridViewCellStyle3.Format = "N2";
            colMonto.DefaultCellStyle = dataGridViewCellStyle3;
            colMonto.HeaderText = "Monto (S/)";
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            // 
            // colMetodo
            // 
            colMetodo.DataPropertyName = "MetodoPago";
            colMetodo.HeaderText = "Método";
            colMetodo.Name = "colMetodo";
            colMetodo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaPago";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy HH:mm";
            colFecha.DefaultCellStyle = dataGridViewCellStyle4;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colIdPaciente
            // 
            colIdPaciente.DataPropertyName = "IdPaciente";
            colIdPaciente.HeaderText = "IdPaciente";
            colIdPaciente.Name = "colIdPaciente";
            colIdPaciente.ReadOnly = true;
            colIdPaciente.Visible = false;
            // 
            // FrmPagos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1058, 510);
            Controls.Add(dgvPagos);
            Controls.Add(groupBoxFiltro);
            Controls.Add(groupBoxForm);
            Controls.Add(panelTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Pagos - Proyecto Dental";
            Load += FrmPagos_Load;
            groupBoxForm.ResumeLayout(false);
            groupBoxForm.PerformLayout();
            groupBoxFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colIdPago;
        private DataGridViewTextBoxColumn colPaciente;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colMetodo;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colIdPaciente;
    }
}