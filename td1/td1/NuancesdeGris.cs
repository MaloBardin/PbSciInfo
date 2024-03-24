using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class NuancesGris
    {
        Pixel couleur;
        Image dessin;
        public NuancesGris()
        {
           
        }
        public Pixel PixelEnGris(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B) / 3;
            gris.R = valeur;
            gris.G = valeur;
            gris.B = valeur;
            return gris;
        } 
        
        public Image ImageEnGris(Image dessin)
             
        {
            Pixel[,] imageGris = new Pixel[dessin.MatricePixel.GetLength(0), dessin.MatricePixel.GetLength(1)];

            for (int i=0; i<dessin.MatricePixel.GetLength(0); i++)
            {
                for (int j=0; j<dessin.MatricePixel.GetLength(1); j++)
                {
                    imageGris[i, j] = PixelEnGris(dessin.MatricePixel[i, j]);
                }
            }

            dessin.MatricePixel = imageGris;

            return dessin;
        }
    }
}
