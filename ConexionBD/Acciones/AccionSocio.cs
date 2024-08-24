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
        ServicioSocio servicioSocio = new ServicioSocio();
        
        public void mostrarSocios()
        {
            List<Socio> socios = servicioSocio.consulta(null);
                        
            foreach (Socio socio in socios)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"ID: {socio.id}///// Nombre: {socio.nombre} /// Direccion:{socio.direccion} //// Telefono:{socio.telefono}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Deporte:{socio.deportes}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
        public void buscarSocio()
        {
            Console.ForegroundColor=ConsoleColor.Gray;
            Console.Write("Ingrese Nombre o ID del usuario a buscar: ");
            string dato = Console.ReadLine();
            List<Socio> socios = servicioSocio.consulta(dato);
            Console.ForegroundColor =ConsoleColor.DarkGreen;
            foreach (Socio socio in socios)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"ID: {socio.id}///// Nombre: {socio.nombre} /// Direccion:{socio.direccion} //// Telefono:{socio.telefono}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Deporte:{socio.deportes}");
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------------------------------------");
            }
            if (socios.Count== 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("no se encontraron registros...");
            }
        }
        public void modificarSocio()
        {
            Socio socio = new Socio();
            Console.Write("indique el numero de ID del socio que desea modificar: ");
            string dato= Console.ReadLine();
            List<Socio> socios = servicioSocio.consulta(dato);
            if (socios.Count == 1)
            {
                 socio= socios[0];
                Console.Write("ingrese el nuevo nombre: ");
               string nombre= Console.ReadLine();
                if (nombre != null)
                {
                    socio.nombre = nombre;
                }
                Console.Write("ingrese la nueva direccion: ");
                string direccion = Console.ReadLine();
                if (direccion != null)
                {
                    socio.direccion = direccion;
                }
                Console.Write("ingrese el nuevo mail: ");
                string mail = Console.ReadLine();
                if (mail != null)
                {
                    socio.mail = mail;
                }
                Console.Write("ingrese el  nuevo telefono: ");
                string telefonoInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefonoInput) && Int64.TryParse(telefonoInput, out long telefono))
                {
                    socio.telefono = telefono;
                }
                Console.Write("ingrese el nuevo deporte: ");
                string deporte = Console.ReadLine();
                if (deporte != null)
                {
                    socio.deportes = deporte;
                }
                servicioSocio.updateSocio(socio);
                
                Console.WriteLine("socio modificado ");
            }
            else{ 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo modificar socio"); }
            
            
           

        }
        public void eliminarSocio()
        {
            Boolean val = false;
            do
            {
                Console.Write("ingresa el ID del socio que desea eliminar: ");
                long id = (long.Parse(Console.ReadLine()));
                
                List<Socio> socios = servicioSocio.consulta(id.ToString());
                if (socios.Count==0)
                {
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("No se encontro el socio");
                    val = true;
                }
                else
                {
                    servicioSocio.deleteSocio(id);
                    Console.ForegroundColor=ConsoleColor.Magenta;
                    Console.WriteLine("Socio eliminado");
                    val=true;
                }
            } while (!val);
            
           


        }
        public void crearSocio()
        {
            Socio socio = new Socio();
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Imgrese nombre: ");
                socio.nombre = Console.ReadLine();
                Console.Write("Imgrese direccion: ");
                socio.direccion = Console.ReadLine();
                Console.Write("Imgrese mail: ");
                socio.mail = Console.ReadLine();
                Console.Write("Imgrese telefono: ");
                socio.telefono = Int64.Parse(Console.ReadLine());
                Console.Write("ingrese deporte: ");
                socio.deportes = Console.ReadLine();
                servicioSocio.createSocio(socio);
            }
            catch (Exception e)
            {

                Console.WriteLine("No se pudo crear usuario");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
           
           
        }

    }
}
