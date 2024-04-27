using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace td1
{
    internal class Image
    {

        Pixel[,] matricePixel;
        byte[] header;
        int tailleX;
        int tailleY;
        int tailleFichier;
        int tailleImage;

        public Pixel[,] MatricePixel
        {
            get { return matricePixel; }
            set { matricePixel = value; }
        }

        public byte[] Header
        {
            get { return header; }
            set { header = value; }
        }

        public int TailleX
        {
            get { return tailleX; }
            set { tailleX = value; }
        }
        public int TailleY
        {
            get { return tailleY; }
            set { tailleY = value; }
        }

        public int TailleFichier
        {
            get { return tailleFichier; }
            set { tailleFichier = value; }
        }

        public int TailleImage
        {
            get { return tailleImage; }
            set { tailleImage = value; }
        }



        public Image()
        {
            // création vide
        }

        public Pixel PixelEnGris(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B) / 3;
            gris.R = valeur;
            gris.G = valeur;
            gris.B = valeur;
            return gris;
        }

        public Pixel PixelEnNoir(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B) / 3;
            if (valeur < 125)
            {
                gris.R = 0; gris.B=0; gris.G = 0;
            } else
            {
                gris.R = 255; gris.B = 255; gris.G = 255;
            }
            return gris;
        }


        public Image ImageEnNoir(Image dessin)

        {
            Pixel[,] pixelNoir = new Pixel[dessin.MatricePixel.GetLength(0), dessin.MatricePixel.GetLength(1)];

            for (int i = 0; i < dessin.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < dessin.MatricePixel.GetLength(1); j++)
                {
                    pixelNoir[i, j] = PixelEnNoir(dessin.MatricePixel[i, j]);
                }
            }

            dessin.MatricePixel = pixelNoir;

            return dessin;
        }


        public Image ImageEnGris(Image dessin)

        {
            Pixel[,] pixelGris = new Pixel[dessin.MatricePixel.GetLength(0), dessin.MatricePixel.GetLength(1)];

            for (int i = 0; i < dessin.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < dessin.MatricePixel.GetLength(1); j++)
                {
                    pixelGris[i, j] = PixelEnGris(dessin.MatricePixel[i, j]);
                }
            }

            dessin.MatricePixel = pixelGris;

            return dessin;
        }



        public Image(Pixel[,] MatricePixel, byte[] Header, int tailleX, int tailleY, int tailleFichier, int tailleImage)
        { 
            this.MatricePixel = MatricePixel;
            this.Header = Header;
            this.tailleX = tailleX;
            this.tailleY = tailleY;
            this.tailleFichier = tailleFichier;
            this.tailleImage = tailleImage;
        }


        public byte[] Int2ToByte(int nombre)

        {
            byte[] byteTab = new byte[4];
            byteTab[0] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[1] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[2] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[3] = (byte)(nombre % 256);

            return byteTab;
        }

        public int Byte2Int(byte[] tabByte)
        {
            int resultat = 0;
            resultat = resultat + tabByte[0] * 1;
            resultat = resultat + tabByte[1] * 256;
            resultat = resultat + tabByte[2] * 256 * 256;
            resultat = resultat + tabByte[3] * 256 * 256 * 256;
            return resultat;
        }


        public void RotationDegre(int degre)
        {
           
            double rad = degre * Math.PI / 180.0;

            // Calcul des dimensions de l'image de sortie
            // nouvelle taille x = taille x * |cos(rad)| + taille y * |sin(rad)|
            // nouvelle taille y = taille x * |sin(rad)| + taille y * |cos(rad)|


            int nvtailleX = Convert.ToInt32(tailleX * Math.Abs(Math.Cos(rad)) + tailleY * Math.Abs(Math.Sin(rad)));
            int nvtailleY = Convert.ToInt32(tailleX * Math.Abs(Math.Sin(rad)) + tailleY * Math.Abs(Math.Cos(rad)));

            // Ajuster les dimensions pour qu'elles soient des multiples de 4 (sinon BMP pas lisible)
            while (nvtailleX % 4 != 0)
            {
                nvtailleX++;
            }
            while (nvtailleY % 4 != 0)
            {
                nvtailleY++;
            }

            // Création de l'image de sortie
            Pixel[,] imageTournee = new Pixel[nvtailleX, nvtailleY];

            // Calcul des coordonnées du centre de l'image d'entrée
            int centreX = tailleX / 2;
            int centreY = tailleY / 2;

            // Calcul des coordonnées du centre de l'image de sortie
            int nvcentreX = nvtailleX / 2;
            int nvcentreY = nvtailleY / 2;


            // Parcourir tous les pixels de l'image d'entrée et les placer dans l'image de sortie
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    // Calcul des coordonnées du pixel dans l'image de sortie
                    // nouveau x = (x - centreX) * cos(rad) - (y - centreY) * sin(rad) + nvcentreX
                    // nouveau y = (x - centreX) * sin(rad) + (y - centreY) * cos(rad) + nvcentreY
                    // on rajoute les nouveaux centres pour recentrer l'image autour du centre et pas en 0,0

                    int nvx = Convert.ToInt32(((x - centreX) * Math.Cos(rad) - (y - centreY) * Math.Sin(rad) + nvcentreX));
                    int nvy = Convert.ToInt32(((x - centreX) * Math.Sin(rad) + (y - centreY) * Math.Cos(rad) + nvcentreY));

                    // Copier le pixel de l'image d'entrée dans l'image de sortie si les coordonnées sont valides
                    if (nvx >= 0 && nvx < nvtailleX && nvy >= 0 && nvy < nvtailleY)
                    {
                        imageTournee[nvx, nvy] = MatricePixel[x, y];
                    }
                }
            }

            // pour éviter des pixels noirs un peu partout (car la trigo implique qu'il y aura des pixels non remplis)

            // vérifie si les pixels adjacents à un pixel nul sont plus de 6 à etre non nuls,
            // si oui on fait la moyenne des pixels non nuls du pixel en question

            for (int x = 0; x < nvtailleX; x++)
            {
                for (int y = 0; y < nvtailleY; y++)
                {
                    if (imageTournee[x, y] == null)
                    {
                        // on initialise les sommes
                        int nbPixelNonNuls = 0;
                        int sommeB = 0;
                        int sommeG = 0;
                        int sommeR = 0;
                        // On parcourt les pixels autour du pixel en question
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                // On vérifie que le pixel est dans l'image
                                if (x + i >= 0 && x + i < nvtailleX && y + j >= 0 && y + j < nvtailleY)
                                {
                                    // On vérifie que le pixel n'est pas nul
                                    if (imageTournee[x + i, y + j] != null)
                                    {
                                        // On incrémente le nombre de pixels non nuls
                                        nbPixelNonNuls++;
                                        // On fait la somme des couleurs B,G,R des pixels non nuls
                                        // (qu'on va ensuite diviser par le nb de pixels non nuls pour obtenir une moyenne)
                                        sommeB += imageTournee[x + i, y + j].B;
                                        sommeG += imageTournee[x + i, y + j].G;
                                        sommeR += imageTournee[x + i, y + j].R;

                                    }
                                }
                            }
                        }
                        // Si plus de 6 pixels non nuls, on fait la moyenne des pixels non nuls (division par le nb de pixels non nuls)
                        if (nbPixelNonNuls >= 6)
                        {
                            imageTournee[x, y] = new Pixel(Convert.ToByte(sommeB / nbPixelNonNuls), Convert.ToByte(sommeG / nbPixelNonNuls), Convert.ToByte(sommeR / nbPixelNonNuls));
                        }
                        // Sinon on met un pixel noir (pour les pixels tout autour)
                        else
                        {
                            imageTournee[x, y] = new Pixel(0, 0, 0);
                        }
                    }
                }
            }
            MatricePixel = imageTournee;

        }




        public void CacherLimage(Image ImageACacher)
        {
            for (int i = 0; i < ImageACacher.TailleX; i++)
            {
                for (int j = 0; j < ImageACacher.TailleY; j++)
                {
                    //bit point fort du background (donc devant)  bit point fort de l'image à cacher ( derriere)
                    MatricePixel[i, j].R = 16 * (int)(MatricePixel[i, j].R / 16) + (int)(ImageACacher.MatricePixel[i, j].R/16);
                    MatricePixel[i, j].G = 16 * (int)(MatricePixel[i, j].G / 16) + (int)(ImageACacher.MatricePixel[i, j].G / 16);
                    MatricePixel[i, j].B = 16 * (int)(MatricePixel[i, j].B / 16) + (int)(ImageACacher.MatricePixel[i, j].B / 16);

                    MatricePixel[i, j].R = 255; MatricePixel[i, j].G = 255; MatricePixel[i, j].B = 255;
                }
            }
        }

        public void RevelerLImage(int reponse)
        {
            for (int i = 0; i < TailleX; i++)
            {
                for (int j = 0; j < TailleY; j++)
                {
                    if (reponse == 1)
                    {
                        // c'est l'image cachée dans l'image background
                        MatricePixel[i, j].R = 16 * (int)(MatricePixel[i, j].R % 16); // % car on prend le bit de point faible que l'on remet en point fort ( d'ou me x16)
                        MatricePixel[i, j].G = 16 * (int)(MatricePixel[i, j].G % 16);
                        MatricePixel[i, j].B = 16 * (int)(MatricePixel[i, j].B % 16);
                    } else
                    {
                        //matrice pixel donne juste l'image background sans limage cachée derrriere
                        MatricePixel[i, j].R = 16 * (int)(MatricePixel[i, j].R / 16); // on divise par 16 car on garde que le bit de point fort  
                        MatricePixel[i, j].G = 16 * (int)(MatricePixel[i, j].G / 16); ;
                        MatricePixel[i, j].B = 16 * (int)(MatricePixel[i, j].B / 16);
                    }
                   

                  
                }
            }
        }



        public Pixel[,] Filtrerimage(Image image)
        {
            Pixel[,] MatricePixel = new Pixel[image.TailleX, image.TailleY];

            for (int i = 0; i < image.TailleX; i++)
            {
                for (int j = 0; j < image.TailleY; j++)
                {
                    MatricePixel[i, j] = new Pixel(0, 0, 0); /// On initialise notre matrice de sorte a qu'il soit rempli de pixels noirs
                }
            }

            Console.SetCursorPosition(25, 7); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:");
            int coeff = Convert.ToInt32(Console.ReadLine());
            while (coeff % 2 == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(25, 7); Console.WriteLine("Erreur, votre matrice n'est pas impair.");
                Console.SetCursorPosition(25, 8); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:");
                coeff = Convert.ToInt32(Console.ReadLine());
            }
            int copy = coeff;
            int a = 0;
            while (coeff != 1)
            {
                coeff -= 2;
                a++;
            }
            Console.Clear();
            Console.WriteLine("Super! votre matrice (" + copy + "x" + copy + ") fonctionne avec notre programme");

            Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
            Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
            Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
            Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
            Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
            Console.SetCursorPosition(15, 13); Console.Write("Quel filtre souhaitez-vous?");
            Console.SetCursorPosition(15, 14); string answern = Console.ReadLine();
            while (answern != "1" && answern != "2" && answern != "3" && answern != "4")
            {
                Console.Clear();
                Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                Console.SetCursorPosition(15, 13); Console.WriteLine("Votre choix n'est pas valide. Veuillez réessayer:");
                Console.SetCursorPosition(15, 14); answern = Console.ReadLine();
            }
            Console.Clear();
            switch (answern)
            {
                case "1": /// Filtre: Détection de contour                                          
                    int[,] MatriceConvContour = new int[copy, copy];
                    if (copy != 3 && copy != 5)
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);
                                MatriceConvContour[i, j] = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                        }
                    }
                    if (copy == 3)
                    {
                        Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(3000);
                        MatriceConvContour = new int[,]
                        {
                                   {-1,-1,-1},
                                   {-1, 8,-1},
                                   {-1,-1,-1}
                        };
                    }
                    if (copy == 5)
                    {
                        Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(3000);
                        MatriceConvContour = new int[,]
                        {
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0, 4, 0, 0},
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0,-1, 0, 0},
                        };
                    }

                    for (int i = a; i < image.TailleX - a; i++)
                    {
                        for (int j = a; j < image.TailleY - a; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                            for (int k = -a; k <= a; k++)
                            {
                                for (int l = -a; l <= a; l++)
                                {
                                    ajouteurR += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                    ajouteurG += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                    ajouteurB += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].B;
                                }
                            }

                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }

                            MatricePixel[i, j].R = ajouteurR;
                            MatricePixel[i, j].G = ajouteurG;
                            MatricePixel[i, j].B = ajouteurB;
                        }
                    }


                    break;

                case "2":// Filtre: Renforcement des bords
                    Console.Clear();

                    int[,] MatriceConvRenfort = new int[copy, copy];
                    if (copy != 3)
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);
                                MatriceConvRenfort[i, j] = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(3000);
                        MatriceConvRenfort = new int[,]
                        {
                                   { 0, 0, 0},
                                   {-1, 1, 0},
                                   { 0, 0, 0}
                        };
                    }

                    for (int i = a; i < image.TailleX - a; i++)
                    {
                        for (int j = a; j < image.TailleY - a; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                            for (int k = -a; k <= a; k++)
                            {
                                for (int l = -a; l <= a; l++)
                                {
                                    ajouteurR += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                    ajouteurG += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                    ajouteurB += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].B;
                                }
                            }

                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }

                            MatricePixel[i, j].R = ajouteurR;
                            MatricePixel[i, j].G = ajouteurG;
                            MatricePixel[i, j].B = ajouteurB;
                        }
                    }

                    break;

                case "3": /// Filtre: Flou
                    for (int i = a; i < image.TailleX - a; i++)
                    {
                        for (int j = a; j < image.TailleY - a; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                            for (int k = -a; k <= a; k++)
                            {
                                for (int l = -a; l <= a; l++)
                                {
                                    ajouteurR += image.MatricePixel[i + k, j + l].R;
                                    ajouteurG += image.MatricePixel[i + k, j + l].G;
                                    ajouteurB += image.MatricePixel[i + k, j + l].B;
                                }
                            }


                            MatricePixel[i, j].R = ajouteurR / (copy * copy);
                            MatricePixel[i, j].G = ajouteurG / (copy * copy);
                            MatricePixel[i, j].B = ajouteurB / (copy * copy);

                        }
                    }
                    break;

                case "4": /// Filtre: Repoussage
                    Console.Clear();

                    int[,] MatriceConvRepoussage = new int[copy, copy];
                    if (copy != 3)
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);
                                MatriceConvRepoussage[i, j] = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(3000);
                        MatriceConvRepoussage = new int[,]
                        {
                                   {-2,-1, 0},
                                   {-1, 1, 1},
                                   { 0, 1, 2}
                        };
                    }
                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                            for (int k = -a; k <= a; k++)
                            {
                                for (int l = -a; l <= a; l++)
                                {
                                    ajouteurR += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                    ajouteurG += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                    ajouteurB += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].B;
                                }
                            }


                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }
                            MatricePixel[i, j].R = ajouteurR;
                            MatricePixel[i, j].G = ajouteurG;
                            MatricePixel[i, j].B = ajouteurB;

                        }
                    }
                    break;
            }
            return MatricePixel;

        }



        public void Agrandissement(int CoefAggrandissement)
        {
            
            Pixel[,] matriceAgrandie = new Pixel[tailleX * CoefAggrandissement, tailleY * CoefAggrandissement];//on créée une matrice agarandie

            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++) //balade matrice classique
                {
                    for (int k = 0; k < CoefAggrandissement; k++) 
                    {
                        for (int l = 0; l < CoefAggrandissement; l++)
                        {
                            matriceAgrandie[i * CoefAggrandissement + l, j * CoefAggrandissement + k] = MatricePixel[i, j];
                        }
                    }
                }
            }

            tailleX = tailleX * CoefAggrandissement;
            tailleY = tailleY * CoefAggrandissement;
            MatricePixel = matriceAgrandie; //on change notre matrice ainsi que les tailles de l'image
        }

        public void FractaleMandelbrot(int tailleX, int tailleY, int nbIterations, byte bleu, byte vert, byte rouge, bool chaleur)
        {
            // on met les tailles données comme multiple de 4 au cas où
            while (tailleX % 4 != 0)
            {
                tailleX++;
            }
            while (tailleY % 4 != 0)
            {
                tailleY++;
            }
            //création de la matrice
            Pixel[,] matrice = new Pixel[tailleX, tailleY];


            // définition du centre de l'image
            int centreX = 2 * tailleX / 3; //on décale le x à 2/3 pour que ce soit plus joli
            int centreY = tailleY / 2;

            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    //on définit les coordonnées de z
                    // z est un nombre complexe de la forme reelZ + i*imZ et z0 est le point de départ
                    // z0 est une constante

                    double reelZ = 1.5 * (x - centreX) / (0.5 * tailleX);
                    double imZ = (y - centreY) / (0.5 * tailleY);
                    double reelZ0 = reelZ;
                    double imZ0 = imZ;
                    int i = 0;
                    while (i < nbIterations && reelZ * reelZ + imZ * imZ < 4) // on teste si le module de z est inférieur à 2 et si on a pas dépassé le nombre d'itérations
                    {
                        // récurrence de Mandelbrot (zn+1 = zn^2 + z0)
                        double reelZTemp = reelZ; // on stocke reelZ dans une variable temporaire pour ne pas écraser la valeur de reelZ dans le calcul de imZ
                        reelZ = reelZTemp * reelZTemp - imZ * imZ + reelZ0;
                        imZ = 2 * reelZTemp * imZ + imZ0;

                        i++;
                    }
                    // on passe au coloriage de la matrice

                    // si on a dépassé le nombre d'itérations (c'est à dire si le module a toujours été inférieur à 4), on noircit le pixel
                    if (i == nbIterations)
                    {
                        matrice[x, y] = new Pixel(0, 0, 0);
                    }
                    // sinon on colorie le pixel 
                    else
                    {
                        if (chaleur == false) // si on ne veut pas de dégradé de couleur
                        {
                            matrice[x, y] = new Pixel(bleu, vert, rouge);
                        }
                        else // si on veut un dégradé de couleur en fonction du nombre d'itérations
                        {
                            // on définit la couleur rouge en fonction du nombre d'itérations pour donner un sens de chaleur quand on s'approche du noir
                            byte degrade = Convert.ToByte(i * 255 / nbIterations);
                            matrice[x, y] = new Pixel(bleu, vert, degrade);
                        }

                    }
                }
            }

            MatricePixel = matrice;
        }

        public Pixel[,] Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);
            Header = new byte[54];

            for (int i = 0; i < 54; i++)
            {
                Header[i] = fichier[i];
            }


            Console.WriteLine();
            byte[] LaTailleX = { fichier[18], fichier[19], fichier[20], fichier[21] };
            tailleX = Byte2Int(LaTailleX);
            byte[] LaTailleY = { fichier[22], fichier[23], fichier[24], fichier[25] };
            tailleY = Byte2Int(LaTailleY);
            //Console.WriteLine("Largeur de l'image : " + tailleX);
            //Console.WriteLine("Hauteur de l'image : " + tailleY);
            MatricePixel = new Pixel[tailleX, tailleY];
            int TailleMatriceX = 0;
            int TailleMatriceY = 0;
            int a = 54;
            for (int y=0; y < tailleY; y++)
            {
                for (int x=0; x < tailleX; x++)
                {
                    MatricePixel[x, y] = new Pixel(fichier[a], fichier[a+1], fichier[a+2]);
                    a = a + 3;
                }
            }
            return MatricePixel;
        }

        public void CorrigerImageApresModif(Image ImageACorriger)
        {

            // taille fichier
            // offset
            // largeur et longueur déja update 
            // nombre bits
            // taille image

            ImageACorriger.tailleX = ImageACorriger.MatricePixel.GetLength(0);

            ImageACorriger.tailleY = ImageACorriger.MatricePixel.GetLength(1);

            ImageACorriger.tailleFichier = tailleX * tailleY * 3 + 54;

            ImageACorriger.tailleImage = ImageACorriger.tailleFichier - 54;


            // FAIRE OFFSET

        }

        public byte[] BuildLeBonHeader(Image ImageAvecLeHeader)
        {
            byte[] newHeader = new byte[54]; // creation d'un tab de byte vide
            newHeader[0] = 66; newHeader[1] = 77; // les deux lettres BM pour bitmap


            byte[] tailleFichierBytes = Int2ToByte(ImageAvecLeHeader.tailleFichier); // t fichier
            Array.Copy(tailleFichierBytes, 0, newHeader, 2, 4);

            for (int i = 6; i < 10; i++)
            {
                newHeader[i] = 0;
            }

            newHeader[10] = 54;
            for (int i = 11; i < 14; i++)
            {
                newHeader[i] = 0;
            }

            newHeader[14] = 40; newHeader[15] = 0; newHeader[16] = 0; newHeader[17] = 0;

            // FLOU AVEC LE 40

            byte[] tailleXBytes = Int2ToByte(ImageAvecLeHeader.tailleX);
            Array.Copy(tailleXBytes, 0, newHeader, 18, 4); // on copie la taillex
            byte[] tailleYBytes = Int2ToByte(ImageAvecLeHeader.tailleY);
            Array.Copy(tailleYBytes, 0, newHeader, 22, 4); // on copie la tailley

            newHeader[26] = 1; newHeader[27] = 0; //nombre plan constant à 1

            newHeader[28] = 24; newHeader[29] = 0; // constant car 24 bits/pixels

            for (int i = 30; i < 34; i++)
            {
                newHeader[i] = 0; // compression =0
            }

            byte[] tailleImageBytes = Int2ToByte(ImageAvecLeHeader.tailleImage);
            Array.Copy(tailleImageBytes, 0, newHeader, 34, 4); // taille image

            newHeader[38] = 0; newHeader[39] = 0; newHeader[40] = 0; newHeader[41] = 0;
            newHeader[42] = 0; newHeader[43] = 0; newHeader[44] = 0; newHeader[45] = 0;

            return newHeader;
        }

        public void SauvegardeImage(string wantedFileName, Image Imagesauvegardee)
        {
            // Construction du header du fichier BMP
            byte[] header = BuildLeBonHeader(Imagesauvegardee);

            // Création du tableau de bytes pour le fichier BMP en incluant le header
            byte[] fichier = new byte[header.Length + (Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3)];

            // Copie du header dans le tableau fichier
            Array.Copy(header, fichier, header.Length);



            int a = header.Length; // Position de début des données de pixel dans le fichier BMP

            // Copie des données de pixel dans le fichier BMP
            for (int j = 0; j < Imagesauvegardee.tailleY; j++)
            {
                for (int i = 0; i < Imagesauvegardee.tailleX; i++)
                {
                    // Copie des composantes de couleur dans le bon ordre (BGR)
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].B);
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].G);
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].R);
                }
            }

            // Écriture du fichier BMP
            File.WriteAllBytes(wantedFileName + ".bmp", fichier);
        }

    }
}