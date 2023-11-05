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
        [DataRow("pepe09")]
        [DataRow("nanics")]
        public void ValidarUser_CuandoElUsuarioEsValido_DeberiaRetornarTrue(string unUsuario)
        {
            //Act - Metodo a probar
            bool resultadoDelMetodo = Usuario.ValidarUser(unUsuario);

            //Asert - resultado esperado
            Assert.AreEqual(true, resultadoDelMetodo);
        }

        [TestMethod]
        [DataRow("98654254872")]
        [DataRow("meaaaaaaaaaaaAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ValidarUser_CuandoElUsuarioNoEsValido_DeberiaRetornarFalse(string unUsuario)
        {
            bool resultadoDelMetodo = Usuario.ValidarUser(unUsuario);
            Assert.AreEqual(false, resultadoDelMetodo);
        }

        [TestMethod]
        [DataRow("pepe@gmail.com")]
        [DataRow("mario@gmail.com")]
        [DataRow("koko@gmail.com")]
        public void ValidarEmail_CuandoElEmailEsValido_DeberiaRetornarTrue(string email)
        {
            Assert.AreEqual(true, Usuario.ValidarEmail(email));
        }

        [TestMethod]
        public void ValidarContracenia_CuandoLaCotaraceniaEsAlfanumerica_DeberiaRetornarTrue()
        {
            //Arrenge - Preparacion el caso de prueva
            string unUsuario = "junc45etopablo.Julia.n";

            //Act - Metodo a probar
            bool resultadoDelMetodo = Usuario.ValidarContracenia(unUsuario);

            //Asert - resultado esperado
            Assert.AreEqual(true, resultadoDelMetodo);
        }

        [TestMethod]
        public void BuscarUnUsuario_CuandoElUsusuarioNoEstaEnLalista_DeberiaRetornarError()
        {
            //Arrenge - Preparacion el caso de prueva
            List<Usuario> listaDeCliente = new List<Usuario>() {
               new Cliente("pepe","12345678","pepe@gmail.com","123456789"),
               new Cliente("mario","12345678","mario@gmail.com","123456789"),
               new Cliente("koko","12345678","koko@gmail.com","123456789"),
            };

            //Act - Metodo a probar
            Usuario resultadoDelMetodo = Usuario.EncontarUsuario(listaDeCliente, "..........", "123456789");

            //Asert - resultado esperado
            Assert.IsNull(resultadoDelMetodo);
        }

        [TestMethod]
        public void BuscarUnUsuario_CuandoLaListaContieneElementosNulosPeroLeMandoUnUsuarioQueEstaEnLaLista_DeberiaRetornarLaReferenciaAlJugador()
        {
            //Arrenge - Preparacion el caso de prueva
            List<Usuario> listaDeCliente = new List<Usuario>() {
               null,
               new Cliente("mario10","mario@gmail.com","12345678","123456789123"),
               null
            };

            //Act - Metodo a probar
            Usuario resultadoDelMetodo = Usuario.EncontarUsuario(listaDeCliente, "mario@gmail.com", "12345678");

            //Asert - resultado esperado
            Assert.IsNotNull(resultadoDelMetodo);
        }


    }
}
