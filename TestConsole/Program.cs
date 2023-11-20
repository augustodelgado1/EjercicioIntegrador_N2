using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using Entidades;
using Entidades.Archivo;
using Entidades.BaseDeDatos;

namespace TestConsole
{
    public static class Program
    {
        static Vehiculo unVehiculo;
        static List<Vehiculo> Vehiculos;
        static List<Cliente> Clientes;
        static List<Servicio> servicios;
        static Program()
        {
          /*  Clientes = new ClienteDao().Leer();*/
            Vehiculos = new VehiculoDao().Leer();
            servicios = new ServicioDao().Leer();


            int uno = servicios.Count;
        }
        static void Main(string[] args)
        {
            


            
        }

    }
}