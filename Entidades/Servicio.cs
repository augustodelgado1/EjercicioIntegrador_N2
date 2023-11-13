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
        Mecanico unMecanico;
        Vehiculo unVehiculo;
        DateTime fechaDeIngreso;
        DateTime fechaDeEgreso;
        string descripcion;
        List<Diagnostico> diagnosticos;
        EstadoDelSevicio estado;

        private Servicio()
        {
            this.id = this.GetHashCode();
            this.diagnosticos = new List<Diagnostico>();
            this.fechaDeEgreso = default;
        }

        public Servicio(string descripcion, Vehiculo unVehiculo) : this()
        {
            this.UnVehiculo = unVehiculo;
            this.descripcion = descripcion;
        }

        internal Servicio(int id, string descripcion,
            DateTime fechaDeIngreso, DateTime fechaDeEgreso,
            Vehiculo unVehiculo, Cliente unCliente, EstadoDelSevicio estado, Mecanico unMecanico = null) : this(descripcion, unVehiculo)
        {
            this.id = id;
            this.FechaDeIngreso = fechaDeIngreso;
            this.FechaDeEgreso = fechaDeEgreso;
            this.UnCliente = unCliente;
            this.estado = estado;
            this.UnMecanico = unMecanico;

        }

        private float CalcularCosto()
        {
            float costo = 0;
            if (this.diagnosticos is not null && this.diagnosticos.Count > 0)
            {
                foreach (Diagnostico unDiagnostico in this.diagnosticos)
                {
                    costo += unDiagnostico.Costo;
                }
            }

            return costo;
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
        internal void Cancelar()
        {
            this.TerminarServicio();
            this.estado = EstadoDelSevicio.Cancelado;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is Servicio servicio &&
                   this.id == servicio.id
                   && this.unVehiculo.Equals(servicio.unVehiculo);
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"fechaDeIngreso = {this.fechaDeIngreso}");
            stringBuilder.AppendLine($"fechaDeEgreso = {this.fechaDeEgreso}");
            stringBuilder.AppendLine($"descripcion = {this.descripcion}");
            stringBuilder.AppendLine($"estado = {this.estado}");

            return stringBuilder.ToString();
        }
        public static bool operator +(Servicio servicio, Diagnostico unDiagnostico)
        {
            bool result = false;

            if (servicio is not null && servicio.diagnosticos.Contains(unDiagnostico) == false)
            {
                servicio.diagnosticos.Add(unDiagnostico);
                result = true;
            }


            return result;
        } 
        
        public static bool operator -(Servicio servicio, Diagnostico unDiagnostico)
        {
            bool result = false;

            if (servicio is not null && servicio.diagnosticos.Contains(unDiagnostico) == true)
            {
                servicio.diagnosticos.Remove(unDiagnostico);
                result = true;
            }


            return result;
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
            && servicio.unCliente + servicio)
            {
                servicio.unCliente = unCliente;
                result = true;
            }


            return result;
        }

        internal int Id { get => id; }
        internal float Cotizacion { get => CalcularCosto(); }
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

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Cliente UnCliente { get => unCliente;

            internal set
            {
                if (this + value)
                { 
                    this.unCliente = value;
                }
            }
        }

        internal List<Diagnostico> Diagnosticos { get => diagnosticos;  }
        
        public Mecanico UnMecanico { get => unMecanico;

            set
            {
               this.unMecanico = value;
               
            }
        }

        public string MecanicoAsignado
        {
            get
            {
                string respuesta;
                respuesta = "No Asignado";
                
                if (this.unMecanico is not null)
                {
                    respuesta = this.unMecanico.Nombre;
                }

                return respuesta;
            }
        }

        public enum EstadoDelSevicio
        {
            EnProceso,
            Cancelado,
            Terminado
        }
    }
}