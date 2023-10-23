using System.Diagnostics;
using System.Text;
using Entidades;
namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("Menu" +
                    "\n1.IngresarDatos" +
                    "\n2.ComprarProductos" +
                    "\n3.OfecerProductos");

                if (int.TryParse(Console.ReadLine(),out option) == true)
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
                                                 +"\n10.Salir");

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

                            do
                            {
                                Console.WriteLine("Menu" +
                                                 "\n1.AgreagarProductos" +
                                                 "\n2.BorrarProducto" +
                                                 "\n3.RealizarCompra" +
                                                 "\n4.CancelarCompra" +
                                                 "\n10.Salir");

                                if (int.TryParse(Console.ReadLine(), out option) == true)
                                {

                                    switch (option)
                                    {
                                        case 1:
                                            break;
                                        
                                        case 2:
                                            break;
                                        
                                        case 3:
                                            break;
                                    }
                                }

                            } while (option != 10);

                            break;



                        default:

                            do
                            {
                                Console.WriteLine("Menu" +
                                                 "\n1.IngresarProductos" +
                                                 "\n2.CargarArchivo" +
                                                 "\n5.Salir");

                                if (int.TryParse(Console.ReadLine(), out option) == true)
                                {

                                    switch (option)
                                    {
                                        case 1:
                                            break;
                                    }
                                }

                            } while (option != 10);

                            break;

                    }
                }
            } while (true);
        }
    }
}