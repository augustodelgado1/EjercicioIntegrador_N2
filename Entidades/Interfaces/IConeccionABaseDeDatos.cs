using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Esta interfaz contiene las funcionalidades para el menejo de datos atravez de la base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IConeccionABaseDeDatos<T> 
        where T : class
    {
        /// <summary>
        /// Lee los datos de la base de datos y los guarda dentro de una lista 
        /// </summary>
        /// <returns>(List<T>) la lista con los datos</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public List<T> Leer();

        /// <summary>
        /// Permite obtener un elemento del tipo indicado obteniendo los dadoas que guarda el SqlDataRead 
        /// </summary>
        /// <param name="dataReader">Dataread con los Datos</param>
        /// <returns>(null) en caso de que no se pueda lee los datos</returns>
        public T ObtenerUnElemento(SqlDataReader dataRead);

        /// <summary>
        /// Agrega los Datos De la lista en la base de datos
        /// </summary>
        /// <param name="list">(List<T>) los datos a guardar</param>
        /// <returns>(true) si se pudo gurdar los datos, (false) de caso contrario</returns>
        public bool Agregar(List<T> lista);

        /// <summary>
        /// Agrega un unElemento a la base de datos
        /// </summary>
        /// <param name="unElemento">el unElemento a agregar</param>
        /// <returns>(true) si lo pudo agragar,(false) si no lo pudo agragar</returns>
        /// <exception cref="ConeccionBaseDeDatosException"></exception>
        public bool Agregar(T unElemento);
    }
}
