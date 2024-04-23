using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Fractale
    {
        public Fractale()
        {

        }
        public Pixel[,] FractaleMandelbrot(int tailleX, int tailleY, int nbIterations, byte bleu, byte vert, byte rouge) 
        {
            // on met les tailles données comme multiple de 4 au cas où
            while(tailleX % 4 != 0)
            {
                tailleX++;
            }
            while (tailleY % 4 != 0)
            {
                tailleY++;
            }
            //création de la matrice
            Pixel[,] matrice = new Pixel[tailleX, tailleY];
            //remplissage de la matrice en noir
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    matrice[x, y] = new Pixel(0, 0, 0);
                }
            }
            

            // crée une fractale avec des pixels b,g,r comme donnés, un nombre d'itératiions défini. je veux que l'intérieur de la fractale soit colorié et que le fond soit noir
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    double a = 1.5 * (x - centreX) / (0.5 * tailleX);
                    double b = (y - centreY) / (0.5 * tailleY);
                    double a0 = a;
                    double b0 = b;
                    int i = 0;
                    while (i < nbIterations && a * a + b * b < 4)
                    {
                        double aTemp = a * a - b * b + a0;
                        b = 2 * a * b + b0;
                        a = aTemp;
                        i++;
                    }
                    if (i == nbIterations)
                    {
                        matrice[x, y] = new Pixel(0, 0, 0);
                    }
                    else
                    {
                        matrice[x, y] = new Pixel(bleu, vert, rouge);
                    }
                }
            }

            return matrice;
        }
    }
}
