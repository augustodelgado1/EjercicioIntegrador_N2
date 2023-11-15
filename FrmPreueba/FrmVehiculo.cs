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
    public partial class FrmVehiculo : FrmListar<Vehiculo>
    {

        public FrmVehiculo(List<Vehiculo> listaDeVehiculos):base(listaDeVehiculos)
        {
            InitializeComponent();
            this.Load += FrmVehiculo_Load;
        }

        private void FrmVehiculo_Load(object? sender, EventArgs e)
        {

        }

        public override Vehiculo Alta()
        {
            throw new NotImplementedException();
        }

        public override bool Baja(Vehiculo element)
        {
            throw new NotImplementedException();
        }

        public override bool Modificacion(Vehiculo element)
        {
            throw new NotImplementedException();
        }

        public override bool Mostrar(Vehiculo element)
        {
            throw new NotImplementedException();
        }

        protected override void ActualizarDataGried(DataGridView dgtv, List<Vehiculo> lista)
        {
            throw new NotImplementedException();
        }

        protected override void AgregarColumnasDataGried(DataGridView dgtvList, List<Vehiculo> listGeneric)
        {
            throw new NotImplementedException();
        }

    }
}
