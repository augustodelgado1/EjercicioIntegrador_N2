using System.Data.SqlClient;
using System.Data;
using Entidades.Exepciones;

namespace Entidades.BaseDeDatos
{
    internal class MecanicoDao:ConeccionABaseDeDatos<Mecanico>
    {
        public override bool Agregar(Mecanico unElemento)
        {
            bool estado;
            estado = false;
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@email", unElemento.Email);
                comando.Parameters.AddWithValue("@clave", unElemento.Clave);
                comando.Parameters.AddWithValue("@Nombre", unElemento.Nombre);
                comando.Parameters.AddWithValue("@FechaDeNacimiento", unElemento.FechaDeNacimiento);
                comando.Parameters.AddWithValue("@dni", unElemento.Dni);
                comando.Parameters.AddWithValue("@path", unElemento.Path);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Mecanico(nombre,email,clave,dni,path,fechaDeNacimiento) " +
                   "Values(@Nombre,@email,@clave,@dni,@path,@FechaDeNacimiento)";

                if (comando.ExecuteNonQuery() != 1)
                {
                    throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos");
                }
                estado = true;
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

        public override List<Mecanico> Leer()
        {
            List<Mecanico> list = null;

            try
            {

                coneccionSql.Open();
                comando.CommandText = $"Select * From Mecanico";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Mecanico>();
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

        public override Mecanico ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Mecanico(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["nombre"]), Convert.ToString(dataReader["dni"]),
               Convert.ToDateTime(dataReader["fechaDeNacimiento"]), Convert.ToString(dataReader["email"]), Convert.ToString(dataReader["clave"]));
        }
    }
}