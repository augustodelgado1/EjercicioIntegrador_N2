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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Interfaz
{
    public partial class FrmCrearUsuario : Form
    {

        private bool retornoDeUser;
        private bool retornoDeClave;
        private bool retornoDeEmail;

        public FrmCrearUsuario()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {



        }
        private void MostrarLabelError(System.Windows.Forms.Label unLabel, string msgError)
        {
            if (string.IsNullOrEmpty(msgError) == false)
            {
                unLabel.Visible = true;
                unLabel.Text = msgError;
            }
        }
        private string ManejadorDeFallas()
        {
            StringBuilder stringBuilder = new StringBuilder();




            return stringBuilder.ToString();
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
