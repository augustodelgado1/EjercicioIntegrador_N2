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
    public abstract partial class FrmListar<T> : Form,IAbm<T>
        where T : class
    {
        private int indexRow;
        private int indexColumn;
        private List<T> listGeneric;
        SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        public event Action<string,string> InformarError;
        public event Action<string,string> Informar;
        public event Func<string, List<T>, List<T>> Buscador;
        public FrmListar(List<T> listGeneric)
        {
            InitializeComponent();
            this.listGeneric = listGeneric;
        }
        protected T this[int index]
        {
            get
            {
                T element = default;

                if (index >= 0 && index <= this.listGeneric.Count)
                {
                    element = this.listGeneric.ElementAt(index);
                }

                return element;
            }
        }
        private void FrmListar_Load(object sender, EventArgs e)
        {
            ActualizarDataGried(this.dgtvList,this.listGeneric);
        }

        private bool OnInformarError(string titulo, string mensaje)
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
        private List<T> OnSeBuscador(string mensaje,List<T> unaLista)
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
                this.Informar(titulo,mensaje);
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
                this.dgtvList[indexColumn, indexRow].Value = element;
                this.OnInformar("Alta", "Se realizo la Alta correctamente");
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this[indexRow] is not null
             && this.Baja(indexRow))
            {
                this.listGeneric.RemoveAt(indexRow);
                this.dgtvList[indexColumn, indexRow].Value = default;
                this.OnInformar("Baja", "Se realizo la Baja correctamente");
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            T element = this.Modificacion(indexRow);
            if (element is not null)
            {
                listGeneric[indexRow] = element;
                this.dgtvList[indexColumn, indexRow].Value = element;
                this.OnInformar("Modificacion", "Se realizo la modificacion correctamente");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarDataGried(this.dgtvList, this.OnSeBuscador(this.txtBuscar.Text, this.listGeneric));
        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e is not null && e.ColumnIndex <= dgtvList.Columns.Count &&
                 e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.RowIndex <= dgtvList.RowCount)
            {
                indexRow = e.RowIndex;
                indexColumn = e.ColumnIndex;
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
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
                        ActualizarDataGried(dgtvList,unLista);
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

        private void btnGuardarArchivo_Click(object sender, EventArgs e)
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

        private void btnInfo_Click(object sender, EventArgs e)
        {
            /*this.Mostrar(index);*/
        }

        public abstract T Alta();

        public abstract void ActualizarDataGried(DataGridView dgtv, List<T> lista);
        public abstract T Modificacion(int index);
        public abstract bool Baja(int index);
        public abstract void Mostrar(int index);
    }
}
