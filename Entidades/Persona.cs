using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Usuario;

namespace Entidades
{
    public abstract class Persona:Usuario
    {
        string nombre;
        string dni;
        DateTime fechaDeNacimiento;
        public Persona(string nombre, string dni, DateTime fechaDeNacimiento, string email, string clave, Roles rol, string path = null) 
            : base(email, clave, rol, path)
        {
            this.Nombre = nombre;
            this.Dni = dni;
            this.FechaDeNacimiento = fechaDeNacimiento;
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Persona unPersona
                 && unPersona.dni == this.dni;
        }

        public static bool ValidarDni(string dni)
        {
            return string.IsNullOrWhiteSpace(dni) == false
                 && dni.EsNumerica() == true && dni.Length >= 6
               && dni.Length <= 8;
        }

        public static bool ValidarFechaDeNacimiento(string text)
        {
            throw new NotImplementedException();
        }

        public static bool ValidarFechaDeNacimiento(DateTime value)
        {
            return value.Year != DateTime.Now.Year;
        }

        public static bool ValidarNombre(string text)
        {
            return string.IsNullOrWhiteSpace(text) == false && text.isLetter() == true;
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

        public string Nombre { get => nombre;

            set
            {
                if (ValidarNombre(value))
                {
                    this.nombre = value.ToLower();
                }
            }
        }
    }
}
