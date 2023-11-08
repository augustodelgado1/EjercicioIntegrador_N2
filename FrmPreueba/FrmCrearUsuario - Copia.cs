using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;

namespace Interfaz
{
    public partial class FrmCrearUsuario2 : Form
    {
        private Usuario unUsuario;
        private bool retornoDeUser;
        private bool retornoDeClave;
        private bool retornoDeEmail;
        public event Action<Usuario> SeRegistroUnUsuario;

        public FrmCrearUsuario2()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(retornoDeUser == true && retornoDeClave == true && retornoDeEmail == true)
            {
                OnSeRegistroUnUsuario(unUsuario);
            }
        }

        private void OnSeRegistroUnUsuario(Usuario unUsuario)
        {
            if (unUsuario is not null
             && this.SeRegistroUnUsuario is not null)
            {
                this.SeRegistroUnUsuario(unUsuario);
            }
        }

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {


        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
