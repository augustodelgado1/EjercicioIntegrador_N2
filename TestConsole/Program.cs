using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using Entidades;
using Entidades.BaseDeDatos;

namespace TestConsole
{
    public static class Program
    {
        static Cliente unCliente;
        static Usuario unUsuario;
        static Vehiculo unVehiculo;
        static Vehiculo otroVehiculo;
        static Program()
        {
            



        }
        static void Main(string[] args)
        {
            int option;
            int index;
            Vehiculo veh;
            
            Servicio ser;
            List<Vehiculo> listaDeVehiculos;


                do
                {
                    Console.WriteLine("Menu"             +
                                    "\n1.Cofiguracion"   +
                                    "\n2.Pedir Servicio" +
                                    "\n3.Diagnosticar"   +
                                    "\n4.Clientes"       +
                                    "\n5.Cambiar de Rol" +
                                    "\n6.ControlBase De Datos" + 
                                    "\n7.Salir");

                    if (int.TryParse(Console.ReadLine(), out option) == true)
                    {
                        switch (option)
                        {
                            case 1:

                                do
                                {
                                    Console.WriteLine("Menu" +
                                                     "\n1.AltaCliente" +
                                                     "\n2.CargarArchivo" +
                                                     "\n3.ModificarDatos"
                                                     + "\n10.Salir");

                                    if (int.TryParse(Console.ReadLine(), out option) == true)
                                    {

                                        switch (option)
                                        {
                                            case 1:
                                                break;

                                            default:
                                                break;
                                        }
                                    }

                                } while (option != 10);

                                break;

                            case 2:
                            unUsuario = Negocio.unClienteRandom;
                            do
                                {
                                    Console.WriteLine("Diagnosticos" +
                                                     "\n1.Cargar Servicios" +
                                                     "\n2.Cancelar Diagnostico" +
                                                     "\n3.Listar Servicios En Procesos" +
                                                     "\n4.Historial de servicios" +
                                                     "\n5.Salir");

                                    if (int.TryParse(Console.ReadLine(), out option) == true)
                                    {

                                        switch (option)
                                        {
                                            case 1:
                                            List<Servicio> lista = new List<Servicio>()
                                            {
                                                new Servicio( "Anda mal el motor", new Vehiculo("4444455", Vehiculo.MarcaDelVehiculo.Golf, Vehiculo.TipoDeVehiculo.Auto, "1789")),
                                                new Servicio( "Anda mal el Auto", new Vehiculo("9999991", Vehiculo.MarcaDelVehiculo.Nissan, Vehiculo.TipoDeVehiculo.Camion, "1233")),
                                                new Servicio("Anda mal el aire", new Vehiculo("6966666", Vehiculo.MarcaDelVehiculo.Golf, Vehiculo.TipoDeVehiculo.Auto, "6652")),
                                            };

                                            foreach (Servicio unServicio in lista)
                                            {
                                                if(((Cliente)unUsuario) + unServicio == false)
                                                {
                                                    Console.WriteLine("No se pudo cargar");
                                                    break;
                                                }
                                            }
                                                break;

                                            case 2:
                                                foreach (Servicio unServicio in ((Cliente)unUsuario).ServiciosEnProcesos)
                                                {
                                                    if (unServicio is not null)
                                                    {
                                                        Console.WriteLine(unServicio.ToString());
                                                    }
                                                }

                                                Console.WriteLine("Ingresa el indice ");
                                                index = int.Parse(Console.ReadLine());
                                                

                                            if((ser = ((Cliente)unUsuario).Servicios.ElementAt(index)) is not null 
                                             && ((Cliente)unUsuario) - ser)
                                            {
                                                Console.WriteLine("Se Cancelo con exito");
                                            }

                                                break;


                                            case 4:

                                            foreach (Servicio unServicio in ((Cliente)unUsuario).Servicios)
                                            {
                                                if (unServicio is not null)
                                                {
                                                    Console.WriteLine(unServicio.ToString());
                                                }
                                            }

                                            break;

                                        }
                                    }

                                } while (option != 10);
                                break;

                            case 3:

                                if (unUsuario is not null && unUsuario.Rol != Usuario.Roles.Cliente)
                                {
                                    do
                                    {
                                        Console.WriteLine("Menu" +
                                                         "\n1.Servicios En Proceso" +
                                                         "\n2.CargarAuto" +
                                                         "\n5.Salir");

                                        if (int.TryParse(Console.ReadLine(), out option) == true)
                                        {

                                            switch (option)
                                            {
                                                case 1:

                                                    foreach (Servicio unServicio in Negocio.ListaDeServicio)
                                                    {
                                                        if (unServicio is not null)
                                                        {
                                                            Console.WriteLine(unServicio.ToString());
                                                        }
                                                    }

                                                    break;

                                                case 2:
                                                    break;
                                            }
                                        }

                                    } while (option != 10);
                                }


                                break;

                            case 4:

                                if (Negocio.ListaDeClientes.Count > 0)
                                {
                                    foreach (Cliente unCliente in Negocio.ListaDeClientes)
                                    {
                                        if (unCliente is not null)
                                        {
                                            Console.WriteLine(unCliente.ToString());
                                        }
                                    }
                                }

                                break;

                        case 5:

                            do
                            {
                                Console.WriteLine("Menu" +
                                                 "\n1.Admin" +
                                                 "\n2.Mecanico" +
                                                 "\n3.Cliente" +
                                                 "\n5.Salir");

                                if (int.TryParse(Console.ReadLine(), out option) == true)
                                {

                                    switch (option)
                                    {
                                        case 1:
                                            unUsuario = Negocio.unClienteRandom;
                                            break;

                                        case 2:
                                            unUsuario = Negocio.unMecanicoRandom;
                                            break;

                                        case 3:
                                            
                                            break;

                                        default:
                                            option = 10;
                                            break;
                                    }
                                }

                            } while (option != 10);


                            break;

                        case 6:
                            do
                            {
                                Console.WriteLine("Menu" +
                                                 "\n1.Leer" +
                                                 "\n2.Agregar" +
                                                 "\n3.Guardar" +
                                                 "\n5.Salir");

                                if (int.TryParse(Console.ReadLine(), out option) == true)
                                {

                                    switch (option)
                                    {
                                        case 1:
                                            try
                                            {
                                                List<Cliente> listaDeCliente = new ClienteDao().Leer();
                                                foreach (Cliente unCliente in listaDeCliente)
                                                {
                                                    Console.WriteLine(unCliente.ToString());
                                                }
                                            }
                                            catch (Exception e)
                                            {

                                                Console.WriteLine(e.Message);
                                            }
                                            
                                            break;

                                        case 2:

                                            try
                                            {
                                                
                                            }
                                            catch (Exception e)
                                            {

                                                Console.WriteLine(e.Message);
                                            }

                                            break;

                                        case 3:

                                            break;

                                        default:
                                            option = 10;
                                            break;
                                    }
                                }

                            } while (option != 10);
                            break;


                            default:
                                option = 7;
                                break;

                        }
                    }
                } while (option != 7);
            
        }

       /* private static List<Vehiculo> CrearUnVehiculoRandom(int cantidad)
        {
            List<Vehiculo> list = null;

            if (cantidad > 0)
            {
                list = new List<Vehiculo>();
                for (int i = 0; i < cantidad; i++)
                {
                    list.Add(CrearUnVehiculoRandom());
                }
            }

            return list;
        }*/
      
    }
}