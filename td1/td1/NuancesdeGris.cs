using System;
using System.Collections.Generic;
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
        public NuancesGris(Pixel couleur)
        {
            this.couleur = couleur;
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
        /*

        public Pixel[,] ImageEnGris(Image dessin)
        {
            Pixel[,] imageGris;
            for (int i=0; i<dessin.matricePixel.GetLength(0); i++)
            {
                for (int j=0; j<dessin.matricePixel.GetLength(1); j++)
                {
                    imageGris[i, j] = PixelEnGris(matricePixel[i, j]); 
                }
            }
            return imageGris;
        }*/
    }
}
