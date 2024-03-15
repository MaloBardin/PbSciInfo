using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Image
    {

        int tailleX;
        int tailleY;
        Pixel[,] MatricePixel;
        int[] Header;
        int[] HeaderInfo;


        public void Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);




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
            for (int i = 54; i < fichier.Length; i=i+50)
            {
                for (int j = i; j < i + 50 && j < fichier.Length; j++)
                {
                    Console.Write(fichier[j] + " ");
                }
                Console.WriteLine();
            }



            Console.WriteLine();
            tailleX = BitConverter.ToInt32(fichier, 18);
            tailleY = BitConverter.ToInt32(fichier, 22);

            MatricePixel = new Pixel[tailleX, tailleY];
            int TailleMatriceX = 0;
            int TailleMatriceY = 0;
            for (int i = 54; i < fichier.Length; i=i+3)
            {
                if (TailleMatriceX>= tailleX)
                {
                    TailleMatriceY++; //on augmente de 1 la hauteur
                    TailleMatriceX = 0; //on remet x a 0

                    if (TailleMatriceY >= tailleY)
                    {
                        
                        break; // on detecte la fin de l'image (on est en dehors des limites de l'image)
                    }
                }
                
                MatricePixel[TailleMatriceX, TailleMatriceY] = new Pixel(fichier[i], fichier[i + 1], fichier[i+2]);
                TailleMatriceX++; // on incremente pour aller a droite automatiquement

            }



        }

        public void PrintImage(string filename)
        {
            Console.WriteLine("\n\n\n fichier image Matrice");
            for (int i=0; i<tailleY; i++)
            {
                for (int j=0; j<tailleX; j++)
                {

                    Console.Write(MatricePixel[j, i].R + " ");
                    Console.Write(MatricePixel[j, i].G + " ");
                    Console.Write(MatricePixel[j, i].B + " ");
                }
                Console.WriteLine();
            }




        }



    }
}
