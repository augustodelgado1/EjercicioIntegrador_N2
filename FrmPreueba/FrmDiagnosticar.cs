using Entidades;
using Entidades.Extension;
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

namespace FrmPreueba
{
    public partial class FrmDiagnosticar : Form
    {
        bool retornoCot;
        bool respuesta;
        Servicio unServicio;
        public FrmDiagnosticar(Servicio unServicio)
        {
            InitializeComponent();
            this.unServicio = unServicio;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError("No se aceptan valores vacios", ControlExtended.DetectarTextBoxVacio, this.Controls) &&
            lblError.ActivarControlError<string>("la cotizacion debe ser un valor numerico", unTexto => string.IsNullOrEmpty(unTexto) == false && unTexto.EsNumerica() == true, txtCotizacion.Text);

            if (unServicio is not null && respuesta == true && int.TryParse(txtCotizacion.Text, out int cotizacion) == true
             && cmbDignosticar.SelectedItem is Servicio.Diagnostico unDiagnostico)
            {
                unServicio.Diagnistico = unDiagnostico;
                unServicio.Cotizacion = cotizacion;
                this.DialogResult = DialogResult.OK;
            }
        }
        private void FrmDiagnosticar_Load(object sender, EventArgs e)
        {
            cmbDignosticar.DataSource = Enum.GetValues(typeof(Servicio.Diagnostico));
            lblError.Visible = false;
        }
    }
}
