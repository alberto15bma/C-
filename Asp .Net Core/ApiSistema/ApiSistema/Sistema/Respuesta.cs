using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSistema.Sistema
{
    public class Respuesta
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
    }
}
