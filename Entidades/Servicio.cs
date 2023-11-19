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
        DateTime fechaDeIngreso;
        DateTime fechaDeEgreso;
        string descripcionDelProblema;
        Diagnostico diagnostico;
        EstadoDelSevicio estado;
        float costo;

        private Servicio()
        {
            this.fechaDeEgreso = default;
            this.diagnostico = Diagnostico.NoDeterminado;
        }

        public Servicio(string descripcion, Vehiculo unVehiculo) : this()
        {
            this.UnVehiculo = unVehiculo;
            this.descripcionDelProblema = descripcion;
        }

        internal Servicio(int id, string descripcion,
            DateTime fechaDeIngreso, DateTime fechaDeEgreso,
            Vehiculo unVehiculo, Cliente unCliente, EstadoDelSevicio estado) : this(descripcion, unVehiculo)
        {
            this.id = id;
            this.FechaDeIngreso = fechaDeIngreso;
            this.FechaDeEgreso = fechaDeEgreso;
            this.UnCliente = unCliente;
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
        public override bool Equals(object? obj)
        {
            return obj is Servicio servicio &&
                   this.id == servicio.id
                   && this.unVehiculo.Equals(servicio.unVehiculo);
        }
        public static bool operator +(Servicio servicio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (unVehiculo is not null && servicio is not null
             && servicio.Estado == EstadoDelSevicio.EnProceso
             && unVehiculo.Estado != EstadoDeVehiculo.Diagnosticado)
            {
                servicio.unVehiculo = unVehiculo;
                servicio.fechaDeIngreso = DateTime.Now;
                unVehiculo.Estado = EstadoDeVehiculo.Diagnosticado;
                result = true;
            }


            return result;
        }

        internal void TerminarServicio()
        {
            this.estado = EstadoDelSevicio.Terminado;
            this.fechaDeEgreso = DateTime.Now;
            this.UnVehiculo.Estado = EstadoDeVehiculo.NoDiagnosticado;
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
                unCliente.Servicios.Remove(servicio);
                result = true;
            }


            return result;
        }

        internal int Id { get => id; }
        public float Cotizacion { get => costo; set => this.costo = value; }
        public string CotizacionStr {
            get 
            { 
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Costo {this.costo}");
                if (this.costo == 0)
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine("No Determinada");
                }
            
                return stringBuilder.ToString();
            }
        }
        public EstadoDelSevicio Estado { get => estado; set => estado = value; }
        public DateTime FechaDeIngreso { get => fechaDeIngreso; private set => this.fechaDeIngreso = value; }
        public DateTime FechaDeEgreso { get => fechaDeEgreso; private set => this.fechaDeEgreso = value; }
        public Diagnostico Diagnistico 
        {
            set { this.diagnostico = value; }
            get
            {
                return this.diagnostico;
            }
        }

        public Vehiculo UnVehiculo { get => unVehiculo;
            
            set
            {
                if(this + value)
                {
                    this.unVehiculo = value;
                }
            }
        
        }
        public string Problema { get => descripcionDelProblema; set => descripcionDelProblema = value; }
        public Cliente UnCliente { get => unCliente;

             set
            {
                if (this + value)
                { 
                    this.unCliente = value;
                }
            }
        }
 

        public enum EstadoDelSevicio
        {
            EnProceso,
            Cancelado,
            Terminado
        }

        public enum Diagnostico
        {
            NoDeterminado,
            CambioDeRuedas,
            CambioDeFrenos,
            Suspension,
            ReparacionDeMotor,
        }
    }
}