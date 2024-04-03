using System;
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
        public byte[] Header = new byte[54];



        public Pixel[,] Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);



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

        public void SauvegardeImage(string wantedFileName, string file, Image Imagesauvegardee)
        {
            byte[] fichier = File.ReadAllBytes(file); //coucouououu

            /*
            //pour le moment on écrase le fichier avec des nouvelles données mais l'idée c'est de créer son propre truc à terme
            for (int i = 0; i < 54; i++)
            {
                fichier[i] = Convert.ToByte(Imagesauvegarder.Header[i]);
            }
            */

            
            int a = 54; // Position de début des données de pixel dans le fichier BMP

            Pixel[,] NvMatricePixel = Imagesauvegardee.MatricePixel;

            // Copie des données de pixel dans le fichier BMP
            for (int i = 0; i < Imagesauvegardee.tailleX; i++)
            {
                for (int j = 0; j < Imagesauvegardee.tailleY; j++)
                {
                    fichier[a++] = Convert.ToByte(NvMatricePixel[i, j].B); // Rouge
                    fichier[a++] = Convert.ToByte(NvMatricePixel[i, j].G); // Vert
                    fichier[a++] = Convert.ToByte(NvMatricePixel[i, j].R); // Bleu
                }
            }

            File.WriteAllBytes(wantedFileName+".bmp", fichier);
        }

    }
}
