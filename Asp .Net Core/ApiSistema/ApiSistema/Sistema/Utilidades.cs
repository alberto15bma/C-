using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSistema.Sistema
{
    public static class Utilidades
    {
        public static string Encriptar(this string texto)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(texto);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string texto)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(texto);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
