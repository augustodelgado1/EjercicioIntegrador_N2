using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ISerilizadora<T> 
    where T : class, new()
    {
        bool GuardarJson(string path, List<T> List);

        bool GuardarArchivoXml(string path, List<T> listadoDePasajero);

    }
}
