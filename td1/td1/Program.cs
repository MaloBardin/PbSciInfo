using System;
using System.Diagnostics;
using System.Drawing;


namespace td1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //choix de l'image 
            Console.SetCursorPosition(35, 10); Console.WriteLine("Bienvenue sur le convertisseur, merci d'indiquer le nom de votre image");
            Console.SetCursorPosition(35, 11); string filename = Console.ReadLine(); string filesource = "./Images/" + filename + ".bmp";
            Console.SetCursorPosition(35, 12); Console.WriteLine("Nous allons donc convertir le fichier " + filename+". Merci de patienter");
            Thread.Sleep(1500);



            
            Image ImageEnCours = new Image();
            Pixel[,] MatriceDePixelCouleur = ImageEnCours.Lecture(filesource); //on récupère içi notre matrice d'image 
                                                                               //on peut y accèder via ImageEnCours.MatricePixel
            

            Console.Clear();// vidange 

            int turnModifOnMessage = 0;
            while (1 == 1)
            {//faire la condition
                Console.SetCursorPosition(10, 2); Console.WriteLine("Image : " + filename + "    Source : " + filesource);
                Console.SetCursorPosition(57, 5); Console.WriteLine("Le convertisseur");
                Console.SetCursorPosition(20, 8); Console.WriteLine("1 Noir et Blanc");
                Console.SetCursorPosition(20, 9); Console.WriteLine("2 Agrandissement");
                Console.SetCursorPosition(20, 10); Console.WriteLine("3 A FAIRE");
                Console.SetCursorPosition(20, 11); Console.WriteLine("4 A FAIRE");
                Console.SetCursorPosition(20, 12); Console.WriteLine("5 Changement image (à faire)");
                Console.SetCursorPosition(20, 13); Console.WriteLine("6 Sauvegarder de votre image");
                Console.SetCursorPosition(30, 19); Console.Write("Faites votre choix avec 1,2,3,4 ou 5 : ");

                if (turnModifOnMessage == 1)
                {
                    Console.SetCursorPosition(30, 16); Console.Write("Modifications effectuées avec succès !");
                } else if (turnModifOnMessage == 2)
                {
                    Console.SetCursorPosition(30, 16); Console.Write("Sauvegarde effectuée avec succès !");
                }
                Console.SetCursorPosition(30, 20); string choixMenu = Console.ReadLine();


                switch (choixMenu)
                {
                    case "1":
                        Console.Clear();
                        //creation de la partie noir et blanc
                        NuancesGris Decoloration = new NuancesGris();
                        Image ImageDecoloree = Decoloration.ImageEnGris(ImageEnCours);
                        //matrice en n&b ImageDecoloRee si on veut l'utiliser -> on utilise image en cours classiquement
                        turnModifOnMessage = 1;
                        break;

                    case "2":
                        Console.Clear();
                        //On va agrandir notre image
                        int tailleMult=1; //par quelle int on multiplie notre taille
                        Agrandissement Aumgentation = new Agrandissement();
                        Aumgentation.MultiplicationMatrice(ImageEnCours, tailleMult);
                        turnModifOnMessage = 1;
                        break;

                    case "6":
                        Console.Clear();
                        Console.SetCursorPosition(25, 7); Console.WriteLine("Sous quel nom voulez vous sauvegarder votre image ?");
                        Console.SetCursorPosition(25, 8); string wantedFileName = Console.ReadLine();
                        ImageEnCours.SauvegardeImage(wantedFileName, filesource, ImageEnCours); //sauvegarde de notre image en n&b  | On peut aussi utiliser image en cours -> SAUVEGARDE A DEPLACER !
                        turnModifOnMessage = 2;
                        break;
                    default:
                        Console.SetCursorPosition(20, 20); Console.WriteLine("Erreur choix invalide");
                        turnModifOnMessage = 0;
                        break;

                }

                Console.Clear();
            }



            
           

            

            Console.WriteLine("done");




        }
    }
}