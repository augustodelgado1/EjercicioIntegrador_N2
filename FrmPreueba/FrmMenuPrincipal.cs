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
        private FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        public FrmMenuPrincipal(Usuario unUsuario) : this()
        {
            this.unUsuario = unUsuario;
            this.Load += FrmMenuPrincipal_Load;
            this.FormClosing += FrmMenuPrincipal_FormClosing;
        }

        private void FrmMenuPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (Confirmar("¿Esta seguro que quiere salir?", "Salir") == false)
            {
                try
                {
                    unNegocio.GuardarBaseDeDatos();
                }
                catch (Exception ex)
                {
                    InformarError("Guardar Datos", ex.Message);
                }
                e.Cancel = true;
            }
        }

        public void SetUser(Usuario unUsuario)
        {
            if (unUsuario is not null)
            {

            }
        }

        private void FrmMenuPrincipal_Load(object? sender, EventArgs e)
        {
            this.SetUser(this.unUsuario);
            this.panelContenedor.Tag = "Inicio";
            try
            {
                unNegocio = new Negocio("Taller Mecanico", new ServicioDao().Leer(), new ClienteDao().Leer(), new VehiculoDao().Leer());
            }
            catch (Exception ex)
            {
                InformarError("Carga de Datos", ex.Message);
                this.Close();
            }
            frmSevicios = new FrmSevicios((Persona)unUsuario, unNegocio.ListaDeServicio);
            AbrirPanel(frmSevicios);
        }

        private void InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Informar(string titulo, string mensajeDeError)
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Tag is string texto && texto != "Clientes")
            {
                frmClientes = new FrmClientesList(unNegocio);
                AbrirPanel(frmClientes);
                this.panelContenedor.Tag = "Clientes";
            }
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            if (unUsuario is Cliente unCliente && this.panelContenedor.Tag is string texto && texto != "Servicio")
            {
                frmSevicios = new FrmSevicios(unCliente, unCliente.Servicios);
                AbrirPanel(frmSevicios);
            }
            else
            {
                if (unUsuario is Mecanico unMecanico)
                {
                    frmSevicios = new FrmSevicios(unMecanico, unNegocio.ListaDeServicio);
                    AbrirPanel(frmSevicios);
                }
            }
            this.panelContenedor.Tag = "Servicio";
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
        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Tag is string texto && texto != "Inicio")
            {
                frmSevicios = new FrmSevicios(unNegocio.ListaDeServicio);
                AbrirPanel(frmSevicios);
                this.panelContenedor.Tag = "Inicio";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
