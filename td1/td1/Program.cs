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
            ImageEnCours.Lecture(filesource);//on récupère içi notre matrice d'image 
            ImageEnCours.CorrigerImageApresModif(ImageEnCours);                 // on met les modifs de notre image
                                                                               //on peut y accèder via ImageEnCours.MatricePixel


            Console.Clear();// vidange 

            int turnModifOnMessage = 0;
            while (1 == 1)
            {//faire la condition
                Console.SetCursorPosition(10, 2); Console.WriteLine("Image : " + filename + "    Source : " + filesource);
                Console.SetCursorPosition(57, 5); Console.WriteLine("Le convertisseur");
                Console.SetCursorPosition(20, 8); Console.WriteLine("1 Noir et Blanc");
                Console.SetCursorPosition(20, 9); Console.WriteLine("2 Agrandissement");
                Console.SetCursorPosition(20, 10); Console.WriteLine("3 Rotation");
                Console.SetCursorPosition(20, 11); Console.WriteLine("4 Filtres");
                Console.SetCursorPosition(20, 12); Console.WriteLine("5 Fractales");
                Console.SetCursorPosition(20, 13); Console.WriteLine("6 Sauvegarde de votre image");
                Console.SetCursorPosition(20, 14); Console.WriteLine("7 Changer votre image");
                Console.SetCursorPosition(30, 19); Console.Write("Faites votre choix avec 1,2,3,4,5,6 ou 7 : ");

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
                        Console.SetCursorPosition(20, 9); Console.WriteLine("Voulez vous une image en nuance de gris(1) ou en noir et blanc (2)");
                        Console.SetCursorPosition(20, 11); int reponse = int.Parse(Console.ReadLine());
                        if (reponse == 1)
                        {
                            ImageEnCours.ImageEnGris(ImageEnCours);
                        } else
                        {
                            ImageEnCours.ImageEnNoir(ImageEnCours);
                        }
                       
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        //matrice en n&b ImageDecoloRee si on veut l'utiliser -> on utilise image en cours classiquement
                        turnModifOnMessage = 1;
                        break;

                    case "2":
                        Console.Clear();
                        //On va agrandir notre image
                        int tailleMult; //par quelle int on multiplie notre taille
                        Console.SetCursorPosition(30, 16); Console.Write("Combien de fois voulez-vous agrandir votre image ? : "); Console.SetCursorPosition(100, 16); tailleMult = int.Parse(Console.ReadLine());
                        ImageEnCours.Agrandissement(tailleMult);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        turnModifOnMessage = 1;
                        break;
                    
                    case "3":
                        Console.Clear();
                        //On va faire une rotation de notre image
                        
                        Console.SetCursorPosition(25, 7); Console.WriteLine("De combien de degrés voulez vous tourner votre image ?");
                        Console.SetCursorPosition(25, 8); int degre = Convert.ToInt32(Console.ReadLine());
                        ImageEnCours.RotationDegre(degre);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        break;

                    case "4":
                        Console.Clear();
                        //On va appliquer un filtre sur notre image
                        Filtre Filt = new Filtre(ImageEnCours);
                        ImageEnCours.MatricePixel = Filt.Filtrerimage(ImageEnCours);
                        break;
                    case "5":
                        Console.Clear();
                        //On va créer une fractale
                        Fractale Fract = new Fractale();
                        Console.SetCursorPosition(25, 7);
                        Console.WriteLine("Donnez la largeur de votre image voulue");
                        Console.SetCursorPosition(25, 8); int tailleX = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(25, 9); Console.WriteLine("Donnez la hauteur de votre image voulue");
                        Console.SetCursorPosition(25, 10); int tailleY = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(25, 11); Console.WriteLine("Donnez le nombre d'itérations : ");
                        Console.SetCursorPosition(25, 12); int nbIterations = Convert.ToInt32(Console.ReadLine());
                        Console.SetCursorPosition(25, 13); Console.WriteLine("Vous allez maintenant donner les valeurs RGB");
                        Console.SetCursorPosition(25, 14); Console.WriteLine("Donnez la valeur du rouge :");
                        Console.SetCursorPosition(25, 15); byte r = Convert.ToByte(Console.ReadLine());
                        Console.SetCursorPosition(25, 16); Console.WriteLine("Donnez la valeur du vert :");
                        Console.SetCursorPosition(25, 17); byte g = Convert.ToByte(Console.ReadLine());
                        Console.SetCursorPosition(25, 18); Console.WriteLine("Donnez la valeur du bleu :");
                        Console.SetCursorPosition(25, 19); byte b = Convert.ToByte(Console.ReadLine());
                        ImageEnCours.MatricePixel = Fract.FractaleMandelbrot(tailleX, tailleY, nbIterations, b, g, r);
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
                        break;


                    case "6":
                        Console.Clear();
                        Console.SetCursorPosition(25, 7); Console.WriteLine("Sous quel nom voulez vous sauvegarder votre image ?");
                        Console.SetCursorPosition(25, 8); string wantedFileName = Console.ReadLine();
                        ImageEnCours.SauvegardeImage(wantedFileName, ImageEnCours); //sauvegarde de notre image en n&b  | On peut aussi utiliser image en cours -> SAUVEGARDE A DEPLACER !
                        turnModifOnMessage = 2;
                        break;
                    case "7":
                        Console.Clear();
                        Console.SetCursorPosition(35, 10); Console.WriteLine("Merci d'indiquer le nom de votre image");
                        Console.SetCursorPosition(35, 11); filename = Console.ReadLine();filesource = "./Images/" + filename + ".bmp";
                        ImageEnCours.Lecture(filesource);//on récupère içi notre matrice d'image 
                        ImageEnCours.CorrigerImageApresModif(ImageEnCours);
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