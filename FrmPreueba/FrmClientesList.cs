using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;

namespace FrmPreueba
{
    public partial class FrmClientesList : FrmListar<Cliente>
    {
        Cliente unCliente;
        public FrmClientesList(List<Cliente> listaDeClientes) : base(listaDeClientes)
        {
            InitializeComponent();
           
        }

        private void FrmClientesList_Load(object? sender, EventArgs e)
        {
            base.btnAgregar.Text = "Agregar un Cliente";
            base.btnModificar.Text = "Modificar un Cliente";
            base.btnCargar.Text = "Cargar Archivo";
            base.btnGuardarArchivo.Text = "Guardar Archivo";
            base.btnInfo.Text = "Mostrar Informacion Mas Ampliada";
            base.btnEliminar.Text = "Eliminar un Cliente";
            base.Informar += FrmClientesList_Informar;
            base.InformarError += FrmClientesList_InformarError; 
            base.Buscador += FrmClientesList_Buscador; 
        }

        private List<Cliente> FrmClientesList_Buscador(string text)
        {
            return listGeneric.FindAll(unCliente => unCliente is not null && unCliente.Nombre == text);
        }
        private void FrmClientesList_InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmClientesList_Informar(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override bool Alta()
        {
            FrmAltaDePersona frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente);
            bool estado;
            frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
            if(estado = frmAltaDeCliente.ShowDialog() == DialogResult.OK)
            {
                listGeneric.Add(unCliente);
            }
            return estado;
        }

        protected override void ConfigurarDataGrid(DataGridViewColumnCollection columnas)
        {
            foreach (DataGridViewColumn col in columnas)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (col is not null && (string.Compare(col.Name, "rol", true) == 0
                    || string.Compare(col.Name, "path", true) == 0 
                    || string.Compare(col.Name, "gastos", true) == 0))
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
                frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
                estado = true;
                if(frmAltaDeCliente.ShowDialog() == DialogResult.OK)
                {
                    listGeneric[index] = unCliente;
                }
            }

            return estado;
        }
        public override void Mostrar(int index)
        {
            


        }

        
    }
}
