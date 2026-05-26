namespace CapaEntidades
{
    public class E_Movimiento
    {
        public int IdMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty; // Ingreso, Egreso
        public decimal Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }

    public class E_ReporteVentas
    {
        public string Periodo { get; set; } = string.Empty; // "2026-05" para mensual, "2026" para anual
        public int TotalTransacciones { get; set; }
        public decimal TotalVentas { get; set; }
    }
}