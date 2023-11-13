using Entidades;
using FrmPreueba;
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
        public event Action<Usuario> LoginUser;
        Usuario unUsuario;
        Negocio unNegocio;
        FrmMenuPrincipal frmMenuPrincipal;
        Cliente unCliente;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.LoginUser += FrmLogin_loginUser;
            lblError.Visible = false;
        }

        private void FrmLogin_loginUser(Usuario unUsuario)
        {
            if (unUsuario is not null)
            {
                frmMenuPrincipal = new FrmMenuPrincipal(unUsuario);
                frmMenuPrincipal.Show();
                this.Hide();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError("No se aceptan valores vacios", ControlExtended.DetectarTextBoxVacio, this.Controls) == true;
            if (respuesta == true)
            {
                if((unUsuario = Usuario.EncontarUsuario(Negocio.ListaDeUsuarios, this.txtEmail.Text, this.txtClave.Text)) is not null)
                {
                    lblError.Visible = false;
                    OnLoginUser(unUsuario);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "el usuario ingresado no existe";
                }
            }
        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmAltaDePersona frmAltaDePersona = new FrmAltaDePersona(Usuario.Roles.Cliente);
            frmAltaDePersona.seIngesaronDatos += FrmAltaDePersona_seIngesaronDatos;
            if (frmAltaDePersona.ShowDialog() == DialogResult.OK)
            {
                OnLoginUser(unUsuario);
            }
        }
        private void FrmAltaDePersona_seIngesaronDatos(Persona obj)
        {
            if (obj is not null)
            {
                this.unUsuario = obj;
            }
        }

        private void OnLoginUser(Usuario unUsuario)
        {
            if (unUsuario is not null
             && this.LoginUser is not null)
            {
                this.LoginUser(unUsuario);
            }
        }
        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError<string>("el Email Debe tener como minimo 8 caracteres", Persona.ValidarEmail, this.txtEmail.Text);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError<string>("el Clave Debe tener como minimo 8 caracteres", Persona.ValidarContracenia, this.txtClave.Text);
        }
    }
}
