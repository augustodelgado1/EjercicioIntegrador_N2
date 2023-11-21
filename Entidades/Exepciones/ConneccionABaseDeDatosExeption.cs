using System.Runtime.Serialization;

namespace Entidades.Exepciones
{
    public class ConeccionBaseDeDatosException : Exception
    {
        /// <summary>
        /// Inicializa los valores de la clase 
        /// </summary>
        /// <param name="message">el mensaje que va indicar que exepcion se produjo y porque</param>
        public ConeccionBaseDeDatosException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// Inicializa los valores de la clase 
        /// </summary>
        /// <param name="message">el mensaje que va indicar que exepcion se produjo y porque</param>
        /// <param name="innerException">la exepcion que sucedio</param>
        public ConeccionBaseDeDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}