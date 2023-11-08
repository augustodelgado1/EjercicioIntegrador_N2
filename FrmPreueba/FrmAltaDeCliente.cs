using Entidades;
using Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FrmAltaDeCliente : FrmCrearUsuario2
    {
        Cliente unCliente;
        bool result;

        private FrmAltaDeCliente()
        {
            InitializeComponent();
        }

        public FrmAltaDeCliente(Cliente unCliente) : this()
        {
            this.unCliente = unCliente;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (result = (unCliente.Nombre = this.txtNombre.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Nombre Debe Contener solo letras\"";
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (result = (unCliente.Dni = this.txtDni.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Dni Debe tener como minimo 6 numeros y maximo 8 numeros";
            }
        }

        private void DateFechaDeNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (result == true)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmAltaDeCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
