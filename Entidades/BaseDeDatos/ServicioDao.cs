using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exepciones;
using Entidades.Interfaces;

namespace Entidades.BaseDeDatos
{
    public class ServicioDao : IConeccionABaseDeDatos<Servicio>
    {
        protected static string cadenaConexion;
        protected static SqlConnection coneccionSql;
        protected static SqlCommand comando;
        static ServicioDao()
        {
            cadenaConexion = @"Data Source = .;Initial Catalog=TallerMecanico;Integrated Security=True";
            coneccionSql = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = coneccionSql;
        }

        /// <summary>
        /// Agrega los Datos De la lista de Servicio en la base de datos
        /// </summary>
        /// <param name="list">(List<Servicio>) los datos a guardar</param>
        /// <returns>(true) si lo pudo gurdar, (false) de caso contrario</returns>
        public bool Agregar(List<Servicio> list)
        {
            bool estado;
            estado = false;
            if (list is not null && list.Count > 0)
            {
                estado = true;
                foreach (Servicio element in list)
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
        /// Agrega un Servicio a la base de datos
        /// </summary>
        /// <param name="unElemento">el Servicio a agregar</param>
        /// <returns>(true) si lo pudo agragar,(false) si no lo pudo agragar</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public bool Agregar(Servicio unElemento)
        {
            bool estado;
            estado = false;
            try
            {
                if (unElemento.UnVehiculo is not null)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@FechaDeIngreso", unElemento.FechaDeIngreso);
                    comando.Parameters.AddWithValue("@IdCliente", unElemento.UnCliente.Id);
                    comando.Parameters.AddWithValue("@Estado", (int)unElemento.Estado);
                    comando.Parameters.AddWithValue("@IdVehiculo", unElemento.UnVehiculo.Id);
                    comando.Parameters.Add(ClienteDao.SetValueSqlParameter("@descripcion", unElemento.Problema));
                    comando.Parameters.AddWithValue("@Diagnistico", (int)unElemento.Diagnistico);
                    coneccionSql.Open();
                    comando.CommandText = "INSERT INTO Servicio(descripcion,fechaDeIngreso,idDeVehiculo,idCliente,estado,idDiagnostico) " +
                        "Values(@descripcion,@FechaDeIngreso,@IdVehiculo,@IdCliente,@Estado,@Diagnistico)";

                    if (comando.ExecuteNonQuery() == 1)
                    {
                        estado = true;
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

            return estado;
        }
        /// <summary>
        /// Lee los datos de la base de datos y los guarda dentro de una lista de Servicios
        /// </summary>
        /// <returns>(List<Servicio>) la lista con los datos de los Servicios</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public List<Servicio> Leer()
        {
            List<Servicio> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Servicio AS S INNER JOIN Vehiculo AS V ON S.idDeVehiculo = V.ID INNER JOIN Cliente AS C ON S.idCliente = C.ID";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Servicio>();
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
        /// Permite obtener un elemento del tipo Servicio obteniendo los dadoas que guarda el SqlDataRead 
        /// </summary>
        /// <param name="dataReader">Dataread con los Datos Servicio</param>
        /// <returns>(null) en caso de que no se pueda lee los datos</returns>
        public Servicio ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Servicio(Convert.ToInt32(dataReader["id"]), Convert.ToString(dataReader["descripcion"])
                , Convert.ToDateTime(dataReader["fechaDeIngreso"]),new VehiculoDao().ObtenerUnElemento(dataReader)
                , new ClienteDao().ObtenerUnElemento(dataReader), (Servicio.EstadoDelSevicio)Convert.ToInt32(dataReader["estado"]));
        }
    }
}
