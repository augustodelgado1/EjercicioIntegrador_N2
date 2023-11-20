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

        internal Vehiculo(int id, string patente, MarcaDelVehiculo marca, TipoDeVehiculo tipo, string modelo, EstadoDeVehiculo estado = EstadoDeVehiculo.NoDiagnosticado, string path = null) 
            :this(patente, marca, tipo,modelo,path)
        { 
            this.id = id;
            this.estado = estado;
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
            char[] separadores = { ',','.', '_', '-',' ' };
            if (string.IsNullOrWhiteSpace(patente) == false)
            {
                patente = patente.BorrarCaracteres(separadores);
                patente = patente.ToUpper();
                result = patente.EsAlphaNumerica() == true  
                    && patente.Length >= 6 && patente.Length <= 7;
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vehiculo vehiculo &&
                   id == vehiculo.id;
        }
        public int Id { get => id; }
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
            bool result;
            result = false;
            char[] separadores = { ' ', ',', '_', '-','/','*' };
            if (string.IsNullOrWhiteSpace(modelo) == false)
            {
                modelo = modelo.BorrarCaracteres(separadores);
                result = modelo.EsAlphaNumerica();
            }
            return result;
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
            Toyota,Honda,Pontiac
        }

        public enum EstadoDeVehiculo
        {
            NoDiagnosticado, Diagnosticado
        };

    }
}