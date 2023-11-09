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
using TallerMecanico;

namespace FrmPreueba
{
    public partial class FrmClientesList : FrmListar<Cliente>
    {
        Cliente unCliente;
        public FrmClientesList() : base(new List<Cliente>())
        {
            InitializeComponent();
        }

        public override Cliente Alta()
        {
            FrmAltaDePersona frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente);
            frmAltaDeCliente.seRealizoUnAlta += FrmAltaDeCliente_seRealizoUnAlta;
            frmAltaDeCliente.ShowDialog();
            return unCliente;
        }

        protected override void ConfigurarDataGrid(DataGridViewColumnCollection columnas)
        {
            foreach (DataGridViewColumn col in columnas)
            {
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (col is not null && (string.Compare(col.Name, "rol",true) == 0 || string.Compare(col.Name, "path", true) == 0))
                { 
                    col.Visible = false;
                }
            }
        }

        private void FrmAltaDeCliente_seRealizoUnAlta(Persona obj)
        {
            if (obj is Cliente clienteAlta)
            {
                unCliente = clienteAlta;
                Negocio.listaDeCliente.Add(unCliente);
            }
        }

        public override bool Baja(int index)
        {
            bool estado = false;
            if (listGeneric.Count  > 0 && index >= 0 && index <= listGeneric.Count)
            {
                listGeneric.Remove(listGeneric[index]);
                estado = true;
            }

            return estado;
        }

        public override bool Modificacion(int index)
        {
            bool estado = false;
            FrmAltaDePersona frmAltaDeCliente;
            if (listGeneric.Count > 0 && index >= 0 && index <= listGeneric.Count)
            {
                frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente, listGeneric[index]);
                estado = true;
                frmAltaDeCliente.ShowDialog();
            }

            return estado;
        }

        public override void Mostrar(int index)
        {
            throw new NotImplementedException();
        }

        public override void Mostrar(List<Cliente> list)
        {
            throw new NotImplementedException();
        }

        
    }
}
