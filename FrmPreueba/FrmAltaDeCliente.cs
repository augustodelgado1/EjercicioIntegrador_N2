using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;

namespace FrmPreueba
{
    public partial class FrmAltaDePersona : Form
    {
        OpenFileDialog ofd;
        Cliente unaPersona;
        Usuario.Roles unRol;
        Cliente ClienteModify;
        public event Action<Cliente> seIngesaronDatos;
        bool result;
        string path;

        public FrmAltaDePersona(Usuario.Roles unRol)
        {
            InitializeComponent();
            this.unRol = unRol;
            this.path = null;
        }
        /// <summary>
        /// Permite invocar al evento seIngesaronDatos pasandole los parametros 
        /// , verificando que los parametros pasados sean validos y que el evento
        /// este referenciado a un metodo
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <returns>(false) si se cumplieron las condiciones ,(true) si se se pudo invocar al metodo</returns>
        private void ManejadorSeIngesaronDatos(Cliente unaPersona)
        {
            if (seIngesaronDatos is not null)
            {
                seIngesaronDatos(unaPersona);
            }
        }
        public FrmAltaDePersona(Usuario.Roles unRol, Cliente ClienteModify) : this(unRol)
        {
            this.ClienteModify = ClienteModify;
            SetPersona();
        }
        private void FrmAltaDeCliente_Load(object sender, EventArgs e)
        {
            this.lb_Fallas.Visible = false;
        }
        private void SetPersona()
        {
            if (this.ClienteModify is not null)
            {
                this.txtEmail.Text = this.ClienteModify.Email;
                this.txtNombre.Text = this.ClienteModify.Nombre;
                this.txtDni.Text = this.ClienteModify.Dni;
                this.path = this.ClienteModify.Path;
                this.txtClave.Visible = false;
                this.txtClave.Text = this.ClienteModify.Clave;
                this.DateFechaDeNacimiento.Value = this.ClienteModify.FechaDeNacimiento;
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            result = FrmMenuPrincipal.ActivarControlError(lb_Fallas, "No se aceptan valores vacios", FrmMenuPrincipal.DetectarTextBoxVacio, this.Controls) == true
                && FrmMenuPrincipal.ActivarControlError(lb_Fallas, "el dni debe tener como min 6 y max 8 numeros", Cliente.ValidarDni, this.txtDni.Text)
                && FrmMenuPrincipal.ActivarControlError(lb_Fallas, "La fecha no es valida", Cliente.ValidarFechaDeNacimiento, this.DateFechaDeNacimiento.Value) == true
                && FrmMenuPrincipal.ActivarControlError(lb_Fallas, "el Nombre Debe Contener solo letras", Cliente.ValidarNombre, this.txtNombre.Text) == true
                && FrmMenuPrincipal.ActivarControlError(lb_Fallas, "el Email Debe tener como min 8 caracteres", Cliente.ValidarEmail, this.txtEmail.Text)
                && FrmMenuPrincipal.ActivarControlError(lb_Fallas, "el Clave Debe tener como min 8 caracteres", Cliente.ValidarContracenia, this.txtClave.Text);

            if (result == true)
            {
                this.unaPersona = new Cliente(this.txtNombre.Text, this.txtDni.Text, this.DateFechaDeNacimiento.Value, this.txtEmail.Text, this.txtClave.Text, path); ;
                if (ClienteModify is not null)
                {
                    this.unaPersona.Servicios = ClienteModify.Servicios;
                }
                ManejadorSeIngesaronDatos(this.unaPersona);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            result = FrmMenuPrincipal.ActivarControlError(lb_Fallas, "el Email Debe tener como min 8 caracteres", Cliente.ValidarEmail, this.txtEmail.Text);
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            ofd = FrmListar<Cliente>.AbrirArchivo("Imagen de perfil", "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            if (ofd is not null)
            {
                this.path = ofd.FileName;
            }
        }
    }
}
