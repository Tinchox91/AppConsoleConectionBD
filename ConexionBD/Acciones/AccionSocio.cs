using ConexionBD.Entidades;
using ConexionBD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Acciones
{
    internal class AccionSocio
    {
        public void mostrarSocios()
        {
            // Crea una instancia de ServicioSocio
            ServicioSocio servicioSocio = new ServicioSocio();
            

            Console.Write("Ingrese nombre del usuario a buscar: ");
            string dato = Console.ReadLine();
            // Llama al método consulta() pasando null para obtener todos los socios

            List<Socio> socios = servicioSocio.consulta(dato);

            // Recorre la lista de socios y los muestra en la consola
            foreach (Socio socio in socios)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"ID: {socio.id}, Nombre: {socio.nombre} Direccion:{socio.direccion} Telefono:{socio.telefono}");
                Console.ForegroundColor= ConsoleColor.DarkBlue;
                Console.WriteLine( $"Deporte:{socio.deportes}" );
            }
        }
    }
}
