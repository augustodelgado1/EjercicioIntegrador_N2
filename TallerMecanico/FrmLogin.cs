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
        private bool retornoDeUser;
        private bool retornoDeClave;
        public event Action<Usuario> loginUser;
        Usuario unUsuario;
        FrmMenuPrincipal frmMenuPrincipal;
        FrmCrearUsuario frmCrearUsuario;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal = new FrmMenuPrincipal();
            if (retornoDeUser && retornoDeClave 
             && (unUsuario = Usuario.EncontarUsuario(Negocio.listaDeUsuarios,this.txtUser.Text,this.txtClave.Text)) is not null)
            {
                OnLoginUser(unUsuario);
                frmMenuPrincipal.Show();
                this.Hide();
            }

        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmCrearUsuario = new FrmCrearUsuario();
            if(frmCrearUsuario.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
            }
        }

        private void OnLoginUser(Usuario unUsuario)
        {
            if(unUsuario is not null 
             && this.loginUser is not null)
            {
                this.loginUser(unUsuario);
            }
        }

        private void MostarErrorConLabel(string msgError, Label unLabel)
        {
            if (string.IsNullOrWhiteSpace(msgError) == true
                && msgError.isLetter() == true && unLabel is not null)
            {
                unLabel.Visible = true;
                unLabel.Text = msgError;
            }
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
            frmMenuPrincipal = new FrmMenuPrincipal();
            if (this.cmBoxPrueba.SelectedIndex > 0 && this.cmBoxPrueba.SelectedIndex < this.cmBoxPrueba.Items.Count
             && (unUsuario = Usuario.BuscarUnUsuarioPorUser(Negocio.listaDeUsuarios, (string)this.cmBoxPrueba.Items[this.cmBoxPrueba.SelectedIndex])) is not null)
            {
                this.txtUser.Text = unUsuario.User;
                this.txtClave.Text = unUsuario.Clave;
            }
        }

        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {
            if ((retornoDeUser = Usuario.ValidarUser(this.txtUser.Text)) == false)
            {
                this.MostarErrorConLabel("Ingrese un Usuario valido", this.lbl_fallas);
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if ((retornoDeClave = Usuario.ValidarContracenia(this.txtClave.Text)) == false)
            {
                this.MostarErrorConLabel("Ingrese un Clave valida", this.lbl_fallas);
            }
        }
    }
}
