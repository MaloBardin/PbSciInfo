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
        public Pixel[,] FractaleMandelbrot(int tailleX, int tailleY, int nbIterations) 
        {
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
            // définition du centre de l'image
            int centreX = tailleX / 2;
            int centreY = tailleY / 2;

            // crée une fractale de mandelbrot avec des pixels violets (B = 213, G = 72, R  199) et avec un nombre d'itérations défini
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
                        matrice[x, y] = new Pixel(213, 72, 199);
                    }
                }
            }



            return matrice;
        }
    }
}
