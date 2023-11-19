using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Archivo;
using Entidades.Exepciones;
using System.Threading.Tasks;

namespace TestProject
{
    public class JsonFileTest
    {
        [DataRow("      ")]
        [DataRow(",,,,,,,,,,,,,,,,,,Lkfkfk,,,,,,,,,,,,,,,,,,,+,,,")]
        [DataRow("9621233l")]
        public void LeerArchivoServicio_CunadoElPathEsValido(string path)
        {
            Assert.IsTrue(JsonFile<Servicio>.LeerArchivo(path) is not null);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonFileException))]
        [DataRow("      ")]
        [DataRow(",,,,,,,,,,,,,,,,,,Lkfkfk,,,,,,,,,,,,,,,,,,,+,,,")]
        [DataRow("9621233l")]
        public void LeerArchivoServicio_CunadoElPathNoValido(string path)
        {
            Assert.IsFalse(JsonFile<Servicio>.LeerArchivo(path) is not null);
        }

        [TestMethod]
        public void GuargarArchivoServicios_CunadoElPathEsValido(string path,List<Servicio> Servicios)
        {
            Assert.IsTrue(JsonFile<Servicio>.GuardarArchivo(path, Servicios));
        }
        
        [TestMethod]
        [ExpectedException(typeof(JsonFileException))]
        [DataRow("      ")]
        public void GuardarArchivoServicios_CunadoElPathNoValido(string path)
        {
            Assert.IsFalse(JsonFile<Servicio>.LeerArchivo(path) is null);
        }

    }
}
