using Entidades.Exepciones;
using Entidades.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    public class VehiculoDao : IConeccionABaseDeDatos<Vehiculo>
    {
        protected static string cadenaConexion;
        protected static SqlConnection coneccionSql;
        protected static SqlCommand comando;
        static VehiculoDao()
        {
            cadenaConexion = @"Data Source = .;Initial Catalog=TallerMecanico;Integrated Security=True";
            coneccionSql = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = coneccionSql;
        }

        public bool Agregar(List<Vehiculo> list)
        {
            bool estado;
            estado = false;
            if (list is not null && list.Count > 0)
            {
                estado = true;
                foreach (Vehiculo element in list)
                {
                    try
                    {
                        Agregar(element);
                    }
                    catch (ConeccionBaseDeDatosException)
                    {
                        throw;
                    }

                }
            }

            return estado;
        }
        public bool Agregar(Vehiculo unElemento)
        {
            bool estado;
            estado = false;
            try
            {
               
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@patente", unElemento.Patente);
                comando.Parameters.AddWithValue("@tipo",(int) unElemento.Tipo);
                comando.Parameters.AddWithValue("@modelo", unElemento.Modelo);
                comando.Parameters.AddWithValue("@Estado", unElemento.Estado);
                comando.Parameters.Add(ClienteDao.SetValueSqlParameter("@Path", unElemento.Path));
                comando.Parameters.AddWithValue("@marca", (int)unElemento.Marca);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Vehiculo(patente,tipo,modelo,idDeServicio,marca,estado,path) " +
                    "Values(@patente,@tipo,@modelo,@id,@marca,@Estado,@Path)";

                if (comando.ExecuteNonQuery() == 1)
                {
                    estado = true;
                }
            }
            catch (Exception e)
            {
                throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos", e.InnerException);
            }
            finally
            {
                if (coneccionSql.State == ConnectionState.Open)
                {
                    coneccionSql.Close();
                }
            }

            return estado;
        }

        public List<Vehiculo> Leer()
        {
            List<Vehiculo> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Vehiculo";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Vehiculo>();
                    while (dataReader.Read())
                    {
                        list.Add(ObtenerUnElemento(dataReader));
                    }
                }
            }
            catch (Exception e)
            {
                throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos", e.InnerException);
            }
            finally
            {
                if (coneccionSql.State == ConnectionState.Open)
                {
                    coneccionSql.Close();
                }
            }

            return list;
        }

        public Vehiculo ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Vehiculo(Convert.ToInt32(dataReader["id"]), Convert.ToString(dataReader["patente"]), (Vehiculo.MarcaDelVehiculo)Convert.ToInt32(dataReader["marca"]), (Vehiculo.TipoDeVehiculo)Convert.ToInt32(dataReader["tipo"]),
                Convert.ToString(dataReader["modelo"]), (Vehiculo.EstadoDeVehiculo)Convert.ToInt32(dataReader["estado"]),new ClienteDao().ObtenerUnElemento(dataReader));
        }
    }
}