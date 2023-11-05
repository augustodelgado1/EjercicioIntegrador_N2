using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades.Interfaces
{
    public interface IConeccionABaseDeDatos<T> 
        where T : class
    {
        public List<T> Leer();
        public T ObtenerUnElemento(SqlDataReader dataRead);
        public bool Agregar(List<T> lista);
        public bool Agregar(T unElemento);
    }
}
