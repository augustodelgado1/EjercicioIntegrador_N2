using Interfaz;
using Entidades;
namespace TallerMecanico
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FrmLogin frmLogin = new FrmLogin();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            frmLogin.loginUser += Negocio.SetUser;
            Application.Run(frmLogin);
        }
    }
}