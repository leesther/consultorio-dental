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
                                        (idpago, tipocomprobante, serie, numero, subtotal, igv, total)
                                     VALUES
                                        (@idPago, @tipoComprobante, @serie, @numero, @subtotal, @igv, @total)
                                     RETURNING idcomprobante;";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idPago", NpgsqlDbType.Integer).Value = (object?)obj.IdPago ?? DBNull.Value;
                    cmd.Parameters.Add("@tipoComprobante", NpgsqlDbType.Varchar).Value = obj.TipoComprobante;
                    cmd.Parameters.Add("@serie", NpgsqlDbType.Varchar).Value = obj.Serie ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@numero", NpgsqlDbType.Varchar).Value = obj.Numero;
                    cmd.Parameters.Add("@subtotal", NpgsqlDbType.Numeric).Value = obj.Subtotal;
                    cmd.Parameters.Add("@igv", NpgsqlDbType.Numeric).Value = obj.IGV;
                    cmd.Parameters.Add("@total", NpgsqlDbType.Numeric).Value = obj.Total;

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
                    string query = @"SELECT idcomprobante, idpago, tipocomprobante, serie, numero,
                                            subtotal, igv, total
                                     FROM tblcomprobante
                                     ORDER BY idcomprobante DESC";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            E_Comprobante obj = new E_Comprobante();
                            obj.IdComprobante = dr.GetInt32(dr.GetOrdinal("idcomprobante"));
                            obj.IdPago = dr.IsDBNull(dr.GetOrdinal("idpago")) ? null : dr.GetInt32(dr.GetOrdinal("idpago"));
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipocomprobante"));
                            obj.Serie = dr.IsDBNull(dr.GetOrdinal("serie")) ? null : dr.GetString(dr.GetOrdinal("serie"));
                            obj.Numero = dr.GetString(dr.GetOrdinal("numero"));
                            obj.Subtotal = dr.GetDecimal(dr.GetOrdinal("subtotal"));
                            obj.IGV = dr.GetDecimal(dr.GetOrdinal("igv"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("total"));
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
                    string query = @"SELECT idcomprobante, idpago, tipocomprobante, serie, numero,
                                            subtotal, igv, total
                                     FROM tblcomprobante
                                     WHERE idcomprobante = @idComprobante";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idComprobante", NpgsqlDbType.Integer).Value = idComprobante;
                    cn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new E_Comprobante();
                            obj.IdComprobante = dr.GetInt32(dr.GetOrdinal("idcomprobante"));
                            obj.IdPago = dr.IsDBNull(dr.GetOrdinal("idpago")) ? null : dr.GetInt32(dr.GetOrdinal("idpago"));
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipocomprobante"));
                            obj.Serie = dr.IsDBNull(dr.GetOrdinal("serie")) ? null : dr.GetString(dr.GetOrdinal("serie"));
                            obj.Numero = dr.GetString(dr.GetOrdinal("numero"));
                            obj.Subtotal = dr.GetDecimal(dr.GetOrdinal("subtotal"));
                            obj.IGV = dr.GetDecimal(dr.GetOrdinal("igv"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("total"));
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
                "Boleta" => "B001",
                "Factura" => "F001",
                _ => "C001"
            };

            int consecutivo = 1;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"SELECT COALESCE(MAX(CAST(numero AS INTEGER)), 0) + 1
                                     FROM tblcomprobante
                                     WHERE serie = @serie";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@serie", NpgsqlDbType.Varchar).Value = prefijo;
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
            return prefijo + "-" + consecutivo.ToString("D8");
        }

        public void AnularComprobante(int idComprobante)
        {
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
                {
                    string query = @"DELETE FROM tblcomprobante WHERE idcomprobante = @idComprobante";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                    cmd.Parameters.Add("@idComprobante", NpgsqlDbType.Integer).Value = idComprobante;
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
                    string query = @"SELECT idcomprobante, tipocomprobante, serie, numero,
                                            subtotal, igv, total
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
                            obj.TipoComprobante = dr.GetString(dr.GetOrdinal("tipocomprobante"));
                            obj.Serie = dr.IsDBNull(dr.GetOrdinal("serie")) ? null : dr.GetString(dr.GetOrdinal("serie"));
                            obj.Numero = dr.GetString(dr.GetOrdinal("numero"));
                            obj.Subtotal = dr.GetDecimal(dr.GetOrdinal("subtotal"));
                            obj.IGV = dr.GetDecimal(dr.GetOrdinal("igv"));
                            obj.Total = dr.GetDecimal(dr.GetOrdinal("total"));
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