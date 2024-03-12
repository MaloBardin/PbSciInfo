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
            int u = 0;
            int total = 0;
            for (int i = 14; i < 54; i++)
            {
                Console.Write(fichier[i] + " ");
                
                if (i >= 19 && i <= 23){
                    total += fichier[i] ^ u;
                    u++;
                }
            }

            total = tailleX;
            Console.WriteLine("\n \nIMAGE");
            for (int i = 54; i < fichier.Length; i=i+60)
            {
                for (int k = i; k < i + 60; k++)
                {
                    Console.Write(fichier[i] + " ");
                }
                Console.WriteLine();
            }



            int TailleMatriceL = 0;
            int TailleMatriceLarg = 0;
            for (int i = 54; i < fichier.Length; i=i+3)
            {
                if (TailleMatriceL> tailleX)
                {
                    TailleMatriceLarg++;
                    TailleMatriceL = 0;
                }
                MatricePixel[TailleMatriceL, TailleMatriceLarg].R = fichier[i];
                MatricePixel[TailleMatriceL, TailleMatriceLarg].G = fichier[i];
                MatricePixel[TailleMatriceL, TailleMatriceLarg].B = fichier[i];



            }


        }
       
           
    }
}
