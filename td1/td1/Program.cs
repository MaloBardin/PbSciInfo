using System;
using System.Diagnostics;
using System.Drawing;


namespace td1
{
    internal class Program
    {

        static void Dessin()
        {
           
            

            //choix de l'image & MENU
            Console.SetCursorPosition(37, 2);
            Console.Write("                                                                                                                                      \r\n"); Console.SetCursorPosition(37, 3);
            Console.Write("░░████████    ██████████        ▓▓██▒▒          ████████▓▓  ██████▒▒  ░░████░░     ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓     ████▒▒                ████▒▒\r\n"); Console.SetCursorPosition(37, 4);
            Console.Write("    ████        ▒▒████        ████░░████░░        ▒▒██        ████      ██         ████████▒▒▒▒▒▒▒▒██     ▒▒████              ▒▒████  \r\n"); Console.SetCursorPosition(37, 5);
            Console.Write("    ████        ░░██▒▒      ██        ░░██▒▒      ░░██        ██▒▒    ██             ████▒▒        ▒▒     ▒▒████░░         ▒▒█████▓▓  \r\n"); Console.SetCursorPosition(37, 6);
            Console.Write("    ████        ░░██▒▒    ████          ████░░    ░░██        ██▒▒  ██                 ████░░             ▒▒██  ██       ▒▒███  ██▓▓  \r\n"); Console.SetCursorPosition(37, 7);
            Console.Write("    ████▒▒▒▒▒▒▒▒▓▓██▒▒    ██░░██████████  ████    ░░██        ████▒▒██▒▒                 ████▒▒           ▒▒██  ░░██   ▒▒███    ██▓▓  \r\n"); Console.SetCursorPosition(37, 8);
            Console.Write("    ████  ░░░░░░▒▒██▒▒    ██  ██████████  ████    ░░██        ████  ████                   ██████         ▒▒██    ████▒▒██      ██▓▓  \r\n"); Console.SetCursorPosition(37, 9);
            Console.Write("    ████        ░░██▒▒    ██▒▒▒▒      ▒▒  ████    ░░██        ██▒▒    ██▒▒                 ▒▒██░░         ▒▒██      ████▒▒      ██▓▓  \r\n"); Console.SetCursorPosition(37, 10);
            Console.Write("    ████        ░░██▒▒    ████          ▒▒██      ░░██        ██▒▒    ▒▒██               ░░██             ▒▒██      ░░██        ██▓▓  \r\n"); Console.SetCursorPosition(37,11);
            Console.Write("    ████        ░░██▒▒      ██░░        ██░░      ░░██        ██▒▒      ████           ░░██               ▒▒██                  ██▓▓  \r\n"); Console.SetCursorPosition(37, 12);
            Console.Write("    ████        ██████        ██████████          ████░░      ████      ▒▒██▒▒        ▒▒██          ██    ████                  ████  \r\n"); Console.SetCursorPosition(37, 13);
            Console.Write("  ░░░░░░░░    ░░░░░░░░                          ░░░░░░░░    ░░░░░░      ░░░░░░░░    ░░████████████████    ░░░░                ░░░░░░░░\r\n"); Console.SetCursorPosition(37, 14);


            Console.SetCursorPosition(0, 0);
            Console.Write("\r\n░░░░░░▒▒  ░░▒▒▒▒░░  ░░░░░░░░▓▓▓▓▒▒▒▒\r\n  ░░▓▓░░▓▓▒▒▒▒▓▓░░▒▒▒▒░░░░░░▓▓▓▓▒▒▒▒\r\n    ░░▓▓▓▓▓▓░░▓▓▒▒░░░░░░▒▒▓▓▒▒▓▓██▒▒\r\n        ░░██▒▒██░░▒▒▒▒░░░░████      \r\n        ░░▒▒▓▓██▒▒░░░░░░░░██▒▒      \r\n          ░░▓▓▓▓░░░░░░░░░░▓▓░░      \r\n          ░░▒▒▓▓░░░░░░░░░░▓▓        \r\n          ░░▒▒▓▓░░░░░░░░░░▒▒        \r\n          ░░▒▒▒▒░░▓▓▓▓▒▒▓▓██        \r\n          ░░░░▓▓░░▓▓▓▓░░▒▒▒▒        \r\n          ▒▒▒▒▓▓▒▒▒▒▒▒▒▒▓▓░░        \r\n              ░░▓▓▓▓▒▒░░░░░░        \r\n          ░░  ░░  ░░░░░░░░          \r\n               ▒▒▒▒▒▒▒▒▒░░          \r\n            ▒▒▒▒▒▒▒▒▒▒▒▒░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n                ░░░░░░░░░░          \r\n                ░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n            ░░░░░░░░░░░░░░          \r\n          ▓▓░░░░░░░░░░░░░░██        \r\n          ▒▒░░  ░░░░░░░░▒▒▓▓        \r\n          ░░▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒░░      \r\n      ▒▒    ░░░░░░░░░░░░░░░░░░▓▓    \r\n    ░░▓▓▓▓░░            ░░░░▓▓▓▓▓▓  \r\n    ▓▓▓▓▓▓░░▒▒▒▒░░░░▒▒▒▒▒▒▒▒▓▓▓▓██  \r\n    ▒▒░░░░░░▒▒▓▓    ▒▒▓▓▒▒░░▒▒▒▒▓▓  \r\n      ▓▓▒▒░░░░▒▒░░░░░░░░░░░░▓▓▓▓    \r\n        ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░      \r\n");
            Console.SetCursorPosition(170, 0);

            Console.Write("                                    "); Console.SetCursorPosition(170, 1);
            Console.Write("  ░░▓▓░░▓▓▒▒▒▒▓▓░░▒▒▒▒░░░░░░▓▓▓▓▒▒▒▒"); Console.SetCursorPosition(170, 2);
            Console.Write("    ░░▓▓▓▓▓▓░░▓▓▒▒░░░░░░▒▒▓▓▒▒▓▓██▒▒"); Console.SetCursorPosition(170, 3);
            Console.Write("        ░░██▒▒██░░▒▒▒▒░░░░████      "); Console.SetCursorPosition(170, 4);
            Console.Write("        ░░▒▒▓▓██▒▒░░░░░░░░██▒▒      "); Console.SetCursorPosition(170, 5);
            Console.Write("          ░░▓▓▓▓░░░░░░░░░░▓▓░░      "); Console.SetCursorPosition(170, 6);
            Console.Write("          ░░▒▒▓▓░░░░░░░░░░▓▓        "); Console.SetCursorPosition(170, 7);
            Console.Write("          ░░▒▒▓▓░░░░░░░░░░▒▒        "); Console.SetCursorPosition(170, 8);
            Console.Write("          ░░▒▒▒▒░░▓▓▓▓▒▒▓▓██        "); Console.SetCursorPosition(170, 9);
            Console.Write("          ░░░░▓▓░░▓▓▓▓░░▒▒▒▒        "); Console.SetCursorPosition(170, 10);
            Console.Write("          ▒▒▒▒▓▓▒▒▒▒▒▒▒▒▓▓░░        "); Console.SetCursorPosition(170, 11);
            Console.Write("              ░░▓▓▓▓▒▒░░░░░░        "); Console.SetCursorPosition(170, 12);
            Console.Write("          ░░  ░░  ░░░░░░░░          "); Console.SetCursorPosition(170, 13);
            Console.Write("               ▒▒▒▒▒▒▒▒▒░░          "); Console.SetCursorPosition(170, 14);
            Console.Write("            ▒▒▒▒▒▒▒▒▒▒▒▒░░          "); Console.SetCursorPosition(170, 15);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 16);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 17);
            Console.Write("                ░░░░░░░░░░          "); Console.SetCursorPosition(170, 18);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 19);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 20);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 21);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 22);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 23);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 24);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 25);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 26);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 27);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 28);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 29);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 30);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 31);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 32);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 33);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 34);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 35);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 36);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 37);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 38);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 39);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 40);
            Console.Write("            ░░░░░░░░░░░░░░          "); Console.SetCursorPosition(170, 41);
            Console.Write("          ▓▓░░░░░░░░░░░░░░██        "); Console.SetCursorPosition(170, 42);
            Console.Write("          ▒▒░░  ░░░░░░░░▒▒▓▓        "); Console.SetCursorPosition(170, 43);
            Console.Write("          ░░▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒░░      "); Console.SetCursorPosition(170, 44);
            Console.Write("      ▒▒    ░░░░░░░░░░░░░░░░░░▓▓    "); Console.SetCursorPosition(170, 45);
            Console.Write("    ░░▓▓▓▓░░            ░░░░▓▓▓▓▓▓  "); Console.SetCursorPosition(170, 46);
            Console.Write("    ▓▓▓▓▓▓░░▒▒▒▒░░░░▒▒▒▒▒▒▒▒▓▓▓▓██  "); Console.SetCursorPosition(170, 47);
            Console.Write("    ▒▒░░░░░░▒▒▓▓    ▒▒▓▓▒▒░░▒▒▒▒▓▓  "); Console.SetCursorPosition(170, 48);
            Console.Write("      ▓▓▒▒░░░░▒▒░░░░░░░░░░░░▓▓▓▓    "); Console.SetCursorPosition(170, 49);
            Console.Write("        ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░      "); Console.SetCursorPosition(170, 20);

        }

        static void AffichageMenu(string filename, string filesource)
        {
            Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 26); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 27); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 28); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 29); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 30); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 31); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 32); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.SetCursorPosition(75, 34); Console.WriteLine("Image : " + filename);
            Console.SetCursorPosition(115, 34); Console.Write("    Source : " + filesource);
            Console.SetCursorPosition(62, 23); Console.WriteLine("1 Noir et Blanc");
            Console.SetCursorPosition(62, 25); Console.WriteLine("2 Nuances de Gris");
            Console.SetCursorPosition(62, 27); Console.WriteLine("3 Agrandissement");
            Console.SetCursorPosition(62, 29); Console.WriteLine("4 Rotation");
            Console.SetCursorPosition(97, 23); Console.WriteLine("5 Filtres");
            Console.SetCursorPosition(97, 25); Console.WriteLine("6 Fractales");
            Console.SetCursorPosition(97, 27); Console.WriteLine("7 Cacher une image");
            Console.SetCursorPosition(97, 29); Console.WriteLine("8 Reveler une image");
            Console.SetCursorPosition(132, 23); Console.WriteLine("9 Sauvegarder l'image");
            Console.SetCursorPosition(132, 25); Console.WriteLine("10 Changer d'image");
            Console.SetCursorPosition(132, 27); Console.WriteLine("11 Quitter");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez mettre votre console en plein écran et de suivre le tutoriel");
            Console.WriteLine(" pdf fourni dans le projet afin d'avoir la meilleur expérience possible");
            Console.WriteLine("\n\nMerci d'appuyer sur une touche lorsque cela a été effectué");
            Console.ReadKey();
            Console.Clear();
            Dessin();
            //Console.Write("                                                                  \r\n                ░░▓▓▓▓▓▓▓▓▒▒░░░░                                  \r\n              ▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒░░░░                      \r\n            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▒▒              \r\n          ▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒              \r\n        ▒▒▓▓░░░░░░▒▒▒▒▒▒▒▒░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░            \r\n      ░░▓▓▓▓░░░░▒▒▒▒░░░░▒▒▓▓▒▒░░░░▒▒░░░░░░░░░░░░░░░░░░░░          \r\n      ░░▓▓▒▒▒▒░░▒▒░░▒▒▒▒░░▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒░░        \r\n      ░░░░░░▒▒░░▒▒▒▒░░░░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▓▓▒▒▒▒░░░░░░▒▒░░      \r\n    ░░▒▒░░▒▒▓▓░░▒▒░░▒▒░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▒▒▒▒░░░░░░      \r\n      ▒▒▒▒▓▓▓▓▒▒▒▒▒▒░░░░▒▒▒▒▓▓▒▒▓▓▓▓▓▓▒▒▓▓▓▓▓▓░░▒▒░░░░▒▒░░▒▒      \r\n        ▒▒▓▓▓▓██▓▓▓▓▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓██░░▒▒▒▒▒▒▒▒▒▒▒▒      \r\n          ▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▒▒▒▒        \r\n            ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒░░▒▒▒▒░░▒▒▓▓▓▓  ▒▒▒▒▒▒▒▒░░        \r\n              ▒▒▒▒▒▒▓▓▓▓▓▓▒▒░░▒▒░░▒▒▒▒░░▒▒▒▒▒▒    ░░░░░░░░        \r\n                ▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒                    \r\n                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒░░                    \r\n                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░                    \r\n              ░░▓▓▒▒▒▒▒▒▒▒▒▒░░░░▒▒░░▒▒▒▒▒▒▓▓░░                    \r\n                ▒▒▒▒▒▒░░░░▓▓▒▒░░░░░░░░░░░░▒▒                      \r\n                ▒▒▒▒▒▒░░▓▓▓▓░░░░░░░░░░░░░░▒▒                      \r\n                ▒▒▒▒░░░░▒▒▒▒░░░░░░░░░░░░░░░░                      \r\n                ▒▒░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░                      \r\n                ▒▒░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░                    \r\n                ▒▒░░░░░░▒▒▒▒░░░░░░░░░░░░░░▒▒                      \r\n                ▒▒▒▒░░░░░░▒▒░░░░░░░░░░░░░░░░░░                    \r\n                ▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░                    \r\n                ░░░░░░░░░░░░░░░░░░░░░░░░░░░░                      \r\n                ▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░                      \r\n                ▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░                    \r\n                ▒▒░░░░░░░░░░░░░░▒▒░░▒▒░░░░▒▒░░                    \r\n                ▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░                    \r\n                ▒▒░░░░░░░░░░▒▒░░░░░░░░░░░░▒▒░░                    \r\n                ▒▒░░░░░░░░░░▒▒░░▒▒░░░░░░░░▒▒░░                    \r\n                ▒▒░░░░░░░░░░▒▒░░░░░░░░░░░░▒▒░░                    \r\n                ░░░░░░░░░░░░▒▒░░░░░░▒▒░░░░▒▒░░                    \r\n                ▒▒▒▒░░░░░░░░▒▒░░░░░░░░░░░░▒▒▒▒                    \r\n              ░░░░░░░░░░░░░░░░░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ░░▒▒░░░░░░░░▒▒░░▒▒░░░░░░░░▒▒▒▒                    \r\n                ░░░░░░░░░░░░░░░░▒▒░░░░░░░░▒▒▒▒                    \r\n              ░░░░░░░░░░░░░░░░░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ░░░░░░░░░░░░▒▒░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ░░░░░░░░░░░░▒▒░░░░░░▒▒░░░░▒▒▒▒                    \r\n                ░░▒▒░░░░░░░░▒▒░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ░░░░▒▒░░░░░░░░░░▒▒░░░░░░░░▒▒▒▒                    \r\n                ░░░░░░░░░░░░░░░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ░░░░░░░░░░░░▒▒░░▒▒░░▒▒░░░░▒▒▒▒                    \r\n                ▒▒░░░░░░░░░░▒▒░░▒▒░░▒▒░░▒▒▒▒▒▒                    \r\n                ░░░░░░░░░░░░░░░░▒▒░░▒▒░░▒▒▒▒▒▒                    \r\n                ▒▒░░▒▒░░░░░░▒▒░░▒▒░░▒▒░░▒▒▒▒▒▒                    \r\n");
            Console.SetCursorPosition(79, 23); Console.WriteLine("   Merci d'indiquer le nom de votre image");
            Console.SetCursorPosition(79, 24);Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(79, 25); Console.Write("█                                         █"); // choix de l'image
            Console.SetCursorPosition(79, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            
            Console.SetCursorPosition(98, 25); string filename = Console.ReadLine(); string filesource = "./Images/" + filename + ".bmp";
            Console.SetCursorPosition(70, 28); Console.WriteLine("Nous allons donc convertir le fichier " + filename+". Merci de patienter");
            Thread.Sleep(2000);

            Image ImageEnCours = new Image();
            ImageEnCours.Lecture(filesource);//on récupère içi notre matrice d'image 
            ImageEnCours.CorrigerImageApresModif(ImageEnCours);                 // on met les modifs de notre image
                                                                               //on peut y accèder via ImageEnCours.MatricePixel




            Console.Clear();// vidange  



            int turnModifOnMessage = 0;
            while (1 == 1)
            {//faire la condition


                Dessin();

                AffichageMenu(filename, filesource);
               
                Console.SetCursorPosition(83, 18); Console.Write("Faites votre choix en appuyant sur enter");
                //Console.SetCursorPosition(112, 18); 


                if (turnModifOnMessage == 1)
                {
                    Console.SetCursorPosition(87, 37); Console.Write("Modifications effectuées avec succès !       ");
                }
                else if (turnModifOnMessage == 2)
                {
                    Console.SetCursorPosition(87, 37); Console.Write("Sauvegarde effectuée avec succès !           ");
                }


                int posX = 61; int posY = 22;
                Console.SetCursorPosition(posX, posY); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                Console.SetCursorPosition(posX, posY + 1); Console.Write("█"); Console.SetCursorPosition(posX + 22, posY + 1); Console.Write("█");
                Console.SetCursorPosition(posX, posY + 2); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                int initCancellatoucheclavier = 0;
                Console.SetCursorPosition(127, 18); ConsoleKeyInfo toucheclavier=Console.ReadKey();
                
                while (toucheclavier.Key != ConsoleKey.Enter) // validation du choix
                {
                    if (initCancellatoucheclavier != 0) {
                        Console.SetCursorPosition(127, 18);
                        toucheclavier = Console.ReadKey();
                    }                                   //sert a éviter la double lecture de touche (du while et d'ici)
                    initCancellatoucheclavier = 1;

                    if ((toucheclavier.Key == ConsoleKey.Z || toucheclavier.Key == ConsoleKey.UpArrow) && posY>22) // verif qu'on est pas en dehors
                    {
                        posY=posY-2;
                        AffichageMenu(filename, filesource);
                    }
                    else if ((toucheclavier.Key == ConsoleKey.S || toucheclavier.Key == ConsoleKey.DownArrow ) && posY<28 )
                    {
                        posY = posY + 2;
                        AffichageMenu(filename, filesource);
                    }
                    else if ((toucheclavier.Key == ConsoleKey.D || toucheclavier.Key == ConsoleKey.RightArrow )&& posX<129)
                    {
                        posX = posX + 35;
                        AffichageMenu(filename, filesource);
                    }
                    else if ((toucheclavier.Key == ConsoleKey.Q || toucheclavier.Key == ConsoleKey.LeftArrow )&& posX >61)
                    {
                        posX=posX-35;
                        AffichageMenu(filename, filesource);
                    }

                    
                        Console.SetCursorPosition(posX, posY);Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(posX, posY+1); Console.Write("█"); Console.SetCursorPosition(posX + 22, posY + 1); Console.Write("█");
                        Console.SetCursorPosition(posX, posY+2); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                }

                string choixMenu = "";


                if (posX==61 && posY==22) { 
                    choixMenu = "1"; 
                }
                else if (posX == 61 && posY == 24) 
                {
                    choixMenu = "2";
                }
                else if (posX == 61 && posY == 26) {
                    choixMenu = "3";
                } else if (posX == 61 && posY == 28) {
                    choixMenu = "4";
                } else if (posX == 96 && posY == 22) {
                    choixMenu = "5";
                } else if (posX == 96 && posY == 24) {
                    choixMenu = "6";
                } else if (posX == 96 && posY == 26) {
                    choixMenu = "7";
                }
                else if (posX == 96 && posY == 28) {
                    choixMenu = "8";
                } else if (posX == 131 && posY == 22) {
                    choixMenu = "9";
                } else if (posX == 131 && posY == 24) {
                    choixMenu = "10";
                } else if (posX == 131 && posY == 26) {
                    choixMenu = "11";
                }
                

                



                switch (choixMenu)
                {
                    case "1":
                        Console.Clear();
                        ImageEnCours.ImageEnNoir(ImageEnCours);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        //matrice en n&b ImageDecoloRee si on veut l'utiliser -> on utilise image en cours classiquement
                        turnModifOnMessage = 1;
                        break;

                    case "2":
                        Console.Clear();
                        ImageEnCours.ImageEnGris(ImageEnCours);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;

                    case "3":
                        Console.Clear();
                        //On va agrandir notre image
                        Dessin(); // on ramène nos colonnes
                        int tailleMult; //par quelle int on multiplie notre taille
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.SetCursorPosition(60, 22); Console.Write("Combien de fois voulez-vous agrandir votre image ? : "); Console.SetCursorPosition(135, 22); tailleMult = int.Parse(Console.ReadLine());
                        ImageEnCours.Agrandissement(tailleMult);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;
                    
                    case "4":
                        Console.Clear();
                        //On va faire une rotation de notre image
                        Dessin(); // on ramène nos colonnes
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.SetCursorPosition(60, 22); Console.WriteLine("De combien de degrés voulez vous tourner votre image ?");
                        Console.SetCursorPosition(135, 22); int degre = Convert.ToInt32(Console.ReadLine());
                        ImageEnCours.RotationDegre(degre);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;

                    case "5":
                        Console.Clear();
                        //On va appliquer un filtre sur notre image
                        ImageEnCours.MatricePixel = ImageEnCours.Filtrerimage(ImageEnCours);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;
                    case "6":
                        Console.Clear();

                        Dessin(); // on ramène nos colonnes
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

                        Console.SetCursorPosition(54, 21);
                        Console.WriteLine("Donnez la largeur de votre image voulue :");
                        Console.SetCursorPosition(97, 21); int tailleX = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(105, 21); Console.WriteLine("Donnez la hauteur de votre image voulue :");
                        Console.SetCursorPosition(150, 21); int tailleY = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(54, 22); Console.WriteLine("Donnez le nombre d'itérations : ");
                        Console.SetCursorPosition(86, 22); int nbIterations = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(89, 22); Console.WriteLine("Vous allez maintenant donner les valeurs RGB du fond de l'image");
                        Console.SetCursorPosition(54, 23); Console.WriteLine("Donnez la valeur du rouge :");
                        Console.SetCursorPosition(82, 23); byte r = Convert.ToByte(Console.ReadLine());
                        Console.SetCursorPosition(88, 23); Console.WriteLine("Donnez la valeur du vert :");
                        Console.SetCursorPosition(115, 23); byte g = Convert.ToByte(Console.ReadLine());
                        Console.SetCursorPosition(119, 23); Console.WriteLine("Donnez la valeur du bleu :");
                        Console.SetCursorPosition(147, 23); byte b = Convert.ToByte(Console.ReadLine());
                        Console.SetCursorPosition(54, 25); Console.WriteLine("Voulez vous que la fractale ait une aura chaude autour de la fractale ? (o/n) : ");
                        Console.SetCursorPosition(140, 25); string chaleur = Console.ReadLine();
                        bool chal = false;
                        if (chaleur == "o") { chal = true; }
                        ImageEnCours.FractaleMandelbrot(tailleX, tailleY, nbIterations, b, g, r, chal) ;
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;

                    case "7":
                        Console.Clear();
                        Image MonImageACacher = new Image();

                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        do
                        {
                            Console.SetCursorPosition(70, 22); Console.WriteLine("Attention à ne pas avoir une image à cacher plus grande que le fond !");
                            Console.SetCursorPosition(80, 23); Console.WriteLine("Quel est le nom de l'image qui se cache ?");
                            Console.SetCursorPosition(100, 24); string filesourcenameToHide = Console.ReadLine();
                            MonImageACacher.Lecture("./Images/" + filesourcenameToHide + ".bmp");
                            MonImageACacher.CorrigerImageApresModif(MonImageACacher);
                        } while (MonImageACacher.TailleX> ImageEnCours.TailleX && MonImageACacher.TailleY > ImageEnCours.TailleY);


                        ImageEnCours.CacherLimage(MonImageACacher);
                        turnModifOnMessage = 1;
                        break;

                    case "8":
                        Console.Clear();
                        Dessin(); // on ramène nos colonnes
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 25); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.SetCursorPosition(70, 22); Console.WriteLine("Vous souhaitez 1: garder l'image qui était cachée ou "); Console.SetCursorPosition(70, 23); Console.Write(" 2: sauvegarder l'image visible sans image qui se cache ?");
                        Console.SetCursorPosition(130, 23); int reponseChoix = int.Parse(Console.ReadLine());
                        ImageEnCours.RevelerLImage(reponseChoix);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;

                    case "9":
                        Console.Clear();
                        Dessin(); // on ramène nos colonnes
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 25); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.SetCursorPosition(79, 22); Console.WriteLine("Sous quel nom voulez vous sauvegarder votre image ?");
                        Console.SetCursorPosition(104, 23); string wantedFileName = Console.ReadLine();
                        ImageEnCours.SauvegardeImage(wantedFileName, ImageEnCours); //sauvegarde de notre image en n&b  | On peut aussi utiliser image en cours -> SAUVEGARDE A DEPLACER !
                        turnModifOnMessage = 2;
                        break;

                    case "10":
                        Console.Clear();
                        Dessin(); // on ramène nos colonnes
                        Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                        Console.SetCursorPosition(52, 25); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                        Console.SetCursorPosition(86, 22); Console.WriteLine("Merci d'indiquer le nom de l'image");
                        Console.SetCursorPosition(100, 23); filename = Console.ReadLine();filesource = "./Images/" + filename + ".bmp";
                        ImageEnCours.Lecture(filesource);//on récupère içi notre matrice d'image 
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        break;

                    case "11":

                        Console.Clear();
                        System.Environment.Exit(0); // exit  si on veut
                        break;
                                       

                    default:
                        Console.SetCursorPosition(90, 37); Console.WriteLine("Erreur choix invalide");
                        turnModifOnMessage = 0;
                        break;

                }

            }



            
           

            

            




        }

        
    }
}