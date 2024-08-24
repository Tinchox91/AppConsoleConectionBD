using ConexionBD.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Menu
{
    internal class MenuPrincipalSocio
    {
        AccionSocio cl = new AccionSocio();
        public int menu()
        {

            // Definición de las opciones del menú
            string[] opciones = {
                "1. Agregar Socio",
                "2.Mostrar Todos los socios",
                "3. Buscar socio",
                "4.Modificar Socio",
                "5.Eliminar Socio",
                "6.Salir"
            };

            // Índice de la opción actualmente seleccionada
            int seleccionActual = 0;

            // Variable para almacenar la tecla presionada
            ConsoleKey key;

            // Bucle principal que continúa hasta que se presione Enter
            do
            {
                // Limpia la consola en cada iteración para redibujar el menú
                Console.Clear();

                // Itera sobre las opciones del menú
                for (int i = 0; i < opciones.Length; i++)
                {
                    // Si la opción es la actualmente seleccionada, se resalta
                    if (i == seleccionActual)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto a rojo
                        Console.WriteLine("> " + opciones[i]); // Imprime la opción con un marcador
                        Console.ResetColor(); // Restablece el color del texto
                    }
                    else
                    {
                        // Imprime las opciones que no están seleccionadas
                        Console.WriteLine("  " + opciones[i]);
                    }
                }

                // Captura la tecla presionada por el usuario sin mostrarla en la consola
                key = Console.ReadKey(true).Key;

                // Maneja la tecla presionada
                switch (key)
                {
                    // Si se presiona la flecha hacia arriba y no estamos en la primera opción
                    case ConsoleKey.UpArrow:
                        if (seleccionActual > 0)
                        {
                            seleccionActual--; // Mueve la selección una opción hacia arriba
                        }
                        break;

                    // Si se presiona la flecha hacia abajo y no estamos en la última opción
                    case ConsoleKey.DownArrow:
                        if (seleccionActual < opciones.Length - 1)
                        {
                            seleccionActual++; // Mueve la selección una opción hacia abajo
                        }
                        break;
                }
            } while (key != ConsoleKey.Enter); // El bucle continúa hasta que se presione Enter

            // Limpia la consola al finalizar el bucle
            Console.Clear();

            switch (seleccionActual)
            {
                case 0:

                    cl.crearSocio(); break;
                case 1: cl.mostrarSocios(); break;
                case 2: cl.buscarSocio(); break;
                case 3: cl.modificarSocio(); break;
                case 4: cl.eliminarSocio(); break;
                case 6:  break;

            }

            // Espera a que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
            return seleccionActual;
        }
        public Boolean continuarSiNo()
        {
            string[] opcion = { "SI", "NO" };
            int seleccionActual = 0;
            ConsoleKey key;
            Console.Clear();
            do
            {
                for (int i = 0; i < opcion.Length; i++)
                {
                    // Si la opción es la actualmente seleccionada, se resalta
                    if (i == seleccionActual)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Cambia el color del texto a rojo
                        Console.WriteLine("> " + opcion[i]); // Imprime la opción con un marcador
                        Console.ResetColor(); // Restablece el color del texto
                    }
                    else
                    {
                        // Imprime las opciones que no están seleccionadas
                        Console.WriteLine("  " + opcion[i]);
                    }
                }
                key = Console.ReadKey(true).Key;
                switch (key)
                {

                    case ConsoleKey.UpArrow:
                        if (seleccionActual > 0)
                        {
                            seleccionActual--;
                        }
                        break;


                    case ConsoleKey.DownArrow:
                        if (seleccionActual < opcion.Length - 1)
                        {
                            seleccionActual++;
                        }
                        break;
                }
                Console.Clear();

            } while (key != ConsoleKey.Enter);
            if (seleccionActual == 1)
            {
                return false;
            }
            return true;


        }
        public List<string> menuDeportes()
        {
            List<string> deportes = new List<string>();
            string[] dep = new string[]
            {
        "Futbol",
        "Basquet",
        "Tenis",
        "Natacion",
        "Gimnasia artistica",
        "Patin en Hielo",
        "Boxeo",
        "Taek-Wondo",
        "Terminar y Salir"
            };
            int seleccionActual = 0;
            ConsoleKey key;
            do
            {
                do
                {
                    Console.Clear();

                    for (int i = 0; i < dep.Length; i++)
                    {
                        if (i == seleccionActual)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("> " + dep[i]);

                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("  " + dep[i]);
                        }

                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {

                        case ConsoleKey.UpArrow:
                            if (seleccionActual > 0)
                            {
                                seleccionActual--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (seleccionActual < dep.Length - 1)
                            {
                                seleccionActual++;
                            }
                            break;
                    }

                } while (key != ConsoleKey.Enter);
                if (seleccionActual != 8)//se evita que se guarde "terminar y salir"
                {
                    deportes.Add(dep[seleccionActual]);//se va agregando la opcion del indice que se da enter
                }

            } while (seleccionActual != 8); //en el indice 8 se sale del bucle de eleccion        

            return deportes;//retorno la lista
        }
    }



}

