using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Entidades.Usuario;
using static System.Net.Mime.MediaTypeNames;

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
        public static bool ValidarFechaDeNacimiento(DateTime value)
        {
            return value.Year < DateTime.Now.Year;
        }

        public static bool ValidarNombre(string text)
        {
            bool estado;
            estado = false;
            char[] separadores = { ' ' ,',','.', '_' , '-' };
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.BorrarCaracteres(separadores);
                estado = text.isLetter() == true;
            }
            return estado;
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
