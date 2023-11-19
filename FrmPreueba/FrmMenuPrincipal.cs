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

        public void SetUser(Usuario unUsuario)
        {
            if (unUsuario.Rol == Usuario.Roles.Cliente)
            {

            }
        }

        private void FrmMenuPrincipal_Load(object? sender, EventArgs e)
        {
            this.SetUser(this.unUsuario);
            frmClientes = new FrmClientesList(unNegocio, unUsuario.Rol);
            AbrirPanel(frmClientes);
            this.panelContenedor.Tag = "Clientes";
        }

        public static void InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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
        CancellationTokenSource cancellationToken;
        public Task ActivarProgessBar(ProgressBar barra, Servicio unServicio)
        {
            if (unServicio is not null && (tareaProssgerBar is null || tareaProssgerBar.IsCompleted == true || tareaProssgerBar.IsCanceled == true))
            {
                return Task.Run(() => AvanzarProgessBar(barra, unServicio), cancellationToken.Token);
            }

            return default;
        }
        private void AvanzarProgessBar(ProgressBar barra, Servicio unServicio)
        {
            Random random = new Random();

            if (barra is not null)
            {
                do
                {
                    Thread.Sleep(random.Next(100, 1000));
                    IncrementarProgessBar(barra);
                } while (barra.Value < barra.Maximum && tareaProssgerBar.IsCanceled == false);
                barra.Visible = false;
                barra.Value = 0;
                unServicio.Estado = Servicio.EstadoDelSevicio.Terminado;
            }
        }
        private void IncrementarProgessBar(ProgressBar barra)
        {
            if (InvokeRequired)
            {
                Invoke(() => IncrementarProgessBar(barra));
            }
            else
            {
                barra.Increment(1);
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
                    frmSevicios = new FrmSevicios(unCliente.Servicios, unNegocio, unCliente);
                }
                else
                {
                    frmSevicios = new FrmSevicios(unNegocio.ListaDeServicio, unNegocio, unUsuario);
                }
                this.AbrirPanel(frmSevicios);
                this.panelContenedor.Tag = "Servicio";
            }
        }

        /*private Task FrmSevicios_Predicate(Servicio obj)
        {
            this.progressBar1.Visible = true;
            return ActivarProgessBar(this.progressBar1, obj);
        }
*/
        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            if (unUsuario is Cliente unCliente && this.panelContenedor.Tag is string texto && texto != "Vehiculos")
            {
                frmVehiculo = new FrmVehiculo(unNegocio, unCliente, unCliente.Vehiculos);
            }
            else
            {
                if (unUsuario.Rol != Usuario.Roles.Cliente)
                {
                    frmVehiculo = new FrmVehiculo(unNegocio.ListaDeVehiculos);
                }
            }
            AbrirPanel(frmVehiculo);
            this.panelContenedor.Tag = "Vehiculos";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
