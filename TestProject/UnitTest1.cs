using Entidades;
using System.Reflection;
using System.Text.RegularExpressions;
using static Entidades.Vehiculo;

namespace Test
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        [DataRow("Hjajaajajajja")]
        [DataRow(null)]
        [DataRow("6S5*25A")]
        public void ValidarPatente_CunadoNoValido(string patente)
        {
            Vehiculo unVehiculo = new Vehiculo(patente, MarcaDelVehiculo.Scort, TipoDeVehiculo.Moto, "1989");
            Assert.IsFalse(unVehiculo.Patente is not null);
        }

        [TestMethod]
        [DataRow("6S525A")]
        [DataRow("6S5 25A")]
        [DataRow("HoalMe")]
        public void ValidarPatente_CunadoLaPatenteEsValida(string patente)
        {
            Vehiculo unVehiculo = new Vehiculo(patente, MarcaDelVehiculo.Scort, TipoDeVehiculo.Moto, "1989");
            Assert.IsTrue(unVehiculo.Patente is not null);
        } 
        
        [TestMethod]
        [DataRow("/////////////")]
        [DataRow(null)]
        public void ValidarModelo_CunadoNoValido(string modelo)
        {
            Assert.IsFalse(Vehiculo.ValidarModelo(modelo));
        }

        [TestMethod]
        [DataRow("6S525A")]
        [DataRow("6S5 25A")]
        [DataRow("HoalMe")]
        public void ValidarModelo_CunadoEsValido(string modelo)
        {
            Assert.IsTrue(Vehiculo.ValidarModelo(modelo));
        }
    }
}