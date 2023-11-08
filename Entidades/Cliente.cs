using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Entidades.Servicio;

namespace Entidades
{
    public class Cliente: Persona
    {
        List<Servicio> servicios;
        public event Action<Cliente,Servicio> SeAgregoUnServicio;
        public event Action<Cliente, Servicio> SeCanceloUnServicio;

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

      

        private void OnSeAgregoUnServicio(Servicio unServicio)
        {
            if (this.SeAgregoUnServicio is not null)
            {
                this.SeAgregoUnServicio(this, unServicio);
            }
        }
        
        private void OnSeCanceloUnServicio(Servicio unServicio)
        {
            if (this.SeCanceloUnServicio is not null)
            {
                this.SeCanceloUnServicio(this,unServicio);
            }
        }

        public static bool operator +(Cliente unCliente, Servicio unServicio)
        {
            bool result = false;

            if (unCliente is not null && unServicio is not null
              && unCliente.servicios.Contains(unServicio) == false)
            {
                unCliente.servicios.Add(unServicio);
                unCliente.OnSeAgregoUnServicio(unServicio);
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
                unCliente.OnSeCanceloUnServicio(unServicio);
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

       
        internal List<Servicio> Servicios { get => this.servicios; }
        public List<Servicio> ServiciosEnProcesos { get =>  Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.EnProceso); }
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Terminado); }
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Cancelado); }
        public float Gastos { get => CalcularGastosTotales(); }
    }

   
    
}