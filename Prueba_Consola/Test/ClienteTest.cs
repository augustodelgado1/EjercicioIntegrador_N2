using Entidades;
namespace Test
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        [DataRow]
        public static void Constructor_CuandoInstancioUnUsuarioValido_DeberiaDevolverLaInstanciaConLosDatosPasados(string user, string email, string clave, string telefono)
        {
            Cliente usuario = new Cliente(user, email, clave, telefono);
            Assert.IsTrue(Assert.Equals(user, usuario.User) && Assert.Equals(email, usuario.Email) && Assert.Equals(telefono, usuario.Telefono));
        }
    }
}