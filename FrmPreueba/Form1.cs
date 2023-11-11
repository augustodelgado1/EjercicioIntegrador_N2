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
using System.Xml.Linq;

namespace TallerMecanico
{
    public abstract partial class FrmListar<T> : Form, IAbm<T>
        where T : class
    {
        private int indexRow;
        private List<T> listGeneric;
        SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        public event Action<string, string> InformarError;
        public event Action<string, string> Informar;
        public event Func<string, List<T>, List<T>> Buscador;
        public FrmListar(List<T> listGeneric)
        {
            InitializeComponent();
            this.listGeneric = listGeneric;
            this.Load += FrmListar_Load;
            indexRow = -1;
        }
        protected T this[int index]
        {
            get
            {
                T element = default;
                try
                {
                    element = this.listGeneric.ElementAt(index);
                }
                catch (Exception)
                {
                    OnInformarError("Error indice","Debe seleccionar un elemento valido");
                }

                return element;
            }
        }
        private void FrmListar_Load(object? sender, EventArgs e)
        {
            AgregarColumnasDataGried(this.dgtvList, this.listGeneric);
            ActualizarDataGried(this.dgtvList, this.listGeneric);
        }

        

        private bool OnInformarError(string titulo, string mensaje)
        {
            bool estado;
            estado = false;
            if (this.InformarError is not null
             && string.IsNullOrWhiteSpace(titulo) == false
             && string.IsNullOrWhiteSpace(mensaje) == false)
            {
                this.InformarError(titulo, mensaje);
                estado = true;
            }

            return estado;
        }
        private List<T> OnSeBuscador(string mensaje, List<T> unaLista)
        {
            List<T> list = default;
            if (Buscador is not null)
            {
                list = this.Buscador.Invoke(mensaje, unaLista);
            }

            return list;
        }

        private bool OnInformar(string titulo, string mensaje)
        {
            bool estado;

            estado = false;
            if (this.Informar is not null
             && string.IsNullOrWhiteSpace(titulo) == false
             && string.IsNullOrWhiteSpace(mensaje) == false)
            {
                this.Informar(titulo, mensaje);
                estado = true;
            }

            return estado;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            T element;
            element = this.Alta();
            if (element is not null)
            {
                listGeneric.Add(element);
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.OnInformar("Alta", "Se realizo la Alta correctamente");
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this[indexRow] is not null
             && this.Baja(indexRow))
            {
                this.listGeneric.RemoveAt(indexRow);
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.OnInformar("Baja", "Se realizo la Baja correctamente");
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            T element;
            if (this[indexRow] is not null 
             && (element = this.Modificacion(indexRow)) is not null)
            {
                listGeneric[indexRow] = element;
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.OnInformar("Modificacion", "Se realizo la modificacion correctamente");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<T> result;
            if((result = this.OnSeBuscador(this.txtBuscar.Text, this.listGeneric)) is  null 
              || this.txtBuscar.Text == string.Empty)
            {
                ActualizarDataGried(this.dgtvList, this.listGeneric);
            }
            else
            {
                ActualizarDataGried(this.dgtvList, result);
            }
            
        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = -1;
            if (e is not null && e.ColumnIndex <= dgtvList.Columns.Count &&
                 e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.RowIndex <= dgtvList.RowCount)
            {
                indexRow = e.RowIndex;
            }
        }
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            List<T> unLista;
            if ((this.openFileDialog = AbrirArchivo("Cargar archivo", "Archivo Json (*.Json)|*.Json",
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                try
                {
                    if ((unLista = JsonFile<T>.LeerArchivoArray(this.openFileDialog.FileName)) is not null)
                    {
                        this.listGeneric = unLista;
                        ActualizarDataGried(dgtvList, unLista);
                    }
                }
                catch (Exception ex)
                {
                    OnInformarError("Abrir Archivo", ex.Message);
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

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BtnGuardarArchivo_Click(object sender, EventArgs e)
        {
            if ((this.saveFileDialog = GuardarArchivo("Guardar archivo", "Archivo Json (*.Json)|*.Json",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                try
                {
                    JsonFile<T>.GuardarArchivoArray(this.saveFileDialog.FileName, listGeneric);
                    OnInformar("Guardar archivo", "los datos se Guardaron correctamente ");
                }
                catch (Exception ex)
                {
                    OnInformarError("Guardar archivo", ex.Message);
                }

            }
        }

        public abstract T Alta();
        protected abstract void ActualizarDataGried(DataGridView dgtv, List<T> lista);
        protected abstract void AgregarColumnasDataGried(DataGridView dgtvList, List<T> listGeneric);
        public abstract T Modificacion(int index);
        public abstract bool Baja(int index);
        public abstract void Mostrar(int index);
    }
}
