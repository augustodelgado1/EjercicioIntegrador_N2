using Archi01;
using Entidades;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace TallerMecanico
{
    public partial class FrmListar : Form
    {
        Cliente unCliente;
        List<Cliente> clienteList;
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;
        public event Action<Cliente> SeRealizoAlta;
        public event Action<string> Buscador;
        public FrmListar()
        {
            InitializeComponent();
        }

        private bool OnSeRealizoAlta(Cliente unCliente)
        {
            bool estado;
            estado = false;
            if (SeRealizoAlta is not null)
            {
                this.SeRealizoAlta.Invoke(unCliente);
                estado = true;
            }

            return estado;
        }

        private bool OnSeBuscador(string mensaje)
        {
            bool estado;
            estado = false;
            if (Buscador is not null)
            {
                this.Buscador.Invoke(mensaje);
                estado = true;
            }

            return estado;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaDePersona frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente);

            if (frmAltaDeCliente.ShowDialog() == DialogResult.OK)
            {
                OnSeRealizoAlta(unCliente);
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if ((this.openFileDialog = AbrirArchivo("Cargar archivo", "Archivo Json (*.Json)|*.Json",
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                try
                {
                    this.clienteList = JsonFile<Cliente>.LeerArchivoArray(this.openFileDialog.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Abrir Archivo", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public static SaveFileDialog GuardarArchivo(string title, string filter, string initialDirectory)
        {
            SaveFileDialog saveFileDialog = null;
            DialogResult result;
            if (title is not null && filter is not null && initialDirectory is not null)
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = title;
                saveFileDialog.Filter = filter;
                saveFileDialog.InitialDirectory = initialDirectory;
                saveFileDialog.FileName = "saveFile";

                if ((result = saveFileDialog.ShowDialog()) != DialogResult.OK)
                {
                    saveFileDialog = null;
                }
            }

            return saveFileDialog;
        }

        public static OpenFileDialog AbrirArchivo(string title, string filter, string initialDirectory)
        {
            OpenFileDialog openFileDialog = default;
            DialogResult result;

            if (title is not null && filter is not null
               && initialDirectory is not null)
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = title;
                openFileDialog.Filter = filter;
                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.FileName = "saveFile";
                result = openFileDialog.ShowDialog();
            }

            return openFileDialog;
        }

        private void btnGuardarArchivo_Click(object sender, EventArgs e)
        {
            if ((this.saveFileDialog = GuardarArchivo("Guardar archivo", "Archivo Json (*.Json)|*.Json",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                try
                {
                    JsonFile<Cliente>.GuardarArchivoArray(this.saveFileDialog.FileName, clienteList);
                    MessageBox.Show("los datos se Guardaron correctamente ", "Se guardaron Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Guardar Archivo", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
