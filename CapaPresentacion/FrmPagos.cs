using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmPagos : Form
    {
        N_Finanzas objNegocio = new N_Finanzas();
        N_Pacientes objNegocioPaciente = new N_Pacientes();

        public FrmPagos()
        {
            InitializeComponent();
        }

        private async void FrmPagos_Load(object sender, EventArgs e)
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
                    Pacientes = objNegocioPaciente.ListarPacientes(),
                    Pagos = objNegocio.ListarPagos()
                });

                cmbPaciente.DataSource = datos.Pacientes;
                cmbPaciente.DisplayMember = "Nombres";
                cmbPaciente.ValueMember = "IdPaciente";

                cmbFiltroPaciente.DataSource = objNegocioPaciente.ListarPacientes();
                cmbFiltroPaciente.DisplayMember = "Nombres";
                cmbFiltroPaciente.ValueMember = "IdPaciente";
                cmbFiltroPaciente.SelectedIndex = -1;

                dgvPagos.AutoGenerateColumns = false;
                dgvPagos.DataSource = datos.Pagos;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void CargarLista()
        {
            dgvPagos.AutoGenerateColumns = false;
            dgvPagos.DataSource = await Task.Run(() => objNegocio.ListarPagos());
        }

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            txtMetodo.Clear();
            txtDescripcion.Clear();
            cmbPaciente.SelectedIndex = -1;
            txtIdPago.Clear();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaciente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMetodo.Text))
                {
                    MessageBox.Show("Ingrese un método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                E_Pago objPago = new E_Pago
                {
                    IdPaciente = Convert.ToInt32(cmbPaciente.SelectedValue),
                    Monto = monto,
                    MetodoPago = txtMetodo.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    FechaPago = DateTime.Now
                };

                objNegocio.GuardarPago(objPago);
                MessageBox.Show("Pago registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdPago.Text))
                {
                    MessageBox.Show("Seleccione un pago de la tabla para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbPaciente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto))
                {
                    MessageBox.Show("Ingrese un monto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMetodo.Text))
                {
                    MessageBox.Show("Ingrese un método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                E_Pago objPago = new E_Pago
                {
                    IdPago = Convert.ToInt32(txtIdPago.Text),
                    IdPaciente = Convert.ToInt32(cmbPaciente.SelectedValue),
                    Monto = monto,
                    MetodoPago = txtMetodo.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    FechaPago = DateTime.Now
                };

                // La edición usa el mismo método de registro (nuevo registro que reemplaza)
                objNegocio.GuardarPago(objPago);
                MessageBox.Show("Pago actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdPago.Text))
                {
                    MessageBox.Show("Seleccione un pago de la tabla para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show("¿Está seguro de eliminar este pago?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // La eliminación se hace mediante una actualización de estado (o directamente vía SQL)
                    // Por ahora usamos la capa de negocio - se necesita un método Delete en D_Finanzas
                    MessageBox.Show("Funcionalidad de eliminación: implementar Delete en capa de datos.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPagos.Rows[e.RowIndex];

                txtIdPago.Text = row.Cells["colIdPago"].Value?.ToString();
                txtMonto.Text = row.Cells["colMonto"].Value?.ToString();
                txtMetodo.Text = row.Cells["colMetodo"].Value?.ToString();
                txtDescripcion.Text = row.Cells["colDescripcion"].Value?.ToString();

                // Seleccionar paciente en el combo
                if (row.Cells["colIdPaciente"].Value != null)
                {
                    cmbPaciente.SelectedValue = Convert.ToInt32(row.Cells["colIdPaciente"].Value);
                }

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFiltroPaciente.SelectedValue != null)
                {
                    int idPaciente = Convert.ToInt32(cmbFiltroPaciente.SelectedValue);
                    dgvPagos.AutoGenerateColumns = false;
                    dgvPagos.DataSource = objNegocio.ListarPagosPorPaciente(idPaciente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cmbFiltroPaciente.SelectedIndex = -1;
            CargarLista();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void groupBoxFiltro_Enter(object sender, EventArgs e)
        {

        }
    }
}