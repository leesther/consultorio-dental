using CapaEntidades;
using Npgsql;
using NpgsqlTypes;

namespace CapaDatos
{
    public class D_Pacientes
    {
        public List<E_Paciente> ListarPacientes()
        {
            List<E_Paciente> lista = new List<E_Paciente>();

            using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
            {
                string query = @"SELECT idPaciente, nombres, apellidos, dni, carnetExtranjeria,
                                        fechaNacimiento, edad, telefono, correo, direccion,
                                        genero, alergias, observaciones, fechaRegistro, estado
                                 FROM tblPaciente
                                  WHERE estado = true
                                 ORDER BY apellidos, nombres";

                NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                cn.Open();

                using (NpgsqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        E_Paciente obj = new E_Paciente();
                        obj.IdPaciente = dr.GetInt32(dr.GetOrdinal("idPaciente"));
                        obj.Nombres = dr.GetString(dr.GetOrdinal("nombres"));
                        obj.Apellidos = dr.GetString(dr.GetOrdinal("apellidos"));
                        obj.DNI = dr.IsDBNull(dr.GetOrdinal("dni")) ? null : dr.GetString(dr.GetOrdinal("dni"));
                        obj.CarnetExtranjeria = dr.IsDBNull(dr.GetOrdinal("carnetExtranjeria")) ? null : dr.GetString(dr.GetOrdinal("carnetExtranjeria"));
                        obj.FechaNacimiento = dr.IsDBNull(dr.GetOrdinal("fechaNacimiento")) ? null : dr.GetDateTime(dr.GetOrdinal("fechaNacimiento"));
                        obj.Edad = dr.IsDBNull(dr.GetOrdinal("edad")) ? null : dr.GetInt32(dr.GetOrdinal("edad"));
                        obj.Telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? null : dr.GetString(dr.GetOrdinal("telefono"));
                        obj.Correo = dr.IsDBNull(dr.GetOrdinal("correo")) ? null : dr.GetString(dr.GetOrdinal("correo"));
                        obj.Direccion = dr.IsDBNull(dr.GetOrdinal("direccion")) ? null : dr.GetString(dr.GetOrdinal("direccion"));
                        obj.Genero = dr.IsDBNull(dr.GetOrdinal("genero")) ? null : dr.GetString(dr.GetOrdinal("genero"));
                        obj.Alergias = dr.IsDBNull(dr.GetOrdinal("alergias")) ? null : dr.GetString(dr.GetOrdinal("alergias"));
                        obj.Observaciones = dr.IsDBNull(dr.GetOrdinal("observaciones")) ? null : dr.GetString(dr.GetOrdinal("observaciones"));
                        obj.FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fechaRegistro")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("fechaRegistro"));
                        obj.Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? true : dr.GetBoolean(dr.GetOrdinal("estado"));
                        lista.Add(obj);
                    }
                }
            }

            return lista;
        }

