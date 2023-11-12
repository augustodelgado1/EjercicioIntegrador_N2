using Entidades;
using System.Reflection;
using TallerMecanico;

namespace FrmPreueba
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Predicate<PropertyInfo> unPropertyInfoPredicate;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmAltaServicio());
           /* Application.Run(new FrmMostrar(typeof(Cliente), Negocio.unClienteRandom, unPropertyInfoPredicate,"hola"," "));
*/

        }
    }
}