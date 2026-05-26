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

                // Crear lista formateada para mostrar más info en el ComboBox
                var pagosFormateados = datos.Pagos.Select(p => new
                {
                    p.IdPago,
                    Display = $"{p.PacienteNombre ?? "Sin nombre"} | S/ {p.Monto:F2} | {p.FechaPago:dd/MM/yyyy} | {p.Descripcion ?? "Sin descripción"}"
                }).ToList();

                cmbPago.DataSource = pagosFormateados;
                cmbPago.DisplayMember = "Display";
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
            btnEnviarCorreo.Enabled = false;
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


                E_Comprobante comprobante = objNegocio.ObtenerComprobantePorId(idComprobante);


                E_Pago pago = objFinanzas.ObtenerPagoPorId(comprobante.IdPago ?? 0);


                N_Exportaciones export = new N_Exportaciones();
                string html = export.GenerarComprobanteHTML(comprobante, pago);


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

        private async void btnExportarPDF_Click(object sender, EventArgs e)
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

                E_Comprobante comprobante = objNegocio.ObtenerComprobantePorId(idComprobante);
                E_Pago pago = objFinanzas.ObtenerPagoPorId(comprobante.IdPago ?? 0);

                N_Exportaciones export = new N_Exportaciones();

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    FileName = $"{comprobante.TipoComprobante}_{comprobante.NumeroComprobante}.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    byte[] pdfBytes = await Task.Run(() =>
                    {
                        string html = export.GenerarComprobanteHTML(comprobante, pago);
                        return export.ConvertirHtmlAPdf(html);
                    });

                    await File.WriteAllBytesAsync(sfd.FileName, pdfBytes);

                    this.Cursor = Cursors.Default;

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
                    }

                    MessageBox.Show("PDF exportado con éxito.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEnviarCorreo_Click(object sender, EventArgs e)
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

                this.Cursor = Cursors.WaitCursor;

                // Obtener comprobante, pago y datos del paciente
                E_Comprobante comprobante = objNegocio.ObtenerComprobantePorId(idComprobante);
                E_Pago pago = objFinanzas.ObtenerPagoPorId(comprobante.IdPago ?? 0);
                E_Paciente? paciente = objPacientes.ObtenerPacientePorId(pago.IdPaciente);

                if (paciente == null || string.IsNullOrWhiteSpace(paciente.Correo))
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Este paciente no tiene un correo electrónico registrado.\n\n" +
                        "Agregue un correo en la ficha del paciente para poder enviar comprobantes.",
                        "Sin correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar PDF del comprobante
                N_Exportaciones export = new N_Exportaciones();
                string html = export.GenerarComprobanteHTML(comprobante, pago);
                byte[] pdfBytes = await Task.Run(() => export.ConvertirHtmlAPdf(html));

                // Generar HTML del correo
                string nombreCompleto = $"{paciente.Nombres} {paciente.Apellidos}";
                string htmlCorreo = N_Correos.GenerarHtmlComprobante(
                    nombrePaciente: nombreCompleto,
                    tipoComprobante: comprobante.TipoComprobante,
                    numeroComprobante: comprobante.NumeroComprobante,
                    monto: $"S/ {comprobante.Total:N2}",
                    fecha: comprobante.FechaEmision.ToString("dd/MM/yyyy HH:mm"),
                    mensajeAdicional: "Puede imprimir este comprobante o presentarlo digitalmente en nuestra clínica."
                );

                string nombreArchivo = $"{comprobante.TipoComprobante}_{comprobante.NumeroComprobante}.pdf";

                // Enviar correo
                N_Correos servicioCorreo = new N_Correos();
                N_Correos.RespuestaEnvio resultado = await servicioCorreo.EnviarComprobantePorCorreoAsync(
                    destinatarioEmail: paciente.Correo,
                    destinatarioNombre: nombreCompleto,
                    asunto: $"Su comprobante {comprobante.NumeroComprobante} - Clínica Dental Leon",
                    mensajeHtml: htmlCorreo,
                    pdfBytes: pdfBytes,
                    nombreArchivo: nombreArchivo
                );

                this.Cursor = Cursors.Default;

                if (resultado.Resultado == N_Correos.ResultadoEnvio.Exito)
                {
                    MessageBox.Show($"✅ {resultado.Mensaje}",
                        "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultado.Resultado == N_Correos.ResultadoEnvio.ErrorAutenticacion)
                {
                    MessageBox.Show($"⚠️ {resultado.Mensaje}",
                        "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var respuesta = MessageBox.Show($"❌ {resultado.Mensaje}",
                        "Error de envío", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (respuesta == DialogResult.Yes)
                    {
                        // Fallback: guardar PDF localmente
                        SaveFileDialog sfd = new SaveFileDialog
                        {
                            Filter = "PDF Files|*.pdf",
                            FileName = nombreArchivo
                        };
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            await File.WriteAllBytesAsync(sfd.FileName, pdfBytes);
                            MessageBox.Show("PDF guardado exitosamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al enviar correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnEnviarCorreo.Enabled = haySeleccion;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}