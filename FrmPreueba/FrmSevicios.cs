using Entidades;
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
    public partial class FrmSevicios : FrmListar<Servicio>
    {
        Persona unaPersona;
        Servicio unServicio;
        bool estado;
        public FrmSevicios(List<Servicio> listaDeServicio) :base(listaDeServicio)
        {
            InitializeComponent();
            this.Load += FrmSevicios_Load;
        }

        public FrmSevicios(Persona unaPersona, List<Servicio> listaDeServicio) :this(listaDeServicio)
        {
            this.unaPersona = unaPersona;
            this.ConfigurarForm(unaPersona);
        }

        private void ConfigurarForm(Persona unaPersona)
        {
            if (unaPersona is Cliente)
            {
                this.btnTerminarServicio.Visible = false;
                this.btnTerminarServicio.Enabled = false;
            }
            else
            {
                if(unaPersona is Mecanico)
                {
                    this.btnAgregar.Visible = false;
                    this.btnAgregar.Enabled = false;
                    this.btnEliminar.Visible = false;
                    this.btnEliminar.Enabled = false;
                    this.btnModificar.Visible = false;
                    this.btnModificar.Enabled = false;
                }
            }
        }

        private void FrmSevicios_Load(object? sender, EventArgs e)
        {
            base.cmbFilter.Visible = true;
            base.cmbFilter.DataSource = Enum.GetValues(typeof(Servicio.EstadoDelSevicio));
            base.Filtrar += FrmSevicios_Filtrar;
            base.Informar += FrmSevicios_Informar;
            base.InformarError += FrmSevicios_InformarError;
            base.Buscador += FrmSevicios_Buscador;
        }

        private void BtnTerminarServicio_Click(object sender, EventArgs e)
        {
            FrmDiagnosticar frmDiagnosticar = new FrmDiagnosticar(this.unServicio);
        
            if(frmDiagnosticar.ShowDialog() == DialogResult.OK
                && unaPersona is Mecanico unMecanico)
            {
                if(unMecanico + this.unServicio)
                {
                  /*  FrmSevicios_Informar();*/
                }
                else
                {
                    /*FrmSevicios_InformarError();*/
                }
            }
        }

        private List<Servicio> FrmSevicios_Filtrar(List<Servicio> unaLista,string criterio)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(criterio) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.Estado.ToString() == criterio);
            }
            return result;
        }

        private List<Servicio> FrmSevicios_Buscador(string patente, List<Servicio> unaLista)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(patente) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.UnVehiculo.Patente.Contains(patente.ToLower()) == true);
            }
            return result;
        }

        private void FrmSevicios_InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmSevicios_Informar(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override Servicio Alta()
        {
            FrmAltaServicio frmAltaSevicio = new FrmAltaServicio();
            frmAltaSevicio.seIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;
            
            if (unaPersona is Cliente unCliente 
               && frmAltaSevicio.ShowDialog() == DialogResult.OK
               && unServicio + unCliente)
            {

            }
            return this.unServicio;
        }

        private void FrmAltaSevicio_seIngesaronDatos(Servicio unServicio, Vehiculo unVehiculo)
        {
            this.unServicio = unServicio;
        }

        public override bool Baja(Servicio unServicio)
        {
            estado = false;
            FrmMostrar<Servicio> frmMostrar;
           
            if (unaPersona is Cliente unCliente && unServicio is not null)
            {
                frmMostrar = new FrmMostrar<Servicio>(unServicio, unPropertyInfoPredicate, unServicio.UnVehiculo.Path, "Vehiculo");
                frmMostrar.Activated += FrmMostrar_Shown;
                frmMostrar.Show();

                if(estado == true && unServicio - unCliente == false)
                {
                    estado = false;
                }
            }

            return estado;
        }

        public override bool Modificacion(Servicio unServicioEdit)
        {
            bool estado;
            estado = true;
            FrmAltaServicio frmSevicios;
            frmSevicios = new FrmAltaServicio(unServicioEdit);
            frmSevicios.seIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;
            if (frmSevicios.ShowDialog() == DialogResult.OK)
            {
                unServicioEdit = this.unServicio;
            }

            return estado;
        }
        public override bool Mostrar(Servicio unServicio)
        {
            bool estado = false;
            FrmMostrar<Servicio> frmMostrar;

            if (unServicio is not null)
            {
                frmMostrar = new FrmMostrar<Servicio>(unServicio, unPropertyInfoPredicate, unServicio.UnVehiculo.Path, "Un Cliente");
                frmMostrar.Show();
                estado = true;
            }
            return estado;
        }

        private bool unPropertyInfoPredicate(PropertyInfo unaPrpiedad)
        {
            return string.Compare(unaPrpiedad.Name, "Descripcion", true) == 0
                || string.Compare(unaPrpiedad.Name, "MecanicoAsignado", true) == 0
                || string.Compare(unaPrpiedad.Name, "Patente", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "CotizacionStr", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "UnCliente", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "Estado", true) == 0;
        }

        
        private void FrmMostrar_Shown(object? sender, EventArgs e)
        {
            if (sender is FrmMostrar<Servicio>)
            {
                estado = FrmMenuPrincipal.Confirmar("¿Esta seguro que desea eliminar ese Cliente", "Eliminar");
                ((FrmMostrar<Servicio>)sender).Close();
            }
        }

        protected override void ActualizarDataGried(DataGridView dgtv, List<Servicio> lista)
        {
            string textoCot;
            if(dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear();
                foreach (Servicio unServicio in lista)
                {
                    dgtv.Rows.Add(unServicio.UnCliente.Nombre, unServicio.MecanicoAsignado, unServicio.Problema, unServicio.UnVehiculo.Patente, unServicio.CotizacionStr);
                }
            }
        }

        protected override void AgregarColumnasDataGried(DataGridView dgtvList, List<Servicio> listGeneric)
        {
            dgtvList.Columns.Add("colClienteName", "Cliente");
            dgtvList.Columns.Add("colMecanicoName", "Mecanico");
            dgtvList.Columns.Add("colDescripcion", "Descripcion");
            dgtvList.Columns.Add("colUnVehiculo", "Patente");
            dgtvList.Columns.Add("colCosto", "Costo");
        }
        
        
    }
}
