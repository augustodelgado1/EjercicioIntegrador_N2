﻿using Entidades;
using FrmPreueba;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
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
using Entidades.Interfaces;
using Entidades.Archivo;

namespace TallerMecanico
{
    /// <summary>
    /// Permite Manejar los datos de una lista atravez de un abm , cosultar datos de esta lista , filtar elementos , etc
    /// </summary>
    /// <typeparam name="T">el tipo de la clase de abm que se va generar</typeparam>
    public abstract partial class FrmListar<T> : Form, IAbm<T>
        where T : class
    {
        protected T element;
        private int indexRow;
        protected List<T> listGeneric;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        protected event Action<string, string> InformarError;
        protected event Action<string, string> Informar;
        protected event Func<string, List<T>, List<T>> Buscador;
        protected event Func<List<T>, string, List<T>> Filtrar;
        public FrmListar(List<T> listGeneric)
        {
            InitializeComponent();
            this.listGeneric = listGeneric;
            this.Load += FrmListar_Load;
            indexRow = -1;
        }
        private T this[int index]
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
                    ManejadorInformarError("Error indice","Debe seleccionar un elemento valido");
                }

                return element;
            }
        }
        private void FrmListar_Load(object? sender, EventArgs e)
        {
            AgregarColumnasDataGried(this.dgtvList);
            ActualizarDataGried(this.dgtvList, this.listGeneric);
        }

        /// <summary>
        /// Permite invocar al evento InformarError pasandole los parametros , verificando que los parametros pasados sean validos y que el evento
        /// este referenciado a un metodo
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <returns>(false) si se cumplieron las condiciones ,(true) si se se pudo invocar al metodo</returns>
        private bool ManejadorInformarError(string titulo, string mensaje)
        {
            bool estado;
            estado = false;
            if (this.InformarError is not null)
            {
                this.InformarError(titulo, mensaje);
                estado = true;
            }

            return estado;
        }
        /// <summary>
        /// Permite invocar al evento Informar pasandole los parametros , verificando que los parametros pasados sean validos y que el evento
        /// este referenciado a un metodo
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <returns>(false) si se cumplieron las condiciones ,(true) si se se pudo invocar al metodo</returns>
        private bool ManejadorInformar(string titulo, string mensaje)
        {
            bool estado;

            estado = false;
            if (this.Informar is not null)
            {
                this.Informar(titulo, mensaje);
                estado = true;
            }

            return estado;
        }
        /// <summary>
        /// Permite invocar al evento Filtrar pasandole los parametros , verificando que los parametros pasados sean validos y que el evento
        /// este referenciado a un metodo
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nombreDelFiltro"></param>
        /// <returns>()</returns>
        private List<T> ManejadorFiltrar(List<T> lista,string nombreDelFiltro)
        {
            List<T> result;
            result = default;
            if (this.Filtrar is not null && lista is not null && nombreDelFiltro is not null)
            {
                result = this.Filtrar.Invoke(lista, nombreDelFiltro);
            }

            return result;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.Alta())
            {
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.ManejadorInformar("Alta", "Se realizo la Alta correctamente");
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this[indexRow] is not null 
             && this.Baja(this[indexRow]) == true)
            {
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.ManejadorInformar("Baja", "Se realizo la Baja correctamente");
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (this[indexRow] is not null 
             && Modificacion(this[indexRow]) == true)
            {
                ActualizarDataGried(this.dgtvList, this.listGeneric);
                this.ManejadorInformar("Modificacion", "Se realizo la modificacion correctamente");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<T> result;
            if (Buscador is not null)
            { 
                if ((result = this.Buscador(this.txtBuscar.Text, this.listGeneric)) is null
                  || this.txtBuscar.Text == string.Empty)
                {
                    ActualizarDataGried(this.dgtvList, this.listGeneric);
                }
                else
                {
                    ActualizarDataGried(this.dgtvList, result);
                }
            }
            
        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = -1;
            if (e is not null && e.ColumnIndex <= dgtvList.Columns.Count &&
                 e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.RowIndex <= dgtvList.RowCount)
            {
                indexRow = e.RowIndex;
                element = this[indexRow];
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
                    if ((unLista = JsonFile<T>.LeerArchivo(this.openFileDialog.FileName)) is not null)
                    {
                        ActualizarDataGried(dgtvList, listGeneric);
                        this.ManejadorInformar("Abrir Archivo", "Se cargo el archivo correctamente");
                    }
                }
                catch (Exception ex)
                {
                    ManejadorInformarError("Abrir Archivo", ex.Message);
                }
            }
        }
        /// Le Pide al usurio que seleccione donde quiere guardar el arhivo 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="filter"></param>
        /// <param name="initialDirectory"></param>
        /// <returns>(SaveFileDialog) ua instancia con los datos de archivo,(NULL) de caso contrario</returns>
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
        /// <summary>
        /// Le Pide al usurio que seleccione que un archivo 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="filter"></param>
        /// <param name="initialDirectory"></param>
        /// <returns>(OpenFileDialog) ua instancia con los datos de archivo,(NULL) de caso contrario</returns>
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
            if (sender is ComboBox unComboBox)
            {
                this.ActualizarDataGried(this.dgtvList, ManejadorFiltrar(this.listGeneric, unComboBox.Text));
            }
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            this.Mostrar(this[indexRow]);
        }
        private void BtnGuardarArchivo_Click(object sender, EventArgs e)
        {
            if ((this.saveFileDialog = GuardarArchivo("Guardar archivo", "Archivo Json (*.Json)|*.Json",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) is not null)
            {
                 
                try
                {
                    JsonFile<T>.GuardarArchivo(this.saveFileDialog.FileName, listGeneric);//Le paso el path y lo guardo
                    ManejadorInformar("Guardar archivo", "los datos se Guardaron correctamente ");
                }
                catch (Exception ex)
                {
                    ManejadorInformarError("Guardar archivo", ex.Message);
                }
            }
        }


        public abstract bool Alta();

        /// <summary>
        /// Guarda los datos de la lista en el dataGriedView
        /// </summary>
        /// <param name="dgtv">el dataGriedView donde se van a guardar los datos</param>
        /// <param name="lista">la lista con los elementos a guardar</param>
        public abstract void ActualizarDataGried(DataGridView dgtv, List<T> lista);

        /// <summary>
        /// Agrega columnas al Data dataGriedView
        /// </summary>
        /// <param name="dgtvList"></param>
        /// <param name="listGeneric"></param>
        public abstract void AgregarColumnasDataGried(DataGridView dgtvList);
        public abstract bool Baja(T element);
        public abstract bool Mostrar(T element);
        public abstract bool Modificacion(T element);
    }
}
