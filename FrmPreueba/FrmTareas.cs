using Entidades;
using System;
using System.Collections;
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
    public partial class FrmTareas : FrmListar<Servicio>
    {
        Task tarea;
        Servicio unServicio;
        FrmSevicios frmSevicios;
        Negocio unNegocio;
        CancellationTokenSource cancellationTokenSource;
        public FrmTareas(Negocio unNegocio,List<Servicio> listaDeServicio):base(listaDeServicio)
        {
            InitializeComponent();
            this.unNegocio = unNegocio;
        }
        private void FrmTareas_Load(object sender, EventArgs e)
        {
            this.btnDiagnosticarServicio.Click += BtnDiagnosticarServicio_Click;
            base.Buscador += FrmTareas_Buscador;
            base.Filtrar += FrmTareas_Filtrar;
            base.cmbFilter.DataSource = Enum.GetValues(typeof(Servicio.Diagnostico));
            base.btnAgregar.Visible = false;
            base.btnEliminar.Visible = false;
            base.btnModificar.Visible = false;
            base.btnGuardarArchivo.Visible = false;
            base.btnCargar.Visible = false;
            base.txtBuscar.Location = new Point(12, 4);
            this.progressBar1.Location = new Point(12, 38);
            this.progressBar1.Size = base.txtBuscar.Size;
        }

        private void BtnDiagnosticarServicio_Click(object sender, EventArgs e)
        {
            if (base.element is not null && base.element.Diagnistico == Servicio.Diagnostico.NoDeterminado
             && base.element.Cotizacion == 0)
            {
                FrmDiagnosticar frmDiagnosticar = new FrmDiagnosticar(base.element);

                if (frmDiagnosticar.ShowDialog() == DialogResult.OK)
                {
                    FrmMenuPrincipal.Informar("Diagnosticar", "Se diagnostico el servicio correctamente");
                    frmSevicios.ActualizarDataGried(base.dgtvList, base.listGeneric);
                    // o Negocio.
                }
            }
        }

        private List<Servicio> FrmTareas_Filtrar(List<Servicio> unaLista, string criterio)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(criterio) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => string.Compare(unServicio.Diagnistico.ToString(),criterio,true) == 0);
            }
            return result;
        }

        private List<Servicio> FrmTareas_Buscador(string Patente, List<Servicio> unaLista)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(Patente) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.UnVehiculo.Patente.ToString().Contains(Patente.ToLower()) == true);
            }
            return result;
        }
        private void BtnCancelarServicio_Click(object sender, EventArgs e)
        {
            if(cancellationTokenSource is not null)
            {
                cancellationTokenSource.Cancel();
                btnCancelarServicio.Enabled = false;
            }
        }

        private void BtnIniciarServicio_Click(object sender, EventArgs e)
        {
            if (base.element is not null && base.element.Diagnistico != Servicio.Diagnostico.NoDeterminado 
             && base.element.Cotizacion > 0 && base.element.Estado == Servicio.EstadoDelSevicio.EnProceso 
             && ActivarProgessBar(this.progressBar1, this.unServicio) == true)
            {
                this.btnIniciarServicio.Enabled = false;
            }

        }
        public override bool Alta()
        {
            throw new NotImplementedException();
        }

        public override void ActualizarDataGried(DataGridView dgtv, List<Servicio> lista)
        {
            frmSevicios.ActualizarDataGried(dgtv, lista);
        }

        public override void AgregarColumnasDataGried(DataGridView dgtvList, List<Servicio> listGeneric)
        {
            frmSevicios = new FrmSevicios(listGeneric);
            frmSevicios.AgregarColumnasDataGried(dgtvList, listGeneric);
        }

        public override bool Baja(Servicio element)
        {
            throw new NotImplementedException();
        }

        public override bool Mostrar(Servicio element)
        {
            return frmSevicios.Mostrar(element);
        }

        public override bool Modificacion(Servicio element)
        {
            throw new NotImplementedException();
        }


        public bool ActivarProgessBar(ProgressBar barra, Servicio unServicio)
        {
            bool estado;
            estado = false;
            if (unServicio is not null && (tarea is null || tarea.IsCompleted == true || cancellationTokenSource.IsCancellationRequested == true))
            {
                estado = true;
                cancellationTokenSource = new CancellationTokenSource();
                tarea = Task.Run(() => AvanzarProgessBar(barra, unServicio), cancellationTokenSource.Token);
                
            }
            return estado;
        }
        private void AvanzarProgessBar(ProgressBar barra, Servicio unServicio)
        {
            Random random = new Random();

            if (barra is not null && unServicio is not null)
            {
                do
                {
                    Thread.Sleep(random.Next(100, 1000));
                    IncrementarProgessBar(barra);
                } while (barra.Value < barra.Maximum && cancellationTokenSource.IsCancellationRequested == false);

                ActualizarBoton(this.btnIniciarServicio);
                cancellationTokenSource = null;
                if (tarea.IsCompleted == true && this.unNegocio - unServicio)
                {
                    this.ActualizarDataGriedView(base.dgtvList, listGeneric);
                }
            }
        }

        private void ActualizarDataGriedView(DataGridView dataGrid,List<Servicio> lista)
        {
            if (InvokeRequired)
            {
                Invoke(() => ActualizarDataGriedView(dataGrid, lista));
            }
            else
            {
                this.ActualizarDataGried(dataGrid, lista);
            }
        }
        private void IncrementarProgessBar(ProgressBar barra)
        {
            if (InvokeRequired)
            {
                Invoke(() => IncrementarProgessBar(barra));
            }
            else
            {
                barra.Increment(1);
            }
        } 
        
        private void ActualizarBoton(Button unButton)
        {
            if (InvokeRequired)
            {
                Invoke(() => ActualizarBoton(unButton));
            }
            else
            {
                unButton.Enabled = true;
            }
        }

        /*this.unServicio = new Servicio("No anda", new Vehiculo("123456", Vehiculo.MarcaDelVehiculo.Pontiac, Vehiculo.TipoDeVehiculo.Auto, "Sunnaty"));
            *//*if (base.element is not null)
            {*//*
                FrmDiagnosticar frmDiagnosticar = new FrmDiagnosticar(unServicio);
        btnTerminarServicio.Enabled = false;
                if (frmDiagnosticar.ShowDialog() == DialogResult.OK && Predicate is not null
                  && Predicate(unServicio, btnTerminarServicio) is Task unaTarea)
                {


                }*/
}
}
