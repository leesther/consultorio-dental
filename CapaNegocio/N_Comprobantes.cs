using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Comprobantes
    {
        private readonly D_Comprobantes _datos = new D_Comprobantes();

        public E_Comprobante GenerarComprobante(E_Comprobante obj)
        {
            ValidarComprobante(obj);
            int id = _datos.RegistrarComprobante(obj);
            return _datos.ObtenerComprobantePorId(id)!;
        }

        public List<E_Comprobante> ListarComprobantes() => _datos.ListarComprobantes();

        public E_Comprobante? ObtenerComprobantePorId(int idComprobante) => _datos.ObtenerComprobantePorId(idComprobante);

        public string GenerarNumeroComprobante(string tipoComprobante) => _datos.GenerarNumeroComprobante(tipoComprobante);

        public void AnularComprobante(int idComprobante) => _datos.AnularComprobante(idComprobante);

        public E_Comprobante? ObtenerUltimoComprobante() => _datos.ObtenerUltimoComprobante();

        private void ValidarComprobante(E_Comprobante obj)
        {
            if (string.IsNullOrWhiteSpace(obj.TipoComprobante))
                throw new ArgumentException("El tipo de comprobante es obligatorio.");
            if (obj.Total <= 0)
                throw new ArgumentException("El monto debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(obj.NumeroComprobante))
                throw new ArgumentException("El número de comprobante es obligatorio.");
        }
    }
}