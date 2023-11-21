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
        /// <summary>
        /// Agrega los Datos De la lista de Vehiculos en la base de datos
        /// </summary>
        /// <param name="list">(List<Vehiculo>) los datos a guardar</param>
        /// <returns>(true) si lo pudo gurdar, (false) de caso contrario</returns>
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
        /// <summary>
        /// Agrega un Vehiculo a la base de datos
        /// </summary>
        /// <param name="unElemento">el Vehiculo a agregar</param>
        /// <returns>(true) si lo pudo agragar,(false) si no lo pudo agragar</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
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
        /// <summary>
        /// Lee los datos de la base de datos y los guarda dentro de una lista de Vehiculos
        /// </summary>
        /// <returns>(List<Vehiculo>) la lista con los datos de los Vehiculos</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public List<Vehiculo> Leer()
        {
            List<Vehiculo> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Vehiculo";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    var a = dataReader.GetSchemaTable();
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

        /// <summary>
        /// Permite obtener un elemento del tipo Vehiculos obteniendo los dadoas que guarda el SqlDataRead 
        /// </summary>
        /// <param name="dataReader">Dataread con los Datos Vehiculos</param>
        /// <returns>(null) en caso de que no se pueda lee los datos</returns>
        public Vehiculo ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Vehiculo(Convert.ToInt32(dataReader["id"]), Convert.ToString(dataReader["patente"]), (Vehiculo.MarcaDelVehiculo)Convert.ToInt32(dataReader["marca"]), (Vehiculo.TipoDeVehiculo)Convert.ToInt32(dataReader["tipo"]),
                Convert.ToString(dataReader["modelo"]));
        }
    }
}