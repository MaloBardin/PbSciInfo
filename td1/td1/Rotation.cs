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
        /*
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
            for(int i = 0; i<rotatedImage.GetLength(0); i++)
            {
                for(int j = 0; j<rotatedImage.GetLength(1); j++)
                {
                    if (rotatedImage[i,j] == null)
                    {
                        rotatedImage[i, j] = new Pixel(255, 255, 255);
                    }
                }
            }   
            return rotatedImage;
        }*/
        /*
        public Pixel[,] RotationDegre(Image Dessin, int degre)
        {
            int TailleX = Dessin.tailleX;
            int TailleY = Dessin.tailleY;

            double angle = degre * Math.PI / 180.0;
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);

            Pixel[,] rotatedImage = new Pixel[TailleX, TailleY];

            // Calcul des coordonnées du centre de l'image
            double centreX = TailleX / 2.0;
            double centreY = TailleY / 2.0;

            // Parcourir tous les pixels de l'image résultante
            for (int x = 0; x < TailleX; x++)
            {
                for (int y = 0; y < TailleY; y++)
                {
                    // Déplacer le centre de l'image aux coordonnées du pixel actuel
                    double offsetX = x - centreX;
                    double offsetY = y - centreY;

                    // Appliquer la rotation
                    double nouveauX = offsetX * cosTheta - offsetY * sinTheta + centreX;
                    double nouveauY = offsetX * sinTheta + offsetY * cosTheta + centreY;

                    // Convertir les coordonnées en entiers
                    int intNouveauX = (int)Math.Round(nouveauX);
                    int intNouveauY = (int)Math.Round(nouveauY);

                    // Copier le pixel de l'image d'origine dans l'image résultante
                    if (intNouveauX >= 0 && intNouveauX < TailleX && intNouveauY >= 0 && intNouveauY < TailleY)
                    {
                        rotatedImage[intNouveauX, intNouveauY] = Dessin.MatricePixel[x, y];
                    }
                }
            }

            // Remplir les pixels nuls avec des pixels noirs
            for (int x = 0; x < TailleX; x++)
            {
                for (int y = 0; y < TailleY; y++)
                {
                    if (rotatedImage[x, y] == null)
                    {
                        rotatedImage[x, y] = new Pixel(255, 255, 255); // Pixel noir
                    }
                }
            }

            return rotatedImage;
        }*/
        /*
        public Pixel[,] RotationDegre(Image Dessin, int degre)
        {
            int TailleX = Dessin.tailleX;
            int TailleY = Dessin.tailleY;

            double angle = degre * Math.PI / 180.0;
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);

            Pixel[,] rotatedImage = new Pixel[TailleX, TailleY];

            // Calcul des coordonnées du centre de l'image
            double centreX = TailleX / 2.0;
            double centreY = TailleY / 2.0;

            // Parcourir tous les pixels de l'image résultante
            for (int x = 0; x < TailleX; x++)
            {
                for (int y = 0; y < TailleY; y++)
                {
                    // Déplacer les coordonnées au centre de l'image
                    double offsetX = x - centreX;
                    double offsetY = y - centreY;

                    // Appliquer la rotation autour du centre de l'image
                    double nouveauX = offsetX * cosTheta - offsetY * sinTheta + centreX;
                    double nouveauY = offsetX * sinTheta + offsetY * cosTheta + centreY;

                    // Convertir les coordonnées en entiers
                    int intNouveauX = (int)Math.Round(nouveauX);
                    int intNouveauY = (int)Math.Round(nouveauY);

                    // Copier le pixel de l'image d'origine dans l'image résultante
                    if (intNouveauX >= 0 && intNouveauX < TailleX && intNouveauY >= 0 && intNouveauY < TailleY)
                    {
                        rotatedImage[intNouveauX, intNouveauY] = Dessin.MatricePixel[x, y];
                    }
                }
            }

            // Remplir les pixels nuls avec des pixels noirs
            for (int x = 0; x < TailleX; x++)
            {
                for (int y = 0; y < TailleY; y++)
                {
                    if (rotatedImage[x, y] == null)
                    {
                        rotatedImage[x, y] = new Pixel(255,255,255); // Pixel noir
                    }
                }
            }

            return rotatedImage;
        }
         */
        
        public Pixel[,] RotationDegre(Image Dessin, int degre)
        {
            // Calcul des dimensions de l'image de sortie

            double theta = degre * Math.PI / 180.0;
            int nvtailleX = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Cos(theta)) + Dessin.tailleY * Math.Abs(Math.Sin(theta)));
            int nvtailleY = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Sin(theta)) + Dessin.tailleY * Math.Abs(Math.Cos(theta)));

            while (nvtailleX % 4 != 0)
            {
                nvtailleX++;
            }
            while (nvtailleY % 4 != 0)
            {
                nvtailleY++;
            }

            // Création de l'image de sortie
            Pixel[,] rotatedImage = new Pixel[nvtailleX, nvtailleY];

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
                    int nvx = Convert.ToInt32(((x - centreX) * Math.Cos(theta) - (y - centreY) * Math.Sin(theta) + nvcentreX));
                    int nvy = Convert.ToInt32(((x - centreX) * Math.Sin(theta) + (y - centreY) * Math.Cos(theta) + nvcentreY));

                    // Copier le pixel de l'image d'entrée dans l'image de sortie
                    if (nvx >= 0 && nvx < nvtailleX && nvy >= 0 && nvy < nvtailleY)
                    {
                        rotatedImage[nvx, nvy] = Dessin.MatricePixel[x, y];
                    }
                }
            }
            // Remplir les pixels nuls avec des pixels noirs
            for (int x = 0; x < nvtailleX; x++)
            {
                for (int y = 0; y < nvtailleY; y++)
                {
                    if (rotatedImage[x, y] == null)
                    {
                        rotatedImage[x, y] = new Pixel(0, 0, 0); 
                    }
                }
            }
            return rotatedImage;
        }
        


        // TEST D'IMAGE NOIRE JUSTE EN DESSOUS
        // VRAI CODE ACTUEL JUSTE AU DESSUS

        /*
        public Pixel[,] RotationDegre(Image Dessin, int degre)
        {
            // Calcul des dimensions de l'image de sortie

            double theta = degre * Math.PI / 180.0;
            int nvtailleX = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Cos(theta)) + Dessin.tailleY * Math.Abs(Math.Sin(theta)));
            int nvtailleY = Convert.ToInt32(Dessin.tailleX * Math.Abs(Math.Sin(theta)) + Dessin.tailleY * Math.Abs(Math.Cos(theta)));

            // Création de l'image de sortie
            Pixel[,] rotatedImage = new Pixel[nvtailleX, nvtailleY];

            // Remplir les pixels nuls avec des pixels noirs
            for (int x = 0; x < nvtailleX; x++)
            {
                for (int y = 0; y < nvtailleY; y++)
                {
                    if (rotatedImage[x, y] == null)
                    {
                        rotatedImage[x, y] = new Pixel(0, 0, 0);
                    }
                }
            }
            return rotatedImage;
        }
        */

    }
}
