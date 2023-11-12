using Entidades;
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
using System.Windows.Forms;

namespace TallerMecanico
{
    public partial class FrmMenuPrincipal : Form
    {
        private FrmClientesList frmClientes;
        private FrmSevicios frmSevicios;
        private Usuario unUsuario;
        private Action SeCierraElForm;
        private FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void OnSeCierraElForm()
        {
            if (SeCierraElForm is not null)
            {
                SeCierraElForm.Invoke();
            }
        }
        public FrmMenuPrincipal(Usuario unUsuario) : this()
        {
            this.unUsuario = unUsuario;
            this.Load += FrmMenuPrincipal_Load;
            this.FormClosing += FrmMenuPrincipal_FormClosing;
        }

        private void FrmMenuPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if(Confirmar("¿Esta seguro que quiere salir?", "Salir") == false)
            {
                e.Cancel = true;
                OnSeCierraElForm();
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
                unForm.Dock = DockStyle.Bottom;
                this.panelContenedor.Controls.Add(unForm);
                unForm.Show();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes = new FrmClientesList(Negocio.Clientes);
            AbrirPanel(frmClientes);
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            /*frmSevicios = new FrmSevicios(Negocio.unClienteRandom);*/
            AbrirPanel(frmSevicios);
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {

        }

        private void btnCofig_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

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
