using System.Runtime.Serialization;

namespace Entidades
{
    public class JsonFileException : Exception
    {
        public JsonFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}