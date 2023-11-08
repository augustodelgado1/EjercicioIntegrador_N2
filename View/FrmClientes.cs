using Entidades;
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
    public partial class FrmClientes: FrmListarGeneric<Cliente>
    {
        public FrmClientes(List<Cliente> lista):base(lista) 
        {
            InitializeComponent();
        }

        protected override Cliente Agregar()
        {
            throw new NotImplementedException();
        }

        protected override bool Eliminar(int index)
        {
            throw new NotImplementedException();
        }

        protected override bool Modificar(Cliente element)
        {
            throw new NotImplementedException();
        }

        protected override bool SetDataGridView(DataGridView dgtv)
        {
            throw new NotImplementedException();
        }
    }
}
