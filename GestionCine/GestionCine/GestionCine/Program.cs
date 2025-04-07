using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mostrar el arte ASCII de CINE MAX al iniciar
            string[] cineMax = new string[]
            {
           "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
    "@@@@                                                                                                              @@@@",
    "@@@@                                                                                                              @@@@",
    "@@@@    ##########   #####   #####    ####    ###########    ####      ####       #######      #####     #####    @@@@",
    "@@@@    ##########   #####   ######   ####    ###########    #####    #####      #########      #####   #####     @@@@",
    "@@@@    ####         #####   #######  ####    ####           ######  ######     ##### #####      ##### #####      @@@@",
    "@@@@    ####         #####   ######## ####    ###########    ##############     ####   ####       #########       @@@@",
    "@@@@    ####         #####   #### ########    ###########    #### #### ####    #############      #########       @@@@",
    "@@@@    ####         #####   ####  #######    ####           ####  ##  ####    #############     ##### #####      @@@@",
    "@@@@    ##########   #####   ####   ######    ###########    ####      ####    #####   #####    #####   #####     @@@@",
    "@@@@    ##########   #####   ####    #####    ###########    ####      ####    ####     ####   #####     #####    @@@@",
    "@@@@                                                                                                              @@@@",
    "@@@@                                                                                                              @@@@",
    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
    "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
    "...............................................................................................",
    "...............................................................................................",
    "...............................................................................................",
    ".......................................................2222222222..............................",
    ".................................................222222221111112222222.........................",
    "..............................................2222111111111ºº11111111222.......................",
    ".........................................22222211111ºº11ºººfº1f11ººº1112222....................",
    ".......................................22221111ººfffººf1fººff1fºfffºººº11122...................",
    "......................................22211***1ººº1ººººº1ffººfffºffff1ffºº1122.................",
    ".....................................2221****1ºººfffffººffºººfºfff1fffººººº11222...............",
    "....................................22211***1ºffººfffºººfffºººfffºººfffffff1º11222.............",
    "....................................222111**21ººffºººffºººfºfffººfºffºffffººffº1122............",
    ".....................................22211*22211ººfºffºffºffffººfºfºººfffººffffºº122...........",
    ".....................................2221+122222111ººººffºffffºfººººfffºº1ffºººº1122...........",
    ".....................................2211+?+111222211ºººfººffºfffffºffºº1ffººº1111122..........",
    "....................................2211?????112222211111ººººººººººfffººff1111***1122..........",
    "...................................2221+????22111122222221111111ººfffºº111*****11122...........",
    "...................................2211????222222?111112222222221111111*****1112222............",
    "...................................221+???222222?????++11111122***********111222...............",
    "..................................2211???222222?????++*****++11111111111111222.................",
    "..................................221+???22222????++*****++++*******++++1122...................",
    ".................................2221???22222????++*****++++******+++112222....................",
    ".................................2221??22222???++*****++++******+++11222.......................",
    "..................................2221112222???++*****++++******+11122.........................",
    "...................................2222111???++*****++++*****++1122222.........................",
    "......................................22221111*****++++****++11222.............................",
    ".........................................222211111+++*****+11222...............................",
    "............................................222221111111111222.................................",
    "................................................222222222222...................................",
    "...............................................................................................",
    };

            DrawTextArt(cineMax);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();

            // Mostrar el menú principal
            Console.ForegroundColor = ConsoleColor.Cyan;
            int opcion;

            do
            {
                Console.Clear();
                opcion = Pantallas.PantallaPrincipal();

                switch (opcion)
                {
                    case 1:
                        Pantallas.MenuRolCliente();
                        break;
                    case 2:
                        Pantallas.MenuRolTrabajador();
                        break;
                    case 3:
                        Pantallas.MenuRolAdminFun();
                        break;
                    case 0:
                        break;
                }
            } while (opcion != 4);
        }

        // Método para dibujar el arte de texto en la consola
        static void DrawTextArt(string[] textArt)
        {
            foreach (string line in textArt)
            {
                foreach (char c in line)
                {
                    // CINEMAX Pixel
                    if (c == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Black; // El color de las letras
                        Console.Write("█"); // Espacio vacío
                    }

                    //Canchita Pixel
                    if (c == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.Black; // El color de las letras
                        Console.Write("■"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Black; // El color de las letras
                        Console.Write("■"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '?')
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == 'º')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == 'f')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }

                    if (c == '2')
                    {
                        Console.ForegroundColor = ConsoleColor.White; // El color de las letras
                        Console.Write("█"); // Bloque sólido como píxel para que el cartel funciones 
                    }
                }
                Console.WriteLine(); // Nueva línea al final de cada fila
            }
        }
    }
}
