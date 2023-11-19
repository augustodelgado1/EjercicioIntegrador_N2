﻿using Entidades;
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
        static string extension;
        static JsonFile()
        {
            extension = ".json";
        }

        private static bool ValidarPath(string path)
        {
            return string.IsNullOrWhiteSpace(path) == false
             && string.Compare(Path.GetExtension(path), extension, true) == 0;
        }
        public static List<T> LeerArchivo(string path)
        {
            List<T> listaDeClientes = default;

            if (ValidarPath(path) == true)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd();
                        listaDeClientes = JsonSerializer.Deserialize<List<T>>(text);
                    }
                }
                catch (Exception e)
                {
                    throw new JsonFileException($"Ocurrio en error al intentar Leer el archivo de {typeof(T).Name}", e);
                }

            }

            return listaDeClientes;
        }
        public static bool GuardarArchivo(string path, List<T> list)
        {
            bool result = false;

            if (!string.IsNullOrWhiteSpace(path))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        string texto = JsonSerializer.Serialize(list);
                        sw.WriteLine(texto);
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