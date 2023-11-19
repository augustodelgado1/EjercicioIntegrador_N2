using Entidades;
using static Entidades.Vehiculo;

namespace Test
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        [DataRow("      ")]
        [DataRow(",,,,,,,,,,,,,,,,,,Lkfkfk,,,,,,,,,,,,,,,,,,,+,,,")]
        [DataRow("9621233l")]
        public void ValidarNombre_CunadoNoEsValida(string nombre)
        {
            Assert.IsFalse(Cliente.ValidarNombre(nombre));
        }
        
        [TestMethod]
        [DataRow(" mauro A")]
        [DataRow(",,,,,,,,,,,,,,,,,,Lkfkfk,,,,,,,,,,,,,,,,,,,,,,")]
        [DataRow("pep pe pe")]
        [DataRow("lope")]
        public void ValidarNombre_CunadoEsValida(string nombre)
        {
            Assert.IsTrue(Cliente.ValidarNombre(nombre));
        }
        
        [TestMethod]
        [DataRow("hola56")]
        [DataRow(",,,5552,,,,")]
        [DataRow("22 966 3394")]
        public void ValidarDni_CunadoNoEsValida(string dni)
        {
            Assert.IsFalse(Cliente.ValidarDni(dni));
        }
        
        [TestMethod]
        [DataRow("22,966,333")]
        [DataRow("22-966-333")]
        [DataRow("22.966.332")]
        [DataRow("11.278.666")]
        public void ValidarDni_CunadoEsValida(string dni)
        {
            Assert.IsTrue(Cliente.ValidarDni(dni));
        }
    }
}