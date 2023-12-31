﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static Entidades.Vehiculo;

namespace Entidades
{
    public class Servicio
    {
        int id;
        Cliente unCliente;
        Vehiculo unVehiculo;
        DateTime fechaDeIngreso;
        string descripcionDelProblema;
        Diagnostico diagnostico;
        EstadoDelSevicio estado;
        float costo;

        private Servicio()
        {
            this.diagnostico = Diagnostico.NoDeterminado;
        }

        public Servicio(string descripcion, Vehiculo unVehiculo) : this()
        {
            this.UnVehiculo = unVehiculo;
            this.descripcionDelProblema = descripcion;
        }

        public Servicio(int id, string descripcion,
            DateTime fechaDeIngreso,Vehiculo unVehiculo, Cliente unCliente, EstadoDelSevicio estado) : this(descripcion, unVehiculo)
        {
            this.id = id;
            this.FechaDeIngreso = fechaDeIngreso;
            this.UnCliente = unCliente;
            this.estado = estado;
        }
        /// <summary>
        /// Busca los servicios que cocidan con el estado pasado por parametro y los guarda en una lista
        /// </summary>
        /// <param name="listaDeServicios"></param>
        /// <param name="estado"></param>
        /// <returns>(null) si los parametro no son validos ,(List<Servicio>) de caso contrario</returns>
        public static List<Servicio> BuscarPorEstado(List<Servicio> listaDeServicios, EstadoDelSevicio estado)
        {
            List<Servicio> result = null;
            if (listaDeServicios is not null)
            {
                result = listaDeServicios.FindAll(unServicio => unServicio is not null && unServicio.Estado == estado);
            }

            return result;
        }
        public override bool Equals(object? obj)
        {
            return obj is Servicio servicio &&
                   this.id == servicio.id;
        }
        public static bool operator +(Servicio servicio, Vehiculo unVehiculo)
        {
            bool result = false;

            if (unVehiculo is not null && servicio is not null
             && servicio.Estado == EstadoDelSevicio.EnProceso
             && unVehiculo.Estado != EstadoDeVehiculo.Diagnosticado)
            {
                servicio.unVehiculo = unVehiculo;
                servicio.fechaDeIngreso = DateTime.Now;
                unVehiculo.Estado = EstadoDeVehiculo.Diagnosticado;
                result = true;
            }


            return result;
        }
        /// <summary>
        /// Diagnostica el servicio pasado por parametro y le asigna el costo pasado por parametro
        /// </summary>
        /// <param name="servicio"></param>
        /// <param name="diagnostico"></param>
        /// <returns></returns>
        public static bool operator +(Servicio servicio, KeyValuePair<Diagnostico,float> diagnostico)
        {
            bool result = false;

            if (servicio is not null && servicio.Estado == EstadoDelSevicio.EnProceso
              && diagnostico.Key != Diagnostico.NoDeterminado)
            {
                servicio.Diagnistico = diagnostico.Key;
                servicio.Cotizacion = diagnostico.Value;
                result = true;
            }


            return result;
        }
        /// <summary>
        /// Setea al servicio en estado terminado 
        /// </summary>
        internal void TerminarServicio()
        {
            this.estado = EstadoDelSevicio.Terminado;
            this.UnVehiculo.Estado = EstadoDeVehiculo.NoDiagnosticado;
        }
        /// <summary>
        /// Guarda dentro de la lista de servicios de cliente un servicio 
        /// </summary>
        /// <param name="servicio"></param>
        /// <param name="unCliente"></param>
        /// <returns>(true) si pudo Agregarlo,(false) si no pudo Agregarlo</returns>
        public static bool operator +(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && servicio is not null
            && unCliente != servicio && servicio.estado == EstadoDelSevicio.EnProceso)
            {
                unCliente.Servicios.Add(servicio);
                servicio.unCliente = unCliente;
                result = true;
            }


            return result;
        } 
        /// <summary>
        /// Borra de la lista de servicios de cliente el servicio pasado por parametro
        /// </summary>
        /// <param name="servicio"></param>
        /// <param name="unCliente"></param>
        /// <returns>(true) si pudo eliminarlo,(false) si no pudo eliminarlo</returns>
        public static bool operator -(Servicio servicio, Cliente unCliente)
        {
            bool result = false;

            if (unCliente is not null && servicio is not null
            && unCliente == servicio)
            {
                unCliente.Servicios.Remove(servicio);
                result = true;
            }


            return result;
        }

        internal int Id { get => id; }
        public float Cotizacion { get => costo; 
           
            private set
            {
                if (value > 0)
                {
                    this.costo = value;
                }
            }
        }
        public string CotizacionStr {
            get 
            { 
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Costo {this.costo}");
                if (this.costo == 0)
                {
                    stringBuilder.Clear();
                    stringBuilder.AppendLine("No Determinada");
                }
            
                return stringBuilder.ToString();
            }
        }
        public EstadoDelSevicio Estado { get => estado; set => estado = value; }
        public DateTime FechaDeIngreso { get => fechaDeIngreso; 
            
            private set
            { 
                if(value >= DateTime.Now)
                {
                    this.fechaDeIngreso = value;
                }
            } 
        
        }
        public Diagnostico Diagnistico 
        {
           private set { this.diagnostico = value; }
            get
            {
                return this.diagnostico;
            }
        }

        public Vehiculo UnVehiculo { get => unVehiculo;
            
            set
            {
                if(this + value)
                {
                    this.unVehiculo = value;
                }
            }
        
        }
        public string Problema { get => descripcionDelProblema; set => descripcionDelProblema = value; }
        public Cliente UnCliente { get => unCliente;

             set
            {
                if (this + value)
                { 
                    this.unCliente = value;
                }
            }
        }
 

        public enum EstadoDelSevicio
        {
            EnProceso,
            Cancelado,
            Terminado
        }

        public enum Diagnostico
        {
            NoDeterminado,
            CambioDeRuedas,
            CambioDeFrenos,
            Suspension,
            ReparacionDeMotor,
        }
    }
}