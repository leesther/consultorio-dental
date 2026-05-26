using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Pacientes
    {
        private readonly D_Pacientes _datos = new D_Pacientes();

        public List<E_Paciente> ListarPacientes() => _datos.ListarPacientes();

        public int RegistrarPaciente(E_Paciente obj)
        {
            ValidarPaciente(obj);
            return _datos.RegistrarPaciente(obj);
        }

        public void ActualizarPaciente(E_Paciente obj)
        {
            ValidarPaciente(obj, 1);
            _datos.ActualizarPaciente(obj);
        }

        public E_Paciente? ObtenerPacientePorId(int idPaciente) => _datos.ObtenerPacientePorId(idPaciente);

        public void EliminarPaciente(int idPaciente) => _datos.EliminarPaciente(idPaciente);

        private void ValidarPaciente(E_Paciente obj, int opcion = 0)
        {
            if (string.IsNullOrWhiteSpace(obj.Nombres))
                throw new ArgumentException("El nombre del paciente es obligatorio.");
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
                throw new ArgumentException("Los apellidos del paciente son obligatorios.");
            if (string.IsNullOrWhiteSpace(obj.DNI) && string.IsNullOrWhiteSpace(obj.CarnetExtranjeria))
                throw new ArgumentException("Debe proporcionar al menos un documento de identidad (DNI o Carnet de Extranjería).");
        }
    }
}