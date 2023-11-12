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
        bool estado;
        private Predicate<PropertyInfo> unPropertyInfoPredicate;
        public FrmClientesList(List<Cliente> listaDeClientes) : base(listaDeClientes)
        {
            InitializeComponent();
           
        }
        private void FrmClientesList_Load(object? sender, EventArgs e)
        {
            base.cmbFilter.Visible = false;
            base.Informar += FrmClientesList_Informar;
            base.InformarError += FrmClientesList_InformarError; 
            base.Buscador += FrmClientesList_Buscador;
            unPropertyInfoPredicate = unaPrpiedad =>
            {
                return string.Compare(unaPrpiedad.Name, "Nombre", true) == 0
                || string.Compare(unaPrpiedad.Name, "Dni", true) == 0
                || string.Compare(unaPrpiedad.Name, "FechaDeNacimiento", true) == 0 ||
                string.Compare(unaPrpiedad.Name, "Gastos", true) == 0 ||
                string.Compare(unaPrpiedad.Name, "CantidadDeServicios", true) == 0;

            };
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

        public override bool Baja(Cliente unCliente)
        {
            estado = false;
            FrmMostrar<Cliente> frmMostrar;

            if (unCliente is not null)
            {
                frmMostrar = new FrmMostrar<Cliente>(unCliente, unPropertyInfoPredicate, unCliente.Path, "Un Cliente");
                frmMostrar.Activated += FrmMostrar_Shown;
                frmMostrar.Show();
            }

            return estado;
        }

        private void FrmMostrar_Shown(object? sender, EventArgs e)
        {
            if (sender is FrmMostrar<Cliente>)
            {
                estado = FrmMenuPrincipal.Confirmar("¿Esta seguro que desea eliminar ese Cliente", "Eliminar");
                ((FrmMostrar<Cliente>)sender).Close();
            }
        }

        public override bool Modificacion(Cliente unClienteEdit)
        {
            bool estado = false;
            FrmAltaDePersona frmAltaDeCliente;
            if (unClienteEdit is not null)
            {
                frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente, unClienteEdit);
                frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
                if (frmAltaDeCliente.ShowDialog() == DialogResult.OK)
                {
                    unClienteEdit = this.unCliente;
                    estado = true;
                }
            }
            return estado;
        }

       
        public override bool Mostrar(Cliente unCliente)
        {
            bool estado = false;
            FrmMostrar<Cliente> frmMostrar;

            if (unCliente is not null)
            {
                frmMostrar = new FrmMostrar<Cliente>(unCliente, unPropertyInfoPredicate, unCliente.Path,"Un Cliente");
                estado = true;
            }

            return estado;
        }

        
    }
}
