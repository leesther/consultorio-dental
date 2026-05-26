using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmMovimientos : Form
    {
        N_Finanzas objNegocio = new N_Finanzas();

        public FrmMovimientos()
        {
            InitializeComponent();
        }

        private async void FrmMovimientos_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
            LimpiarCampos();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var datos = await Task.Run(() => new
                {
                    Movimientos = objNegocio.ListarMovimientos(),
                    Balance = objNegocio.ObtenerBalance()
                });

                dgvMovimientos.AutoGenerateColumns = false;
                dgvMovimientos.DataSource = datos.Movimientos;

                lblBalance.Text = $"Balance: S/ {datos.Balance:N2}";
                lblBalance.ForeColor = datos.Balance >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                lblBalance.Text = "Error al calcular balance";
                MessageBox.Show("Error al cargar movimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void CargarLista()
        {
            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.DataSource = await Task.Run(() => objNegocio.ListarMovimientos());
        }

        private async void ActualizarBalance()
        {
            try
            {
                decimal balance = await Task.Run(() => objNegocio.ObtenerBalance());
                lblBalance.Text = $"Balance: S/ {balance:N2}";
                lblBalance.ForeColor = balance >= 0 ? Color.Green : Color.Red;
            }
            catch
            {
                lblBalance.Text = "Error al calcular balance";
            }
        }

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            txtDescripcion.Clear();
            cmbTipo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? tipoSeleccionado = cmbTipo.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(tipoSeleccionado))
                {
                    MessageBox.Show("Seleccione un tipo de movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                E_Movimiento objMov = new E_Movimiento
                {
                    TipoMovimiento = tipoSeleccionado,
                    Monto = monto,
                    Descripcion = txtDescripcion.Text.Trim(),
                    FechaMovimiento = dtpFecha.Value
                };

                objNegocio.RegistrarMovimiento(objMov);
                MessageBox.Show("Movimiento registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                ActualizarBalance();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFiltroTipo.SelectedIndex == -1)
                {
                    CargarLista();
                    return;
                }

                string? tipo = cmbFiltroTipo.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(tipo))
                {
                    CargarLista();
                    return;
                }
                dgvMovimientos.AutoGenerateColumns = false;
                dgvMovimientos.DataSource = objNegocio.ListarMovimientosPorTipo(tipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cmbFiltroTipo.SelectedIndex = -1;
            CargarLista();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}