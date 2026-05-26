using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace CapaNegocio
{
    /// <summary>
    /// Servicio de envío de correos usando Resend Email API.
    /// Usa una API Key maestra configurada en código para funcionar "out-of-the-box".
    /// </summary>
    public class N_Correos
    {
        // ═══════════════════════════════════════════════════════════════
        // CONFIGURACIÓN MAESTRA — Reemplaza con tu API Key de Resend
        // https://resend.com/api-keys
        // ═══════════════════════════════════════════════════════════════
        private const string RESEND_API_KEY = "re_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        private const string RESEND_API_URL = "https://api.resend.com/email";
        private const string REMITENTE_NOMBRE = "Clínica Dental Leon";
        private const string REMITENTE_EMAIL = "comprobantes@tudominio.com"; // Cambia por tu dominio verificado en Resend
        private const int MAX_REINTENTOS = 2;

        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        /// <summary>
        /// Tipos de resultado del envío.
        /// </summary>
        public enum ResultadoEnvio
        {
            Exito,
            ErrorAutenticacion,
            ErrorRed,
            ErrorDesconocido
        }

        /// <summary>
        /// Resultado del envío con mensaje descriptivo.
        /// </summary>
        public class RespuestaEnvio
        {
            public ResultadoEnvio Resultado { get; set; }
            public string Mensaje { get; set; } = string.Empty;
            public string? IdMensaje { get; set; }
        }

        /// <summary>
        /// Envía un PDF de comprobante por correo electrónico.
        /// </summary>
        /// <param name="destinatarioEmail">Email del paciente.</param>
        /// <param name="destinatarioNombre">Nombre del paciente.</param>
        /// <param name="asunto">Asunto del correo.</param>
        /// <param name="mensajeHtml">Cuerpo HTML del correo.</param>
        /// <param name="pdfBytes">Bytes del PDF adjunto.</param>
        /// <param name="nombreArchivo">Nombre del archivo PDF adjunto.</param>
        public async Task<RespuestaEnvio> EnviarComprobantePorCorreoAsync(
            string destinatarioEmail,
            string destinatarioNombre,
            string asunto,
            string mensajeHtml,
            byte[] pdfBytes,
            string nombreArchivo)
        {
            return await EnviarConReintentosAsync(
                destinatarioEmail, destinatarioNombre, asunto, mensajeHtml, pdfBytes, nombreArchivo, MAX_REINTENTOS);
        }

        /// <summary>
        /// Genera el HTML del correo para un comprobante.
        /// </summary>
        public static string GenerarHtmlComprobante(
            string nombrePaciente,
            string tipoComprobante,
            string numeroComprobante,
            string monto,
            string fecha,
            string? mensajeAdicional = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset=\"utf-8\">");
            sb.AppendLine("<style>");
            sb.AppendLine("body{font-family:'Segoe UI',Arial,sans-serif;margin:0;padding:0;background:#f4f6f9;color:#2d3436}");
            sb.AppendLine(".container{max-width:560px;margin:30px auto;background:#fff;border-radius:10px;overflow:hidden;box-shadow:0 2px 12px rgba(0,0,0,0.08)}");
            sb.AppendLine(".header{background:linear-gradient(135deg,#0a84ff,#0066d4);padding:30px 20px;text-align:center}");
            sb.AppendLine(".header h1{color:#fff;margin:0;font-size:22px;letter-spacing:0.5px}");
            sb.AppendLine(".header p{color:rgba(255,255,255,0.85);margin:8px 0 0;font-size:14px}");
            sb.AppendLine(".body{padding:30px 25px}");
            sb.AppendLine(".body p{margin:0 0 12px;font-size:14px;line-height:1.6}");
            sb.AppendLine(".datos{margin:20px 0;border:1px solid #e9ecef;border-radius:8px;overflow:hidden}");
            sb.AppendLine(".datos .row{display:flex;border-bottom:1px solid #f1f3f5}");
            sb.AppendLine(".datos .row:last-child{border-bottom:none}");
            sb.AppendLine(".datos .label{width:140px;padding:12px 15px;background:#f8f9fa;font-weight:600;font-size:13px;color:#495057}");
            sb.AppendLine(".datos .value{padding:12px 15px;font-size:13px;color:#212529;flex:1}");
            sb.AppendLine(".footer{margin-top:25px;padding-top:20px;border-top:1px solid #e9ecef;font-size:12px;color:#868e96;text-align:center;line-height:1.6}");
            sb.AppendLine("</style></head><body><div class=\"container\">");

            // Header
            sb.AppendLine("<div class=\"header\">");
            sb.AppendLine($"<h1>🦷 {System.Net.WebUtility.HtmlEncode(REMITENTE_NOMBRE)}</h1>");
            sb.AppendLine("<p>Comprobante Electrónico</p>");
            sb.AppendLine("</div>");

            // Body
            sb.AppendLine("<div class=\"body\">");
            sb.AppendLine($"<p>Estimado(a) <strong>{System.Net.WebUtility.HtmlEncode(nombrePaciente)}</strong>,</p>");
            sb.AppendLine("<p>Adjunto encontrará su comprobante electrónico emitido por nuestra clínica.</p>");

            // Datos
            sb.AppendLine("<div class=\"datos\">");
            sb.Append("<div class=\"row\"><div class=\"label\">Tipo</div><div class=\"value\">");
            sb.Append(System.Net.WebUtility.HtmlEncode(tipoComprobante));
            sb.AppendLine("</div></div>");

            sb.Append("<div class=\"row\"><div class=\"label\">N° Comprobante</div><div class=\"value\">");
            sb.Append(System.Net.WebUtility.HtmlEncode(numeroComprobante));
            sb.AppendLine("</div></div>");

            sb.Append("<div class=\"row\"><div class=\"label\">Monto</div><div class=\"value\">");
            sb.Append(System.Net.WebUtility.HtmlEncode(monto));
            sb.AppendLine("</div></div>");

            sb.Append("<div class=\"row\"><div class=\"label\">Fecha</div><div class=\"value\">");
            sb.Append(System.Net.WebUtility.HtmlEncode(fecha));
            sb.AppendLine("</div></div>");
            sb.AppendLine("</div>");

            if (!string.IsNullOrWhiteSpace(mensajeAdicional))
            {
                sb.Append($"<p>{System.Net.WebUtility.HtmlEncode(mensajeAdicional)}</p>");
            }

            sb.AppendLine("<p>Gracias por confiar en nosotros.</p>");

            // Footer
            sb.AppendLine("<div class=\"footer\">");
            sb.AppendLine("<p>Este es un mensaje automático. Por favor no responda a este correo.</p>");
            sb.AppendLine($"<p>&copy; {DateTime.Now.Year} Clínica Dental Leon — Todos los derechos reservados.</p>");
            sb.AppendLine("</div>");

            sb.AppendLine("</div></div></body></html>");
            return sb.ToString();
        }

        private async Task<RespuestaEnvio> EnviarConReintentosAsync(
            string destinatarioEmail,
            string destinatarioNombre,
            string asunto,
            string mensajeHtml,
            byte[] pdfBytes,
            string nombreArchivo,
            int reintentosRestantes)
        {
            string? ultimoError = null;

            for (int intento = 0; intento <= reintentosRestantes; intento++)
            {
                try
                {
                    if (intento > 0)
                        await Task.Delay(1000 * intento); // espera progresiva

                    var request = new HttpRequestMessage(HttpMethod.Post, RESEND_API_URL);
                    request.Headers.Add("Authorization", $"Bearer {RESEND_API_KEY}");

                    var payload = new
                    {
                        from = $"{REMITENTE_NOMBRE} <{REMITENTE_EMAIL}>",
                        to = new[] { $"{destinatarioNombre} <{destinatarioEmail}>" },
                        subject = asunto,
                        html = mensajeHtml,
                        attachments = new[]
                        {
                            new
                            {
                                filename = nombreArchivo,
                                content = Convert.ToBase64String(pdfBytes),
                                content_type = "application/pdf"
                            }
                        }
                    };

                    string json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    });

                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        using var doc = JsonDocument.Parse(responseBody);
                        string? id = doc.RootElement.TryGetProperty("id", out var idProp)
                            ? idProp.GetString()
                            : null;

                        return new RespuestaEnvio
                        {
                            Resultado = ResultadoEnvio.Exito,
                            Mensaje = "El comprobante fue enviado exitosamente al correo del paciente.",
                            IdMensaje = id
                        };
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                        response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        return new RespuestaEnvio
                        {
                            Resultado = ResultadoEnvio.ErrorAutenticacion,
                            Mensaje = "No se pudo autenticar con el servicio de correo. Contacte al administrador del sistema."
                        };
                    }

                    // Error de la API (límite de tasa, validación, etc.)
                    ultimoError = $"API error {response.StatusCode}: {responseBody}";
                }
                catch (TaskCanceledException)
                {
                    ultimoError = "Timeout de conexión.";
                }
                catch (HttpRequestException ex)
                {
                    ultimoError = ex.Message;
                }
            }

            return new RespuestaEnvio
            {
                Resultado = ResultadoEnvio.ErrorDesconocido,
                Mensaje = "No se pudo enviar el correo en este momento. ¿Desea guardar el comprobante en PDF para entregarlo manualmente?"
            };
        }
    }
}