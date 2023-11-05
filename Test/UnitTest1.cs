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
        [DataRow("6S525A", MarcaDelVehiculo.Scort, TipoDeVehiculo.Moto,"1989")]
        [DataRow("6S5 25A", MarcaDelVehiculo.Ford, TipoDeVehiculo.Auto,"9666")]
        public void Constructor_CuandoInstancioUnUsuarioValido_DeberiaDevolverLaInstanciaConLosDatosPasados(string patente, MarcaDelVehiculo marca, TipoDeVehiculo tipo, string modelo)
        {
            Assert.IsNotNull(new Vehiculo(patente, marca,tipo,modelo));
        }

        [TestMethod]
        [DataRow("Hjajaajajajja")]
        [DataRow(null)]
        public void ValidarPatente_CunadoNoValido(string patente)
        {
            Assert.IsFalse(Vehiculo.ValidarPatente(patente));
        }

        [TestMethod]
        [DataRow("6S525A")]
        [DataRow("6S5 25A")]
        [DataRow("HoalMe")]
        public void ValidarPatente_CunadoLaPatenteEsValida(string patente)
        {
            Assert.IsTrue(Vehiculo.ValidarPatente(patente));
        }
    }
}