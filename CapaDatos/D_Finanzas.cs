using CapaEntidades;
using Npgsql;
using NpgsqlTypes;

namespace CapaDatos
{
    public class D_Finanzas
    {
        public int RegistrarPago(E_Pago obj)
        {
            int idGenerado = 0;

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"INSERT INTO tblPago
                                        (idPaciente, monto, metodoPago, descripcion, fechaPago)
                                     VALUES
                                        (@idPaciente, @monto, @metodoPago, @descripcion, @fechaPago)
                                     RETURNING idPago;";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPaciente", NpgsqlDbType.Integer).Value = obj.IdPaciente;
                    cmd.Parameters.Add("@monto", NpgsqlDbType.Numeric).Value = obj.Monto;
                    cmd.Parameters.Add("@metodoPago", NpgsqlDbType.Varchar).Value = (object?)obj.MetodoPago ?? DBNull.Value;
                    cmd.Parameters.Add("@descripcion", NpgsqlDbType.Varchar).Value = (object?)obj.Descripcion ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaPago", NpgsqlDbType.Timestamp).Value = obj.FechaPago;

                    cn.Open();
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al registrar pago: " + ex.Message, ex);
            }

            return idGenerado;
        }

        public List<E_Pago> ListarPagos()
        {
            List<E_Pago> lista = new List<E_Pago>();

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT p.idPago, p.idPaciente, p.monto, p.metodoPago, p.descripcion, p.fechaPago,
                                            CONCAT(pa.nombres, ' ', pa.apellidos) AS pacienteNombre
                                     FROM tblPago p
                                     INNER JOIN tblPaciente pa ON p.idPaciente = pa.idPaciente
                                     ORDER BY p.fechaPago DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Pago obj = new E_Pago();
                            obj.IdPago = dr.GetInt32(dr.GetOrdinal("idPago"));
                            obj.IdPaciente = dr.GetInt32(dr.GetOrdinal("idPaciente"));
                            obj.Monto = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.MetodoPago = dr.GetString(dr.GetOrdinal("metodoPago"));
                            obj.Descripcion = dr.IsDBNull(dr.GetOrdinal("descripcion")) ? null : dr.GetString(dr.GetOrdinal("descripcion"));
                            obj.FechaPago = dr.GetDateTime(dr.GetOrdinal("fechaPago"));
                            obj.PacienteNombre = dr.GetString(dr.GetOrdinal("pacienteNombre"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al listar pagos: " + ex.Message, ex);
            }

            return lista;
        }

        public List<E_Pago> ListarPagosPorPaciente(int idPaciente)
        {
            List<E_Pago> lista = new List<E_Pago>();

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT p.idPago, p.idPaciente, p.monto, p.metodoPago, p.descripcion, p.fechaPago,
                                            CONCAT(pa.nombres, ' ', pa.apellidos) AS pacienteNombre
                                     FROM tblPago p
                                     INNER JOIN tblPaciente pa ON p.idPaciente = pa.idPaciente
                                     WHERE p.idPaciente = @idPaciente
                                     ORDER BY p.fechaPago DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPaciente", NpgsqlDbType.Integer).Value = idPaciente;
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Pago obj = new E_Pago();
                            obj.IdPago = dr.GetInt32(dr.GetOrdinal("idPago"));
                            obj.IdPaciente = dr.GetInt32(dr.GetOrdinal("idPaciente"));
                            obj.Monto = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.MetodoPago = dr.GetString(dr.GetOrdinal("metodoPago"));
                            obj.Descripcion = dr.IsDBNull(dr.GetOrdinal("descripcion")) ? null : dr.GetString(dr.GetOrdinal("descripcion"));
                            obj.FechaPago = dr.GetDateTime(dr.GetOrdinal("fechaPago"));
                            obj.PacienteNombre = dr.GetString(dr.GetOrdinal("pacienteNombre"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al listar pagos por paciente: " + ex.Message, ex);
            }

            return lista;
        }

        public E_Pago? ObtenerPagoPorId(int idPago)
        {
            E_Pago? obj = null;

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT p.idPago, p.idPaciente, p.monto, p.metodoPago, p.descripcion, p.fechaPago,
                                            CONCAT(pa.nombres, ' ', pa.apellidos) AS pacienteNombre
                                     FROM tblPago p
                                     INNER JOIN tblPaciente pa ON p.idPaciente = pa.idPaciente
                                     WHERE p.idPago = @idPago";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPago", NpgsqlDbType.Integer).Value = idPago;
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new E_Pago();
                            obj.IdPago = dr.GetInt32(dr.GetOrdinal("idPago"));
                            obj.IdPaciente = dr.GetInt32(dr.GetOrdinal("idPaciente"));
                            obj.Monto = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.MetodoPago = dr.GetString(dr.GetOrdinal("metodoPago"));
                            obj.Descripcion = dr.IsDBNull(dr.GetOrdinal("descripcion")) ? null : dr.GetString(dr.GetOrdinal("descripcion"));
                            obj.FechaPago = dr.GetDateTime(dr.GetOrdinal("fechaPago"));
                            obj.PacienteNombre = dr.GetString(dr.GetOrdinal("pacienteNombre"));
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener pago: " + ex.Message, ex);
            }

            return obj;
        }

        public int RegistrarMovimiento(E_Movimiento obj)
        {
            int idGenerado = 0;

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"INSERT INTO tblmovimientoinventario
                                        (tipomovimiento, cantidad, observacion, fechamovimiento)
                                     VALUES
                                        (@tipoMovimiento, @monto, @descripcion, @fechaMovimiento)
                                     RETURNING idmovimiento;";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@tipoMovimiento", NpgsqlDbType.Varchar).Value = obj.TipoMovimiento;
                    cmd.Parameters.Add("@monto", NpgsqlDbType.Numeric).Value = obj.Monto;
                    cmd.Parameters.Add("@descripcion", NpgsqlDbType.Varchar).Value = (object?)obj.Descripcion ?? DBNull.Value;
                    cmd.Parameters.Add("@fechaMovimiento", NpgsqlDbType.Timestamp).Value = obj.FechaMovimiento;

                    cn.Open();
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al registrar movimiento: " + ex.Message, ex);
            }

            return idGenerado;
        }

        public List<E_Movimiento> ListarMovimientos()
        {
            List<E_Movimiento> lista = new List<E_Movimiento>();

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT idmovimiento, tipomovimiento, cantidad, observacion, fechamovimiento
                                     FROM tblmovimientoinventario
                                     ORDER BY fechamovimiento DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Movimiento obj = new E_Movimiento();
                            obj.IdMovimiento = dr.GetInt32(dr.GetOrdinal("idmovimiento"));
                            obj.TipoMovimiento = dr.GetString(dr.GetOrdinal("tipomovimiento"));
                            obj.Monto = dr.GetDecimal(dr.GetOrdinal("cantidad"));
                            obj.Descripcion = dr.IsDBNull(dr.GetOrdinal("observacion")) ? null : dr.GetString(dr.GetOrdinal("observacion"));
                            obj.FechaMovimiento = dr.GetDateTime(dr.GetOrdinal("fechamovimiento"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al listar movimientos: " + ex.Message, ex);
            }

            return lista;
        }

        public List<E_Movimiento> ListarMovimientosPorTipo(string tipoMovimiento)
        {
            List<E_Movimiento> lista = new List<E_Movimiento>();

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT idmovimiento, tipomovimiento, cantidad, observacion, fechamovimiento
                                     FROM tblmovimientoinventario
                                     WHERE tipomovimiento = @tipoMovimiento
                                     ORDER BY fechamovimiento DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@tipoMovimiento", NpgsqlDbType.Varchar).Value = tipoMovimiento;
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Movimiento obj = new E_Movimiento();
                            obj.IdMovimiento = dr.GetInt32(dr.GetOrdinal("idmovimiento"));
                            obj.TipoMovimiento = dr.GetString(dr.GetOrdinal("tipomovimiento"));
                            obj.Monto = dr.GetDecimal(dr.GetOrdinal("cantidad"));
                            obj.Descripcion = dr.IsDBNull(dr.GetOrdinal("observacion")) ? null : dr.GetString(dr.GetOrdinal("observacion"));
                            obj.FechaMovimiento = dr.GetDateTime(dr.GetOrdinal("fechamovimiento"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al listar movimientos por tipo: " + ex.Message, ex);
            }

            return lista;
        }

        public void EliminarPago(int idPago)
        {
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"DELETE FROM tblComprobante WHERE idPago = @idPago;
                                     DELETE FROM tblPago WHERE idPago = @idPago;";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPago", NpgsqlDbType.Integer).Value = idPago;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al eliminar pago: " + ex.Message, ex);
            }
        }

        public decimal ObtenerTotalPorMovimiento(string tipoMovimiento)
        {
            decimal total = 0;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query;
                    NpgsqlCommand cmd;

                    if (tipoMovimiento == "Ingreso")
                    {
                        query = @"SELECT COALESCE(SUM(monto), 0) FROM tblPago";
                        cmd = new NpgsqlCommand(query, cn);
                    }
                    else
                    {
                        query = @"SELECT COALESCE(SUM(cantidad), 0) FROM tblmovimientoinventario WHERE tipomovimiento = @tipo";
                        cmd = new NpgsqlCommand(query, cn);
                        cmd.Parameters.Add("@tipo", NpgsqlDbType.Varchar).Value = tipoMovimiento;
                    }

                    cn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener total por tipo de movimiento: " + ex.Message, ex);
            }
            return total;
        }

        public decimal ObtenerTotalPagos()
        {
            decimal total = 0;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT COALESCE(SUM(monto), 0) FROM tblPago";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener total de pagos: " + ex.Message, ex);
            }
            return total;
        }

        public decimal ObtenerBalance()
        {
            decimal balance = 0;

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    cn.Open();

                    using (NpgsqlCommand cmdIngresos = new NpgsqlCommand(
                        @"SELECT COALESCE(SUM(monto), 0) FROM tblPago", cn))
                    {
                        var result = cmdIngresos.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            balance = Convert.ToDecimal(result);
                    }

                    using (NpgsqlCommand cmdEgresos = new NpgsqlCommand(
                        @"SELECT COALESCE(SUM(cantidad), 0) FROM tblmovimientoinventario WHERE tipomovimiento = 'Egreso'", cn))
                    {
                        var result = cmdEgresos.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            balance -= Convert.ToDecimal(result);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener balance financiero: " + ex.Message, ex);
            }

            return balance;
        }

        public List<E_ReporteVentas> ObtenerReporteVentas(string agrupacion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<E_ReporteVentas> lista = new List<E_ReporteVentas>();
            string labelFecha = agrupacion.ToLower() switch
            {
                "diario" => @"TO_CHAR(fechaPago, 'YYYY-MM-DD')",
                "semanal" => @"TO_CHAR(fechaPago, 'YYYY-""W""IW')",
                "mensual" => @"TO_CHAR(fechaPago, 'YYYY-MM')",
                _ => @"TO_CHAR(fechaPago, 'YYYY-MM')"
            };

            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = $@"SELECT {labelFecha} AS periodo,
                                             COUNT(*) AS totalTransacciones,
                                             COALESCE(SUM(monto), 0) AS totalVentas
                                      FROM tblPago
                                      WHERE fechaPago BETWEEN @fechaInicio AND @fechaFin
                                      GROUP BY {labelFecha}
                                      ORDER BY periodo";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@fechaInicio", NpgsqlDbType.Timestamp).Value = fechaInicio;
                    cmd.Parameters.Add("@fechaFin", NpgsqlDbType.Timestamp).Value = fechaFin;
                    cn.Open();

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_ReporteVentas obj = new E_ReporteVentas();
                            obj.Periodo = dr.GetString(dr.GetOrdinal("periodo"));
                            obj.TotalTransacciones = dr.GetInt32(dr.GetOrdinal("totalTransacciones"));
                            obj.TotalVentas = dr.GetDecimal(dr.GetOrdinal("totalVentas"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener reporte de ventas: " + ex.Message, ex);
            }

            return lista;
        }
    }
}