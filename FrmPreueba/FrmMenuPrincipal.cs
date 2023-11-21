using Entidades;
using Entidades.BaseDeDatos;
using FrmPreueba;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TallerMecanico
{
    public partial class FrmMenuPrincipal : Form
    {
        private FrmClientesList frmClientes;
        private FrmSevicios frmSevicios;
        private FrmVehiculo frmVehiculo;
        private Usuario unUsuario;
        private Negocio unNegocio;
        private Task tareaProssgerBar;
        public event Action<object> CancelarProgessBar;
        public event Action TerminarProgessBar;
        CancellationTokenSource cancellationToken;
        private FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        public FrmMenuPrincipal(Negocio unNegocio, Usuario unUsuario) : this()
        {
            this.unNegocio = unNegocio;
            this.unUsuario = unUsuario;
            this.Load += FrmMenuPrincipal_Load;
            this.FormClosing += FrmMenuPrincipal_FormClosing;

        }

        private void FrmMenuPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (Confirmar("¿Esta seguro que quiere salir?", "Salir") == true)
            {
                try
                {
                    unNegocio.GuardarBaseDeDatos();
                }
                catch (Exception ex)
                {
                    InformarError("Guardar Datos", ex.Message);
                }
                e.Cancel = false;
            }
        }

        private void FrmMenuPrincipal_Load(object? sender, EventArgs e)
        {
            unNegocio.ActualizarClientes();
            frmClientes = new FrmClientesList(unNegocio, unUsuario.Rol);
            AbrirPanel(frmClientes);
            this.panelContenedor.Tag = "Clientes";
           
        }
        /// <summary>
        /// Informa que sucedio un error atraves de un MessageBox
        /// </summary>
        /// <param name="titulo">Titulo del error</param>
        /// <param name="mensajeDeError">el mensaje de error que indica que error sucedio</param>
        public static void InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Informa que sucedio un suceso atraves de un MessageBox
        /// </summary>
        /// <param name="titulo">Titulo del suceso</param>
        /// <param name="mensajeDeError">el mensaje de error que indica que suceso sucedio</param>
        public static void Informar(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// le Muestra al usuario un mesaje con MessageBox un donde le da dos opciones para elegir (si o no)
        /// 
        /// </summary>
        /// <param name="mensaje">un Mesaje que se va a mostrar</param>
        /// <param name="titulo">el titulo del mensaje</param>
        /// <returns>(si == true)</returns>
        public static bool Confirmar(string mensaje, string titulo)
        {
            bool resultado = false;

            if (string.IsNullOrWhiteSpace(mensaje) == false && string.IsNullOrWhiteSpace(titulo) == false
             && MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Guarda un formulario en el panel y lo abre 
        /// </summary>
        /// <param name="unForm">el formulario a guardar y abrir</param>
        private void AbrirPanel(Form unForm)
        {
            if (unForm is not null)
            {
                if (this.panelContenedor.Controls.Count > 0)
                {
                    this.panelContenedor.Controls.Clear();
                }
                unForm.TopLevel = false;
                unForm.FormBorderStyle = FormBorderStyle.None;
                unForm.Dock = DockStyle.Bottom;
                this.panelContenedor.Controls.Add(unForm);
                unForm.Show();

            }
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Tag is string texto && texto != "Clientes")
            {
                frmClientes = new FrmClientesList(unNegocio, unUsuario.Rol);
                AbrirPanel(frmClientes);
                this.panelContenedor.Tag = "Clientes";
            }
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Tag is string texto && texto != "Servicio")
            {
                if (unUsuario is Cliente unCliente)
                {
                    unNegocio.ActualizarClientes();
                    frmSevicios = new FrmSevicios(unCliente.Servicios, unNegocio, unCliente);
                    this.AbrirPanel(frmSevicios);
                }
                else
                {

                    FrmTareas frmTareas = new FrmTareas(unNegocio, unNegocio.ServiciosEnProcesos);
                    frmTareas.Show();

                }

                this.panelContenedor.Tag = "Servicio";
            }
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Tag is string texto && texto != "Vehiculos")
            {
                frmVehiculo = new FrmVehiculo(unNegocio.ListaDeVehiculos);
                AbrirPanel(frmVehiculo);
                this.panelContenedor.Tag = "Vehiculos";
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestra un Control informando que criterio debe cumplir el elemento pasado por parametro
        /// </summary>
        /// <param name="unControl">el control que va a mostrar el error</param>
        /// <param name="mensaje">Mensaje informando que criterio debe cumplir el control</param>
        /// <param name="predicate">el metodo que va a derminar si se cumplieron las criterio , que debe
        /// <param name="element">el elemento a verificar</param>
        /// retornar (True) en caso que se cumpla o (false) de caso contrario</param>
        /// <returns>(false) en caso de que el elemento no se cumpla con la criterio de el metodo pasado por parametro,
        /// de lo contrario devueve (true)</returns>
        public static bool ActivarControlError<T>(Control unControl, string msgError, Predicate<T> predicate, T element)
        {
            bool estado;
            estado = false;
            if (unControl is not null && predicate is not null)
            {
                unControl.Visible = true;
                unControl.Text = msgError;
                if ((estado = predicate.Invoke(element)) == true)
                {
                    estado = true;
                    unControl.Visible = false;
                }
            }

            return estado;
        }

        /// <summary>
        /// Recorre la lista de controles y verifica si un text box esta vacio
        /// </summary>
        /// <param name="listaDeControles">una lista de controles</param>
        /// <returns>(true) si no encontro ningun text box vacio , (false) de caso contrario </returns>
        public static bool DetectarTextBoxVacio(Control.ControlCollection listaDeControles)
        {
            bool result = false;
            if (listaDeControles is not null)
            {
                result = true;
                foreach (Control unControlDeLaLista in listaDeControles)
                {
                    if (unControlDeLaLista is TextBox unTexbox
                     && string.IsNullOrWhiteSpace(unTexbox.Text))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

    }
}
