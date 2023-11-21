using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Esta interfaz contiene las fucionalidades para realizar un Abm 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAbm<T> where T : class
    {
        /// <summary>
        /// Permite dar de alta un elemento del tipo pasado por parametro
        /// </summary>
        /// <returns>(false) en caso de que no se haya podido dar de alta,(true) de caso contratio</returns>
        public bool Alta();

        /// <summary>
        /// Permite Modificacar un elemento del tipo pasado por parametro
        /// </summary>
        /// <returns>(false) en caso de que no se haya podido dar de Modificacion,(true) de caso contratio</returns>
        public bool Modificacion(T element);

        /// <summary>
        /// Permite Eliminar un elemento del tipo pasado por parametro
        /// </summary>
        /// <returns>(false) en caso de que no se haya podido dar de Modificacion,(true) de caso contratio</returns>
        public bool Baja(T element);

        /// <summary>
        /// Permite Mostrar los datos de un elemento del tipo pasado por parametro
        /// </summary>
        /// <returns>(false) en caso de que no se haya podido dar de Modificacion,(true) de caso contratio</returns>
        public bool Mostrar(T element);
    }
}
