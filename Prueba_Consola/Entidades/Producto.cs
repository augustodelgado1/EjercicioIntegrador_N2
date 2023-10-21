using System.Text;

namespace Entidades
{
    public class Producto
    {
        int id;
        string nombre;
        float cotizacion;
        CategoriaDelProduto categoria;
        int stock;
        string path;
        EstadoDelProducto estado;

        public Producto(string nombre, float cotizacion, 
            CategoriaDelProduto categoria,int stock, string path)
        {
            this.id = this.GetHashCode();
            this.Nombre = nombre;
            this.cotizacion = cotizacion;
            this.categoria = categoria;
            this.stock = stock;
            this.path = path;
        }

       

        public override bool Equals(object? obj)
        {
            return obj is Producto producto &&
                   id == producto.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public EstadoDelProducto Estado
        {

            get
            {

                EstadoDelProducto estado;
                estado = EstadoDelProducto.NoDisponible;
                if (this.stock > 0)
                {
                    estado = EstadoDelProducto.Disponible;
                }

                return estado;

            }
        }
        public float Costo
        {
            get { return this.cotizacion; }
            set
            {
                this.cotizacion = 0;
                if (value >= 0)
                {
                    this.cotizacion = value;
                }
            }
        }
        public string Nombre
        {
            get => nombre;

            set
            {
                this.nombre = "nombre invalido";
                if (string.IsNullOrWhiteSpace(value) == false
                 && value.EsAlphaNumerica() == true)
                {
                    this.nombre = value;
                }
            }
        }
        public string Path { get => path; set => path = value; }
        public CategoriaDelProduto Categoria { get => categoria; }
        public int Stock
        {
            get => stock;

            set
            {
                stock = 0;
                if (value >= 0)
                {
                    stock = value;
                }
            }
        }
        public enum CategoriaDelProduto { Herramientas, Moda ,Tecnologia,Vehiculo};
        public enum EstadoDelProducto { Disponible,NoDisponible};
    }
}