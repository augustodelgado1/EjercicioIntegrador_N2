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
            base.cmbFilter.Visible = false; 
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

        private List<Cliente> FrmClientesList_Buscador(string text, List<Cliente> listaDeClientes)
        {
            List<Cliente> result = default;
            if (listaDeClientes is not null && string.IsNullOrWhiteSpace(text) == false)
            {
                text = text.ToLower();
                result = listaDeClientes.FindAll(unCliente => unCliente is not null && unCliente.Nombre.Contains(text) );
            }
            return result;
        }
        private void FrmClientesList_InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmClientesList_Informar(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override Cliente Alta()
        {
            FrmAltaDePersona frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente);
            bool estado;
            frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
            if(estado = frmAltaDeCliente.ShowDialog() != DialogResult.OK)
            {
                unCliente = null;
            }
            return unCliente;
        }

        protected override void ActualizarDataGried(DataGridView dgtv, List<Cliente> lista)
        {
            string textoCot;
            if (dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear();
                foreach (Cliente unCliente in lista)
                {
                    dgtv.Rows.Add(unCliente.Nombre, unCliente.Email, unCliente.FechaDeNacimiento, unCliente.Gastos);
                }
            }
        }

        protected override void AgregarColumnasDataGried(DataGridView dgtvList, List<Cliente> listGeneric)
        {
            dgtvList.Columns.Add("colClienteName", "Nombre");
            dgtvList.Columns.Add("colEmailName", "Email");
            dgtvList.Columns.Add("colFechaDeNacimiento", "FechaDeNacimiento");
            dgtvList.Columns.Add("colGastos", "Gastos");
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
            return true;
        }

        public override Cliente Modificacion(int index)
        {
            bool estado = false;
            FrmAltaDePersona frmAltaDeCliente;
            frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente, base[index]);
            frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
            estado = true;
            if(frmAltaDeCliente.ShowDialog() != DialogResult.OK)
            {
                unCliente = null;
            }
            return unCliente;
        }
        public override void Mostrar(int index)
        {
            


        }

        
    }
}
