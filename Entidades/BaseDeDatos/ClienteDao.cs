using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exepciones;
using System.Reflection.Metadata;
using Entidades.Interfaces;

namespace Entidades.BaseDeDatos
{
    public class ClienteDao : IConeccionABaseDeDatos<Cliente>
    {
        protected static string cadenaConexion;
        protected static SqlConnection coneccionSql;
        protected static SqlCommand comando;
        static ClienteDao()
        {
            cadenaConexion = @"Data Source = .;Initial Catalog=TallerMecanico;Integrated Security=True";
            coneccionSql = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = coneccionSql;
        }

        public bool Agregar(List<Cliente> list)
        {
            bool estado;
            estado = false;
            if (list is not null && list.Count > 0)
            {
                estado = true;
                foreach (Cliente element in list)
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

        public static SqlParameter SetValueSqlParameter(string parameter, object value)
        {
            SqlParameter parametro = new(parameter, value);
            if (value is null)
            {
                parametro.Value = DBNull.Value;
            }

            return parametro;
        }

        public bool Agregar(Cliente unElemento)
        {
            bool estado;
            estado = false;
            try
            {
                /*[ID]
      ,[nombre]
      ,[email]
      ,[clave]
      ,[path]
      ,[dni]
      ,[fechaDeNacimiento]*/
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@email", unElemento.Email);
                comando.Parameters.AddWithValue("@clave", unElemento.Clave);
                comando.Parameters.AddWithValue("@nombre", unElemento.Nombre);
                comando.Parameters.AddWithValue("@fechaDeNacimiento", unElemento.FechaDeNacimiento.ToString("d/MM/yy"));
                comando.Parameters.AddWithValue("@dni", unElemento.Dni);
                comando.Parameters.Add(SetValueSqlParameter("@path", unElemento.Path));
                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Cliente(nombre,email,clave,dni,path,fechaDeNacimiento) " +
                    "Values(@nombre,@email,@clave,@dni,@path,@fechaDeNacimiento)";

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

        public List<Cliente> Leer()
        {
            List<Cliente> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Cliente";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Cliente>();
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

        public Cliente ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Cliente(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["nombre"]), Convert.ToString(dataReader["dni"]),
                Convert.ToDateTime(dataReader["fechaDeNacimiento"]),Convert.ToString(dataReader["email"]), Convert.ToString(dataReader["clave"]));
        }

       
    }
}
