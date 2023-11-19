using Entidades.Extension;
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
        EstadoDeVehiculo estado;
        private Cliente duenio;

        internal Vehiculo(int id, string patente, MarcaDelVehiculo marca, TipoDeVehiculo tipo, string modelo, EstadoDeVehiculo estado,Cliente unCliente, string path = null) 
            :this(patente, marca, tipo,modelo,path)
        { 
            this.id = id;
            this.estado = estado;
            this.Duenio = unCliente;
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
            char[] separadores = { ' ', ',', '.', '_', '-' };
            if (string.IsNullOrWhiteSpace(patente) == false)
            {
                patente = patente.BorrarCaracteres(separadores);
                patente = patente.ToUpper();
                result = patente.EsAlphaNumerica()
                    && patente.Length >= 6 && patente.Length <= 7;
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vehiculo vehiculo &&
                   id == vehiculo.id;
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

        public static bool operator +(Vehiculo unVehiculo, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && unCliente is not null
             && unCliente.Vehiculos.Contains(unVehiculo) == false)
            {
                unCliente.Vehiculos.Add(unVehiculo);
                unVehiculo.duenio = unCliente;
                result = true;
            }


            return result;
        }

        public static bool operator -(Vehiculo unVehiculo, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && unCliente is not null
             && unCliente.Vehiculos.Contains(unVehiculo) == true)
            {
                unCliente.Vehiculos.Remove(unVehiculo);
                unVehiculo.duenio = null;
                result = true;
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
                /*if (ValidarPatente(value) == true)
                {*/
                    patente = value;
                
            }
        }

        public EstadoDeVehiculo Estado {

            get => this.estado;

            internal set 
            {
                this.estado = value;
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
        public Cliente Duenio { get => duenio; 
            
            set { 
            
                if(this + value)
                {
                    this.duenio = value;
                }
            
            } 
        
        }

        public string DuenioName { get => duenio.Nombre; }

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
            Toyota,Honda,Pontiac
        }

        public enum EstadoDeVehiculo
        {
            NoDiagnosticado, Diagnosticado
        };

    }
}