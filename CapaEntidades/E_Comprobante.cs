namespace CapaEntidades
{
    public class E_Comprobante
    {
        
        public int IdComprobante { get; set; }
        public int? IdPago { get; set; }
        public string TipoComprobante { get; set; } = string.Empty;
        public string? Serie { get; set; }
        public string Numero { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }
        public string? XmlSunat { get; set; }
        public string? PdfComprobante { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;

        
        public string RazonSocial { get; set; } = "Clínica Dental S.A.C.";
        public string RUC { get; set; } = "20123456789";
        public string Estado { get; set; } = "Emitido";

        
        public string NumeroComprobante
        {
            get => $"{Serie}-{Numero}";
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains('-'))
                {
                    var partes = value.Split('-', 2);
                    Serie = partes[0];
                    Numero = partes[1];
                }
                else
                {
                    Numero = value ?? string.Empty;
                }
            }
        }
    }
}