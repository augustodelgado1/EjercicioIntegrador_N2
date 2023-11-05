using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Negocio
    {
        public static List<Usuario> listaDeUsuarios;
        public static List<Vehiculo> listaDeVehiculos;
        public static List<Diagnostico> listaDiagnostico;
        public static List<Servicio> listaDeServicio;
        static Negocio()
        {
            listaDiagnostico = new List<Diagnostico>()
            {
                new Diagnostico("CambioDeAceite","cambio de aceite",950),
                new Diagnostico("ReparacionDeMotor","cambio de aceite",1050),
                new Diagnostico("Suspension","cambio de aceite",850),
                new Diagnostico("CambioDeRuedas","cambio de aceite",350),
            };

            listaDeUsuarios = new List<Usuario>()
            {
                  new Cliente("pepe", "pepe@gmail.com", "12345678", "12345678")
                , new Cliente("Mario","Mario@gmail.com", "89998552", "12345678")
                , new Cliente("Pergoline", "Pergoline@gmail.com", "235211", "12345678")
                , new Cliente("juan", "juan@gmail.com", "6351235", "12345678")
                , new Cliente("mauricio", "mauricio@gmail.com", "285521", "12345678")
                , new Cliente("macri", "macri@gmail.com", "269651552", "12345678")
                , new Mecanico("Edu", "Edu@gmail.com", "12345678", "12345678")
                , new Mecanico("Marty", "Marty@gmail.com", "12345678", "12345678")
                , new Mecanico("marlyn", "marlyn@gmail.com", "269651552", "12345678")
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

        public static List<Cliente> ListaDeClientes { get => Usuario.ObtenerLista<Cliente>(listaDeUsuarios); }
        public static Cliente unClienteRandom {

            get { List<Cliente> listaDeClientes = ListaDeClientes;


                return listaDeClientes.ElementAt(new Random().Next(0, listaDeClientes.Count));
            }
        }
        
        public static Mecanico unMecanicoRandom {

            get { List<Mecanico> listaDeClientes = ListaDeMecanicos;


                return listaDeClientes.ElementAt(new Random().Next(0, listaDeClientes.Count));
            }
        }
        public static List<Mecanico> ListaDeMecanicos { get => Usuario.ObtenerLista<Mecanico>(listaDeUsuarios); }
        public static List<Servicio> ListaDeServicio { get => listaDeServicio; set => listaDeServicio = value; }
    }
}
