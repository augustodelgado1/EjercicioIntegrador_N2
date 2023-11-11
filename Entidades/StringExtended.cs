using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class StringExtended
    {
       
        public static string BorrarCaracteres(this string texto, char[] charsAremplazar)
        {
            string result = new string(texto);
            if (charsAremplazar is not null && charsAremplazar.Length > 0)
            {
                foreach (char caracterDeLaLista in charsAremplazar)
                {
                    if (texto.Contains(caracterDeLaLista) == true)
                    {
                        result = texto.Replace(caracterDeLaLista.ToString(), "");
                    }
                }
            }

            return result;
        }
        private static bool VerificarString(this string texto,Predicate<char> criterio)
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
        
        public static bool EsAlphaNumerica(this string texto)
        {
            return VerificarString(texto, char.IsLetterOrDigit);
        } 
        
        public static bool isLetter(this string texto)
        {
            return VerificarString(texto, char.IsLetter);
        } 
        
        public static bool EsNumerica(this string texto)
        {
            return VerificarString(texto, char.IsDigit);
        } 
        public static bool VerificarCaracteres(this string cadena, List<Char> listaDeCaracteres)
        {
            return cadena.VerificarString(listaDeCaracteres.Contains); 
        }
        
    }
}
