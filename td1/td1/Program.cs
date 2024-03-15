using System.Diagnostics;
using System.Drawing;


namespace td1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.SetCursorPosition(57, 5);  Console.WriteLine("Le convertisseur");
            Console.SetCursorPosition(20, 8); Console.WriteLine("1. Lire et écrire une image");

            string filename= "./Images/test2416.bmp";
            Image NouvelleImage = new Image();
            NouvelleImage.Lecture(filename);
            NouvelleImage.PrintImage(filename);


        }
    }
}