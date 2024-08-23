using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Entidades
{
    internal class Socio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }

        public string mail { get; set; }
        public long telefono { get; set; }
        public string deportes { get; set; }
    }
}
