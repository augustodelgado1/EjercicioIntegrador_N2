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

        public Usuario ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Usuario(Convert.ToString(dataReader["email"]), Convert.ToString(dataReader["clave"]),(Usuario.Roles)Convert.ToInt32(dataReader["rol"]));
        }
    
    }
}
