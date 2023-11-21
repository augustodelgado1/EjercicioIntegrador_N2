using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    public static class StringExtended
    {
        /// <summary>
        /// Verifica si el string contiene los elementos del array de char pasado por parametro 
        /// y los Borra los caracteres 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="charsABorrar"></param>
        /// <returns>(string) el string con los caracteres modificados , (NULL) en caso de que los parametros no sean validos</returns>
        public static string BorrarCaracteres(this string texto, char[] charsABorrar)
        {
            string result = new string(texto);
            if (charsABorrar is not null && charsABorrar.Length > 0)
            {
                foreach (char caracterDeLaLista in charsABorrar)
                {
                    if (texto.Contains(caracterDeLaLista) == true)
                    {
                        result = result.Replace(caracterDeLaLista.ToString(), "");
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Verifica si el string cumple con el criterio pasado por parametro 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="criterio"></param>
        /// <returns>(true) si cumple con el criterio,(false) de caso contrario</returns>
        private static bool VerificarString(this string texto, Predicate<char> criterio)
        {
            bool result;
            result = false;

            
            if (texto is not null && texto.Length > 0 && criterio is not null)
            {
                result = true;
                foreach (char caracter in texto)
                {
                    if (criterio(caracter) == false)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Verifica si el string pasado por parametro contiene algun caracter que no sea alphanumerico
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>(true) si es Alpha Numerica,(false) de caso contrario</returns>
        public static bool EsAlphaNumerica(this string texto)
        {
            return texto.VerificarString(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Verifica si el string pasado por parametro contiene algun caracter que no sea una letra
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>(true) si contiene solo letras,(false) de caso contrario</returns>
        public static bool isLetter(this string texto)
        {
            return texto.VerificarString(char.IsLetter);
        }

        /// <summary>
        /// Verifica si el string pasado por parametro contiene solo numeros
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>(true) si contiene solo numeros,(false) de caso contrario</returns>
        public static bool EsNumerica(this string texto)
        {
            return texto.VerificarString(char.IsDigit);
        }

        /// <summary>
        /// Verifica si el string pasado por parametro contiene algun caracter que no este en la lista pasada por parametro
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="listaDeCaracteres"></param>
        /// <returns>(true) si contiene solo los caracteres de la lista,(false) de caso contrario</returns>
        public static bool VerificarCaracteres(this string cadena, List<char> listaDeCaracteres)
        {
            return cadena.VerificarString(listaDeCaracteres.Contains);
        }

    }
}
