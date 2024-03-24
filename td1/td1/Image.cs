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
        int[] Header;
        int[] HeaderInfo;


        public Pixel[,] Lecture(string filename)
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
            for (int i = 54; i < fichier.Length; i = i + 50)
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
            for (int i = 54; i < fichier.Length; i = i + 3)
            {
                if (TailleMatriceX >= tailleX)
                {
                    TailleMatriceY++; //on augmente de 1 la hauteur
                    TailleMatriceX = 0; //on remet x a 0

                    if (TailleMatriceY >= tailleY)
                    {

                        break; // on detecte la fin de l'image (on est en dehors des limites de l'image)
                    }
                }

                MatricePixel[TailleMatriceX, TailleMatriceY] = new Pixel(fichier[i], fichier[i + 1], fichier[i + 2]);
                TailleMatriceX++; // on incremente pour aller a droite automatiquement

            }



            return MatricePixel;
        }

        public void PrintImage(string filename)
        {
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

        public void SauvegardeImage(string file, Image Imagesauvegarder)
        {
            byte[] fichier = File.ReadAllBytes(file);
            byte[] Nvfichier = new byte[54 + 3 * Imagesauvegarder.tailleX * Imagesauvegarder.tailleY];
            int a = 54;
            for (int i = 0; i < 54; i++)
            {
                Nvfichier[i]= fichier[i];
            }

            string filename = "./Images";
            Pixel[,] NvMatricePixel = Imagesauvegarder.MatricePixel;
            for(int b = 0; b < 54; b++)
            {

            }
            
            for (int i = 54; i < Imagesauvegarder.tailleY; i++)                         
            {                         
                for (int j = 54; j < Imagesauvegarder.tailleX; j++)                         
                {               
                    Nvfichier[a++] = Convert.ToByte(NvMatricePixel[i, j].R);                   
                    Nvfichier[a++] = Convert.ToByte(NvMatricePixel[i, j].G);                   
                    Nvfichier[a++] = Convert.ToByte(NvMatricePixel[i, j].B);                    
                }
                
            }
            File.WriteAllBytes(filename, Nvfichier);
        }
        /*public Image CraftingNewImage(Pixel[,] MatriceNouveauxPixels, string filename, Image MonImageAEdit)
        {
            byte[] fichier = File.ReadAllBytes(filename);

            MonImageAEdit.MatricePixel = MatriceNouveauxPixels;
            //on modif uniquement les pixels et jamais le headers ou le infoheader

            SwapMatricePixel(MatriceNouveauxPixels, filename);

            File.WriteAllBytes("Cool.bmp", filename);
            Process.Start("./Images/Sortie.bmp");


            return MonImageAEdit;
        }

      */
    }
}
