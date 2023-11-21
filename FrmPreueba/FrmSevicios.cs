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
    public partial class FrmSevicios : FrmListar<Servicio>
    {
        Usuario unUsuario;
        Servicio unServicio;
        Negocio unNegocio;
        Vehiculo unVehiculo;
        bool estado;
        public FrmSevicios(List<Servicio> listaDeServicio, Negocio unNegocio, Usuario unUsuario) :this(listaDeServicio)
        {
            this.unUsuario = unUsuario;
            this.unNegocio = unNegocio;
            ConfigurarForm(unUsuario.Rol);
        }

        public FrmSevicios(List<Servicio> listaDeServicio) : base(listaDeServicio)
        {
            InitializeComponent();
            this.Load += FrmSevicios_Load;
        }

        private void ConfigurarForm(Usuario.Roles rol)
        {
            if (rol != Usuario.Roles.Cliente)
            {
                this.btnAgregar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnAgregar.Visible = false;
            }
        }

        private void FrmSevicios_Load(object? sender, EventArgs e)
        {
            base.cmbFilter.Visible = true;
            base.cmbFilter.DataSource = Enum.GetValues(typeof(Servicio.EstadoDelSevicio));
            base.Filtrar += FrmSevicios_Filtrar;
            base.Informar += FrmMenuPrincipal.Informar;
            base.InformarError += FrmMenuPrincipal.InformarError;
            base.Buscador += FrmSevicios_Buscador;
        }
        /// <summary>
        /// Busca que elementos de la lista concide con el texto pasado por parametro
        /// </summary>
        /// <param name="unaLista"></param>
        /// <param name="criterio"></param>
        /// <returns>la lista con los elemntos que concidecon el texto o (NULL) en caso de que no se valido el texto</returns>
        private List<Servicio> FrmSevicios_Filtrar(List<Servicio> unaLista,string criterio)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(criterio) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.Estado.ToString() == criterio);
            }
            return result;
        }
        /// <summary>
        /// Busca que elementos de la lista concide con el texto pasado por parametro
        /// </summary>
        /// <param name="diagnostico"></param>
        /// <param name="unaLista"></param>
        /// <returns>la lista con los elemntos que concidecon el texto o (NULL) en caso de que no se valido el texto</returns>
        private List<Servicio> FrmSevicios_Buscador(string diagnostico, List<Servicio> unaLista)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(diagnostico) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.Diagnistico.ToString().Contains(diagnostico.ToLower()) == true);
            }
            return result;
        }
        public override bool Alta()
        {
            bool estado;
            estado = false;
            FrmAltaServicio frmAltaSevicio = new FrmAltaServicio();
            frmAltaSevicio.OnSeIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;

            if (frmAltaSevicio.ShowDialog() == DialogResult.OK
                && this.unNegocio + unServicio && this.unNegocio + unVehiculo  
                && this.unUsuario is Cliente unCliente)
            {
                estado = unServicio + unCliente;
            }
            
            return estado;
        }
       
        private void FrmAltaSevicio_seIngesaronDatos(Servicio unServicio,Vehiculo unVehiculo)
        {
            if (unServicio is not null)
            {
                this.unServicio = unServicio;
                this.unVehiculo = unVehiculo;
            }
        }

        public override bool Baja(Servicio unServicio)
        {
            estado = false;
            FrmMostrar<Servicio> frmMostrar;
           
            if (unServicio is not null)
            {
                frmMostrar = new FrmMostrar<Servicio>(unServicio, unPropertyInfoPredicate, unServicio.UnVehiculo.Path, "Sevicio");
                frmMostrar.Activated += FrmMostrar_Shown;
                frmMostrar.Show();

                if(estado == true && unUsuario is Cliente unCliente)
                {
                    estado = unServicio - unCliente;
                }
            }

            return estado;
        }

        public override bool Modificacion(Servicio unServicioEdit)
        {
            bool estado;
            estado = true;
            FrmAltaServicio frmSevicios;
           
            frmSevicios = new FrmAltaServicio(unServicioEdit);
            frmSevicios.OnSeIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;
            if (frmSevicios.ShowDialog() == DialogResult.OK)
            {
                if (unUsuario is Cliente unCliente 
                  && unServicioEdit - unCliente && this.unServicio + unCliente)
                {
                    this.unNegocio.ListaDeServicio[this.unNegocio.ListaDeServicio.IndexOf(unServicioEdit)] = this.unServicio;
                    this.unNegocio.ListaDeVehiculos[this.unNegocio.ListaDeVehiculos.IndexOf(unServicioEdit.UnVehiculo)] = this.unServicio.UnVehiculo;
                }
            }

            return estado;
        }
        public override bool Mostrar(Servicio unServicio)
        {
            bool estado = false;
            FrmMostrar<Servicio> frmMostrar;

            if (unServicio is not null)
            {
                frmMostrar = new FrmMostrar<Servicio>(unServicio, unPropertyInfoPredicate, unServicio.UnVehiculo.Path, "Un Servicio");
                frmMostrar.Show();
                estado = true;
            }
            return estado;
        }
        /// <summary>
        /// mindica que los datos de que propiedades que se van a mostrar
        /// </summary>
        /// <param name="unaPrpiedad"></param>
        /// <returns>(true) si cumple con el criterio ,(false) de caso contrario</returns>
        private bool unPropertyInfoPredicate(PropertyInfo unaPrpiedad)
        {
            return string.Compare(unaPrpiedad.Name, "FechaDeIngreso", true) == 0
                || string.Compare(unaPrpiedad.Name, "Patente", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "CotizacionStr", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "Estado", true) == 0 ||
                   string.Compare(unaPrpiedad.Name, "Diagnostico", true) == 0
                || string.Compare(unaPrpiedad.Name, "Problema", true) == 0;
            
        }

        
        private void FrmMostrar_Shown(object? sender, EventArgs e)
        {
            if (sender is FrmMostrar<Servicio>)
            {
                estado = FrmMenuPrincipal.Confirmar("¿Esta seguro que desea eliminar ese Cliente", "Eliminar");
                ((FrmMostrar<Servicio>)sender).Close();
            }
        }

        public override void ActualizarDataGried(DataGridView dgtv, List<Servicio> lista)
        {
          
            if(dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear();
                foreach (Servicio unServicio in lista)
                {
                    dgtv.Rows.Add(unServicio.FechaDeIngreso, unServicio.UnVehiculo.Patente, unServicio.Problema, 
                        unServicio.CotizacionStr,unServicio.Diagnistico);
                }
            }
        }

        public override void AgregarColumnasDataGried(DataGridView dgtvList)
        {
            dgtvList.Columns.Add("colFecha", "Fecha De Ingreso");
            dgtvList.Columns.Add("colUnVehiculo", "Patente");
            dgtvList.Columns.Add("colProblema", "Problema");
            dgtvList.Columns.Add("colCosto", "Costo");
            dgtvList.Columns.Add("colDiagnostico", "Diagnostico");
        }
        
        
    }
}
