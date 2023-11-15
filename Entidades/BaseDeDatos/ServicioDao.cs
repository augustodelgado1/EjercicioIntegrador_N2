using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exepciones;

namespace Entidades.BaseDeDatos
{
    public class ServicioDao:ConeccionABaseDeDatos<Servicio>
    {
        public override bool Agregar(Servicio unElemento)
        {
            bool estado;
            estado = false;
            try
            {
                 /*,[idCliente]
      ,[idDeVehiculo]
      ,[fechaDeIngreso]
      ,[fechaDeEgreso]
      ,[descripcion]
      ,[estado]*/
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", unElemento.Problema);
                comando.Parameters.AddWithValue("@FechaDeIngreso", unElemento.FechaDeIngreso);
                comando.Parameters.AddWithValue("@FechaDeEgreso", unElemento.FechaDeEgreso);
                comando.Parameters.AddWithValue("@IdCliente", unElemento.UnCliente.Id);
                comando.Parameters.AddWithValue("@Estado", (int)unElemento.Estado);
                comando.Parameters.AddWithValue("@IdVehiculo", unElemento.UnVehiculo.Id);
                comando.Parameters.AddWithValue("@idMecanico", unElemento.UnMecanico.Id);

                coneccionSql.Open();
                comando.CommandText = "INSERT INTO Servicio(descripcion,fechaDeIngreso,fechaDeEgreso,idDeVehiculo,idCliente,idMecanico,estado) " +
                    "Values(@descripcion,@FechaDeIngreso,@FechaDeEgreso,@IdVehiculo,@IdCliente,@idMecanico,@Estado)";

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

        public override List<Servicio> Leer()
        {
            List<Servicio> list = null;

            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Servicio AS S INNER JOIN Cliente AS C ON S.idCliente = C.ID";

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
      
        public override Servicio ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Servicio(Convert.ToInt32(dataReader["id"]), Convert.ToString(dataReader["descripcion"]), Convert.ToDateTime(dataReader["fechaDeIngreso"]), Convert.ToDateTime(dataReader["fechaDeEgreso"])
                , new VehiculoDao().ObtenerUnElemento(dataReader), new ClienteDao().ObtenerUnElemento(dataReader), (Servicio.EstadoDelSevicio)Convert.ToInt32(dataReader["estado"]), new MecanicoDao().ObtenerUnElemento(dataReader));
        }
    }
}
