using CapaEntidades;
using System.Text;
using ClosedXML.Excel;
using DinkToPdf;

namespace CapaNegocio
{
    public class N_Exportaciones
    {
        /// <summary>
        /// Exporta una lista de pagos a un archivo CSV.
        /// </summary>
        public string ExportarPagosCSV(List<E_Pago> pagos, string rutaArchivo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID Pago,Paciente,Monto,Método de Pago,Descripción,Fecha");

                foreach (var pago in pagos)
                {
                    sb.AppendLine($"{pago.IdPago},{EscapeCsv(pago.PacienteNombre)},{pago.Monto:F2},{EscapeCsv(pago.MetodoPago)},{EscapeCsv(pago.Descripcion)},{pago.FechaPago:yyyy-MM-dd HH:mm:ss}");
                }

                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar a CSV: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Exporta una lista de pagos a un archivo Excel nativo (.xlsx).
        /// </summary>
        public string ExportarPagosExcel(List<E_Pago> pagos, string rutaArchivo)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Pagos");

                // Encabezados
                ws.Cell(1, 1).Value = "ID Pago";
                ws.Cell(1, 2).Value = "Paciente";
                ws.Cell(1, 3).Value = "Monto";
                ws.Cell(1, 4).Value = "Método de Pago";
                ws.Cell(1, 5).Value = "Descripción";
                ws.Cell(1, 6).Value = "Fecha";

                // Estilo de encabezados
                var headerRange = ws.Range(1, 1, 1, 6);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(0x333333);
                headerRange.Style.Font.FontColor = XLColor.White;

                // Datos
                for (int i = 0; i < pagos.Count; i++)
                {
                    var pago = pagos[i];
                    int row = i + 2;
                    ws.Cell(row, 1).Value = pago.IdPago;
                    ws.Cell(row, 2).Value = pago.PacienteNombre ?? "";
                    ws.Cell(row, 3).Value = pago.Monto;
                    ws.Cell(row, 4).Value = pago.MetodoPago ?? "";
                    ws.Cell(row, 5).Value = pago.Descripcion ?? "";
                    ws.Cell(row, 6).Value = pago.FechaPago.ToString("yyyy-MM-dd HH:mm:ss");
                }

                // Auto-ajustar columnas
                ws.Columns().AdjustToContents();

                workbook.SaveAs(rutaArchivo);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar a Excel: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Exporta reporte de ventas a CSV.
        /// </summary>
        public string ExportarVentasCSV(List<E_ReporteVentas> ventas, string rutaArchivo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Periodo,Total Transacciones,Total Ventas");

                foreach (var v in ventas)
                {
                    sb.AppendLine($"{v.Periodo},{v.TotalTransacciones},{v.TotalVentas:F2}");
                }

                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar ventas a CSV: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Exporta reporte de ventas a Excel nativo (.xlsx).
        /// </summary>
        public string ExportarVentasExcel(List<E_ReporteVentas> ventas, string rutaArchivo, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Ventas");

                // Encabezados
                ws.Cell(1, 1).Value = "Período";
                ws.Cell(1, 2).Value = "Total Transacciones";
                ws.Cell(1, 3).Value = "Total Ventas";

                var headerRange = ws.Range(1, 1, 1, 3);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(0x333333);
                headerRange.Style.Font.FontColor = XLColor.White;

                for (int i = 0; i < ventas.Count; i++)
                {
                    var v = ventas[i];
                    int row = i + 2;
                    ws.Cell(row, 1).Value = v.Periodo;
                    ws.Cell(row, 2).Value = v.TotalTransacciones;
                    ws.Cell(row, 3).Value = v.TotalVentas;
                }

                ws.Columns().AdjustToContents();
                ws.Range(2, 3, ventas.Count + 1, 3).Style.NumberFormat.Format = "S/ #,##0.00";

                workbook.SaveAs(rutaArchivo);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar ventas a Excel: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Exporta comprobantes a CSV.
        /// </summary>
        public string ExportarComprobantesCSV(List<E_Comprobante> comprobantes, string rutaArchivo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID,Tipo,Número,Fecha,Razón Social,RUC,Subtotal,IGV,Total,Estado");

                foreach (var c in comprobantes)
                {
                    sb.AppendLine($"{c.IdComprobante},{EscapeCsv(c.TipoComprobante)},{EscapeCsv(c.NumeroComprobante)},{c.FechaEmision:yyyy-MM-dd},{EscapeCsv(c.RazonSocial)},{EscapeCsv(c.RUC)},{c.Subtotal:F2},{c.IGV:F2},{c.Total:F2},{EscapeCsv(c.Estado)}");
                }

                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar comprobantes a CSV: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Exporta comprobantes a Excel nativo (.xlsx).
        /// </summary>
        public string ExportarComprobantesExcel(List<E_Comprobante> comprobantes, string rutaArchivo)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Comprobantes");

                ws.Cell(1, 1).Value = "ID";
                ws.Cell(1, 2).Value = "Tipo";
                ws.Cell(1, 3).Value = "Número";
                ws.Cell(1, 4).Value = "Fecha";
                ws.Cell(1, 5).Value = "Razón Social";
                ws.Cell(1, 6).Value = "RUC";
                ws.Cell(1, 7).Value = "Subtotal";
                ws.Cell(1, 8).Value = "IGV";
                ws.Cell(1, 9).Value = "Total";
                ws.Cell(1, 10).Value = "Estado";

                var headerRange = ws.Range(1, 1, 1, 10);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(0x333333);
                headerRange.Style.Font.FontColor = XLColor.White;

                for (int i = 0; i < comprobantes.Count; i++)
                {
                    var c = comprobantes[i];
                    int row = i + 2;
                    ws.Cell(row, 1).Value = c.IdComprobante;
                    ws.Cell(row, 2).Value = c.TipoComprobante ?? "";
                    ws.Cell(row, 3).Value = c.NumeroComprobante ?? "";
                    ws.Cell(row, 4).Value = c.FechaEmision.ToString("yyyy-MM-dd");
                    ws.Cell(row, 5).Value = c.RazonSocial ?? "";
                    ws.Cell(row, 6).Value = c.RUC ?? "";
                    ws.Cell(row, 7).Value = c.Subtotal;
                    ws.Cell(row, 8).Value = c.IGV;
                    ws.Cell(row, 9).Value = c.Total;
                    ws.Cell(row, 10).Value = c.Estado ?? "";
                }

                ws.Columns().AdjustToContents();
                ws.Range(2, 7, comprobantes.Count + 1, 9).Style.NumberFormat.Format = "S/ #,##0.00";

                workbook.SaveAs(rutaArchivo);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar comprobantes a Excel: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Convierte contenido HTML a PDF usando DinkToPdf (wkhtmltopdf).
        /// </summary>
        public byte[] ConvertirHtmlAPdf(string html)
        {
            try
            {
                var converter = new SynchronizedConverter(new PdfTools());
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings =
                    {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
                    },
                    Objects =
                    {
                        new ObjectSettings
                        {
                            HtmlContent = html,
                            WebSettings = { DefaultEncoding = "utf-8" }
                        }
                    }
                };

                return converter.Convert(doc);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir HTML a PDF: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Genera un comprobante en formato HTML para posterior conversión a PDF.
        /// </summary>
        public string GenerarComprobanteHTML(E_Comprobante comprobante, E_Pago pago)
        {
            string html = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <title>{comprobante.TipoComprobante} - {comprobante.NumeroComprobante}</title>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 40px; }}
        .header {{ text-align: center; border-bottom: 2px solid #333; padding-bottom: 15px; }}
        .clinic-name {{ font-size: 22px; font-weight: bold; }}
        .info {{ margin: 20px 0; }}
        .info table {{ width: 100%; }}
        .info td {{ padding: 5px; }}
        .items {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
        .items th {{ background: #333; color: white; padding: 8px; }}
        .items td {{ border: 1px solid #ccc; padding: 8px; }}
        .total {{ text-align: right; font-size: 18px; font-weight: bold; margin-top: 20px; }}
        .footer {{ margin-top: 50px; text-align: center; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='clinic-name'>Clínica Dental</div>
        <div>RUC: {EscapeHtml(comprobante.RUC)}</div>
        <div>{EscapeHtml(comprobante.RazonSocial)}</div>
    </div>
    <div class='info'>
        <table>
            <tr>
                <td><strong>{comprobante.TipoComprobante}:</strong> {EscapeHtml(comprobante.NumeroComprobante)}</td>
                <td><strong>Fecha:</strong> {comprobante.FechaEmision:dd/MM/yyyy}</td>
            </tr>
            <tr>
                                <td><strong>Paciente:</strong> {EscapeHtml(pago.PacienteNombre)}</td>
                <td><strong>Método de pago:</strong> {EscapeHtml(pago.MetodoPago)}</td>
            </tr>
        </table>
    </div>
    <table class='items'>
        <thead>
            <tr>
                <th>Descripción</th>
                <th>Cantidad</th>
                <th>Precio Unitario</th>
                <th>Subtotal</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>{EscapeHtml(pago.Descripcion)}</td>
                <td>1</td>
                <td>S/ {comprobante.Subtotal:F2}</td>
                <td>S/ {comprobante.Subtotal:F2}</td>
            </tr>
        </tbody>
    </table>
    <table class='items'>
        <tr>
            <td><strong>Subtotal:</strong></td>
            <td style='text-align:right'>S/ {comprobante.Subtotal:F2}</td>
        </tr>
        <tr>
            <td><strong>IGV (18%):</strong></td>
            <td style='text-align:right'>S/ {comprobante.IGV:F2}</td>
        </tr>
        <tr>
            <td><strong>TOTAL:</strong></td>
            <td style='text-align:right'><strong>S/ {comprobante.Total:F2}</strong></td>
        </tr>
    </table>
    <div class='footer'>
        <p>Comprobante generado electrónicamente</p>
        <p>Estado: {EscapeHtml(comprobante.Estado)}</p>
    </div>
</body>
</html>";

            return html;
        }

        /// <summary>
        /// Genera reporte de ventas en formato HTML.
        /// </summary>
        public string GenerarReporteVentasHTML(List<E_ReporteVentas> ventas, string titulo, DateTime fechaInicio, DateTime fechaFin)
        {
            StringBuilder filas = new StringBuilder();
            decimal totalGeneral = 0;
            int totalTransacciones = 0;

            foreach (var v in ventas)
            {
                filas.AppendLine($@"
                <tr>
                    <td>{v.Periodo}</td>
                    <td style='text-align:center'>{v.TotalTransacciones}</td>
                    <td style='text-align:right'>S/ {v.TotalVentas:F2}</td>
                </tr>");
                totalGeneral += v.TotalVentas;
                totalTransacciones += v.TotalTransacciones;
            }

            string html = $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <title>Reporte de Ventas</title>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 40px; }}
        .header {{ text-align: center; border-bottom: 2px solid #333; padding-bottom: 15px; }}
        .clinic-name {{ font-size: 22px; font-weight: bold; }}
        .info {{ margin: 20px 0; }}
        table {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
        th {{ background: #333; color: white; padding: 8px; }}
        td {{ border: 1px solid #ccc; padding: 8px; }}
        .total {{ text-align: right; font-size: 16px; margin-top: 20px; }}
        .footer {{ margin-top: 50px; text-align: center; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='clinic-name'>Clínica Dental - Reporte de Ventas</div>
        <div>{titulo}</div>
    </div>
    <div class='info'>
        <p><strong>Período:</strong> {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}</p>
        <p><strong>Generado:</strong> {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
    </div>
    <table>
        <thead>
            <tr>
                <th>Período</th>
                <th>Transacciones</th>
                <th>Total Ventas</th>
            </tr>
        </thead>
        <tbody>
            {filas.ToString()}
        </tbody>
    </table>
    <div class='total'>
        <p>Total de transacciones: {totalTransacciones}</p>
        <p>Total general: S/ {totalGeneral:F2}</p>
    </div>
    <div class='footer'>
        <p>Reporte generado automáticamente por el Sistema Integral de Gestión Odontológica</p>
    </div>
</body>
</html>";

            return html;
        }

        private static string EscapeCsv(string? input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Contains(",") || input.Contains("\"") || input.Contains("\n"))
                return "\"" + input.Replace("\"", "\"\"") + "\"";
            return input;
        }

        private static string EscapeHtml(string? input)
        {
            return System.Net.WebUtility.HtmlEncode(input ?? string.Empty);
        }

    }
}
