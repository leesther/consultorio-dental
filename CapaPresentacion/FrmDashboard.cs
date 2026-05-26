using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmDashboard : Form
    {
        N_Finanzas objFinanzas = new N_Finanzas();
        N_Comprobantes objComprobantes = new N_Comprobantes();

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private async void FrmDashboard_Load(object sender, EventArgs e)
        {
            await CargarDashboardAsync();
        }

        private async Task CargarDashboardAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var datos = await Task.Run(() =>
                {
                    decimal balance = objFinanzas.ObtenerBalance();
                    decimal totalIngresos = objFinanzas.ObtenerTotalPorMovimiento("Ingreso");
                    decimal totalEgresos = objFinanzas.ObtenerTotalPorMovimiento("Egreso");
                    decimal totalPagos = objFinanzas.ObtenerTotalPagos();
                    int totalComprobantes = objComprobantes.ListarComprobantes().Count;
                    return new { balance, totalIngresos, totalEgresos, totalPagos, totalComprobantes };
                });

                lblBalance.Text = $"S/ {datos.balance:N2}";
                lblBalance.ForeColor = datos.balance >= 0 ? Color.Green : Color.Red;

                lblIngresos.Text = $"S/ {datos.totalIngresos:N2}";
                lblEgresos.Text = $"S/ {datos.totalEgresos:N2}";
                lblTotalPagos.Text = $"S/ {datos.totalPagos:N2}";
                lblComprobantes.Text = datos.totalComprobantes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await CargarDashboardAsync();
        }
    }
}