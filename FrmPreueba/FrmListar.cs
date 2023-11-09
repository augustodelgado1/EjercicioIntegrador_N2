using Archi01;
using Entidades;
using FrmPreueba;
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

namespace TallerMecanico
{
    public abstract partial class FrmListar<T> : Form,IAbm<T>
        where T : class
    {
        int index;
        protected List<T> listGeneric;
        SaveFileDialog saveFileDialog;
        public event Action<T> SeRealizoModificacion;
        public event Action<T> SeRealizoBaja;
        public event Action<string,string> InformarError;
        public FrmListar(List<T> listGeneric)
        {
            InitializeComponent();
            this.listGeneric = listGeneric;
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            ActualizarDataGriedViewList();
            this.ConfigurarDataGrid(this.dgtvList.Columns);
        }

        private bool OnInformar(string titulo, string mensaje)
        {
            bool estado;
            
            estado = false;
            if (this.InformarError is not null
             && string.IsNullOrWhiteSpace(titulo) == false
             && string.IsNullOrWhiteSpace(mensaje) == false)
            {
                this.InformarError(titulo,mensaje);
                estado = true;
            }

            return estado;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Alta();
            ActualizarDataGriedViewList();
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            this.Baja(index);
            ActualizarDataGriedViewList();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            this.Modificacion(index);
            ActualizarDataGriedViewList();
            
        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e is not null)
            {
                index = e.RowIndex;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if ((this.saveFileDialog = GuardarArchivo("Guardar archivo", "Archivo Json (*.Json)|*.Json",
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                try
                {
                    this.listGeneric = JsonFile<T>.LeerArchivoArray(this.saveFileDialog.FileName);
                    ActualizarDataGriedViewList();
                }
                catch (Exception ex)
                {
                    InformarError.Invoke("Abrir Archivo", ex.Message);
                   /* MessageBox.Show("Abrir Archivo", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                }

            }
        }

        private SaveFileDialog GuardarArchivo(string title, string filter, string initialDirectory)
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

        private OpenFileDialog AbrirArchivo(string title, string filter, string initialDirectory)
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
                    JsonFile<T>.GuardarArchivoArray(this.saveFileDialog.FileName, listGeneric);
                    MessageBox.Show("los datos se Guardaron correctamente ", "Se guardaron Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    InformarError.Invoke("Guardar archivo", ex.Message);
                   /* MessageBox.Show("Guardar Archivo", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                }

            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            this.Mostrar(index);
        }

        public abstract T Alta();
        public abstract bool Modificacion(int index);
        public abstract bool Baja(int index);
        public abstract void Mostrar(int index);
        public abstract void Mostrar(List<T> list);
        private void ActualizarDataGriedViewList()
        {
            if (this.dgtvList is not null)
            {
                this.dgtvList.DataSource = null;
                this.dgtvList.DataSource = this.listGeneric;
            }
        }

        protected abstract void ConfigurarDataGrid(DataGridViewColumnCollection columnas);
    }
}
