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
        bool respuesta;
        Servicio unServicio;
        int cotizacion;
        Array unArray;
        KeyValuePair<Servicio.Diagnostico, float> keyValue;
        public FrmDiagnosticar(Servicio unServicio)
        {
            InitializeComponent();
            this.unServicio = unServicio;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            respuesta = FrmMenuPrincipal.ActivarControlError(lblError, "No se aceptan valores vacios", FrmMenuPrincipal.DetectarTextBoxVacio, this.Controls) &&
            FrmMenuPrincipal.ActivarControlError<string>(lblError, "la cotizacion debe ser un valor numerico", unTexto => int.TryParse(unTexto, out cotizacion) == true 
            && cotizacion > 0, txtCotizacion.Text);

            if (unServicio is not null && respuesta == true &&
              cmbDignosticar.SelectedItem is Servicio.Diagnostico unDiagnostico)
            {
                keyValue = new KeyValuePair<Servicio.Diagnostico, float>(unDiagnostico, cotizacion);
                if (unServicio + keyValue)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void FrmDiagnosticar_Load(object sender, EventArgs e)
        {
            cmbDignosticar.DataSource = Enum.GetValues(typeof(Servicio.Diagnostico));
            lblError.Visible = false;
            lblError.ForeColor = Color.Red;
        }
    }
}
