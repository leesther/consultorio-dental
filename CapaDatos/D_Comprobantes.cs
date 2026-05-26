using CapaEntidades;
using Npgsql;
using NpgsqlTypes;

namespace CapaDatos
{
    public class D_Comprobantes
    {
        public int RegistrarComprobante(E_Comprobante obj)
        {
            int idGenerado = 0;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"INSERT INTO tblcomprobante
                                        (idPago, numeroComprobante, tipoComprobante, monto, descripcion, pacienteNombre, fechaEmision)
                                     VALUES
                                        (@idPago, @numeroComprobante, @tipoComprobante, @total, @estado, @razonSocial, @fechaEmision)
                                     RETURNING idComprobante;";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPago", NpgsqlDbType.Integer).Value = (object?)obj.IdPago ?? DBNull.Value;
                    cmd.Parameters.Add("@numeroComprobante", NpgsqlDbType.Varchar).Value = obj.NumeroComprobante;
                    cmd.Parameters.Add("@tipoComprobante", NpgsqlDbType.Varchar).Value = obj.TipoComprobante;
                    cmd.Parameters.Add("@total", NpgsqlDbType.Numeric).Value = obj.Total;
                    cmd.Parameters.Add("@estado", NpgsqlDbType.Varchar).Value = obj.Estado;
                    cmd.Parameters.Add("@razonSocial", NpgsqlDbType.Varchar).Value = obj.RazonSocial;
                    cmd.Parameters.Add("@fechaEmision", NpgsqlDbType.Timestamp).Value = obj.FechaEmision;

                    cn.Open();
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al registrar comprobante: " + ex.Message, ex);
            }
            return idGenerado;
        }

        public List<E_Comprobante> ListarComprobantes()
        {
            List<E_Comprobante> lista = new List<E_Comprobante>();
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT idcomprobante, idPago, numeroComprobante, tipoComprobante,
                                            monto, descripcion, pacienteNombre, fechaEmision, anulado
                                     FROM tblcomprobante
                                     ORDER BY fechaEmision DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Comprobante obj = new E_Comprobante();
                            obj.IdComprobante = dr.GetInt32(dr.GetOrdinal("idcomprobante"));
                            obj.IdPago = dr.IsDBNull(dr.GetOrdinal("idPago")) ? null : dr.GetInt32(dr.GetOrdinal("idPago"));
                            obj.NumeroComprobante = dr.GetString(dr.GetOrdinal("numeroComprobante"));
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipoComprobante"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.Estado = dr.GetBoolean(dr.GetOrdinal("anulado")) ? "Anulado" : "Emitido";
                            obj.RazonSocial = dr.IsDBNull(dr.GetOrdinal("pacienteNombre")) ? "" : dr.GetString(dr.GetOrdinal("pacienteNombre"));
                            obj.FechaEmision = dr.GetDateTime(dr.GetOrdinal("fechaEmision"));
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al listar comprobantes: " + ex.Message, ex);
            }
            return lista;
        }

        public E_Comprobante? ObtenerComprobantePorId(int idComprobante)
        {
            E_Comprobante? obj = null;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT idcomprobante, idPago, numeroComprobante, tipoComprobante,
                                            monto, descripcion, pacienteNombre, fechaEmision, anulado
                                     FROM tblcomprobante
                                     WHERE idcomprobante = @idcomprobante";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idcomprobante", NpgsqlDbType.Integer).Value = idComprobante;
                    cn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new E_Comprobante();
                            obj.IdComprobante = dr.GetInt32(dr.GetOrdinal("idcomprobante"));
                            obj.IdPago = dr.IsDBNull(dr.GetOrdinal("idPago")) ? null : dr.GetInt32(dr.GetOrdinal("idPago"));
                            obj.NumeroComprobante = dr.GetString(dr.GetOrdinal("numeroComprobante"));
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipoComprobante"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.Estado = dr.GetBoolean(dr.GetOrdinal("anulado")) ? "Anulado" : "Emitido";
                            obj.RazonSocial = dr.IsDBNull(dr.GetOrdinal("pacienteNombre")) ? "" : dr.GetString(dr.GetOrdinal("pacienteNombre"));
                            obj.FechaEmision = dr.GetDateTime(dr.GetOrdinal("fechaEmision"));
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener comprobante: " + ex.Message, ex);
            }
            return obj;
        }

        public string GenerarNumeroComprobante(string tipoComprobante)
        {
            string prefijo = tipoComprobante switch
            {
                "Boleta" => "B001-",
                "Factura" => "F001-",
                _ => "C001-"
            };

            int consecutivo = 1;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT COALESCE(MAX(CAST(SUBSTRING(numeroComprobante FROM '\d+$') AS INTEGER)), 0) + 1
                                     FROM tblcomprobante
                                     WHERE numeroComprobante LIKE @prefijo";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@prefijo", NpgsqlDbType.Varchar).Value = prefijo + "%";
                    cn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        consecutivo = Convert.ToInt32(result);
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al generar número de comprobante: " + ex.Message, ex);
            }
            return prefijo + consecutivo.ToString("D8");
        }

        public void AnularComprobante(int idComprobante)
        {
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"UPDATE tblcomprobante SET anulado = true WHERE idcomprobante = @idcomprobante";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idcomprobante", NpgsqlDbType.Integer).Value = idComprobante;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al anular comprobante: " + ex.Message, ex);
            }
        }

        public E_Comprobante? ObtenerUltimoComprobante()
        {
            E_Comprobante? obj = null;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT idcomprobante, numeroComprobante, tipoComprobante, monto,
                                            pacienteNombre, fechaEmision, descripcion
                                     FROM tblcomprobante
                                     ORDER BY idcomprobante DESC
                                     LIMIT 1";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new E_Comprobante();
                            obj.IdComprobante = dr.GetInt32(dr.GetOrdinal("idcomprobante"));
                            obj.NumeroComprobante = dr.GetString(dr.GetOrdinal("numeroComprobante"));
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipoComprobante"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("monto"));
                            obj.RazonSocial = dr.IsDBNull(dr.GetOrdinal("pacienteNombre")) ? "" : dr.GetString(dr.GetOrdinal("pacienteNombre"));
                            obj.FechaEmision = dr.GetDateTime(dr.GetOrdinal("fechaEmision"));
                            obj.Estado = "Emitido";
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Error al obtener último comprobante: " + ex.Message, ex);
            }
            return obj;
        }
    }
}