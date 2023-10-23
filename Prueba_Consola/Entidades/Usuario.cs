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
        string user;
        string email;
        string clave;
        string path;
        Roles rol;
        private Usuario()
        {
            this.id = this.GetHashCode();
        }

        public Usuario(string user, string email, string clave, Roles rol,string path = null) :this()
        {
            this.User = user;
            this.Email = email;
            this.Clave = clave;
            this.path = path;
            this.rol = rol;
        }
        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   this.email == usuario.email &&
                   this.clave == usuario.clave;
        }

        public static bool ValidarContracenia(string contracenia)
        {
            return string.IsNullOrWhiteSpace(contracenia) == false && contracenia.Length >= 8
             && contracenia.Length <= 30;
        }

        public static List<T> ObtenerLista<T>()
            where T : Usuario
        {
            List<T> listaDeUsuarios = new List<T>();

            foreach (Usuario UnUsuario in listaDeUsuarios)
            {
                if (UnUsuario is not null &&
               UnUsuario.GetType() == typeof(T))
                {
                    listaDeUsuarios.Add(((T)UnUsuario));
                }
            }

            return listaDeUsuarios;
        }

        public static bool ValidarUser(string user)
        {
            bool estado = false;
            if(string.IsNullOrWhiteSpace(user) == false)
            {
                user = user.Trim();
                user = user.ToLower();
                estado = user.Length >= 3 && user.Length <= 25
                 && user.EsAlphaNumerica() && user.Count(char.IsLetter) >= 3;
            }
           
            return estado;
        }

        private bool ValidarEmail(string email)
        {
            List<Char> listaDeCaracteres = new List<Char>()
            {
                '.','_','-','@','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','0',
                '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            
            bool estado = false;
            if (string.IsNullOrWhiteSpace(user) == false)
            {
                email = email.ToLower();
                email = email.Trim();
                estado = user.Length >= 3 && user.Length <= 25
                 && user.VerificarCaracteres(listaDeCaracteres) == true;
            }

            return estado;
        }
        public static Usuario EncontarUsuario(List<Usuario> listaDeUsuario,string email,string clave)
        {
            return listaDeUsuario.Find(unUsuario => unUsuario is not null 
            && unUsuario.email == email && unUsuario.clave == clave); ;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string Email
        {
            get { return this.email; }


            set
            {
                if (ValidarEmail(value))
                {
                    this.email = value;
                }

            }
        }

        public string Clave
        {

            set
            {
                if (ValidarContracenia(value))
                {
                    this.clave = value;
                }
            }
        }
        public string User
        {
            get => user;
            set
            {
                if (ValidarUser(value))
                {
                    this.user = value;
                }
            }
        }

        public string Path { get => path; set => path = value; }

        public enum Roles
        {
            Cliente,
            Vendedor,
            Administrador
        }

    }
}
