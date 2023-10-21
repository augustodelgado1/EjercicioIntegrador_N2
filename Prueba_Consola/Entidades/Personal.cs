using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor:Usuario
    {
        List<Producto> productos;
        public Proveedor(string nombre, string email, string clave, string path = null) : base(nombre, email, clave, Roles.Vendedor, path)
        {
            this.productos = new List<Producto>();
        }
    }
}
