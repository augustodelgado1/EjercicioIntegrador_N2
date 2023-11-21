using System.Runtime.Serialization;

namespace Entidades.Exepciones
{
    /// <summary>
    /// indica si sucedió algún error a la hora de carga los datos de un archivo 
    /// </summary>
    public class JsonFileException : Exception
    {
        /// <summary>
        /// Inicializa los valores de la clase 
        /// </summary>
        /// <param name="message">el mensaje que va indicar que exepcion se produjo y porque</param>
        /// <param name="innerException">la exepcion que sucedio</param>
        public JsonFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}