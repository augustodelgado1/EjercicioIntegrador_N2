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
        List<Vehiculo> vehiculos;
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
            this.vehiculos = new List<Vehiculo>();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Cliente unCliente
                 && unCliente.dni == this.dni;
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
        public static bool operator ==(Cliente unCliente, Servicio unServicio)
        {
            return unCliente.servicios.Contains(unServicio);
        }
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

        [JsonIgnore]
        public List<Servicio> ServiciosEnProcesos { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.EnProceso); }

        [JsonIgnore]
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Terminado); }

        [JsonIgnore]
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Cancelado); }
        [JsonIgnore]
        public List<Vehiculo> Vehiculos { get => vehiculos; }
    }

   
    
}