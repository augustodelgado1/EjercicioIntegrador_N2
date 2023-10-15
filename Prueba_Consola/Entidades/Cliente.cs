namespace Entidades
{
    public class Cliente:Usuario
    {
        string direccion;
        List<Pedido> pedidos;
        MetodoDePago metodo;
        public Cliente(string nombre, string email, string clave, string path, string direccion) : base(nombre, email, clave, path, Roles.Cliente)
        {
            this.pedidos = new List<Pedido>();
            this.direccion = direccion;
        }

        public enum MetodoDePago
        {
            Efectivo,TargetaDebito,TarjetaCredito
        }
    }
}