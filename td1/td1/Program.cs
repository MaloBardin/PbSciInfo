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

            string filename= "./Images/pixel.bmp";
            Image NouvelleImage = new Image();
            Pixel[,] MatriceDePixelCouleur= NouvelleImage.Lecture(filename);
            //NouvelleImage.CraftingNewImage(MatriceDePixelCouleur, filename, NouvelleImage);
            //on possède désormais la matrice de pixel (en couleur de l'image de base);

            //creation de la partie noir et blanc
            NuancesGris Decoloration = new NuancesGris();

            Image ImageDecoloree = Decoloration.ImageEnGris(NouvelleImage);
            //matrice en n&b

            NouvelleImage.SauvegardeImage(filename, ImageDecoloree);

            Console.WriteLine("done");




        }
    }
}