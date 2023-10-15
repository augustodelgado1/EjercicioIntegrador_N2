using System.Text;

namespace Entidades
{
    internal class Pedido
    {
        int id;
        Cliente cliente;
        DateTime fechaDePedido;
        Dictionary<Producto,int> productos;
        float cotizacion;
        EstadoDelPedido estado;

        private Pedido()
        {
            this.id = this.GetHashCode();
            this.cotizacion = 0;
            this.productos = new Dictionary<Producto, int>();
            this.estado = EstadoDelPedido.EnCamino;
        }

        public Pedido(Cliente cliente, DateTime fechaDePedido) : this()
        {
            this.cliente = cliente;
            this.fechaDePedido = fechaDePedido;
        }

        private float CalcularCosto()
        {
            float costo = 0;
            if (this.productos is not null && this.productos.Count > 0)
            {
                foreach (KeyValuePair<Producto,int>  unProducto in this.productos)
                {
                    costo += unProducto.Key.Costo * unProducto.Value;
                }
            }

            return costo;
        }

        private string ObtenerProductos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("la lista esta vacia");

            if (this.productos is not null && this.productos.Count > 0)
            {
                stringBuilder.Clear();
                stringBuilder.AppendLine("Productos: ");
                foreach (KeyValuePair<Producto, int> unProducto in this.productos)
                {
                    stringBuilder.AppendLine(unProducto.Key.ToString());
                    stringBuilder.AppendLine("Cantidad: " + unProducto.Value);
                }
            }

            return stringBuilder.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Cliente Cliente { get => cliente;  }
        public DateTime FechaDePedido { get => fechaDePedido;  }
        public float Cotizacion { get => this.CalcularCosto(); }
        private EstadoDelPedido Estado { get => estado; }
        public string Produtos { get => this.ObtenerProductos(); }
        
        enum EstadoDelPedido
        {
            EnCamino,
            Terminado,
            Cancelado
        }
    }
}