        public int RegistrarPaciente(E_Paciente obj)
        {
            int idGenerado = 0;

            using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
            {
                string query = @"INSERT INTO tblPaciente
                                    (nombres, apellidos, dni, carnetExtranjeria, fechaNacimiento,
                                     edad, telefono, correo, direccion, genero, alergias, observaciones)
                                 VALUES
                                    (@nombres, @apellidos, @dni, @carnetExtranjeria, @fechaNacimiento,
                                     @edad, @telefono, @correo, @direccion, @genero, @alergias, @observaciones)
                                 RETURNING idPaciente;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                cmd.Parameters.Add("@nombres", NpgsqlDbType.Varchar).Value = obj.Nombres;
                cmd.Parameters.Add("@apellidos", NpgsqlDbType.Varchar).Value = obj.Apellidos;
                cmd.Parameters.Add("@dni", NpgsqlDbType.Varchar).Value = (object?)obj.DNI ?? DBNull.Value;
                cmd.Parameters.Add("@carnetExtranjeria", NpgsqlDbType.Varchar).Value = (object?)obj.CarnetExtranjeria ?? DBNull.Value;
                cmd.Parameters.Add("@fechaNacimiento", NpgsqlDbType.Date).Value = (object?)obj.FechaNacimiento ?? DBNull.Value;
                cmd.Parameters.Add("@edad", NpgsqlDbType.Integer).Value = (object?)obj.Edad ?? DBNull.Value;
                cmd.Parameters.Add("@telefono", NpgsqlDbType.Varchar).Value = (object?)obj.Telefono ?? DBNull.Value;
                cmd.Parameters.Add("@correo", NpgsqlDbType.Varchar).Value = (object?)obj.Correo ?? DBNull.Value;
                cmd.Parameters.Add("@direccion", NpgsqlDbType.Varchar).Value = (object?)obj.Direccion ?? DBNull.Value;
                cmd.Parameters.Add("@genero", NpgsqlDbType.Varchar).Value = (object?)obj.Genero ?? DBNull.Value;
                cmd.Parameters.Add("@alergias", NpgsqlDbType.Varchar).Value = (object?)obj.Alergias ?? DBNull.Value;
                cmd.Parameters.Add("@observaciones", NpgsqlDbType.Varchar).Value = (object?)obj.Observaciones ?? DBNull.Value;

                cn.Open();
                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return idGenerado;
        }

        public void ActualizarPaciente(E_Paciente obj)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
            {
                string query = @"UPDATE tblPaciente SET
                                    nombres = @nombres,
                                    apellidos = @apellidos,
                                    dni = @dni,
                                    carnetExtranjeria = @carnetExtranjeria,
                                    fechaNacimiento = @fechaNacimiento,
                                    edad = @edad,
                                    telefono = @telefono,
                                    correo = @correo,
                                    direccion = @direccion,
                                    genero = @genero,
                                    alergias = @alergias,
                                    observaciones = @observaciones
                                 WHERE idPaciente = @idPaciente";

                NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                cmd.Parameters.Add("@nombres", NpgsqlDbType.Varchar).Value = obj.Nombres;
                cmd.Parameters.Add("@apellidos", NpgsqlDbType.Varchar).Value = obj.Apellidos;
                cmd.Parameters.Add("@dni", NpgsqlDbType.Varchar).Value = (object?)obj.DNI ?? DBNull.Value;
                cmd.Parameters.Add("@carnetExtranjeria", NpgsqlDbType.Varchar).Value = (object?)obj.CarnetExtranjeria ?? DBNull.Value;
                cmd.Parameters.Add("@fechaNacimiento", NpgsqlDbType.Date).Value = (object?)obj.FechaNacimiento ?? DBNull.Value;
                cmd.Parameters.Add("@edad", NpgsqlDbType.Integer).Value = (object?)obj.Edad ?? DBNull.Value;
                cmd.Parameters.Add("@telefono", NpgsqlDbType.Varchar).Value = (object?)obj.Telefono ?? DBNull.Value;
                cmd.Parameters.Add("@correo", NpgsqlDbType.Varchar).Value = (object?)obj.Correo ?? DBNull.Value;
                cmd.Parameters.Add("@direccion", NpgsqlDbType.Varchar).Value = (object?)obj.Direccion ?? DBNull.Value;
                cmd.Parameters.Add("@genero", NpgsqlDbType.Varchar).Value = (object?)obj.Genero ?? DBNull.Value;
                cmd.Parameters.Add("@alergias", NpgsqlDbType.Varchar).Value = (object?)obj.Alergias ?? DBNull.Value;
                cmd.Parameters.Add("@observaciones", NpgsqlDbType.Varchar).Value = (object?)obj.Observaciones ?? DBNull.Value;
                cmd.Parameters.Add("@idPaciente", NpgsqlDbType.Integer).Value = obj.IdPaciente;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPaciente(int idPaciente)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(ConexionBD.CadenaConexion))
            {
                 string query = @"UPDATE tblPaciente SET estado = false WHERE idPaciente = @idPaciente";
                NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
                cmd.Parameters.Add("@idPaciente", NpgsqlDbType.Integer).Value = idPaciente;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}