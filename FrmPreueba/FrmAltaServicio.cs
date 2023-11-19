using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;
using static Entidades.Vehiculo;
using Entidades.Extension;

namespace FrmPreueba
{
    public partial class FrmAltaServicio : Form
    {
        OpenFileDialog ofd;
        Servicio unServicio;
        Servicio unServicioModify;
        Vehiculo unVehiculo;
        public event Action<Servicio, Vehiculo> OnSeIngesaronDatos;
        Array arrayMarcaDelVehiculo;
        Array arrayTipoDeVehiculo;
        bool result;
        string path;
        public FrmAltaServicio()
        {
            InitializeComponent();
        }
        public FrmAltaServicio(Servicio unServicioModify):this()
        {
            this.unServicioModify = unServicioModify;
            this.SetServicio(unServicioModify);
        }

        private void SetServicio(Servicio unServicio)
        {
            if (unServicio is not null)
            {
                rtbTextDescripcion.Text = unServicio.Problema;
                txtPatente.Text = unServicio.UnVehiculo.Patente;
                this.txtModelo.Text = unServicio.UnVehiculo.Modelo;
                this.cmbTipoDeVehiculo.SelectedValue = unServicio.UnVehiculo.Tipo;
                this.cmbMarcaDeVehiculo.SelectedValue = unServicio.UnVehiculo.Marca;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            result = lblFallas.ActivarControlError("No se aceptan valores vacios", ControlExtended.DetectarTextBoxVacio, this.Controls)
                && this.lblFallas.ActivarControlError<string>("la patente debe tener min 6 y max 8 caracteres", Vehiculo.ValidarPatente, this.txtPatente.Text) 
                && this.lblFallas.ActivarControlError<string>("el Modelo debe se alphanumerico", Vehiculo.ValidarModelo, this.txtModelo.Text); ;

            if (result == true )
            {
                this.unVehiculo = new Vehiculo(txtPatente.Text, (Vehiculo.MarcaDelVehiculo)arrayMarcaDelVehiculo.GetValue(this.cmbMarcaDeVehiculo.SelectedIndex), (Vehiculo.TipoDeVehiculo)arrayTipoDeVehiculo.GetValue(cmbTipoDeVehiculo.SelectedIndex), this.txtModelo.Text, this.path);
                this.unServicio = new Servicio(rtbTextDescripcion.Text, this.unVehiculo);
                if(unServicioModify is not null)
                {
                    this.unServicio.Cotizacion = unServicioModify.Cotizacion;
                    this.unServicio.Diagnistico = unServicioModify.Diagnistico;
                }
                seIngesaronDatos(this.unServicio, this.unVehiculo);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void seIngesaronDatos(Servicio unServicio, Vehiculo unVehiculo)
        {
            if (OnSeIngesaronDatos is not null)
            {
                OnSeIngesaronDatos.Invoke(unServicio, unVehiculo);
            }
        }


        private void btnImagen_Click(object sender, EventArgs e)
        {
            ofd = FrmListar<Servicio>.AbrirArchivo("Imagen de perfil", "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            if (ofd is not null)
            {
                this.path = ofd.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.lblFallas.ActivarControlError<string>("Debe Dar una Descripsion mas coherente", texto => string.IsNullOrWhiteSpace(texto) == false && texto.isLetter(), this.rtbTextDescripcion.Text); ;
        }

        private void FrmAltaServicio_Load(object sender, EventArgs e)
        {
            this.lblFallas.Visible = false;
            arrayMarcaDelVehiculo = Enum.GetValues(typeof(Vehiculo.MarcaDelVehiculo));
            arrayTipoDeVehiculo = Enum.GetValues(typeof(Vehiculo.TipoDeVehiculo));
            this.cmbMarcaDeVehiculo.DataSource = arrayMarcaDelVehiculo;
            this.cmbTipoDeVehiculo.DataSource = arrayTipoDeVehiculo;
        }
    }
}
