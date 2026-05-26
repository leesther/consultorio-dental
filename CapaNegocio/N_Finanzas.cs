using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Finanzas
    {
        private readonly D_Finanzas _datos = new D_Finanzas();

        public int GuardarPago(E_Pago obj)
        {
            ValidarPago(obj);
            return _datos.RegistrarPago(obj);
        }

        public List<E_Pago> ListarPagos() => _datos.ListarPagos();

        public List<E_Pago> ListarPagosPorPaciente(int idPaciente) => _datos.ListarPagosPorPaciente(idPaciente);

        public E_Pago? ObtenerPagoPorId(int idPago) => _datos.ObtenerPagoPorId(idPago);

        public int RegistrarMovimiento(E_Movimiento obj)
        {
            ValidarMovimiento(obj);
            return _datos.RegistrarMovimiento(obj);
        }

        public List<E_Movimiento> ListarMovimientos() => _datos.ListarMovimientos();

        public List<E_Movimiento> ListarMovimientosPorTipo(string tipoMovimiento) => _datos.ListarMovimientosPorTipo(tipoMovimiento);

        public void EliminarPago(int idPago) => _datos.EliminarPago(idPago);

        public decimal ObtenerTotalPorMovimiento(string tipoMovimiento) => _datos.ObtenerTotalPorMovimiento(tipoMovimiento);

        public decimal ObtenerTotalPagos() => _datos.ObtenerTotalPagos();

        public decimal ObtenerBalance() => _datos.ObtenerBalance();

        public List<E_ReporteVentas> ObtenerReporteVentas(string agrupacion, DateTime fechaInicio, DateTime fechaFin)
            => _datos.ObtenerReporteVentas(agrupacion, fechaInicio, fechaFin);

        private void ValidarPago(E_Pago obj)
        {
            if (obj.IdPaciente == 0)
                throw new ArgumentException("No se ha especificado el paciente.");
            if (obj.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(obj.MetodoPago))
                throw new ArgumentException("Debe seleccionar un método de pago.");
        }

        private void ValidarMovimiento(E_Movimiento obj)
        {
            if (string.IsNullOrWhiteSpace(obj.TipoMovimiento))
                throw new ArgumentException("El tipo de movimiento es obligatorio.");
            if (obj.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a 0.");
        }
    }
}