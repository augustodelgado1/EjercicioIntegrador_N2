using System.Runtime.Serialization;

namespace Entidades
{
    public class SerializarException : Exception
    {
        public SerializarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}