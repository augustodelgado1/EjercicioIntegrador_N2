using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BaseDeDatos
{
    internal class ServicioDao:ConeccionABaseDeDatos<Servicio>
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
                comando.Parameters.AddWithValue("@descripcion", unElemento.Descripcion);
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
                comando.CommandText = $"Select * From Servicio";

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

        public void LeerBaseDeDatosRelacionalServicio_Diagnostico()
        {
            Diagnostico unDiagnostico;
            Servicio unServicio;
            try
            {
                coneccionSql.Open();
                comando.CommandText = $"Select * From Servicio_Diagnostico";

                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        unDiagnostico = Diagnostico.BuscarPorId(Negocio.listaDiagnostico, Convert.ToInt32(dataReader["idServicio"]));
                        unServicio = Servicio.BuscarPorId(Negocio.ListaDeServicio, Convert.ToInt32(dataReader["idDiagnostico"]));

                        if (unServicio + unDiagnostico == false)
                        {
                            throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos"); ;
            }
            finally
            {
                if (coneccionSql.State == ConnectionState.Open)
                {
                    coneccionSql.Close();
                }
            }
        } 

        public bool AgregarServicio_Diagnostico(Servicio unServicio)
        {
            bool estado;
            estado = false;
            if (unServicio is not null )
            {
                estado = true;
                foreach (Diagnostico unDiagnostico in unServicio.Diagnosticos)
                {
                    try
                    {
                        AgregarServicio_Diagnostico(unServicio.Id, unDiagnostico.Id);
                    }
                    catch (ConeccionBaseDeDatosException)
                    {
                        throw;
                    }

                }
            }

            return estado;
        }
        private bool AgregarServicio_Diagnostico(int idServicio,int idDiagnostico)
        {
            bool estado;
            estado = false;
            try
            {
                coneccionSql.Open();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idServicio", idServicio);
                comando.Parameters.AddWithValue("@idDiagnostico", idDiagnostico);
                comando.CommandText = "INSERT INTO Servicio_Diagnostico(idServicio,idDiagnostico) " +
                    "Values(@idServicio,@idDiagnostico)";

                if (comando.ExecuteNonQuery() == 1)
                {
                    estado = true;
                }
            }
            catch (Exception)
            {
                throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos"); ;
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
        
      
        public override Servicio ObtenerUnElemento(SqlDataReader dataReader)
        {
            return new Servicio(Convert.ToInt32(dataReader["id"]),
                Convert.ToString(dataReader["descripcion"]), Convert.ToDateTime(dataReader["fechaDeIngreso"]), Convert.ToDateTime(dataReader["fechaDeEgreso"]), Vehiculo.BuscarPorId(Negocio.listaDeVehiculos,Convert.ToInt32(dataReader["idDeVehiculo"]))
                , Cliente.BuscarPorId(Negocio.ListaDeClientes, Convert.ToInt32(dataReader["idCliente"])), (Servicio.EstadoDelSevicio)Convert.ToInt32(dataReader["estado"]));
        }
    }
}
