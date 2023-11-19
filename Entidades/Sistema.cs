using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Sistema
    {
        public static string CrearUnEmailRandom()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<char> listaDeCatacteresEmail = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            stringBuilder.Append($"{GeneradorDeCodigoRandom(listaDeCatacteresEmail,8)}@{GeneradorDeCodigoRandom(listaDeCatacteresEmail, 8)}");


            return stringBuilder.ToString();
        }
        public static string GeneradorDeCodigoRandom(List<char> caracteres, int cantidad)
        {
            Random numeroRandom = new Random();
            string identificador = string.Empty;

            if (caracteres is not null && caracteres.Count > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    identificador += caracteres[numeroRandom.Next(0, caracteres.Count)];
                }
            }

            return identificador;
        }
        public static string GeneradorDeAlphaNumerico(int cantidadDeNumeros,int cantdiadDeletras)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GeneradorDeLetras(cantdiadDeletras) + GeneradorDeNumeros(cantidadDeNumeros).ToString());
            return stringBuilder.ToString();
        }
        public static int GeneradorDeNumeros(int cantidad)
        {
            List<char> caracteres = new List<char>()
            {
                '1','2','3','4','5','6','7','8','9','0'
            };
            string identificador = string.Empty;
            int numero;
            identificador = GeneradorDeCodigoRandom(caracteres, cantidad);

            if (int.TryParse(identificador, out numero) == false)
            {
                numero = 0;
            }
            return numero;
        }
        public static string GeneradorDeLetras(int cantidad)
        {
            List<char> caracteres = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            return GeneradorDeCodigoRandom(caracteres, cantidad);
        }
    }
}
