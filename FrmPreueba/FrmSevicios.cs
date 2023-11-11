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
    public partial class FrmSevicios : FrmListar<Servicio>
    {
        Servicio unServicio;
        public FrmSevicios(List<Servicio> listaDeServicio):base(listaDeServicio)
        {
            InitializeComponent();
        }

        private void FrmSeviciosList_Load(object? sender, EventArgs e)
        {
            base.cmbFilter.Visible = true;
            base.btnAgregar.Text = "Agregar un Cliente";
            base.btnModificar.Text = "Modificar un Cliente";
            base.btnCargar.Text = "Cargar Archivo";
            base.btnGuardarArchivo.Text = "Guardar Archivo";
            base.btnInfo.Text = "Mostrar Informacion Mas Ampliada";
            base.btnEliminar.Text = "Eliminar un Cliente";
            base.Informar += FrmSevicios_Informar;
            base.InformarError += FrmSevicios_InformarError;
            base.Buscador += FrmSevicios_Buscador;
        }

        private void FrmClientesList_InformarError(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmClientesList_Informar(string titulo, string mensajeDeError)
        {
            MessageBox.Show(mensajeDeError, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private List<Servicio> FrmSevicios_Buscador(string arg,List<Servicio> unaLista)
        {
            throw new NotImplementedException();
        }

        private void FrmSevicios_InformarError(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        private void FrmSevicios_Informar(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public override Servicio Alta()
        {
            FrmAltaServicio frmAltaSevicio = new FrmAltaServicio();
            frmAltaSevicio.seIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;
            if (frmAltaSevicio.ShowDialog() != DialogResult.OK)
            {
                this.unServicio = null;
            }
            return this.unServicio;
        }

        private void FrmAltaSevicio_seIngesaronDatos(Servicio unServicio, Vehiculo unVehiculo)
        {
            this.unServicio = unServicio;
        }

        public override bool Baja(int index)
        {
           

            return true;
        }

        public override Servicio Modificacion(int index)
        {
            FrmAltaServicio frmSevicios;
            this.unServicio = base[index];
            frmSevicios = new FrmAltaServicio(this.unServicio);
            frmSevicios.seIngesaronDatos += FrmAltaSevicio_seIngesaronDatos;
            if (frmSevicios.ShowDialog() != DialogResult.OK)
            {
                this.unServicio = null;
            }

            return this.unServicio;
        }

        public override void Mostrar(int index)
        {
            throw new NotImplementedException();
        }
        protected override void ActualizarDataGried(DataGridView dgtv, List<Servicio> lista)
        {
            string textoCot;
            if(dgtv is not null && lista is not null)
            {
                dgtv.Rows.Clear();
                foreach (Servicio unServicio in lista)
                {
                    textoCot = unServicio.Cotizacion.ToString();
                    if(unServicio.Cotizacion == 0)
                    {
                        textoCot = "No Determinado";
                    }
                    dgtv.Rows.Add(unServicio.UnCliente.Nombre, unServicio.MecanicoAsignado, unServicio.Descripcion, unServicio.UnVehiculo.Patente, textoCot);
                }
            }
        }

        protected override void AgregarColumnasDataGried(DataGridView dgtvList, List<Servicio> listGeneric)
        {
            dgtvList.Columns.Add("colClienteName", "Cliente");
            dgtvList.Columns.Add("colMecanicoName", "Mecanico");
            dgtvList.Columns.Add("colDescripcion", "Descripcion");
            dgtvList.Columns.Add("colUnVehiculo", "Patente");
            dgtvList.Columns.Add("colCosto", "Costo");
        }
        
        
    }
}
