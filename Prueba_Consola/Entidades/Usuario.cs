using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Usuario
    {
        int id;
        string nombre;
        string email;
        string clave;
        string path;
        Roles rol;

        private Usuario()
        {
            this.id = this.GetHashCode();
        }

        public Usuario(string nombre, string email, string clave, string path, Roles rol):this()
        {
            this.nombre = nombre;
            this.email = email;
            this.clave = clave;
            this.path = path;
            this.rol = rol;
        }
        public override bool Equals(object? obj)
        {
            return obj is Usuario usuario &&
                   this.email == usuario.email &&
                   this.clave == usuario.clave && 
                   this.rol == usuario.rol;
        }

        public static Usuario EncontarUsuario(List<Usuario> listaDeUsuario,string email,string clave)
        {
            Usuario usuario = null;

            if(string.IsNullOrWhiteSpace(email) == false && string.IsNullOrWhiteSpace(clave) == false)
            {
                usuario = listaDeUsuario.Find(unUsuario => unUsuario is not null && unUsuario.email == email && unUsuario.clave == clave);
            }

            return usuario;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public enum Roles
        {
            Cliente,
            Personal,
            Administrador
        }

    }
}
