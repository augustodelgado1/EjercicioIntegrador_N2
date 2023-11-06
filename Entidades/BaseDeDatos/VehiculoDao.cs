using System.Data;
using System.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    public class VehiculoDao : ConeccionABaseDeDatos<Vehiculo>
    {
        public override bool Agregar(Vehiculo unElemento)
        {
            bool estado;
            estado = false;
            try
            {
               
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@patente", unElemento.Patente);
                comando.Parameters.AddWithValue("@tipo",(int) unElemento.Tipo);
                comando.Parameters.AddWithValue("@modelo", unElemento.Modelo);
                comando.Parameters.AddWithValue("@id", unElemento.Servicio.Id);
                comando.Parameters.AddWithValue("@marca", (int)unElemento.Marca);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Vehiculo(patente,tipo,modelo,idDeServicio,marca) " +
                    "Values(@patente,@tipo,@modelo,@id,@marca)";

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

        public override List<Vehiculo> Leer()
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

        public override Vehiculo ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Vehiculo(Convert.ToInt32(dataReader["id"]), Convert.ToString(dataReader["patente"]), (Vehiculo.MarcaDelVehiculo)Convert.ToInt32(dataReader["marca"]), (Vehiculo.TipoDeVehiculo)Convert.ToInt32(dataReader["tipo"]),
                Convert.ToString(dataReader["modelo"]),Servicio.BuscarPorId(Negocio.ListaDeServicio, Convert.ToInt32(dataReader["idDeServicio"])));
        }
    }
}