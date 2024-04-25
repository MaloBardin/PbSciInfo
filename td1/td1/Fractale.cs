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
            //remplissage de la matrice en noir
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    matrice[x, y] = new Pixel(0, 0, 0);
                }
            }

            // définition du centre de l'image
            int centreX = 2 * tailleX / 3; //on décale le x à 2/3 pour que ce soit plus joli
            int centreY = tailleY / 2;




            
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    double reelZ = 1.5 * (x - centreX) / (0.5 * tailleX);
                    double imZ = (y - centreY) / (0.5 * tailleY);
                    double reelZ0 = reelZ;
                    double imZ0 = imZ;
                    int i = 0;
                    while (i < nbIterations && reelZ * reelZ + imZ * imZ < 4)
                    {
                        double reelZTemp = reelZ * reelZ - imZ * imZ + reelZ0;
                        imZ = 2 * reelZ * imZ + imZ0;
                        reelZ = reelZTemp;
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

