using ConexionBD.Acciones;
using ConexionBD.Menu;
using MySqlX.XDevAPI.Common;
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
           
              MenuPrincipalSocio menuu = new MenuPrincipalSocio();
            Boolean result;
            do
            {
                menuu.menu();
               result= menuu.continuarSiNo();
                
            } while (result);
            
            
           
        }
    }
}
