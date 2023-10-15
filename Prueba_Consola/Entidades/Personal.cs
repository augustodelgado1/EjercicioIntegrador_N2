using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personal:Usuario
    {
        public Personal(string nombre, string email, string clave, string path = null) : base(nombre, email, clave, path, Roles.Personal)
        {

        }
    }
}
