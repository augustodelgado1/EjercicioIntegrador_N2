using Entidades.Extension;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using static Entidades.Servicio;

namespace Entidades
{
    public class Cliente: Usuario
    {
        string nombre;
        string dni;
        DateTime fechaDeNacimiento;
        List<Servicio> servicios;
        internal Cliente(int id, string nombre, string dni, DateTime fechaDeNacimiento, string email, string clave, string path = null)
            : this(nombre, dni, fechaDeNacimiento, email, clave, path)
        {
            base.id = id;
        }
        public Cliente(string nombre, string dni, DateTime fechaDeNacimiento, string email, string clave, string path = null)
           : base(email, clave,Roles.Cliente, path)
        {
            this.Nombre = nombre;
            this.Dni = dni;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.servicios = new List<Servicio>();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Cliente unCliente
                 && unCliente.dni == this.dni;
        }


        /// <summary>
        /// Verifica si el dni pasado por parametro contiene solo numeros y si cantidad de numeros ingresada sea menor o igual a 8
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>(true) en caso de cumpla con esas condiciones ,(false) si no conicide</returns>
        public static bool ValidarDni(string dni)
        {
            bool estado;
            estado = false;
            char[] separadores = { ' ', ',', '.', '_', '-' };
            if (!string.IsNullOrWhiteSpace(dni))
            {
                dni = dni.BorrarCaracteres(separadores);
                estado = dni.EsNumerica() == true && dni.Length >= 6
               && dni.Length <= 8;
            }
            return estado;
        }
        /// <summary>
        /// Valida si la fecha de naciomiento pasada por parametro es valida, verificando que no haya nacido en el dia de ahora  
        /// </summary>
        /// <param name="value"></param>
        /// <returns>(true) en caso de cumpla con esas condiciones ,(false) si no conicide</returns>
        public static bool ValidarFechaDeNacimiento(DateTime value)
        {
            return value.Year < DateTime.Now.Year;
        }
        /// <summary>
        /// Verifica si el Nombre pasado por parametro es valido , verificando si contiene solo letras y borrando todos los separadores ingresados
        /// </summary>
        /// <param name="text"></param>
        /// <returns>(true) en caso de cumpla con esas condiciones ,(false) si no conicide</returns>
        public static bool ValidarNombre(string text)
        {
            bool estado;
            estado = false;
            char[] separadores = { ' ', ',', '.', '_', '-' };
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.BorrarCaracteres(separadores);
                estado = text.isLetter() == true;
            }
            return estado;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Verifica si el Servicio se encuntra dentro de la lista de Servicio de la clase Cliente
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="unServicio"></param>
        /// <returns>(false) en caso de que no lo encuentre,(true) de caso contrario</returns>
        public static bool operator ==(Cliente unCliente, Servicio unServicio)
        {
            return unCliente.servicios.Contains(unServicio);
        }
        /// <summary>
        /// Verifica si el Servicio no se encuntra dentro de la lista de Servicio de la clase Cliente
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="unServicio"></param>
        /// <returns>(true) en caso de que no lo encuentre,(false) de caso contrario</returns>
        public static bool operator !=(Cliente unCliente, Servicio unServicio)
        {
            return !(unCliente == unServicio);
        }

        public DateTime FechaDeNacimiento
        {
            get => fechaDeNacimiento;

            set
            {
                this.fechaDeNacimiento = DateTime.MinValue;
                if (ValidarFechaDeNacimiento(value))
                {
                    this.fechaDeNacimiento = value;
                }
            }
        }
        public string Dni
        {
            get => this.dni;

            set
            {
                if (ValidarDni(value))
                {
                    this.dni = value;
                }
            }
        }

        public string Nombre
        {
            get => nombre;

            set
            {
                if (ValidarNombre(value))
                {
                    this.nombre = value.ToLower();
                }
            }
        }
        [JsonIgnore]
        public List<Servicio> Servicios { get => this.servicios; }
        public int CantidadDeServicios { get => this.servicios.Count; }
 
    }

   
    
}