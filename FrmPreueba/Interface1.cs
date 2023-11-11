using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmPreueba
{
    internal interface IAbm<T> where T : class
    {
        public T Alta();
        public T Modificacion(int index);
        public bool Baja(int index);
        public void Mostrar(int index);
    }
}
