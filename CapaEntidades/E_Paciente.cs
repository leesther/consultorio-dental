namespace CapaEntidades
{
    public class E_Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string? DNI { get; set; }
        public string? CarnetExtranjeria { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Genero { get; set; }
        public string? Alergias { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;
    }
}