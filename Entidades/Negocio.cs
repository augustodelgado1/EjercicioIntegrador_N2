using Entidades.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Negocio
    {
        private static List<Usuario> listaDeUsuarios;
        public static List<Persona> listaDePersona;
        public static List<Cliente> listaDeCliente;
        private static List<Vehiculo> listaDeVehiculos;
        private static List<Diagnostico> listaDiagnostico;
        private static List<Servicio> listaDeServicio;
        private static Usuario unUsuario;
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
        public static List<Cliente> ListaDeClientes { get => Persona.ObtenerLista<Cliente>(listaDeUsuarios); }
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
        
        public static Mecanico unMecanicoRandom {

            get { List<Mecanico> listaDeClientes = ListaDeMecanicos;


                return listaDeClientes.ElementAt(new Random().Next(0, listaDeClientes.Count));
            }
        }
        public static List<Mecanico> ListaDeMecanicos { get => Persona.ObtenerLista<Mecanico>(listaDeUsuarios); }
        public static List<Servicio> ListaDeServicio { get => listaDeServicio; set => listaDeServicio = value; }
        public static Usuario UnUsuario { get => unUsuario; }
        public static List<Diagnostico> ListaDiagnostico { get => listaDiagnostico; set => listaDiagnostico = value; }
        public static List<Usuario> ListaDeUsuarios { get => listaDeUsuarios; set => listaDeUsuarios = value; }
        public static List<Vehiculo> ListaDeVehiculos { get => listaDeVehiculos; set => listaDeVehiculos = value; }

        public static void SetUser(Usuario obj)
        {
            if(obj is not null)
            {
                unUsuario = obj;
            }
        }
    }
}
