using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Rotation
    {
        Image dessin;
        Pixel[,] MatricePixel;
        public Rotation()
        {
            
        }
        public Pixel[,] RotationDegre(Image Dessin, int degre)
        {
            int TailleX = Dessin.tailleX;
            int TailleY = Dessin.tailleY;
            Pixel[,] rotatedImage = new Pixel[TailleX, TailleY];

            double angle = degre * Math.PI / 180.0;
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);

            int centreX = TailleX / 2;
            int centreY = TailleY / 2;

            for (int x = 0; x < TailleX; x++)
            {
                for (int y = 0; y < TailleY; y++)
                {
                    int nouveauX = (int)((x - centreX) * cosTheta - (y - centreY) * sinTheta + centreX);
                    int nouveauY = (int)((x - centreX) * sinTheta + (y - centreY) * cosTheta + centreY);

                    if (nouveauX >= 0 && nouveauX < TailleX && nouveauY >= 0 && nouveauY < TailleY)
                    {
                        rotatedImage[nouveauX, nouveauY] = Dessin.MatricePixel[x, y];
                    }
                }
            }

            return rotatedImage;
        }

        
    }
}
