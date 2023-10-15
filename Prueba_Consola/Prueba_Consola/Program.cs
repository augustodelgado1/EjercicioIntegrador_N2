namespace Prueba_Consola
{
    internal class Program
    {
        public delegate void DelegadoNuevo(int a,int b);
        static void Main(string[] args)
        {
            Task task = Task.Run(() => Console.WriteLine("Hoal me estoy")); 
        }
    }
}