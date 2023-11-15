using Entidades.BaseDeDatos;
using Entidades.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Negocio
    {
        string nombre;
        private List<Usuario> listaDeUsuarios;
        private List<Cliente> listaDeCliente;
        private List<Vehiculo> listaDeVehiculos;
        private Dictionary<Diagnostico,float> listaDiagnostico;
        private List<Servicio> listaDeServicio;
        private Task hiloDeServicio;
        CancellationTokenSource cancellationToken;

        public Negocio(string nombre)
        {
            this.nombre = nombre;
            listaDeServicio = new List<Servicio>();
            listaDeCliente = new List<Cliente>();
            cancellationToken = new CancellationTokenSource();
        }
        
        public Negocio(string nombre,List<Servicio> servicios, List<Cliente> listaDeClientes,List<Vehiculo> listaDeVehiculos):this(nombre)
        {
            this.ListaDeServicio = servicios;
            this.Clientes = listaDeClientes;
            this.ListaDeVehiculos = listaDeVehiculos;
        }

        public Cliente BuscarPorIdCliente(int id)
        {
            return BuscarPorId<Cliente>(this.Clientes, id);
        }
        
        public Mecanico BuscarPorIdMecanico(int id)
        {
            return BuscarPorId<Mecanico>(this.Mecanicos, id);
        }
        private static T BuscarPorId<T>(List<T> listaUsuario, int id)
          where T : Usuario
        {
            T result = default;
            if (listaUsuario is not null)
            {
                result = listaUsuario.Find(unUsuario => unUsuario is not null && unUsuario.Id == id);
            }

            return result;
        }



        public static bool operator +(Negocio unNegocio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && unNegocio is not null  
             && unNegocio.listaDeCliente.Contains(unCliente) == false)
            {
                unNegocio.listaDeCliente.Add(unCliente);
                result = true;
            }


            return result;
        }

        public static bool operator -(Negocio unNegocio, Cliente unCliente)
        {
            bool result = false;

            if (unNegocio is not null && unNegocio.listaDeCliente.Contains(unCliente) == true)
            {
                unNegocio.listaDeCliente.Remove(unCliente);
                result = true;
            }


            return result;
        }

        public static bool operator +(Negocio unNegocio, Servicio unServicio)
        {
            bool result = false;

            if (unNegocio is not null && unServicio is not null
              && unNegocio.ServiciosEnProcesos.Contains(unServicio) == false)
            {
                unNegocio.listaDeServicio.Add(unServicio);
                result = true;
            }


            return result;
        }


        public static bool operator -(Negocio unNegocio, Servicio unServicio)
        {
            bool result = false;

            if (unNegocio is not null && unServicio is not null
              && unNegocio.listaDeServicio.Contains(unServicio) == true)
            {
                unServicio.TerminarServicio();
                result = true;
            }


            return result;
        }

        /// <summary>
        /// C
        /// </summary>
        /// <returns></returns>
        public bool GuardarBaseDeDatos()
        {
            bool estado;
            estado = false;
            try
            {
                new ClienteDao().Agregar(this.listaDeCliente);
                new ServicioDao().Agregar(listaDeServicio);
                new VehiculoDao().Agregar(listaDeVehiculos);
                estado = true;
            }
            catch (ConeccionBaseDeDatosException)
            {
                throw;
            }

            return estado;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

/*        public bool CancelarPartida()
        {
            bool estado = false;

            if (this.hiloDeServicio is not null && this.cancellationToken is not null 
                && this.hiloDeServicio.IsCanceled == false)
            {
                this.cancellationToken.Cancel();
                estado = true;
            }
            return estado;
        }

        
        private async void SimularAtencionDeServicios()
        {
            Servicio unServicio;
            Diagnostico unDiagnostico;
            List<Servicio> servicios = ServiciosEnProcesos;
            if (servicios is not null && servicios.Count > 0)
            {
                while (this.hiloDeServicio.IsCanceled == false && servicios.Count > 0)
                {
                    
                }
            }
        }
        public bool AtenderServicios()
        {
            bool estado;
            estado = false;
            if (this.hiloDeServicio is not null && this.hiloDeServicio.IsCanceled == false)
            {
                this.cancellationToken = new CancellationTokenSource();
                this.hiloDeServicio = Task.Run(SimularAtencionDeServicios, this.cancellationToken.Token);
                estado = true;
            }
            return estado;
        }*/
        public static Cliente unClienteRandom {

            get { ;
                return new Cliente("manuel","123456",DateTime.Now,"manuel@gmail","maurop¿1213");
            }
        }
        
        public static Mecanico unMecanicoRandom
        {

            get { ;
                return new Mecanico("manuel","123456",DateTime.Now,"manuel@gmail","maurop¿1213");
            }
        }

        public enum Diagnostico
        {
            CambioDeRuedas,
            CambioDeFrenos,
            Suspension,
            ReparacionDeMotor,
        }
        public List<Servicio> ListaDeServicio { get => listaDeServicio; set
            {
                this.listaDeServicio = new List<Servicio>();
                if (value is not null)
                {
                    this.listaDeServicio = value;
                }
            }
        }
        public List<Servicio> ServiciosEnProcesos { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.EnProceso); }
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Terminado); }
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Cancelado); }
        public List<Usuario> ListaDeUsuarios { get => listaDeUsuarios;}
        public List<Vehiculo> ListaDeVehiculos { get => listaDeVehiculos; 
            
            set
            {
                this.listaDeVehiculos = new List<Vehiculo>();
                if (value is not null)
                {
                    this.listaDeVehiculos = value;
                }
            }
        }
        public List<Mecanico> Mecanicos { get => Usuario.ObtenerLista<Mecanico>(listaDeUsuarios); }
        public List<Cliente> Clientes { get => this.listaDeCliente; 
            
            set 
            {
                this.listaDeCliente = new List<Cliente>();
                if (value is not null)
                {
                    this.listaDeCliente = value;
                }
            } 
        }
    }
}
