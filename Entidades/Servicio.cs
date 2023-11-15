using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Entidades.Vehiculo;

namespace Entidades
{
    public class Servicio
    {
        int id;
        Cliente unCliente;
        Vehiculo unVehiculo;
        Mecanico unMecanico;
        DateTime fechaDeIngreso;
        DateTime fechaDeEgreso;
        string descripcionDelProblema;
        Dictionary<Diagnostico,float> diagnosaciones;
        EstadoDelSevicio estado;

        private Servicio()
        {
            this.fechaDeEgreso = default;
            this.diagnosaciones = new Dictionary<Diagnostico, float>();
        }

        public Servicio(string descripcion, Vehiculo unVehiculo) : this()
        {
            this.UnVehiculo = unVehiculo;
            this.descripcionDelProblema = descripcion;
        }

        internal Servicio(int id, string descripcion,
            DateTime fechaDeIngreso, DateTime fechaDeEgreso,
            Vehiculo unVehiculo, Cliente unCliente, EstadoDelSevicio estado,Mecanico unMecanico) : this(descripcion, unVehiculo)
        {
            this.id = id;
            this.FechaDeIngreso = fechaDeIngreso;
            this.FechaDeEgreso = fechaDeEgreso;
            this.UnCliente = unCliente;
            this.UnMecanico = unMecanico;
            this.estado = estado;
        }
        public static List<Servicio> BuscarPorEstado(List<Servicio> listaDeServicios, EstadoDelSevicio estado)
        {
            List<Servicio> result = null;
            if (listaDeServicios is not null)
            {
                result = listaDeServicios.FindAll(unServicio => unServicio is not null && unServicio.Estado == estado);
            }

            return result;
        }

        public static Servicio BuscarPorId(List<Servicio> listaDeServicios, int id)
        {
            Servicio result = null;
            if (listaDeServicios is not null)
            {
                result = listaDeServicios.Find(unServicio => unServicio is not null && unServicio.id == id);
            }

            return result;
        }
        public override bool Equals(object? obj)
        {
            return obj is Servicio servicio &&
                   this.id == servicio.id
                   && this.unVehiculo.Equals(servicio.unVehiculo);
        }
        public static bool operator +(Servicio servicio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (unVehiculo is not null && (unVehiculo.Servicio = servicio) is not null)
            {
                servicio.unVehiculo = unVehiculo;
                servicio.fechaDeIngreso = DateTime.Now;
                servicio.estado = EstadoDelSevicio.EnProceso;
                result = true;
            }


            return result;
        }
        internal void TerminarServicio()
        {
            this.estado = EstadoDelSevicio.Terminado;
            this.fechaDeEgreso = DateTime.Now;
        }
        public static bool operator +(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && servicio is not null
            && unCliente != servicio && servicio.estado == EstadoDelSevicio.EnProceso)
            {
                unCliente.Servicios.Add(servicio);
                servicio.unCliente = unCliente;
                result = true;
            }


            return result;
        } 
        public static bool operator -(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && servicio is not null
            && unCliente == servicio)
            {
                servicio.TerminarServicio();
                servicio.estado = EstadoDelSevicio.Cancelado;
                result = true;
            }


            return result;
        }

        internal int Id { get => id; }
        internal float Cotizacion { get => this.CalcularCostos(); }
        public string CotizacionStr { 
            
            get 
            { 
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Costo {this.Cotizacion}");
                if (this.Cotizacion == 0)
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine("No Determinada");
                }
            
                return stringBuilder.ToString();
            }
        }

        private float CalcularCostos()
        {
            float result = 0;
            if (this.diagnosaciones is not null)
            {
                foreach (KeyValuePair<Diagnostico, float> unDiagnostico in this.diagnosaciones)
                {
                    result += unDiagnostico.Value;
                }
            }

            return result;
        }
        public EstadoDelSevicio Estado { get => estado; }
        public DateTime FechaDeIngreso { get => fechaDeIngreso; private set => this.fechaDeIngreso = value; }
        public DateTime FechaDeEgreso { get => fechaDeEgreso; private set => this.fechaDeEgreso = value; }

        public Vehiculo UnVehiculo { get => unVehiculo;
            
            private set
            {
                if(this + value)
                {
                    this.unVehiculo = value;
                }
            }
        
        }

        public string Problema { get => descripcionDelProblema; set => descripcionDelProblema = value; }
        public Cliente UnCliente { get => unCliente;

            internal set
            {
                if (this + value)
                { 
                    this.unCliente = value;
                }
            }
        }
        public object MecanicoAsignado {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("No Determinado");

                if (this.unMecanico is not null)
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine($"{this.unMecanico.Nombre}");
                }

                return stringBuilder.ToString();
            }
        }
        public Mecanico UnMecanico { get => unMecanico; set => unMecanico = value; }

        public enum EstadoDelSevicio
        {
            EnProceso,
            Cancelado,
            Terminado
        }

        public enum Diagnostico
        {
            CambioDeRuedas,
            CambioDeFrenos,
            Suspension,
            ReparacionDeMotor,
        }
    }
}