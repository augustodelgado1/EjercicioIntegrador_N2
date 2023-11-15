using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IAbm<T> where T : class
    {
        public T Alta();
        public bool Modificacion(T element);
        public bool Baja(T element);
        public bool Mostrar(T element);
    }
}
