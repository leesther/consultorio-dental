namespace CapaEntidades
{
    public class E_Pago
    {
        public int IdPago { get; set; }
        public int IdPaciente { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;

        // Datos de navegación (para consultas con JOIN)
        public string? PacienteNombre { get; set; }
    }
}