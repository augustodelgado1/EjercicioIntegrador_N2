using System.Text;

namespace Entidades
{
    public class Compra
    {
        int id;
        Cliente cliente;
        DateTime fechaDeCompra;
        Dictionary<Producto,int> productos;
        MetodoDePago metodo;

        private Compra()
        {
            this.id = this.GetHashCode();
            this.productos = new Dictionary<Producto, int>();
        }

        public Compra(Cliente cliente, DateTime fechaDeCompra, MetodoDePago metodo = MetodoDePago.Efectivo) : this()
        {
            this.cliente = cliente;
            this.fechaDeCompra = fechaDeCompra;
            this.metodo = metodo;
        }  
        
        public Compra(Cliente cliente, DateTime fechaDeCompra, Dictionary<Producto, int> productos, MetodoDePago metodo = MetodoDePago.Efectivo) : this(cliente, fechaDeCompra, metodo)
        {
            this.productos = productos;
        }
        public bool AniadirUnProducto(Producto unProducto)
        {
            bool result = false;
            int cantidad;
            cantidad = 0;
            if (unProducto is not null && this.productos.Keys.Contains(unProducto) == false)
            {
                this.productos.Add(unProducto, 1);
            }
            else
            {
                if (this.productos.Keys.Contains(unProducto) == true &&
                 (cantidad = this.productos[unProducto]) > 0
                && unProducto.Stock >= cantidad)
                {
                    cantidad++;
                    this.productos[unProducto] = cantidad;
                }
            }

            return result;
        }
        public static bool operator +(Compra unaCompra, Producto unProducto)
        {
            return unaCompra.AniadirUnProducto(unProducto);
        }  
        
        public static bool operator -(Compra unaCompra, Producto unProducto)
        {
            bool result = false;

            if (unaCompra.productos.ContainsKey(unProducto) == true)
            {
                unaCompra.productos.Remove(unProducto);
                result = true;
            }

            return result;
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

        public override bool Equals(object obj)
        {
            return obj is Compra compra &&
                   this.id == compra.id;
        }

        public Cliente Cliente { get => cliente;  }
        public DateTime FechaDeCompra { get => fechaDeCompra;  }
        public float Cotizacion { get => this.CalcularCosto(); }
        public string Produtos { get => this.ObtenerProductos(); }
        public enum MetodoDePago
        {
            Efectivo, TargetaDebito, TarjetaCredito
        }
    }
}