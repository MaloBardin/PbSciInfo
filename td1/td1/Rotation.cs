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



    }
}
