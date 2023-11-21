using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UsuarioTest
    {
        /// <summary>
        /// Verifica en que caso el metodo EncontarUsuario deberia Retornar un True  
        /// </summary>
        /// <param name="email">el email del usuario</param>
        [TestMethod]
        [DataRow("pepe@gmail.com")]
        [DataRow("mario@gmail.com")]
        [DataRow("koko@gmail.com")]
        public void ValidarEmail_CuandoElEmailEsValido_DeberiaRetornarTrue(string email)
        {
            Assert.IsTrue(Usuario.ValidarEmail(email));
        }

        /// <summary>
        /// Verifica en que caso el metodo EncontarUsuario deberia Retornar un False  
        /// </summary>
        /// <param name="email">el email del usuario</param>
        [TestMethod]
        [DataRow("jajaja*jajjajaj")]
        [DataRow("...............")]
        [DataRow("1111111@111111111")]
        public void ValidarEmail_CuandoElEmailEsNoValido_DeberiaRetornarFalse(string email)
        {
            Assert.IsFalse(Usuario.ValidarEmail(email));
        }

        /// <summary>
        /// Verifica en que caso el metodo EncontarUsuario deberia Retornar un null  
        /// </summary>
        /// <param name="email">el email a buscar</param>
        /// <param name="contracenia">la contracenia a buscar</param>
        [TestMethod]
        [DataRow("..........", "123456789")]
        [DataRow("jauna@gmail.com", "9666333333")]
        [DataRow(null, null)]
        public void BuscarUnUsuario_CuandoElUsusuarioNoEstaEnLalista_DeberiaRetornarNull(string email,string contracenia)
        {
            //Arrenge - Preparacion el caso de prueva
            List<Usuario> listaDeCliente = new List<Usuario>() {
               new Cliente("pepe", "12345678",DateTime.Now, "mario@gmail.com", "123456789"),
               new Cliente("pepe", "12345678",DateTime.Now, "mario@gmail.com", "123456789"),
              new Cliente("kaak", "12345678",DateTime.Now, "koko@gmail.com", "123456789"),
            };

            Assert.IsNull(Usuario.EncontarUsuario(listaDeCliente, email, contracenia));
        }

        /// <summary>
        /// Verifica en que caso el metodo EncontarUsuario deberia Retornar un Usuario  
        /// </summary>
        /// <param name="email">el email a buscar</param>
        /// <param name="contracenia">la contracenia a buscar</param>
        [TestMethod]
        [DataRow("mario@gmail.com", "123456789")]
        [DataRow("koko@gmail.com", "123456789")]
        public void BuscarUnUsuario_CuandoElUsusuarioEstaEnLalista_DeberiaRetornarElUsuario(string email, string contracenia)
        {
            //Arrenge - Preparacion el caso de prueva
            List<Usuario> listaDeCliente = new List<Usuario>() {
               null,
               new Cliente("kaak", "12345678",DateTime.Now,  "mario@gmail.com", "123456789"),
               new Cliente("kaak", "12345678",DateTime.Now, "koko@gmail.com", "123456789"),
            };

            //Act - Metodo a probar
            Usuario resultadoDelMetodo = Usuario.EncontarUsuario(listaDeCliente, "mario@gmail.com", "123456789");

            //Asert - resultado esperado
            Assert.IsNotNull(resultadoDelMetodo);
        }


    }
}
