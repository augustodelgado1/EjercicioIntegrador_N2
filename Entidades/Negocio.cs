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
            listaDeUsuarios = new List<Usuario>();
            cancellationToken = new CancellationTokenSource();
        }
        
        public Negocio(string nombre,List<Usuario> listaDeUsuarios, List<Cliente> listaDeClientes,List<Vehiculo> listaDeVehiculos, List<Servicio> servicios) :this(nombre)
        {
            this.listaDeUsuarios = listaDeUsuarios;
            this.listaDeServicio = servicios;
            this.listaDeCliente = listaDeClientes;
            this.listaDeVehiculos = listaDeVehiculos;
            this.listaDeUsuarios.AddRange(new List<Cliente>(this.listaDeCliente));
        }

        public static bool operator +(Negocio unNegocio, Usuario unUsuario)
        {
            bool result = false;

            if (unUsuario is not null && unNegocio is not null
             && unNegocio.listaDeUsuarios.Contains(unUsuario) == false)
            {
                unNegocio.listaDeUsuarios.Add(unUsuario);
                result = true;
            }


            return result;
        }

        public static bool operator -(Negocio unNegocio, Usuario unUsuario)
        {
            bool result = false;

            if (unNegocio is not null && unNegocio.listaDeUsuarios.Contains(unUsuario) == true)
            {
                unNegocio.listaDeUsuarios.Remove(unUsuario);
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
        public static bool operator +(Negocio unNegocio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (unNegocio is not null && unVehiculo is not null
              && unNegocio.listaDeVehiculos.Contains(unVehiculo) == false)
            {
                unNegocio.listaDeVehiculos.Add(unVehiculo);
                result = true;
            }


            return result;
        }


        public static bool operator -(Negocio unNegocio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (unNegocio is not null && unVehiculo is not null
              && unNegocio.listaDeVehiculos.Contains(unVehiculo) == true)
            {
                unNegocio.listaDeVehiculos.Remove(unVehiculo);
                result = true;
            }


            return result;
        }

        public Usuario BuscarUsuario(string email,string password)
        {
            return Usuario.EncontarUsuario(this.listaDeUsuarios, email, password);
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
                new ServicioDao().Agregar(listaDeServicio);
                new VehiculoDao().Agregar(listaDeVehiculos);
                new ClienteDao().Agregar(this.listaDeCliente);
                estado = true;
            }
            catch (ConeccionBaseDeDatosException)
            {
                throw;
            }

            return estado;
        } 

        public static Negocio CargarBaseDeDatos(string nombre)
        {
            Negocio unNegocio = default;
            try
            {
                unNegocio = new Negocio(nombre,new UsuarioDao().Leer(), new ClienteDao().Leer(), new VehiculoDao().Leer(), new ServicioDao().Leer());
            }
            catch (Exception ex)
            {
                throw;
            }

            return unNegocio;
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
        
      /*  public static Mecanico unMecanicoRandom
        {

            get { ;
                return new Mecanico("manuel","123456",DateTime.Now,"manuel@gmail","maurop¿1213");
            }
        }*/

        public enum Diagnostico
        {
            CambioDeRuedas,
            CambioDeFrenos,
            Suspension,
            ReparacionDeMotor,
        }
        public List<Servicio> ListaDeServicio { get => listaDeServicio; 
        }
        public List<Servicio> ServiciosEnProcesos { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.EnProceso); }
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Terminado); }
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Cancelado); }
        public List<Usuario> ListaDeUsuarios { get => listaDeUsuarios;}
        public List<Vehiculo> ListaDeVehiculos { get => listaDeVehiculos;
           
        }
        public List<Cliente> Clientes { get => Usuario.ObtenerLista<Cliente>(listaDeUsuarios); }
            
        
    }
}
