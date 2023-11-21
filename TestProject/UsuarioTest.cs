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
        [TestMethod]
        [DataRow("pepe@gmail.com")]
        [DataRow("mario@gmail.com")]
        [DataRow("koko@gmail.com")]
        public void ValidarEmail_CuandoElEmailEsValido_DeberiaRetornarTrue(string email)
        {
            Assert.IsTrue(Usuario.ValidarEmail(email));
        } 
        
        [TestMethod]
        [DataRow("jajaja*jajjajaj")]
        [DataRow("...............")]
        [DataRow("1111111@111111111")]
        public void ValidarEmail_CuandoElEmailEsNoValido_DeberiaRetornarFalse(string email)
        {
            Assert.IsFalse(Usuario.ValidarEmail(email));
        }

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
