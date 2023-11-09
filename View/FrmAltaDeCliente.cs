using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;

namespace View
{
    public partial class FrmAltaDePersona : Form
    {
        Persona unaPersona;
        Usuario.Roles unRol;
        public event Action<Persona> seRealizoUnAlta;
        bool result;

        public FrmAltaDePersona(Usuario.Roles unRol)
        {
            InitializeComponent();
            this.unRol = unRol;
        }
        public FrmAltaDePersona(Usuario.Roles unRol, Persona unaPersona) : this(unRol)
        {
            this.unaPersona = unaPersona;
            SetPersona();
        }
        private void FrmAltaDeCliente_Load(object sender, EventArgs e)
        {
           
        }

        private void SetPersona()
        {
            this.txtEmail.Text = this.unaPersona.Email;
            this.txtNombre.Text = this.unaPersona.Nombre;
            this.txtDni.Text = this.unaPersona.Dni;
            this.DateFechaDeNacimiento.Value = this.unaPersona.FechaDeNacimiento;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (result = Persona.ValidarNombre(this.txtNombre.Text) == false)
            {
                this.lb_Fallas.Text = "\"el Nombre Debe Contener solo letras\"";
            }
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (result = Persona.ValidarDni(this.txtDni.Text) == false)
            {
                this.lb_Fallas.Text = "\"el Dni Debe tener como minimo 6 numeros y maximo 8 numeros";
            }

        }

        private void DateFechaDeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (result = Persona.ValidarFechaDeNacimiento(this.DateFechaDeNacimiento.Value) == false)
            {
                this.lb_Fallas.Text = "\"La fecha no es valida";
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
            if (result =  Persona.ValidarContracenia(this.txtClave.Text) == false)
            {
                this.lb_Fallas.Text = "\"el Clave Debe tener como minimo 8 caracteres";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (result = Persona.ValidarEmail(this.txtEmail.Text) == false)
            {
                this.lb_Fallas.Text = "\"el Email Debe tener como minimo 8 caracteres";
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            FrmListar.AbrirArchivo("Imagen de perfil", "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
