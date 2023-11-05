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

namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private bool retornoDeUser;
        private bool retornoDeClave;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            retornoDeUser = Usuario.ValidarUser(this.txtUser.Text);


        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmCrearUsuario frmCrearUsuario = new FrmCrearUsuario();

        }

        private void NotificarError(Label sender, string msgError)
        {
            if (sender is Label && msgError is not null)
            {
                sender.Visible = true;
                sender.Text = msgError;
            }
        }

        private void btnUsuarioInvitado_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            retornoDeUser = Usuario.ValidarUser(this.txtUser.Text);

            if (retornoDeUser)
            {

            }
        }

        private void cmBoxPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if()
            {
              /*  txtUser.Text = 
                txtClave.Text = */
            }
        }
    }
}
