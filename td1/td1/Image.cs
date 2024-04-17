﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace td1
{
    internal class Image
    {

        public int tailleX;
        public int tailleY;
        public Pixel[,] MatricePixel;
        public byte[] Header;


        public Pixel[,] Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);
            Header = new byte[54];


            /*
            Console.WriteLine("HEADER");
            for (int i = 0; i < 14; i++)
            {
                Console.Write(fichier[i] + " ");
            }
            Console.WriteLine("\n \nHEADER INFO");

            for (int i = 14; i < 54; i++)
            {
                Console.Write(fichier[i] + " ");

            }


            Console.WriteLine("\n \nIMAGE");
            for (int i = 54; i < fichier.Length; i = i + 50)
            {
                for (int j = i; j < i + 50 && j < fichier.Length; j++)
                {
                    Console.Write(fichier[j] + " ");
                }
                Console.WriteLine();
            }*/



            for (int i = 0; i < 54; i++)
            {
                Header[i] = fichier[i];
            }




            Console.WriteLine();
            tailleX = BitConverter.ToInt32(fichier, 18);
            tailleY = BitConverter.ToInt32(fichier, 22);
            Console.WriteLine("Largeur de l'image : " + tailleX);
            Console.WriteLine("Hauteur de l'image : " + tailleY);
            MatricePixel = new Pixel[tailleX, tailleY];
            int TailleMatriceX = 0;
            int TailleMatriceY = 0;
            for (int i = 54; i < fichier.Length; i = i + 3)
            {
                if (TailleMatriceY >= tailleY)
                {
                    TailleMatriceX++; //on augmente de 1 la hauteur
                    TailleMatriceY = 0; //on remet x a 0

                    if (TailleMatriceX >= tailleX)
                    {

                        break; // on detecte la fin de l'image (on est en dehors des limites de l'image)
                    }
                }

                MatricePixel[TailleMatriceX, TailleMatriceY] = new Pixel(fichier[i], fichier[i + 1], fichier[i + 2]);
                TailleMatriceY++; // on incremente pour aller a droite automatiquement

            }



            return MatricePixel;
        }

        public byte[] Int2ToByte(int nombre)
        {
            byte[] byteTab = new byte[4];
            byteTab[0] = (byte)(nombre % 256);
            nombre = nombre/256;
            byteTab[1] = (byte)(nombre % 256);
            nombre = nombre/256;
            byteTab[2] = (byte)(nombre % 256);
            nombre = nombre/ 256;
            byteTab[3] = (byte)(nombre % 256);

            return byteTab;
        }
    
        public void PrintImage(string filename) { 
        
            Console.WriteLine("\n\n\n fichier image Matrice");
            for (int i = 0; i < tailleY; i++)
            {
                for (int j = 0; j < tailleX; j++)
                {

                    Console.Write(MatricePixel[j, i].R + " ");
                    Console.Write(MatricePixel[j, i].G + " ");
                    Console.Write(MatricePixel[j, i].B + " ");
                }
                Console.WriteLine();
            }




        }

        public byte[] BuildLeBonHeader(Image ImageAvecLeHeader)
        {
            byte[] cacao = new byte[54];



            for (int i = 0; i < 54; i++)
            {
                cacao[i] = ImageAvecLeHeader.Header[i];
            }

            ImageAvecLeHeader.tailleX=ImageAvecLeHeader.MatricePixel.GetLength(0);
            ImageAvecLeHeader.tailleY=ImageAvecLeHeader.MatricePixel.GetLength(1); // on remet la bonne taille au cas ou

            Array.Copy(Int2ToByte(ImageAvecLeHeader.MatricePixel.GetLength(0)), 0, cacao, 18, 4);
            Array.Copy(Int2ToByte(ImageAvecLeHeader.MatricePixel.GetLength(1)), 0, cacao, 22, 4);
            
            
            return cacao;
        }

        public void SauvegardeImage(string wantedFileName, string file, Image Imagesauvegardee)
        {
            // Construction du header du fichier BMP
            byte[] header = BuildLeBonHeader(Imagesauvegardee);

            // Création du tableau de bytes pour le fichier BMP en incluant le header
            byte[] fichier = new byte[header.Length + (Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3)];

            // Copie du header dans le tableau fichier
            Array.Copy(header, fichier, header.Length);
            Array.Copy(Int2ToByte(Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3), 0, fichier, 2, Int2ToByte(Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3).Length);
            Console.WriteLine("taille : " + Int2ToByte(Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3));
            Console.WriteLine("LongeurX : " + Int2ToByte(Imagesauvegardee.MatricePixel.GetLength(0)));
            Console.WriteLine("LongeurY : " + Int2ToByte(Imagesauvegardee.MatricePixel.GetLength(1)));
            Console.ReadLine();


            int a = header.Length; // Position de début des données de pixel dans le fichier BMP

            // Copie des données de pixel dans le fichier BMP
            for (int i = 0; i < Imagesauvegardee.tailleX; i++)
            {
                for (int j = 0; j < Imagesauvegardee.tailleY; j++)
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