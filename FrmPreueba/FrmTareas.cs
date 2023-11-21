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
            base.Buscador += FrmTareas_Buscador;
            base.cmbFilter.Visible = false;
            base.cmbFilter.DataSource = Enum.GetValues(typeof(Servicio.Diagnostico));
            base.btnAgregar.Visible = false;
            base.btnEliminar.Visible = false;
            base.btnModificar.Visible = false;
            base.btnGuardarArchivo.Visible = false;
            base.btnCargar.Visible = false;
            base.txtBuscar.Location = new Point(12, 4);
            this.progressBar1.Location = new Point(12, 38);
            this.progressBar1.Size = base.txtBuscar.Size;
            this.btnCancelarServicio.Enabled = false;
        }
        /// <summary>
        /// Busca que elementos coicide con la patente en la lista de vehiculos con el string pasado por parametro 
        /// </summary>
        /// <param name="Patente">la patente del los vehiculos que se quiere buscar</param>
        /// <param name="unaLista">la lista donde se va a buscar</param>
        /// <returns>(List<Vehiculo>) con lso elementos que coincide,(null) en caso de que no sean valido el texto</returns>
        private List<Servicio> FrmTareas_Buscador(string Patente, List<Servicio> unaLista)
        {
            List<Servicio> result = default;
            if (string.IsNullOrWhiteSpace(Patente) == false && unaLista is not null)
            {
                result = unaLista.FindAll(unServicio => unServicio.UnVehiculo.Patente.ToString().Contains(Patente.ToLower()) == true);
            }
            return result;
        }
        /// <summary>
        /// Cuando se presiona el boton cancela el servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (base.element is not null && base.element.Estado == Servicio.EstadoDelSevicio.EnProceso)
            {
                FrmDiagnosticar frmDiagnosticar = new FrmDiagnosticar(base.element);

                if (frmDiagnosticar.ShowDialog() == DialogResult.OK
                    && ActivarProgessBar(this.progressBar1, base.element) == true)
                {
                    FrmMenuPrincipal.Informar("Diagnosticar", "Se diagnostico el servicio correctamente");
                    this.ActualizarDataGriedView(base.dgtvList, unNegocio.ServiciosEnProcesos);
                    this.btnIniciarServicio.Enabled = false;
                    this.btnCancelarServicio.Enabled = true;
                }
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

        public override void AgregarColumnasDataGried(DataGridView dgtvList)
        {
            frmSevicios = new FrmSevicios(listGeneric);
            frmSevicios.AgregarColumnasDataGried(dgtvList);
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

        /// <summary>
        /// Activa el ProgressBar var en un hilo secundario 
        /// </summary>
        /// <param name="barra"></param>
        /// <param name="unServicio"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Incrementar ProgressBar hasta que llegue al final o hasta que se cancele el hilo
        /// </summary>
        /// <param name="barra">la barra que queremos incrementar</param>
        /// <param name="unServicio"></param>
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
                if (barra.Value >= barra.Maximum && this.unNegocio - unServicio)
                {
                    FrmMenuPrincipal.Informar("Se Compelto el servicio", "Se Compelto el servicio correctamente");
                }
                this.ActualizarDataGriedView(base.dgtvList, unNegocio.ServiciosEnProcesos);
                InicializarProsgerBar(barra);
            }
        }

        /// <summary>
        /// Actualiza el DataGridView y verifica si esta el hilo principal o en otro
        /// </summary>
        /// <param name="DataGridView"></param>
        /// <param name="List<Servicio>"</param>
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

        /// <summary>
        /// Inicializa el ProgressBar y verifica si esta el hilo principal o en otro
        /// </summary>
        /// <param name="DataGridView"></param>
        /// <param name="List<Servicio>"</param>
        private void InicializarProsgerBar(ProgressBar barra)
        {
            if (InvokeRequired)
            {
                Invoke(() => InicializarProsgerBar(barra));
            }
            else
            {
                barra.Value = 0;
            }
        }
        /// <summary>
        /// Incrementa el ProgressBar y verifica si esta el hilo principal o en otro
        /// </summary>
        /// <param name="barra">barra de progeso a incrementar</param>
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
        /// <summary>
        /// Actualiza el boton en enable  y verifica si esta el hilo principal o en otro
        /// </summary>
        /// <param name="unButton"></param>
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

       
}
}
