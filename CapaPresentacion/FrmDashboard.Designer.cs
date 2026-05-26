namespace CapaPresentacion
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Panel panelBalance;
        private Label lblBalance;
        private Panel panelIngresos;
        private Panel panelEgresos;
        private Panel panelPagos;
        private Panel panelComprobantes;
        private Label lblIngresos;
        private Label lblEgresos;
        private Label lblTotalPagos;
        private Label lblComprobantes;
        private Button btnActualizar;
        private Label labelIngresosTitulo;
        private Label labelEgresosTitulo;
        private Label labelPagosTitulo;
        private Label labelComprobantesTitulo;
        private Label labelBalanceTitulo;

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
            labelBalanceTitulo = new Label();
            lblBalance = new Label();
            panelIngresos = new Panel();
            labelIngresosTitulo = new Label();
            lblIngresos = new Label();
            panelEgresos = new Panel();
            labelEgresosTitulo = new Label();
            lblEgresos = new Label();
            panelPagos = new Panel();
            labelPagosTitulo = new Label();
            lblTotalPagos = new Label();
            panelComprobantes = new Panel();
            labelComprobantesTitulo = new Label();
            lblComprobantes = new Label();
            btnActualizar = new Button();
            panelBalance.SuspendLayout();
            panelIngresos.SuspendLayout();
            panelEgresos.SuspendLayout();
            panelPagos.SuspendLayout();
            panelComprobantes.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(0, 102, 204);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(962, 45);
            panelTop.TabIndex = 6;
            // 
            // panelBalance
            // 
            panelBalance.BackColor = Color.FromArgb(40, 167, 69);
            panelBalance.Controls.Add(labelBalanceTitulo);
            panelBalance.Controls.Add(lblBalance);
            panelBalance.Location = new Point(18, 68);
            panelBalance.Margin = new Padding(3, 2, 3, 2);
            panelBalance.Name = "panelBalance";
            panelBalance.Size = new Size(928, 92);
            panelBalance.TabIndex = 5;
            // 
            // labelBalanceTitulo
            // 
            labelBalanceTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelBalanceTitulo.ForeColor = Color.FromArgb(200, 255, 200);
            labelBalanceTitulo.Location = new Point(26, 15);
            labelBalanceTitulo.Name = "labelBalanceTitulo";
            labelBalanceTitulo.Size = new Size(350, 19);
            labelBalanceTitulo.TabIndex = 0;
            labelBalanceTitulo.Text = "BALANCE GENERAL";
            // 
            // lblBalance
            // 
            lblBalance.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(26, 38);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(875, 54);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "S/ 0.00";
            // 
            // panelIngresos
            // 
            panelIngresos.BackColor = Color.White;
            panelIngresos.BorderStyle = BorderStyle.FixedSingle;
            panelIngresos.Controls.Add(labelIngresosTitulo);
            panelIngresos.Controls.Add(lblIngresos);
            panelIngresos.Location = new Point(18, 177);
            panelIngresos.Margin = new Padding(3, 2, 3, 2);
            panelIngresos.Name = "panelIngresos";
            panelIngresos.Size = new Size(219, 113);
            panelIngresos.TabIndex = 4;
            // 
            // labelIngresosTitulo
            // 
            labelIngresosTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelIngresosTitulo.ForeColor = Color.FromArgb(108, 117, 125);
            labelIngresosTitulo.Location = new Point(13, 11);
            labelIngresosTitulo.Name = "labelIngresosTitulo";
            labelIngresosTitulo.Size = new Size(192, 19);
            labelIngresosTitulo.TabIndex = 0;
            labelIngresosTitulo.Text = "📈 INGRESOS";
            labelIngresosTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIngresos
            // 
            lblIngresos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblIngresos.ForeColor = Color.FromArgb(40, 167, 69);
            lblIngresos.Location = new Point(13, 41);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(192, 42);
            lblIngresos.TabIndex = 1;
            lblIngresos.Text = "S/ 0.00";
            lblIngresos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelEgresos
            // 
            panelEgresos.BackColor = Color.White;
            panelEgresos.BorderStyle = BorderStyle.FixedSingle;
            panelEgresos.Controls.Add(labelEgresosTitulo);
            panelEgresos.Controls.Add(lblEgresos);
            panelEgresos.Location = new Point(256, 177);
            panelEgresos.Margin = new Padding(3, 2, 3, 2);
            panelEgresos.Name = "panelEgresos";
            panelEgresos.Size = new Size(219, 113);
            panelEgresos.TabIndex = 3;
            // 
            // labelEgresosTitulo
            // 
            labelEgresosTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelEgresosTitulo.ForeColor = Color.FromArgb(108, 117, 125);
            labelEgresosTitulo.Location = new Point(13, 11);
            labelEgresosTitulo.Name = "labelEgresosTitulo";
            labelEgresosTitulo.Size = new Size(192, 19);
            labelEgresosTitulo.TabIndex = 0;
            labelEgresosTitulo.Text = "📉 EGRESOS";
            labelEgresosTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEgresos
            // 
            lblEgresos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblEgresos.ForeColor = Color.FromArgb(220, 53, 69);
            lblEgresos.Location = new Point(13, 41);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.Size = new Size(192, 42);
            lblEgresos.TabIndex = 1;
            lblEgresos.Text = "S/ 0.00";
            lblEgresos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelPagos
            // 
            panelPagos.BackColor = Color.White;
            panelPagos.BorderStyle = BorderStyle.FixedSingle;
            panelPagos.Controls.Add(labelPagosTitulo);
            panelPagos.Controls.Add(lblTotalPagos);
            panelPagos.Location = new Point(490, 177);
            panelPagos.Margin = new Padding(3, 2, 3, 2);
            panelPagos.Name = "panelPagos";
            panelPagos.Size = new Size(219, 113);
            panelPagos.TabIndex = 2;
            // 
            // labelPagosTitulo
            // 
            labelPagosTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPagosTitulo.ForeColor = Color.FromArgb(108, 117, 125);
            labelPagosTitulo.Location = new Point(13, 11);
            labelPagosTitulo.Name = "labelPagosTitulo";
            labelPagosTitulo.Size = new Size(192, 19);
            labelPagosTitulo.TabIndex = 0;
            labelPagosTitulo.Text = "💳 PAGOS REGISTRADOS";
            labelPagosTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPagos
            // 
            lblTotalPagos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalPagos.ForeColor = Color.FromArgb(0, 123, 255);
            lblTotalPagos.Location = new Point(13, 41);
            lblTotalPagos.Name = "lblTotalPagos";
            lblTotalPagos.Size = new Size(192, 42);
            lblTotalPagos.TabIndex = 1;
            lblTotalPagos.Text = "S/ 0.00";
            lblTotalPagos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelComprobantes
            // 
            panelComprobantes.BackColor = Color.White;
            panelComprobantes.BorderStyle = BorderStyle.FixedSingle;
            panelComprobantes.Controls.Add(labelComprobantesTitulo);
            panelComprobantes.Controls.Add(lblComprobantes);
            panelComprobantes.Location = new Point(727, 177);
            panelComprobantes.Margin = new Padding(3, 2, 3, 2);
            panelComprobantes.Name = "panelComprobantes";
            panelComprobantes.Size = new Size(219, 113);
            panelComprobantes.TabIndex = 1;
            // 
            // labelComprobantesTitulo
            // 
            labelComprobantesTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelComprobantesTitulo.ForeColor = Color.FromArgb(108, 117, 125);
            labelComprobantesTitulo.Location = new Point(13, 11);
            labelComprobantesTitulo.Name = "labelComprobantesTitulo";
            labelComprobantesTitulo.Size = new Size(192, 19);
            labelComprobantesTitulo.TabIndex = 0;
            labelComprobantesTitulo.Text = "\U0001f9fe COMPROBANTES";
            labelComprobantesTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblComprobantes
            // 
            lblComprobantes.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblComprobantes.ForeColor = Color.FromArgb(111, 66, 193);
            lblComprobantes.Location = new Point(13, 41);
            lblComprobantes.Name = "lblComprobantes";
            lblComprobantes.Size = new Size(192, 42);
            lblComprobantes.TabIndex = 1;
            lblComprobantes.Text = "0";
            lblComprobantes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(0, 123, 255);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(18, 309);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(131, 30);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "🔄 Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(962, 360);
            Controls.Add(btnActualizar);
            Controls.Add(panelComprobantes);
            Controls.Add(panelPagos);
            Controls.Add(panelEgresos);
            Controls.Add(panelIngresos);
            Controls.Add(panelBalance);
            Controls.Add(panelTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Proyecto Dental";
            Load += FrmDashboard_Load;
            panelBalance.ResumeLayout(false);
            panelIngresos.ResumeLayout(false);
            panelEgresos.ResumeLayout(false);
            panelPagos.ResumeLayout(false);
            panelComprobantes.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}