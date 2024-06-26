﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace td1
{
    public class Image
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


        /// <summary>
        /// remplissage de notre structure via un fichier bmp
        /// </summary>
        /// <param name="filename">nom du fichier</param>
        /// <returns></returns>
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
            for (int y = 0; y < tailleY; y++)
            {
                for (int x = 0; x < tailleX; x++)
                {
                    MatricePixel[x, y] = new Pixel(fichier[a], fichier[a + 1], fichier[a + 2]);
                    a = a + 3;
                }
            }
            return MatricePixel;
        }


        /// <summary>
        /// Fonctions pour pixel en noir et gris
        /// </summary>
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
                gris.R = 0; gris.B = 0; gris.G = 0;
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


        /// <summary>
        /// Constructeurs
        /// </summary>

        public Image()
        {
            // création vide
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



        /// <summary>
        /// Convertion des nombre en int et byte
        /// </summary>

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

        /// <summary>
        /// Fonction de rotation qui modifie la matrice pixel afin d'avoir une image tournée
        /// </summary>
        /// <param name="degre">le nombre de degré pour la rotation (en sens anti horaire)</param>
        public void RotationDegre(int degre)
        {

            double rad = degre * Math.PI / 180.0; //convertion en radiant

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



        /// <summary>
        /// Cache une image dans une autre
        /// </summary>
        /// <param name="ImageACacher">l'image a cacher</param>
        public void CacherLimage(Image ImageACacher)
        {
            for (int i = 0; i < ImageACacher.TailleX; i++)
            {
                for (int j = 0; j < ImageACacher.TailleY; j++)
                {
                    //bit point fort du background (donc devant)  bit point fort de l'image à cacher ( derriere)
                    MatricePixel[i, j].R = 16 * (int)(MatricePixel[i, j].R / 16) + (int)(ImageACacher.MatricePixel[i, j].R / 16);
                    MatricePixel[i, j].G = 16 * (int)(MatricePixel[i, j].G / 16) + (int)(ImageACacher.MatricePixel[i, j].G / 16);
                    MatricePixel[i, j].B = 16 * (int)(MatricePixel[i, j].B / 16) + (int)(ImageACacher.MatricePixel[i, j].B / 16);

                    
                }
            }
        }

        /// <summary>
        /// Fait apparaitre une image cachée
        /// </summary>
        /// <param name="reponse">permet de savoir si on sauvegarde l'imgae cachée ou l'autre</param>
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


        /// <summary>
        /// Filtrage d'une image
        /// </summary>
        /// <param name="image">l'image qu'on souhaite modifier</param>
        /// <returns></returns>
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
            Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

            Console.SetCursorPosition(54, 21);
            Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée: "); Console.SetCursorPosition(120, 21);
            int coeff = Convert.ToInt32(Console.ReadLine());
            while (coeff % 2 == 0) // On cherche une matrice impair
            {

                Console.SetCursorPosition(54, 22); Console.WriteLine("Erreur, votre matrice n'est pas impair.");
                Console.SetCursorPosition(54, 23); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée: ");
                Console.SetCursorPosition(120, 23);
                coeff = Convert.ToInt32(Console.ReadLine());
            }
            int copy = coeff;
            int a = 0;
            while (coeff != 1) //On calcule la distance au centre du noyau
            {
                coeff -= 2;
                a++;
            }
            Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");


            Console.SetCursorPosition(95, 18); Console.WriteLine("Vos choix sont : ");
            Console.SetCursorPosition(90, 21); Console.WriteLine("1.Détection de contour");
            Console.SetCursorPosition(90, 22); Console.WriteLine("2.Renforcement des bords");
            Console.SetCursorPosition(90, 23); Console.WriteLine("3.Flou");
            Console.SetCursorPosition(90, 24); Console.WriteLine("4.Repoussage");
            Console.SetCursorPosition(86, 25); Console.Write("Quel filtre souhaitez-vous?");
            Console.SetCursorPosition(125, 18); string answern = Console.ReadLine();
            while (answern != "1" && answern != "2" && answern != "3" && answern != "4")
            {
                Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
                Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
                Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
                Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
                Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
                Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                Console.SetCursorPosition(95, 18); Console.WriteLine("Vos choix sont : ");
                Console.SetCursorPosition(90, 21); Console.WriteLine("1.Détection de contour");
                Console.SetCursorPosition(90, 22); Console.WriteLine("2.Renforcement des bords");
                Console.SetCursorPosition(90, 23); Console.WriteLine("3.Flou");
                Console.SetCursorPosition(90, 24); Console.WriteLine("4.Repoussage");
                Console.SetCursorPosition(86, 25); Console.Write("Quel filtre souhaitez-vous?");
                Console.SetCursorPosition(125, 18); answern = Console.ReadLine();
            }
            Console.SetCursorPosition(75, 18); Console.Write("                                                                           ");
            Console.SetCursorPosition(52, 20); Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(52, 21); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 22); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 23); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 24); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 25); Console.Write("█                                                                                                     █");
            Console.SetCursorPosition(52, 26); Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            switch (answern)
            {
                case "1": /// Filtre: Détection de contour                                          
                    int[,] MatriceConvContour = new int[copy, copy];
                    if (copy != 3 && copy != 5) //Si la matrice n'est pas 3 ou 5, on demande à ce que l'utilisateur créer sa matrice
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.SetCursorPosition(55, 22);
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j + "                      ");
                                Console.SetCursorPosition(115, 22);
                                MatriceConvContour[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                    }
                    if (copy == 3)
                    {
                        Console.SetCursorPosition(80, 22); Console.WriteLine("Nous avons déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(1500);
                        MatriceConvContour = new int[,]
                        {
                                   {-1,-1,-1},
                                   {-1, 8,-1},
                                   {-1,-1,-1}
                        };
                    }
                    if (copy == 5)
                    {
                        Console.SetCursorPosition(80, 22); Console.WriteLine("Nous avons déjà une matrice filtre pour (5x5)");
                        Thread.Sleep(1500);
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

                            MatricePixel[i, j].R = ajouteurR; //On met les resultats de la convolution dans la matrice créé
                            MatricePixel[i, j].G = ajouteurG;
                            MatricePixel[i, j].B = ajouteurB;
                        }
                    }


                    break;

                case "2":// Filtre: Renforcement des bords

                    int[,] MatriceConvRenfort = new int[copy, copy];
                    if (copy != 3) //Si la matrice n'est pas 3 on demande à ce que l'utilisateur créer sa matrice
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.SetCursorPosition(55, 22);
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j + "                      ");
                                Console.SetCursorPosition(115, 22);
                                MatriceConvRenfort[i, j] = Convert.ToInt32(Console.ReadLine());

                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(80, 22); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(1500);
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

                            MatricePixel[i, j].R = ajouteurR; //On met les resultats de la convolution dans la matrice créé
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
                                    ajouteurR += image.MatricePixel[i + k, j + l].R; //On somme tous les pixels situés dans le noyau
                                    ajouteurG += image.MatricePixel[i + k, j + l].G;
                                    ajouteurB += image.MatricePixel[i + k, j + l].B;
                                }
                            }


                            MatricePixel[i, j].R = ajouteurR / (copy * copy); //On moyenne la somme par le nombre de pixels sommés
                            MatricePixel[i, j].G = ajouteurG / (copy * copy);
                            MatricePixel[i, j].B = ajouteurB / (copy * copy);

                        }
                    }
                    break;

                case "4": /// Filtre: Repoussage

                    int[,] MatriceConvRepoussage = new int[copy, copy];
                    if (copy != 3) //Si la matrice n'est pas 3 on demande à ce que l'utilisateur créer sa matrice
                    {
                        for (int i = 0; i < copy; i++)
                        {
                            for (int j = 0; j < copy; j++)
                            {
                                Console.SetCursorPosition(55, 22);
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j + "                         ");
                                Console.SetCursorPosition(115, 22);
                                MatriceConvRepoussage[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(80, 22); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                        Thread.Sleep(1500);
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


        /// <summary>
        /// Permet d'agrandir une image avec un coefficient entier
        /// </summary>
        /// <param name="CoefAggrandissement">coefficient d'agrandissement</param>
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



        /// <summary>
        /// Affiche l'image dans la console avec des couleurs
        /// </summary>
        public void AffichageIntoConsole()
        {
            int newTX = tailleX;
            int newTY = tailleY;
            int diviX = 1;
            int diviY = 1;
            Console.Clear();
            // Calculer le diviseur pour ajuster la taille de l'image
            while (newTX > 210)
            {
                diviX++;
                newTX = tailleX / diviX;
            }

            while (newTY > 52)
            {
                diviY++;
                newTY = tailleY / diviY;
            }

            // Parcourir les pixels et les afficher avec la couleur appropriée
            for (int i = 0; i < tailleX; i += diviX)
            {
                for (int k = 0; k < tailleY; k += diviY) // boucle pour prendre un pixel tout les x afin de ne pas etre en dehors de la consolooe
                {
                    Console.SetCursorPosition(i / diviX, (tailleY - k - 1) / diviY); // Définir la position du curseur, le principe est assez simple la position en colonne on inverse car notre matrice commence par le bas et on écrit par le haut normalement sur la console (0,0) est sur le coin supérieur gauche
                    Console.WriteLine("\x1b[38;2;" + MatricePixel[i, k].R + ";" + MatricePixel[i, k].G + ";" + MatricePixel[i, k].B + "m█\x1b[0m"); // code pour la couleur en ANSI -> voir lien https://talyian.github.io/ansicolors/      \x1b[48;2;r;g;bm - background
                } /// le 38,2 indique une couleur avant et ensuite chaque matrice pixel c'est pour le rgb
            }

            Console.SetCursorPosition(104, 54);
            Console.WriteLine("Merci d'appuyer sur une touche pour continuer");
            Console.ReadKey();//tempo le temps d'avoir l'image

            Console.Clear();
        }


        /// <summary>
        /// Permet de cacher charlie dans une imagezz (fonctionne de préférence avec les deux fonds)
        /// </summary>
        /// <param name="Charlie">mon image avec cahrlie dedans</param>
        public void OuEstCharlie(Image Charlie)
        {
            Random r = new Random();

            int randomX = r.Next(0, tailleX - Charlie.TailleX);
            int randomY = r.Next(0, tailleY - Charlie.TailleY); // trouve un point bas gauche pour poser  charlie


            for (int i = 0; i < Charlie.TailleX; i++)
            {
                for (int j=0;j<Charlie.TailleY;j++)
                {
                        if (Charlie.MatricePixel[i,j].R==247 && Charlie.MatricePixel[i , j].G==247 && Charlie.MatricePixel[i, j].B == 247) //détourage
                        {
                            MatricePixel[i, j] = MatricePixel[i, j]; // on détoure le blanc autour de charlie
                        } else
                        {
                            MatricePixel[randomX+i, randomY+j] = Charlie.MatricePixel[i, j];                       
                        }
                }
            }

        }


        /// <summary>
        /// Crééé une fractale 
        /// </summary>
        /// <param name="tailleX">taille de l'image longueur</param>
        /// <param name="tailleY">taille de l'image hauteur</param>
        /// <param name="nbIterations">précision</param>
        /// <param name="bleu">valeur de la couleur bleu</param>
        /// <param name="vert">valeur du vert</param>
        /// <param name="rouge">valeur du rouge</param>
        /// <param name="chaleur">permet de savoir si l'utilisateur souhaite un gradiant de couleur semblable à une aura</param>
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

    

        public void ChangementCouleur()
        {
            for (int i = 0; i < TailleX; i++)
            {
                for (int j = 0; j < TailleY; j++)
                {
                    int tempo = MatricePixel[i, j].R;
                    MatricePixel[i, j].R = MatricePixel[i, j].B;
                    MatricePixel[i, j].B = MatricePixel[i, j].G;
                    MatricePixel[i, j].G = tempo;
                }
            }
        }

 
        /// <summary>
        /// Permet de modifier les attributs d'une image après une modification
        /// </summary>
        /// <param name="ImageACorriger">notre image</param>
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
        /// <summary>
        /// Build le header pour la sauvegarde
        /// </summary>
        /// <param name="ImageAvecLeHeader"></param>
        /// <returns></returns>
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

            newHeader[14] = 40;

            for (int i = 15; i<= 17; i++) {
                newHeader[i] = 0;
            }
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

            for (int i = 38; i<= 45; i++)
            {
                newHeader[i] = 0;
            }
       
            return newHeader;
        }
        /// <summary>
        /// Sauvegarde de l'image
        /// </summary>
        /// <param name="wantedFileName">nom du fichier voulu</param>
        /// <param name="Imagesauvegardee"> notre image</param>
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