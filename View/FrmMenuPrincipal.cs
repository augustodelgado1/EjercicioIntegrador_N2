using Entidades;
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
        private Usuario unUsuario;
        private FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        public FrmMenuPrincipal(Usuario unUsuario) : this()
        {
            this.unUsuario = unUsuario;
            this.Load += FrmMenuPrincipal_Load;
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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
