namespace Entidades
{
    public class Mecanico:Usuario
    {
        List<Servicio> servicios;
        EstadoDelMecanico estado;
        public Mecanico(string nombre, string email, string clave, string path = null) : base(nombre, email, clave, Roles.Personal, path)
        {
            this.servicios = new List<Servicio>();
            this.estado = EstadoDelMecanico.Disponible;
        }

        public EstadoDelMecanico Estado {
            
            get {
                this.estado = EstadoDelMecanico.Disponible;
                if (this.servicios.Find(UnServicio => UnServicio is not null && UnServicio.Estado == Servicio.EstadoDelSevicio.EnProceso) is not null)
                {
                    this.estado = EstadoDelMecanico.NoDisponible;
                }
                return this.estado;
            } 
        }

        public enum EstadoDelMecanico
        {
            Disponible,NoDisponible
        }
    }
}