using System.Collections.Generic;
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
        string descripcion;
        List<Diagnostico> diagnosticos;
        EstadoDelSevicio estado;

        public event Action<Diagnostico> seAgregoUnDiagnostico;
        public event Action<Vehiculo> seAgregoUnVehiculo;
        public event Action<Vehiculo> seEliminoUnVehiculo;
        public event Action<Servicio> CambioDeEstadoDeServicio;
        public event Action<Diagnostico> seEliminoUnDiagnostico;

        private Servicio()
        {
            this.id = this.GetHashCode();
            this.diagnosticos = new List<Diagnostico>();
            this.fechaDeEgreso = default;
        }

        public Servicio(string descripcion, Vehiculo unVehiculo):this()
        {
            this.UnVehiculo = unVehiculo;
            this.descripcion = descripcion;
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

        public static List<Servicio> BuscarPorEstado(List<Servicio> listaDeServicios,EstadoDelSevicio estado)
        {
            List<Servicio> result = null;
            if (listaDeServicios is not null)
            {
                result = listaDeServicios.FindAll(unServicio => unServicio is not null && unServicio.Estado == estado);
            }

            return result;
        }
        public void Cancelar()
        {
            this.estado = EstadoDelSevicio.Cancelado;
            this.fechaDeEgreso = DateTime.Now;
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
        
        public static bool operator -(Servicio servicio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (servicio is not null)
            {
                servicio.estado = EstadoDelSevicio.Terminado;
                servicio.fechaDeEgreso = DateTime.Now;
                result = true;
            }


            return result;
        }

        public static bool operator +(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && servicio is not null
            && servicio.unCliente is null)
            {
                servicio.unCliente = unCliente;
                result = true;
            }


            return result;
        }

        public static bool operator -(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

           

            return result;
        }
        public float Cotizacion { get => CalcularCosto(); }
        public EstadoDelSevicio Estado { get => estado; }
        public DateTime FechaDeIngreso { get => fechaDeIngreso; }
        public DateTime FechaDeEgreso { get => fechaDeEgreso;  }
     
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
        public Cliente UnCliente { get => unCliente; }

        public enum EstadoDelSevicio
        {
            EnProceso,
            Cancelado,
            Terminado
        }
    }
}