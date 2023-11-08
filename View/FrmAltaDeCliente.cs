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

namespace View
{
    public partial class FrmAltaDePersona : Form
    {
        Persona unaPersona;
        DateTime fechaDeNacimiento;
        Usuario.Roles unRol;
        public event Action<Persona> seRealizoUnAlta;
        bool result;

        public FrmAltaDePersona(Usuario.Roles unRol)
        {
            InitializeComponent();
            this.unRol = unRol;
        }
        public FrmAltaDePersona(Usuario.Roles unRol, Persona unaPersona):this(unRol)
        {
            this.unaPersona = unaPersona;
        }
        private void FrmAltaDeCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (result = (unaPersona.Nombre = this.txtNombre.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Nombre Debe Contener solo letras\"";
            }
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (result = (unaPersona.Dni = this.txtDni.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Dni Debe tener como minimo 6 numeros y maximo 8 numeros";
            }
        }

        private void DateFechaDeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (result = (unaPersona.FechaDeNacimiento = this.DateFechaDeNacimiento.Value) == DateTime.MinValue)
            {
                this.lb_Fallas.Text = "\"el Dni Debe tener como minimo 6 numeros y maximo 8 numeros";
            }
        }
        private Usuario CrearUsuario()
        {
            Usuario unUsuario;

            if (this.unRol == Usuario.Roles.Cliente)
            {
                unUsuario = new Cliente(this.txtNombre.Text, this.txtDni.Text, this.DateFechaDeNacimiento.Value, this.txtEmail.Text, this.txtClave.Text);
            }
            else
            {
                unUsuario = new Mecanico(this.txtNombre.Text, this.txtDni.Text, this.DateFechaDeNacimiento.Value, this.txtEmail.Text, this.txtClave.Text);
            }

            return unUsuario;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (result == false)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (result = (unaPersona.Clave = this.txtClave.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Clave Debe tener como minimo 8 caracteres";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (result = (unaPersona.Email = this.txtEmail.Text) is null)
            {
                this.lb_Fallas.Text = "\"el Email Debe tener como minimo 8 caracteres";
            }
        }
    }
}
