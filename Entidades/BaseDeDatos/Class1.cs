using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Serialization;
using Entidades.Interfaces;
using Entidades;
using System.Collections.Generic;

namespace Entidades.BaseDeDatos
{
    public abstract class ConeccionABaseDeDatos<T> : IConeccionABaseDeDatos<T>
         where T : class
    {
        protected static string cadenaConexion;
        protected static SqlConnection coneccionSql;
        protected static SqlCommand comando;
        static ConeccionABaseDeDatos()
        {
            cadenaConexion = @"Data Source = .;Initial Catalog=TallerMecanico;Integrated Security=True";
            coneccionSql = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = coneccionSql;
        }

        public bool Agregar(List<T> list)
        {
            bool estado;
            estado = false;
            if (list is not null && list.Count > 0)
            {
                estado = true;
                foreach (T element in list)
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
        public abstract bool Agregar(T unElemento);

        public abstract List<T> Leer();

        public abstract T ObtenerUnElemento(SqlDataReader dataReader);
    }
}



/*public class ConeccionABaseDeDatos : IConeccionABaseDeDatos<Servicio>
{
    static string cadenaConexion;
    static SqlConnection coneccionSql;
    static SqlCommand comando;

    static ConeccionABaseDeDatos()
    {
        cadenaConexion = @"Data Source = .;Initial Catalog=Jugadores;Integrated Security=True";
        coneccionSql = new SqlConnection(cadenaConexion);
        comando = new SqlCommand();
        comando.CommandType = System.Data.CommandType.Text;
        comando.Connection = coneccionSql;
    }
    public List<Servicio> Leer()
    {
        List<Servicio> listaDeServicios = null;

        try
        {
            coneccionSql.Open();
            comando.CommandText = "Select * From Servicios";

            using (SqlDataReader dataReader = comando.ExecuteReader())
            {
                listaDeServicios = new List<Servicio>();
                while (dataReader.Read())
                {
                    *//*listaDeServicios.Add(new Servicio(Convert.ToInt32(dataReader["id"]), (TipoDeServicio)Convert.ToInt32(dataReader["tipoDeServicio"]),
                        (Color)Convert.ToInt32(dataReader["Color"]), dataReader["path"].ToString(), Convert.ToInt32(dataReader["valor"])));*//*
                }
            }
        }
        catch (Exception e)
        {
            throw new ConeccionBaseDeDatosException("Ocurrio un problema al intentar obtener los archivos de la base de datos", e.InnerException);
        }
        finally
        {
            if (coneccionSql.State == System.Data.ConnectionState.Open)
            {
                coneccionSql.Close();
            }
        }

        return listaDeServicios;
    }

    public bool Agregar(List<Servicio> lista)
    {
        bool estado;
        estado = false;
        if (lista is not null && lista.Count > 0)
        {
            estado = true;
            foreach (Servicio unaServicio in lista)
            {
                try
                {
                    if (Agregar(unaServicio) == false)
                    {
                        estado = false;
                        break;
                    }
                }
                catch (ConeccionBaseDeDatosException)
                {
                    throw;
                }

            }
        }

        return estado;
    }

    public bool Agregar(Servicio unElemento)
    {
        bool estado;
        estado = false;
        try
        {
            comando.Parameters.Clear();
            *//*comando.Parameters.AddWithValue("@ColorDeLaServicio", (int)unElemento.ColorDeLaServicio);
            comando.Parameters.AddWithValue("@CaracteristicaDeLaServicio", (int)unElemento.CaracteristicaDeLaServicio);
            comando.Parameters.AddWithValue("@Valor", unElemento.Valor);
            comando.Parameters.AddWithValue("@Path", unElemento.Path);*//*

            coneccionSql.Open();
            comando.CommandText = "INSERT INTO Servicios(Color,tipoDeServicio,valor,path) " +
                "Values(@ColorDeLaServicio,@CaracteristicaDeLaServicio,@Valor,@Path)";

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
}*/