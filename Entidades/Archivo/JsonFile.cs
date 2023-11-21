using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entidades.Exepciones;
using Entidades.Interfaces;

namespace Entidades.Archivo
{
    public static class JsonFile<T>
        where T : class
    {
        /// <summary>
        /// Valida que el path pasado por parametro sea valido
        /// </summary>
        /// <param name="path">donde se ubica el archivo</param>
        /// <returns>(true) si es valido ,(false) de caso contrario</returns>
        private static bool ValidarPath(string path)
        {
            return string.IsNullOrWhiteSpace(path) == false
             && string.Compare(Path.GetExtension(path),".json", true) == 0;
        }
        /// <summary>
        /// Lee un archivo guarda los datos dentro de una lista
        /// </summary>
        /// <param name="path">El path donde se ubica el archivo</param>
        /// <returns>(null) en caso de error o (List<T>) la lista con los datos guardados</returns>
        /// <exception cref="JsonFileException">Lanza una Exception si se produce algun error a la hora de leer el archivo</exception>
        public static List<T> LeerArchivo(string path)
        {
            List<T> listaDeClientes = default;

            if (ValidarPath(path) == true)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))// Abro el archivo con un using para no tener que cerrarlo
                    {
                        string text = sr.ReadToEnd();//, lo leeo hasta el final
                        listaDeClientes = JsonSerializer.Deserialize<List<T>>(text);//deserializo los datos de ese archivo
                                                                                    // y lo guado dentro de la lista 
                    }
                }
                catch (Exception e)
                {
                    throw new JsonFileException($"Ocurrio en error al intentar Leer el archivo de {typeof(T).Name}", e);
                }

            }

            return listaDeClientes;
        }

        /// <summary>
        /// Guarda los datos de la lista dentro de un archivo 
        /// </summary>
        /// <param name="path">el path donde se va a guardar el archivo</param>
        /// <param name="list">la lista con los datos que se quiere guardar</param>
        /// <returns>(true) si se pudo guardar los datos ,(false) de caso contrario</returns>
        /// <exception cref="JsonFileException">Lanza una Exception si se produce algun error a la hora de Guardar el archivo</exception>
        public static bool GuardarArchivo(string path, List<T> list)
        {
            bool result = false;

            if (!string.IsNullOrWhiteSpace(path))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))// Creo o Abro el archivo con un using para no tener que cerrarlo
                    {
                        string texto = JsonSerializer.Serialize(list);//Seliazo los datos de la lista a json y los guardo
                        sw.WriteLine(texto);//y los escrivo dentro del archivo
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    throw new JsonFileException($"Ocurrio un error al intentar Serializar el archivo de {typeof(T).Name}", e);
                }

            }

            return result;
        }
    }
}
