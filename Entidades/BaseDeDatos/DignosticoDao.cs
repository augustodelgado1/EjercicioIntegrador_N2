using Entidades;
using Entidades.BaseDeDatos;
using System.Data;
using System.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    public class DignosticoDao : ConeccionABaseDeDatos<Diagnostico>
    {
        public override bool Agregar(Diagnostico unElemento)
        {
            bool estado;
            estado = false;
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Nombre", unElemento.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", unElemento.Descripcion);
                comando.Parameters.AddWithValue("@Costo", unElemento.Costo);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Diagnostico(nombre,descripcion,costo) " +
                    "Values(@Nombre,@Descripcion,@Costo)";

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

        public override List<Diagnostico> Leer()
        {
            List<Diagnostico> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Diagnostico";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    list = new List<Diagnostico>();
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

        public override Diagnostico ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Diagnostico(Convert.ToInt32(dataReader["ID"]), Convert.ToString(dataReader["Nombre"]), Convert.ToString(dataReader["Descripcion"]), Convert.ToSingle(dataReader["Costo"]));
        }
    }
    
}