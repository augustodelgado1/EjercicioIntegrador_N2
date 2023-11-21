using Entidades.Exepciones;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BaseDeDatos
{
    public class UsuarioDao : IConeccionABaseDeDatos<Usuario>
    {
        protected static string cadenaConexion;
        protected static SqlConnection coneccionSql;
        protected static SqlCommand comando;
        static UsuarioDao()
        {
            cadenaConexion = @"Data Source = .;Initial Catalog=TallerMecanico;Integrated Security=True";
            coneccionSql = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = coneccionSql;
        }
        /// <summary>
        /// Agrega los Datos De la lista de Usuarios en la base de datos
        /// </summary>
        /// <param name="list">(List<Usuario>) los datos a guardar</param>
        /// <returns>(true) si lo pudo gurdar, (false) de caso contrario</returns>
        public bool Agregar(List<Usuario> list)
        {
            bool estado;
            estado = false;
            if (list is not null && list.Count > 0)
            {
                estado = true;
                foreach (Usuario element in list)
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
        /// Agrega un Usuario a la base de datos
        /// </summary>
        /// <param name="unElemento">el Usuario a agregar</param>
        /// <returns>(true) si lo pudo agragar,(false) si no lo pudo agragar</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public bool Agregar(Usuario unElemento)
        {
            bool estado;
            estado = false;
            try
            {

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Email", unElemento.Email);
                comando.Parameters.AddWithValue("@Clave", unElemento.Clave);
                comando.Parameters.AddWithValue("@Rol", unElemento.Rol);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Usuario(email,clave,rol) " +
                    "Values(@Email,@Clave,@Rol)";

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
        /// Lee los datos de la base de datos y los guarda dentro de una lista de Usuarios
        /// </summary>
        /// <returns>(List<Usuario>) la lista con los datos de los Usuarios</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public List<Usuario> Leer()
        {
            List<Usuario> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Usuario";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Usuario>();
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
        /// Permite obtener un elemento del tipo Usuario obteniendo los dadoas que guarda el SqlDataRead 
        /// </summary>
        /// <param name="dataReader">Dataread con los Datos Usuario</param>
        /// <returns>(null) en caso de que no se pueda lee los datos</returns>
        public Usuario ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Usuario(Convert.ToString(dataReader["email"]), Convert.ToString(dataReader["clave"]),(Usuario.Roles)Convert.ToInt32(dataReader["rol"]));
        }
    
    }
}
