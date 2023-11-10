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

namespace View
{
    public partial class FrmAltaServicio : Form
    {
        public FrmAltaServicio()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        private void btnImagen_Click(object sender, EventArgs e)
        {

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
