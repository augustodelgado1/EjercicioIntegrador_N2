namespace Entidades
{
    public class Diagnostico
    {
        int id;
        string nombre;
        string descripcion;
        float costo;

        internal Diagnostico(int id, string nombre, string descripcion, float costo) : this(nombre, descripcion, costo)
        {
            this.id = id;
        }
        public Diagnostico(string nombre, string descripcion, float costo)
        {
            this.id = this.GetHashCode();
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
        }
        public override bool Equals(object? obj)
        {
            return obj is Diagnostico diagnostico &&
                   this.id == diagnostico.id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public float Costo { get { return this.costo; } 
            
            set {
                if (value > 0)
                {
                    this.costo = value;
                } 
            } 
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

       
    }
}