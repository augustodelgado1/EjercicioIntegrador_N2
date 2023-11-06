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

namespace Interfaz
{
    public partial class FrmCrearUsuario : Form
    {

        private bool retornoDeUser;
        private bool retornoDeClave;
        private bool retornoDeEmail;
        public event Action<Usuario> SeRegistroUnUsuario;

        public FrmCrearUsuario()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(retornoDeUser == true && retornoDeClave == true && retornoDeEmail == true)
            {
                /*OnSeRegistroUnUsuario();*/
            }
        }
        private string ManejadorDeFallas()
        {
            StringBuilder stringBuilder = new StringBuilder();




            return stringBuilder.ToString();
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
