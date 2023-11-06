using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Entidades.Servicio;

namespace Entidades
{
    public class Cliente:Usuario
    {
        string dni;
        List<Servicio> servicios;
        public event Action<Cliente,Servicio> SeAgregoUnServicio;
        public event Action<Cliente, Servicio> SeCanceloUnServicio;

        internal Cliente(int id,string nombre, string email, string clave, string dni, string path = null)
            : this(nombre, email, clave,path)
        {
            base.id = id;
        }
        public Cliente(string nombre, string email, string clave, string dni, string path = null) :base(nombre, email, clave, Roles.Cliente, path)
        {
            this.Dni = dni;
            this.servicios = new List<Servicio>();
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
            stringBuilder.AppendLine($"Dni = {this.dni.ToString()}");


            return base.ToString();
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Cliente unCliente 
                 && unCliente.dni == this.dni;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool ValidarDni(string dni)
        {
            return string.IsNullOrWhiteSpace(dni) == false
                 && dni.EsNumerica() == true && dni.Length >= 6 && dni.Length <= 8;
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

        public string Dni { get => this.dni; 
            
            set {
                if (ValidarDni(value))
                {
                    this.dni = value;
                }  
            } 
        }
        internal List<Servicio> Servicios { get => this.servicios; }
        public List<Servicio> ServiciosEnProcesos { get =>  Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.EnProceso); }
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Terminado); }
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(this.servicios, Servicio.EstadoDelSevicio.Cancelado); }
       
    }

   
    
}