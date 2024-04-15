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
            //modif de l'header pour mettre la bonne taille
            int tailleX = ImageEnCours.MatricePixel.GetLength(0);
            int tailleY = ImageEnCours.MatricePixel.GetLength(1);


            Pixel[,] matriceAgrandie = new Pixel[tailleX*CoefAggrandissement,tailleY*CoefAggrandissement];

            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++)
                {
                    for (int k = 0; k < CoefAggrandissement; k++)
                    {
                        for (int l = 0; l < CoefAggrandissement; l++) // PROBLEME ICI ALEDDD
                        {
                            matriceAgrandie[i * CoefAggrandissement + k, j * CoefAggrandissement + l] = ImageEnCours.MatricePixel[i, j];
                        }
                    }
                }
            }
            ImageEnCours.MatricePixel = matriceAgrandie;
          
        }


    }
}
