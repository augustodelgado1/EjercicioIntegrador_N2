using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Negocio
    {
        static List<Usuario> listaDeUsuarios;
        static List<Producto> listaDeProductos;
        
        static Negocio()
        {
            listaDeProductos = new List<Producto>() { };
            listaDeUsuarios = new List<Usuario>() { };
        }
        public static List<Producto> ListaDeProductos { get => listaDeProductos; set => listaDeProductos = value; }
        public static List<Cliente> ListaDeClientes { get => Usuario.ObtenerLista<Cliente>(); }
        public static List<Proveedor> ListaDeProveedores { get => Usuario.ObtenerLista<Proveedor>(); }

    }
}
