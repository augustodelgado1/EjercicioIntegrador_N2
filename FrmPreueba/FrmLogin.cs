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

namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private bool respuesta;
        public event Action<Usuario> loginUser;
        Usuario unUsuario;
        FrmMenuPrincipal frmMenuPrincipal;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (respuesta == true
             && (unUsuario = Usuario.EncontarUsuario(Negocio.listaDeUsuarios, this.txtEmail.Text, this.txtClave.Text)) is not null)
            {
                OnLoginUser(unUsuario);
                frmMenuPrincipal = new FrmMenuPrincipal(unUsuario);
                frmMenuPrincipal.Show();
                this.Hide();
            }
        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

        }

        private void OnLoginUser(Usuario unUsuario)
        {
            if (unUsuario is not null
             && this.loginUser is not null)
            {
                this.loginUser(unUsuario);
            }
        }
        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {
            respuesta = lbl_fallas.ActivarControlError<string>("el Email Debe tener como minimo 8 caracteres", Persona.ValidarEmail, this.txtEmail.Text);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            respuesta = lbl_fallas.ActivarControlError<string>("el Clave Debe tener como minimo 8 caracteres", Persona.ValidarContracenia, this.txtClave.Text);
        }
    }
}
