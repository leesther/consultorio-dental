using CapaEntidades;
using System.Text;

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

        /// <summary>
        /// Exporta datos genéricos a Excel usando formato CSV (compatible con Excel).
        /// Guarda como .csv que Excel puede abrir nativamente.
        /// </summary>
        public string ExportarExcelDesdeCSV(string csvPath)
        {
            // Simplemente retorna el path - CSV es compatible con Excel
            return csvPath;
        }
    }
}
