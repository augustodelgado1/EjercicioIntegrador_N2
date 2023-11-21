using Entidades;
using System.Reflection;
using System.Text.RegularExpressions;
using static Entidades.Vehiculo;

namespace Test
{
    [TestClass]
    public class VehiculoTest
    {
        /// <summary>
        /// Verifica en que caso el metodo ValidarPatente deberia Retornar false  
        /// </summary>
        /// <param name="patente">la patente del vehiculo</param>
        [TestMethod]
        [DataRow("Hjajaajajajja")]
        [DataRow(null)]
        [DataRow("6S5*25A")]
        public void ValidarPatente_CunadoNoValido_DeberiaRetornarFalse(string patente)
        {
            Assert.IsFalse(Vehiculo.ValidarPatente(patente));
        }

        /// <summary>
        /// Verifica en que caso el metodo ValidarPatente deberia Retornar True  
        /// </summary>
        /// <param name="patente">la patente del vehiculo</param>
        [TestMethod]
        [DataRow("6S525A")]
        [DataRow("6S5 25A")]
        [DataRow("HoalMe")]
        public void ValidarPatente_CunadoLaPatenteEsValida_DeberiaRetornarTrue(string patente)
        {
            Assert.IsTrue(Vehiculo.ValidarPatente(patente));
        }

        /// <summary>
        /// Verifica en que caso el metodo ValidarModelo deberia Retornar false  
        /// </summary>
        /// <param name="modelo"> el modelo del vehiculo</param>
        [TestMethod]
        [DataRow("/////////////")]
        [DataRow(null)]
        public void ValidarModelo_CunadoNoValido(string modelo)
        {
            Assert.IsFalse(Vehiculo.ValidarModelo(modelo));
        }

        /// <summary>
        /// Verifica en que caso el metodo ValidarModelo deberia Retornar false  
        /// </summary>
        /// <param name="modelo">el modelo del vehiculo</param>
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