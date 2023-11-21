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
        public void ValidarNombre_CunadoNoEsValida_DeberiaDebolverFalse(string nombre)
        {
            Assert.IsFalse(Cliente.ValidarNombre(nombre));
        }
        
        [TestMethod]
        [DataRow(" mauro A")]
        [DataRow("pepe")]
        [DataRow("pep pe pe")]
        [DataRow("lope")]
        public void ValidarNombre_CunadoEsValida_DeberiaDebolverTrue(string nombre)
        {
            Assert.IsTrue(Cliente.ValidarNombre(nombre));
        }
        
        [TestMethod]
        [DataRow("hola56")]
        [DataRow(",,,5552,,,,")]
        [DataRow("22 966 3394")]
        public void ValidarDni_CunadoNoEsValida_DeberiaDebolverFalse(string dni)
        {
            Assert.IsFalse(Cliente.ValidarDni(dni));
        }
        
        [TestMethod]
        [DataRow("22,966,333")]
        [DataRow("22-966-333")]
        [DataRow("22.966.332")]
        [DataRow("11.278.666")]
        public void ValidarDni_CunadoEsValida_DeberiaDebolverTrue(string dni)
        {
            Assert.IsTrue(Cliente.ValidarDni(dni));
        }
    }
}