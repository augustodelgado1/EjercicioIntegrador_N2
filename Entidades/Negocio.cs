using Entidades.BaseDeDatos;
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
        private static List<Usuario> listaDeUsuarios;
        private static List<Persona> listaDePersona;
        private static List<Cliente> listaDeCliente;
        private static List<Vehiculo> listaDeVehiculos;
        private static List<Diagnostico> listaDiagnostico;
        private static List<Servicio> listaDeServicio;
        private Task hiloDeServicio;
        CancellationTokenSource cancellationToken;

        public Negocio()
        {
            cancellationToken = new CancellationTokenSource();
        }
        static Negocio()
        {
            listaDeCliente = new List<Cliente>();
            listaDeUsuarios = new List<Usuario>();
            try
            {
                listaDeCliente.AddRange(new ClienteDao().Leer());
                listaDeUsuarios.AddRange(new MecanicoDao().Leer());
                listaDeVehiculos = new VehiculoDao().Leer();
                listaDiagnostico = new DignosticoDao().Leer();
                listaDeServicio = new ServicioDao().Leer();
                new ServicioDao().LeerBaseDeDatosRelacionalServicio_Diagnostico();
            }
            catch (ConeccionBaseDeDatosException)
            {
               
            }

            listaDeUsuarios = new List<Usuario>()
            {
                /*  new Cliente("pepe", "pepe@gmail.com", "12345678", "12345678")
                , new Cliente("Mario","Mario@gmail.com", "89998552", "12345678")
                , new Cliente("Pergoline", "Pergoline@gmail.com", "235211", "12345678")
                , new Cliente("juan", "juan@gmail.com", "6351235", "12345678")
                , new Cliente("mauricio", "mauricio@gmail.com", "285521", "12345678")
                , new Cliente("macri", "macri@gmail.com", "269651552", "12345678")
                , new Mecanico("Edu", "Edu@gmail.com", "12345678", "12345678")
                , new Mecanico("Marty", "Marty@gmail.com", "12345678", "12345678")
                , new Mecanico("marlyn", "marlyn@gmail.com", "269651552", "12345678")*/
            };

            listaDeVehiculos = new List<Vehiculo>()
            {
                new Vehiculo("1234567", Vehiculo.MarcaDelVehiculo.Golf, Vehiculo.TipoDeVehiculo.Auto, "966"),
                new Vehiculo("1238567", Vehiculo.MarcaDelVehiculo.Toyota, Vehiculo.TipoDeVehiculo.Moto, "633"),
                new Vehiculo("8593521", Vehiculo.MarcaDelVehiculo.VolgVagen, Vehiculo.TipoDeVehiculo.Moto, "633"),
                new Vehiculo("4444455", Vehiculo.MarcaDelVehiculo.Golf, Vehiculo.TipoDeVehiculo.Auto, "1789"),
                new Vehiculo("9999991", Vehiculo.MarcaDelVehiculo.Nissan, Vehiculo.TipoDeVehiculo.Camion, "1233"),
                new Vehiculo("6966666", Vehiculo.MarcaDelVehiculo.Golf, Vehiculo.TipoDeVehiculo.Auto, "6652")
            };



        }

        public static bool operator +(Negocio unNegocio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && unNegocio is not null  
             && Negocio.listaDeCliente.Contains(unCliente) == false)
            {
                Negocio.listaDeCliente.Add(unCliente);
                result = true;
            }


            return result;
        }

        public static bool operator -(Negocio unNegocio, Cliente unCliente)
        {
            bool result = false;

            if (unNegocio is not null && listaDeCliente.Contains(unCliente) == true)
            {
                listaDeCliente.Remove(unCliente);
                result = true;
            }


            return result;
        }

        public static bool operator +(Negocio unNegocio, Servicio unServicio)
        {
            bool result = false;

            if (unNegocio is not null && unServicio is not null
              && Negocio.listaDeServicio.Contains(unServicio) == false)
            {
                Negocio.listaDeServicio.Add(unServicio);
                result = true;
            }


            return result;
        }


        public static bool operator -(Negocio unNegocio, Servicio unServicio)
        {
            bool result = false;

            if (unNegocio is not null && unServicio is not null
              && Negocio.listaDeServicio.Contains(unServicio) == true)
            {
                unServicio.TerminarServicio();
                result = true;
            }


            return result;
        }
        private bool GuardarBaseDeDatos()
        {
            bool estado;
            estado = false;
            try
            {
                new ClienteDao().Agregar(listaDeCliente);
                new ServicioDao().Agregar(listaDeServicio);
                new DignosticoDao().Agregar(listaDiagnostico);
                new VehiculoDao().Agregar(listaDeVehiculos);
             /*   new MecanicoDao().Agregar(lis);*/
                estado = true;
            }
            catch (ConeccionBaseDeDatosException)
            {
               
            }

            return estado;
        } 
        
        private bool CargarBaseDeDatos()
        {
            bool estado;
            estado = false;
            try
            {
                listaDeCliente = new ClienteDao().Leer();
                listaDeUsuarios.AddRange(new MecanicoDao().Leer());
                listaDeVehiculos = new VehiculoDao().Leer();
                listaDiagnostico = new DignosticoDao().Leer();
                listaDeServicio = new ServicioDao().Leer();
                new ServicioDao().LeerBaseDeDatosRelacionalServicio_Diagnostico();
            }
            catch (ConeccionBaseDeDatosException)
            {

            }

            return estado;
        }
        public bool CancelarPartida()
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
                    unServicio = servicios.ElementAt(new Random().Next(0, servicios.Count));
                    unDiagnostico = listaDiagnostico.ElementAt(new Random().Next(0, listaDiagnostico.Count));
                    await Task.Delay(3000);

                    if (unServicio + unDiagnostico)
                    {

                    }
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
        }
        public static List<Cliente> Clientes { get => listaDeCliente; }
        public static Cliente unClienteRandom {

            get { ;
                Cliente unCliente = default;
                if(listaDeCliente is not null && listaDeCliente.Count > 0)
                {
                    unCliente = listaDeCliente.ElementAt(new Random().Next(0, listaDeCliente.Count));
                }
                return unCliente;
            }
        }
       
        public static List<Servicio> ListaDeServicio { get => listaDeServicio; set => listaDeServicio = value; }
       
        [JsonIgnore]
        public List<Servicio> ServiciosEnProcesos { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.EnProceso); }

        [JsonIgnore]
        public List<Servicio> ServiciosTerminados { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Terminado); }

        [JsonIgnore]
        public List<Servicio> ServiciosCancelado { get => Servicio.BuscarPorEstado(listaDeServicio, Servicio.EstadoDelSevicio.Cancelado); }

        public static List<Diagnostico> ListaDiagnostico { get => listaDiagnostico; set => listaDiagnostico = value; }
        public static List<Usuario> ListaDeUsuarios { get => listaDeUsuarios; set => listaDeUsuarios = value; }
        public static List<Vehiculo> ListaDeVehiculos { get => listaDeVehiculos; set => listaDeVehiculos = value; }

    }
}
