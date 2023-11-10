using static Entidades.Servicio;

namespace Entidades
{
    public class Vehiculo
    {
        int id;
        string patente;
        TipoDeVehiculo tipo;
        MarcaDelVehiculo marca;
        string modelo;
        string path;
        Servicio servicio;

        internal Vehiculo(int id, string patente, MarcaDelVehiculo marca, TipoDeVehiculo tipo, string modelo,Servicio unServicio, string path = null) 
            :this(patente, marca, tipo,modelo,path)
        { 
            this.id = id;
            this.Servicio = unServicio;
        }

        public Vehiculo(string patente, MarcaDelVehiculo marca,TipoDeVehiculo tipo, string modelo, string path = null)
        {
            this.Patente = patente;
            this.marca = marca;
            this.tipo = tipo;
            this.Modelo = modelo;
            this.path = path;
        }

        public static bool ValidarPatente(string patente)
        {
            bool result;
            result = false;
            if (string.IsNullOrWhiteSpace(patente) == false)
            {
                patente = patente.ToUpper();
                patente = patente.Replace(" ", "");
                result = patente.EsAlphaNumerica()
                    && patente.Length >= 6 && patente.Length <= 7;
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vehiculo vehiculo &&
                   patente == vehiculo.patente;
        }

        internal static Vehiculo BuscarPorId(List<Vehiculo> listaDeVehiculos, int id)
        {
            Vehiculo result = null;
            
            if (listaDeVehiculos is not null )
            {
                result = listaDeVehiculos.Find(unVehiculo => unVehiculo  is not null && unVehiculo.id == id);
            }

            return result;
        }

        internal int Id { get => id; }
        public string Patente
        {
            get => patente;

            set
            {
                this.patente = null;
                if (ValidarPatente(value) == true)
                {
                    patente = value;
                }
            }
        }

        public EstadoDeVehiculo Estado { 

            get {

                EstadoDeVehiculo estado;
                estado = EstadoDeVehiculo.NoDiagnosticado;

                if (this.servicio is not null 
                 && this.servicio.Estado == Servicio.EstadoDelSevicio.EnProceso)
                {
                    estado = EstadoDeVehiculo.Diagnosticado;
                }

                return estado;
            } 
        }

        public Servicio Servicio { get => servicio;

            set
            {
                if (value is not null
                && this.Estado == EstadoDeVehiculo.NoDiagnosticado)
                {
                    this.servicio = value;
                }
            } 
        
        }

        public string Modelo { get => modelo; 
            
            set
            {
                if (ValidarModelo(value))
                {
                    this.modelo = value;
                }
            }
        }

        public static bool ValidarModelo(string modelo)
        {
            return string.IsNullOrWhiteSpace(modelo) == false
                && modelo.EsAlphaNumerica() == true;
        }

        public TipoDeVehiculo Tipo { get => tipo; set => tipo = value; }
        public MarcaDelVehiculo Marca { get => marca; set => marca = value; }
        public string Path { get => path; set => path = value; }

        public enum TipoDeVehiculo
        {
            Moto,
            Camion,
            Auto
        }

        public enum MarcaDelVehiculo
        { 
            VolgVagen,Ford,
            Golf,Scort,Nissan,
            Toyota
        }

        public enum EstadoDeVehiculo
        {
            NoDiagnosticado, Diagnosticado
        };

    }
}