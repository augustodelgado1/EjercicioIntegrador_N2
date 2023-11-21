using Entidades;
using FrmPreueba;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;
namespace FrmPreueba
{
    public partial class FrmVehiculo : FrmListar<Vehiculo>
    {
        Negocio unNegocio;
        Cliente unCliente;
        Vehiculo unVehiculo;
        bool estado;
        public FrmVehiculo(Negocio unNegocio,Cliente unCliente, List<Vehiculo> listaDeVehiculos):this(listaDeVehiculos)
        {
            this.unNegocio = unNegocio;
            this.unCliente = unCliente;
        }
        public FrmVehiculo(List<Vehiculo> listaDeVehiculos) :base(listaDeVehiculos)
        {
            InitializeComponent();
            this.Load += FrmVehiculo_Load;
        }
        private void FrmVehiculo_Load(object? sender, EventArgs e)
        {
            base.btnModificar.Visible = false;
            base.btnAgregar.Visible = false;
            base.btnEliminar.Visible = false;
            base.btnCargar.Visible = false;
            base.btnGuardarArchivo.Visible = false;
            base.Informar += FrmMenuPrincipal.Informar;
            base.InformarError += FrmMenuPrincipal.InformarError;
            base.cmbFilter.Visible = true;
            base.cmbFilter.DataSource = Enum.GetValues(typeof(Vehiculo.EstadoDeVehiculo));
            base.Filtrar += FrmVehiculo_Filtrar;
            base.Buscador += FrmVehiculo_Buscador;
        }

        private List<Vehiculo> FrmVehiculo_Buscador(string patente, List<Vehiculo> vehiculos)
        {
            List<Vehiculo> result = default;
            if (string.IsNullOrWhiteSpace(patente) == false && vehiculos is not null)
            {
                result = vehiculos.FindAll(unVehiculo => unVehiculo is not null &&  unVehiculo.Patente.Contains(patente.ToLower()));
            }
            return result;
        }

        private List<Vehiculo> FrmVehiculo_Filtrar(List<Vehiculo> vehiculos, string criterio)
        {
            List<Vehiculo> result = default;
            if (string.IsNullOrWhiteSpace(criterio) == false && vehiculos is not null && Enum.TryParse(typeof(Vehiculo.EstadoDeVehiculo),criterio,out object estado) 
            && estado is Vehiculo.EstadoDeVehiculo unEstado)
            {
                result = vehiculos.FindAll(unVehiculo => unVehiculo is not null && unVehiculo.Estado == unEstado);
            }
            return result;
        }
        public override bool Baja(Vehiculo element)
        {
            throw new NotImplementedException();
        }
        private bool unPropertyInfoPredicate(PropertyInfo unaPrpiedad)
        {
            return string.Compare(unaPrpiedad.Name, "Patente", true) == 0
            || string.Compare(unaPrpiedad.Name, "Modelo", true) == 0 ||
               string.Compare(unaPrpiedad.Name, "Tipo", true) == 0 ||
               string.Compare(unaPrpiedad.Name, "Estado", true) == 0;
        }

        public override bool Modificacion(Vehiculo element)
        {
            throw new NotImplementedException();
        }

        public override bool Mostrar(Vehiculo element)
        {
            bool estado = false;
            FrmMostrar<Vehiculo> frmMostrar;

            if (element is not null)
            {
                frmMostrar = new FrmMostrar<Vehiculo>(element, unPropertyInfoPredicate, element.Path, "Vehiculo");
                frmMostrar.Show();
                estado = true;
            }
            return estado;
        }


        public override void ActualizarDataGried(DataGridView dgtv, List<Vehiculo> lista)
        {
            if (dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear(); 
                foreach (Vehiculo unVehiculo in lista)
                {
                    dgtv.Rows.Add(unVehiculo.Patente, unVehiculo.Modelo, unVehiculo.Tipo, unVehiculo.Estado);
                }
            }
        }

        public override void AgregarColumnasDataGried(DataGridView dgtvList)
        {
            dgtvList.Columns.Add("colPatente", "Patente");
            dgtvList.Columns.Add("colModelo", "Modelo");
            dgtvList.Columns.Add("colTipo", "Tipo");
            dgtvList.Columns.Add("colEstado", "Estado");
        }

        public override bool Alta()
        {
            throw new NotImplementedException();
        }
    }
}

