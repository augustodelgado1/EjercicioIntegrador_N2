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

namespace FrmPreueba
{
    public partial class FrmAltaServicio : Form
    {
        OpenFileDialog ofd;
        Servicio unaServicio;
        Usuario.Roles unRol;
        public event Action<Servicio> seIngesaronDatos;
        bool result;
        string path;
        public FrmAltaServicio()
        {
            InitializeComponent();
        }
        
        public FrmAltaServicio(Servicio unServicio)
        {
            InitializeComponent();
            this.SetServicio(unServicio);
        }

        private void SetServicio(Servicio unServicio)
        {
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            result = lblFallas.ActivarControlError("No se aceptan valores vacios", ControlExtended.DetectarTextBoxVacio, this.Controls);
            
            if (result == true && string.IsNullOrWhiteSpace(rtbTextDescripcion.Text) == false && 
             Enum.TryParse(typeof(Vehiculo.TipoDeVehiculo), this.cmbMarcaDeVehiculo.Text, out object tipoDeVehiculo) &&
             Enum.TryParse(typeof(Vehiculo.MarcaDelVehiculo), this.cmbMarcaDeVehiculo.Text, out object marcaDelVehiculo)
             && tipoDeVehiculo is Vehiculo.TipoDeVehiculo unTipoDeVehiculo && marcaDelVehiculo is Vehiculo.MarcaDelVehiculo
             unaMarcaDelVehiculo)    
            {
                this.unaServicio = new Servicio(rtbTextDescripcion.Text, new Vehiculo(txtPatente.Text, unaMarcaDelVehiculo, unTipoDeVehiculo, this.txtModelo.Text, this.path));
                OnSeIngesaronDatos(this.unaServicio);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void OnSeIngesaronDatos(Servicio unServicio)
        {
            if(seIngesaronDatos is not null)
            {
                seIngesaronDatos.Invoke(unServicio);
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

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            this.lblFallas.ActivarControlError<string>("la patente debe tener minimo 6  y maximo 8 caracteres", Vehiculo.ValidarPatente, this.txtPatente.Text);
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            this.lblFallas.ActivarControlError<string>("el Modelo debe se alphanumerico", Vehiculo.ValidarModelo, this.txtModelo.Text);
        }

        private void lblFallas_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAltaServicio_Load(object sender, EventArgs e)
        {
            this.lblFallas.Visible = false;
            this.cmbMarcaDeVehiculo.DataSource = Enum.GetValues(typeof(Vehiculo.MarcaDelVehiculo));
            this.cmbTipoDeVehiculo.DataSource = Enum.GetValues(typeof(Vehiculo.TipoDeVehiculo));
        }
    }
}
