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
        FrmMenuPrincipal frmMenuPrincipal;
        Negocio unNegocio;
        Cliente unCliente;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                unNegocio = Negocio.CargarBaseDeDatos("Taller Mecanico");
            }
            catch (Exception ex)
            {
                FrmMenuPrincipal.InformarError("Error Base De Datos", ex.Message);
                this.Close();
            }

            this.LoginUser += FrmLogin_loginUser;
            lblError.Visible = false;
            this.cmboxRol.DataSource = Enum.GetValues(typeof(Usuario.Roles));
        }

        private void FrmLogin_loginUser(Usuario unUsuario)
        {
            if (unUsuario is not null)
            {
                frmMenuPrincipal = new FrmMenuPrincipal(unNegocio, unUsuario);
                frmMenuPrincipal.Show();
                this.Hide();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError("No se aceptan valores vacios", ControlExtended.DetectarTextBoxVacio, this.Controls) == true &&
                lblError.ActivarControlError<string>("el Email Debe tener como minimo 8 caracteres", Cliente.ValidarEmail, this.txtEmail.Text)
                && lblError.ActivarControlError<string>("el Clave Debe tener como minimo 8 caracteres", Cliente.ValidarContracenia, this.txtClave.Text);
            if (respuesta == true)
            {
                if ((unUsuario = unNegocio.BuscarUsuario(this.txtEmail.Text, this.txtClave.Text)) is not null)
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
        private void FrmAltaDePersona_seIngesaronDatos(Cliente obj)
        {
            if (obj is not null && unNegocio + obj)
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
            respuesta = lblError.ActivarControlError<string>("el Email Debe tener como minimo 8 caracteres", Cliente.ValidarEmail, this.txtEmail.Text);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            respuesta = lblError.ActivarControlError<string>("el Clave Debe tener como minimo 8 caracteres", Cliente.ValidarContracenia, this.txtClave.Text);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmboxRol.SelectedItem is Usuario.Roles unRol
             && Usuario.ObtenerUnUsuarioPorRol(unNegocio.ListaDeUsuarios, unRol) is Usuario unUsuario)
            {
                txtEmail.Text = unUsuario.Email;
                txtClave.Text = unUsuario.Clave;
            }
        }
    }
}
