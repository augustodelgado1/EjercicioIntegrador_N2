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
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
        }

        public static Diagnostico BuscarPorId(List<Diagnostico> listaDeDiagnostico, int id)
        {
            Diagnostico result = null;
            if (listaDeDiagnostico is not null)
            {
                result = listaDeDiagnostico.Find(unDiagnostico => unDiagnostico is not null && unDiagnostico.id == id);
            }

            return result;
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
        internal int Id { get => id;  }
    }
}