using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Entidades.Extension;

namespace Entidades
{
    [JsonSerializable(typeof(Cliente))] 
    public class Usuario
    {
        protected int id;
        string email;
        string clave;
        string path;
        Roles rol;
        private Usuario()
        {
            this.id = this.GetHashCode();
        }
        public Usuario(string email, string clave, Roles rol,string path = null):this()
        {
            this.Email = email;
            this.Clave = clave;
            this.path = path;
            this.rol = rol;
        }
        /// <summary>
        /// Verifica si el string pasado por parametro cumple con las condiciones para que sea un contracenia, 
        /// verificando que tenga al menos 8 caracteres
        /// </summary>
        /// <param name="contracenia"></param>
        /// <returns>(true) si el contracenia cumple con las condiciones , (false) de caso contrario</returns>
        public static bool ValidarContracenia(string contracenia)
        {
            return string.IsNullOrWhiteSpace(contracenia) == false && contracenia.Length >= 8
             && contracenia.Length <= 30;
        }
        /// <summary>
        /// Verifica si el string pasado por parametro cumple con las condiciones para que sea un email , permitiedole caracteres alphanumericos 
        /// y que obligatoriamente tenega un @  
        /// </summary>
        /// <param name="email"></param>
        /// <returns>(true) si el email cumple con las condiciones , (false) de caso contrario</returns>
        public static bool ValidarEmail(string email)
        {
            List<Char> listaDeCaracteres = new List<Char>()
            {
                '.','_','-','@','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','0',
                '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            char[] separadores = { ' ', ','};
            bool estado = false;
            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.ToLower();
                email = email.BorrarCaracteres(separadores);
                estado = email.Length >= 3 && email.Length <= 25
                 && email.VerificarCaracteres(listaDeCaracteres) == true 
                 && email.Count(char.IsLetter) >= 5 && email.Contains('@');
            }

            return estado;
        }
        /// <summary>
        /// Busca en la lista de usuario si hay un usuario que coicida con el email y la clave pasados por parametro
        /// </summary>
        /// <param name="listaDeUsuario"></param>
        /// <param name="email"></param>
        /// <param name="clave"></param>
        /// <returns>(NULL) en caso de que no coincida con ningun elemnto de la lista ,(Usuario) en caso de uqe haya en encontrado un usuario que coincida</returns>
        public static Usuario EncontarUsuario(List<Usuario> listaDeUsuario,string email,string clave)
        {
            Usuario unUsuario = null;
            if (listaDeUsuario is not null)
            {
                unUsuario = listaDeUsuario.Find(unUsuario => unUsuario is not null && unUsuario.email == email && unUsuario.clave == clave);
            }
            return unUsuario; 
        }
        public override bool Equals(object? obj)
        {
            return obj is Usuario usuario &&
                   this.email == usuario.email &&
                   this.clave == usuario.clave;
        }
        /// <summary>
        /// Busca si la lista de usuario contiene algun elemento del tipo pasado por parametro que herede de usuario y 
        /// devuelve una lista del tipo con los elementos
        /// </summary>
        /// <typeparam name="T">el tipo a buscar que debe heredar de usuarios</typeparam>
        /// <param name="list"></param>
        /// <returns>(lIST<T>) una lista con los elementos encontrados </returns>
        public static List<T> ObtenerLista<T>(List<Usuario> list)
            where T : Usuario
        {
            List<T> listaDeUsuarios = new List<T>();

            if (list is not null && list.Count > 0)
            {

                foreach (Usuario UnUsuario in list)
                {
                    if (UnUsuario is not null &&
                   UnUsuario.GetType() == typeof(T))
                    {
                        listaDeUsuarios.Add(((T)UnUsuario));
                    }
                }
            }

            return listaDeUsuarios;
        }
        /// <summary>
        /// busca en lista de usuario que elementos coiciden con el rol pasado por parametro y los guarda en una lista
        /// </summary>
        /// <param name="listaDeUsuarios"></param>
        /// <param name="unRol"></param>
        /// <returns>(NULL) en caso de que no coincida con ningun elemnto de la lista , (List<Usuario>) con los elementos que coincide</returns>
        public static List<Usuario> FiltarPorRol(List<Usuario> listaDeUsuarios, Roles unRol)
        {
            List<Usuario> result = null;
            if (listaDeUsuarios is not null)
            {
                result = listaDeUsuarios.FindAll(unUsuario => unUsuario is not null && unUsuario.Rol == unRol);
            }
            return result;
        }

        /// <summary>
        /// Busca en lista de usuario si un elemento coicide con el rol pasado por parametro 
        /// </summary>
        /// <param name="listaDeUsuarios"></param>
        /// <param name="unRol"></param>
        /// <returns>(NULL) en caso de que no coincida con ningun elemnto de la lista ,(Usuario) en caso de uqe haya en encontrado un usuario que coincida</returns>
        public static Usuario ObtenerUnUsuarioPorRol(List<Usuario> listaDeUsuarios, Roles unRol)
        {
            List<Usuario> result = null;
            Usuario unUsuario = null;
            if ((result = Usuario.FiltarPorRol(listaDeUsuarios, unRol)) is not null && result.Count > 0)
            {
                unUsuario = result.First();
            }
            return unUsuario;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        internal int Id { get => id; }
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
            get => this.clave;
            internal set
            {
                if (ValidarContracenia(value))
                {
                    this.clave = value;
                }
            }
        }
        public string Path { get => path; set => path = value; }
        public Roles Rol { get => rol;  }

        public enum Roles
        {
            Cliente = 3,
            Personal = 2,
        }

    }
}
