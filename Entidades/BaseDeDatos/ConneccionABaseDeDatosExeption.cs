using System.Runtime.Serialization;

namespace Entidades.BaseDeDatos
{
    public class ConeccionBaseDeDatosException : Exception
    {
        public ConeccionBaseDeDatosException(string? message) : this(message, null)
        {
        }

        public ConeccionBaseDeDatosException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}