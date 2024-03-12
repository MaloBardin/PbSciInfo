using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class NuancesGris
    {
        Pixel couleur;

        public NuancesGris(Pixel couleur)
        {
            this.couleur = couleur;
        }
        public Pixel PixelEnGris(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B)/3;
            gris.R = valeur;
            gris.G = valeur;
            gris.B = valeur;
            return gris;
        }

    }
}
