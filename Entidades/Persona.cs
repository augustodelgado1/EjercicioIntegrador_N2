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

        private static bool ValidarDni(string dni)
        {
            return string.IsNullOrWhiteSpace(dni) == false
                 && dni.EsNumerica() == true && dni.Length >= 6
               && dni.Length <= 8;
        }
        public DateTime FechaDeNacimiento
        {
            get => fechaDeNacimiento;

            set
            {
                this.fechaDeNacimiento = DateTime.MinValue;
                if (value != DateTime.Now)
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

        public string Nombre { get => nombre; set => nombre = value; }
    }
}
