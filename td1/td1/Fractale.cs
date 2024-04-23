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
        public Fractale(int tailleX, int tailleY) 
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

        }
    }
}
