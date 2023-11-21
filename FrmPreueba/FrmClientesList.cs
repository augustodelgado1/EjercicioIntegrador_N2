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
        Negocio unNegocio;
        bool estado;
        private Predicate<PropertyInfo> unPropertyInfoPredicate;
       
        public FrmClientesList(Negocio unNegocio,Usuario.Roles unRol) : base(unNegocio.Clientes)
        {
            InitializeComponent();
            this.unNegocio = unNegocio;
            this.ConfigurarFrm(unRol);
        }
        /// <summary>
        /// Configura el form para el caso que rol es del usuario que entro
        /// </summary>
        /// <param name="unRol"></param>
        private void ConfigurarFrm(Usuario.Roles unRol)
        {
            if(unRol == Usuario.Roles.Cliente)
            {
                base.btnAgregar.Visible = false;
                base.btnModificar.Visible = false;
                base.btnEliminar.Visible = false;
            }
        }

        private void FrmClientesList_Load(object? sender, EventArgs e)
        {
            base.cmbFilter.Visible = false;
            base.Informar += FrmMenuPrincipal.Informar;
            base.InformarError += FrmMenuPrincipal.InformarError;
            base.Buscador += FrmClientesList_Buscador;
            
            unPropertyInfoPredicate = unaPrpiedad =>
            {
                return string.Compare(unaPrpiedad.Name, "Nombre", true) == 0
                || string.Compare(unaPrpiedad.Name, "Dni", true) == 0
                || string.Compare(unaPrpiedad.Name, "FechaDeNacimiento", true) == 0 
                || string.Compare(unaPrpiedad.Name, "Email", true) == 0 ||
                string.Compare(unaPrpiedad.Name, "CantidadDeServicios", true) == 0;
            };
        }

        /// <summary>
        /// Busca que elementos coicide con el nombre en la lista de clientes con el string pasado por parametro 
        /// </summary>
        /// <param name="text">el nombre del cliente que se quiere buscar</param>
        /// <param name="listaDeClientes">la lista donde se va a buscar</param>
        /// <returns>(List<Cliente>) con lso elementos que coincide,(null) en caso de que no sean valido el texto</returns>
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
        public override bool Alta()
        {
            FrmAltaDePersona frmAltaDeCliente = new FrmAltaDePersona(Usuario.Roles.Cliente);
            bool estado;
            estado = false;
            frmAltaDeCliente.seIngesaronDatos += FrmAltaDeCliente_seRealizoUnAlta;
            if(estado = frmAltaDeCliente.ShowDialog() == DialogResult.OK
             && unNegocio + unCliente)
            {
                estado = true;
            }
            return estado;
        }

        public override void ActualizarDataGried(DataGridView dgtv, List<Cliente> lista)
        {
            string textoCot;
            if (dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear();
                foreach (Cliente unCliente in lista)
                {
                    dgtv.Rows.Add(unCliente.Nombre, unCliente.Email, unCliente.FechaDeNacimiento, unCliente.CantidadDeServicios);
                }
            }
        }
        public override void AgregarColumnasDataGried(DataGridView dgtvList)
        {
            dgtvList.Columns.Add("colClienteName", "Nombre");
            dgtvList.Columns.Add("colEmailName", "Email");
            dgtvList.Columns.Add("colFechaDeNacimiento", "Fecha De Nacimiento");
            dgtvList.Columns.Add("colCantidadDeServicios", "Cantidad De Servicios");
        }
        /// <summary>
        /// Guarda los datos del cliente que se dio de alta
        /// </summary>
        /// <param name="obj">Cliente que se dio de alta</param>
        private void FrmAltaDeCliente_seRealizoUnAlta(Cliente obj)
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
                if (estado == true)
                {
                    estado = unNegocio - unCliente;
                }
            }

            return estado;
        }
        /// <summary>
        /// Permite Confirma si se va a eliminar ese cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if(estado = frmAltaDeCliente.ShowDialog() != DialogResult.OK)
                {
                    unNegocio.Clientes[unNegocio.Clientes.IndexOf(unClienteEdit)] = unCliente;
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
                frmMostrar = new FrmMostrar<Cliente>(unCliente, unPropertyInfoPredicate, unCliente.Path);
                frmMostrar.Show();
                estado = true;
            }

            return estado;
        }

        
    }
}
