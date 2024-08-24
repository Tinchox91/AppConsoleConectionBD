using ConexionBD.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    internal class Inicio
    {
        static void Main(string[] args)
        {
            AccionSocio accionSocio = new AccionSocio();
            string resp;
           
                accionSocio.mostrarSocios();
            
            
           
        }
    }
}
