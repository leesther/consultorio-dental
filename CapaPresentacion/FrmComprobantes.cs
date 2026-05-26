using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmComprobantes : Form
    {
        N_Comprobantes objNegocio = new N_Comprobantes();
        N_Finanzas objFinanzas = new N_Finanzas();
        N_Pacientes objPacientes = new N_Pacientes();

        public FrmComprobantes()
        {
            InitializeComponent();
        }

        private async void FrmComprobantes_Load(object sender, EventArgs e)
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
                    Pagos = objFinanzas.ListarPagos(),
                    Comprobantes = objNegocio.ListarComprobantes()
                });

                cmbPago.DataSource = datos.Pagos;
                cmbPago.DisplayMember = "Descripcion";
                cmbPago.ValueMember = "IdPago";

                dgvComprobantes.AutoGenerateColumns = false;
                dgvComprobantes.DataSource = datos.Comprobantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar comprobantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void CargarLista()
        {
            dgvComprobantes.AutoGenerateColumns = false;
            dgvComprobantes.DataSource = await Task.Run(() => objNegocio.ListarComprobantes());
        }

        private void LimpiarCampos()
        {
            cmbTipo.SelectedIndex = -1;
            txtRazonSocial.Clear();
            txtRUC.Clear();
            cmbPago.SelectedIndex = -1;
            btnVistaPrevia.Enabled = false;
            btnExportarPDF.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el tipo de comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    MessageBox.Show("Ingrese la Razón Social.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRUC.Text))
                {
                    MessageBox.Show("Ingrese el RUC.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbPago.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un pago asociado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? tipoSeleccionado = cmbTipo.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(tipoSeleccionado))
                {
                    MessageBox.Show("Seleccione el tipo de comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                E_Comprobante objComp = new E_Comprobante
                {
                    IdPago = Convert.ToInt32(cmbPago.SelectedValue),
                    TipoComprobante = tipoSeleccionado,
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    RUC = txtRUC.Text.Trim()
                };

                E_Comprobante comprobanteGenerado = objNegocio.GenerarComprobante(objComp);

                MessageBox.Show($"Comprobante {comprobanteGenerado.NumeroComprobante} generado con éxito.\nTotal: S/ {comprobanteGenerado.Total:N2} (IGV: S/ {comprobanteGenerado.IGV:N2})",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarLista();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComprobantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un comprobante de la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object? cellValue = dgvComprobantes.SelectedRows[0].Cells["colIdComprobante"].Value;
                if (cellValue == null)
                {
                    MessageBox.Show("No se pudo obtener el ID del comprobante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idComprobante = Convert.ToInt32(cellValue);

                // Usar ObtenerComprobantePorId en lugar de cargar toda la lista
                E_Comprobante comprobante = objNegocio.ObtenerComprobantePorId(idComprobante);

                // Usar ObtenerPagoPorId en lugar de cargar toda la lista de pagos
                E_Pago pago = objFinanzas.ObtenerPagoPorId(comprobante.IdPago ?? 0);

                // Generar HTML
                N_Exportaciones export = new N_Exportaciones();
                string html = export.GenerarComprobanteHTML(comprobante, pago);

                // Guardar temporal y abrir en navegador
                string tempFile = Path.Combine(Path.GetTempPath(), $"comprobante_{comprobante.NumeroComprobante}.html");
                File.WriteAllText(tempFile, html, System.Text.Encoding.UTF8);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComprobantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un comprobante de la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object? cellValue = dgvComprobantes.SelectedRows[0].Cells["colIdComprobante"].Value;
                if (cellValue == null)
                {
                    MessageBox.Show("No se pudo obtener el ID del comprobante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idComprobante = Convert.ToInt32(cellValue);

                // Usar ObtenerComprobantePorId en lugar de cargar toda la lista
                E_Comprobante comprobante = objNegocio.ObtenerComprobantePorId(idComprobante);

                // Usar ObtenerPagoPorId en lugar de cargar toda la lista de pagos
                E_Pago pago = objFinanzas.ObtenerPagoPorId(comprobante.IdPago ?? 0);

                N_Exportaciones export = new N_Exportaciones();
                string html = export.GenerarComprobanteHTML(comprobante, pago);

                // Abrir diálogo de guardado
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "HTML Files|*.html|PDF Files|*.pdf",
                    FileName = $"{comprobante.TipoComprobante}_{comprobante.NumeroComprobante}.html"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Guardar el archivo como HTML (el navegador permite imprimir a PDF con Ctrl+P)
                    File.WriteAllText(sfd.FileName, html, System.Text.Encoding.UTF8);

                    // Abrir el archivo en el navegador para que el usuario pueda imprimir a PDF
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch
                    {
                        // Si no se puede abrir, al menos ya está guardado
                    }

                    MessageBox.Show("Archivo exportado con éxito. Use Ctrl+P en el navegador para guardar como PDF.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComprobantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un comprobante de la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object? cellValue = dgvComprobantes.SelectedRows[0].Cells["colIdComprobante"].Value;
                if (cellValue == null) return;

                int idComprobante = Convert.ToInt32(cellValue);

                var resultado = MessageBox.Show("¿Está seguro de anular este comprobante?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    objNegocio.AnularComprobante(idComprobante);
                    MessageBox.Show("Comprobante anulado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComprobantes_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = dgvComprobantes.SelectedRows.Count > 0;
            btnVistaPrevia.Enabled = haySeleccion;
            btnExportarPDF.Enabled = haySeleccion;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}