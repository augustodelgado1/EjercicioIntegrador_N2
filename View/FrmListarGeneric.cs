using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanico
{
    public abstract partial class FrmListarGeneric<T> : Form
    {
        T element;
        protected List<T> list;
        private event Action<T> seRealizoAlta;
        private event Action<T> seRealizoModificacion;
        private event Action<T> seRealizoBaja;

        private FrmListarGeneric()
        {
            InitializeComponent();
        }

        private void FrmListarLoad(object sender, EventArgs e)
        {
            this.SetDataGridView(dgtvList);
        }

        private bool SetListDataGridView(List<T> list)
        {
            bool result;
            result = false;
            if (list is not null && list.Count > 0)
            {
                this.dgtvList.DataSource = null;
                this.dgtvList.DataSource = list;
                result = true;
            }
            return result;
        }
        public FrmListarGeneric(List<T> list):this() 
        {
            this.list = list;
        }
        protected virtual T Agregar()
        {
            return default;
        }
        protected virtual bool SetDataGridView(DataGridView dgtv)
        {
            return default;
        }
        protected virtual bool Modificar(T element)
        {
            return default;
        }
        protected virtual bool Eliminar(int index)
        {
            return default;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Agregar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgtvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
