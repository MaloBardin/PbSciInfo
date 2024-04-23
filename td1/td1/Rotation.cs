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
            // Calcul des dimensions de l'image de sortie
            // nouvelle taille x = taille x * |cos(rad)| + taille y * |sin(rad)|
            // nouvelle taille y = taille x * |sin(rad)| + taille y * |cos(rad)|

            double rad = degre * Math.PI / 180.0;
            int nvtailleX = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Cos(rad)) + Dessin.tailleY * Math.Abs(Math.Sin(rad)));
            int nvtailleY = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Sin(rad)) + Dessin.tailleY * Math.Abs(Math.Cos(rad)));

            // Ajuster les dimensions pour qu'elles soient des multiples de 4 (sinon BMP pas lisible)
            while (nvtailleX % 4 != 0)
            {
                nvtailleX++;
            }
            while (nvtailleY % 4 != 0)
            {
                nvtailleY++;
            }

            // Création de l'image de sortie
            Pixel[,] imageTournee = new Pixel[nvtailleX, nvtailleY];

            // Calcul des coordonnées du centre de l'image d'entrée
            int centreX = Dessin.tailleX / 2;
            int centreY = Dessin.tailleY / 2;

            // Calcul des coordonnées du centre de l'image de sortie
            int nvcentreX = nvtailleX / 2;
            int nvcentreY = nvtailleY / 2;


            // Parcourir tous les pixels de l'image d'entrée et les placer dans l'image de sortie
            for (int x = 0; x < Dessin.tailleX; x++)
            {
                for (int y = 0; y < Dessin.tailleY; y++)
                {
                    // Calcul des coordonnées du pixel dans l'image de sortie
                    // nouveau x = (x - centreX) * cos(rad) - (y - centreY) * sin(rad) + nvcentreX
                    // nouveau y = (x - centreX) * sin(rad) + (y - centreY) * cos(rad) + nvcentreY
                    // on rajoute les nouveaux centres pour recentrer l'image autour du centre et pas en 0,0

                    int nvx = Convert.ToInt32(((x - centreX) * Math.Cos(rad) - (y - centreY) * Math.Sin(rad) + nvcentreX));
                    int nvy = Convert.ToInt32(((x - centreX) * Math.Sin(rad) + (y - centreY) * Math.Cos(rad) + nvcentreY));

                    // Copier le pixel de l'image d'entrée dans l'image de sortie
                    if (nvx >= 0 && nvx < nvtailleX && nvy >= 0 && nvy < nvtailleY)
                    {
                        imageTournee[nvx, nvy] = Dessin.MatricePixel[x, y];
                    }
                }
            }

            // pour éviter des pixels noirs un peu partout (car la trigo implique qu'il y aura des pixels non remplis)

            // vérifie si les pixels adjacents à un pixel nul sont plus de 6 à etre non nuls,
            // si oui on fait la moyenne des pixels non nuls du pixel en question

            for (int x = 0; x < nvtailleX; x++)
            {
                for (int y = 0; y < nvtailleY; y++)
                {
                    if (imageTournee[x, y] == null)
                    {
                        // on initialise les sommes
                        int nbPixelNonNuls = 0;
                        int sommeB = 0;
                        int sommeG = 0;
                        int sommeR = 0;
                        // On parcourt les pixels autour du pixel en question
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                // On vérifie que le pixel est dans l'image
                                if (x + i >= 0 && x + i < nvtailleX && y + j >= 0 && y + j < nvtailleY)
                                {
                                    // On vérifie que le pixel n'est pas nul
                                    if (imageTournee[x + i, y + j] != null)
                                    {
                                        // On incrémente le nombre de pixels non nuls
                                        nbPixelNonNuls++;
                                        // On fait la somme des couleurs B,G,R des pixels non nuls
                                        // (qu'on va ensuite diviser par le nb de pixels non nuls pour obtenir une moyenne)
                                        sommeB += imageTournee[x + i, y + j].B;
                                        sommeG += imageTournee[x + i, y + j].G;
                                        sommeR += imageTournee[x + i, y + j].R;

                                    }
                                }
                            }
                        }
                        // Si plus de 6 pixels non nuls, on fait la moyenne des pixels non nuls (division par le nb de pixels non nuls)
                        if (nbPixelNonNuls >= 6)
                        {
                            imageTournee[x, y] = new Pixel(Convert.ToByte(sommeB / nbPixelNonNuls), Convert.ToByte(sommeG / nbPixelNonNuls), Convert.ToByte(sommeR / nbPixelNonNuls));
                        }
                        // Sinon on met un pixel noir (pour les pixels tout autour)
                        else
                        {
                            imageTournee[x, y] = new Pixel(0, 0, 0); 
                        }
                    }
                }
            }   

            return imageTournee;
        }
        


    }
}
