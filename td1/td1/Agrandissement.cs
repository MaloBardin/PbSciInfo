using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Agrandissement
    {
        public void MultiplicationMatrice(Image ImageEnCours, int CoefAggrandissement)
        {
            // Obtention des dimensions de l'image d'origine
            int tailleX = ImageEnCours.MatricePixel.GetLength(0);
            int tailleY = ImageEnCours.MatricePixel.GetLength(1);

            // Création de la matrice agrandie
            Pixel[,] matriceAgrandie = new Pixel[tailleX * CoefAggrandissement, tailleY * CoefAggrandissement];

            // Parcours de chaque pixel de l'image d'origine
            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++)
                {
                    for (int k = 0; k < CoefAggrandissement; k++)
                    {
                        for (int l = 0; l < CoefAggrandissement; l++)
                        {
                            matriceAgrandie[i * CoefAggrandissement + l, j * CoefAggrandissement + k] = ImageEnCours.MatricePixel[i, j];
                        }
                    }
                }
            }


            // Assignation de la matrice agrandie à l'image en cours
            ImageEnCours.tailleX = tailleX * CoefAggrandissement;
            ImageEnCours.tailleY = tailleY * CoefAggrandissement;
            ImageEnCours.MatricePixel = matriceAgrandie;
        }
    }
}



