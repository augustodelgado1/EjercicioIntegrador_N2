using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using static Entidades.Servicio;

namespace Entidades
{
    public class Cliente: Persona
    {
        List<Servicio> servicios;

        internal Cliente(int id, string nombre, string dni, DateTime fechaDeNacimiento, string email, string clave, string path = null)
            : this(nombre, dni, fechaDeNacimiento, email, clave, path)
        {
            base.id = id;
        }
        public Cliente(string nombre, string dni, DateTime fechaDeNacimiento, string email, string clave, string path = null)
           : base(nombre, dni, fechaDeNacimiento, email, clave,Roles.Cliente, path)
        {
            this.servicios = new List<Servicio>();
        }

        public float CalcularGastosTotales()
        {
            float gastosTotal = 0;  
            if (this.Servicios is not null)
            {
                foreach (Servicio unServicio in this.Servicios)
                {
                    gastosTotal += unServicio.Cotizacion;
                }
            }

            return gastosTotal;
        }

        public static Cliente BuscarPorId(List<Cliente> listaDeCliente, int id)
        {
            Cliente result = null;
            if (listaDeCliente is not null)
            {
                result = listaDeCliente.Find(unCliente => unCliente is not null && unCliente.id == id);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{base.ToString()}");
            stringBuilder.AppendLine($"Dni = {base.Dni}");


            return base.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator +(Cliente unCliente, Servicio unServicio)
        {
            bool result = false;

            if (unCliente is not null && unServicio is not null
              && unCliente.servicios.Contains(unServicio) == false)
            {
                unCliente.servicios.Add(unServicio);
                result = true;
            }


            return result;
        }  

       
        public static bool operator -(Cliente unCliente, Servicio unServicio)
        {
            bool result = false;

            if (unCliente is not null && unServicio is not null 
              && unCliente.servicios.Contains(unServicio) == true)
            {
                unServicio.Cancelar();
                result = true;
            }


            return result;
        }

        public static bool operator +(List<Cliente> listaDeCliente, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && listaDeCliente is not null
             && listaDeCliente.Contains(unCliente) == false)
            {
                listaDeCliente.Add(unCliente);
                result = true;
            }


            return result;
        }

        public static bool operator -(List<Cliente> listaDeCliente, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && listaDeCliente is not null
             && listaDeCliente.Contains(unCliente) == false)
            {
                listaDeCliente.Remove(unCliente);
                result = true;
            }


            return result;
        }
        public List<Servicio> Servicios { get => this.servicios; }
        public int CantidadDeServicios { get => this.servicios.Count; }

/*        [JsonIgnore]
        public List<Servicio> ServiciosEnProcesos { get =>  Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.EnProceso); }

        [JsonIgnore]
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Terminado); }

        [JsonIgnore]
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Cancelado); }
*/
        [JsonIgnore]
        public string Gastos { 
            get 
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("No se realizo gastos");
                float gastos = this.CalcularGastosTotales();
                if (gastos > 0)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(gastos.ToString());
                }

                return stringBuilder.ToString();
            } 
        
        }
    }

   
    
}