using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Filtre
    {
        public Image image;
        public Pixel[,] Matricepixel;

        public Filtre(Image image)
        {
            this.image = image;
        }
        
        public Pixel[,] Filtrerimage(Image image)
        {
            Image imagefiltrer;
            Pixel[,] MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)]; 

            for (int i = 0; i < image.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < image.MatricePixel.GetLength(1); j++)
                {
                    MatricePixel[i, j] = new Pixel(0, 0, 0); /// On initialise notre matrice de sorte a qu'il soit rempli de pixels noirs
                }
            }


            Console.SetCursorPosition(25, 7); Console.WriteLine("Quel filtre souhaitez-vous?:"); /// On demande quel filtre l'utilisateur souhaite utiliser
            string num = Console.ReadLine();
            switch (num)
            {   
                case "1":
                    int[,] Matricefiltre13 = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                            int indiceR = 0, indiceG = 0, indiceB = 0;
                            if (image.MatricePixel[i - 1, j - 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i - 1, j - 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i - 1, j - 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i - 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i - 1, j].R;
                                ajouteurG += (-1) * image.MatricePixel[i - 1, j].G;
                                ajouteurB += (-1) * image.MatricePixel[i - 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j + 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i - 1, j + 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i - 1, j + 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i - 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j - 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i, j - 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i, j - 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j] != null)
                            {
                                ajouteurR += 8 * image.MatricePixel[i, j].R;
                                ajouteurG += 8 * image.MatricePixel[i, j].G;
                                ajouteurB += 8 * image.MatricePixel[i, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j + 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i, j + 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i, j + 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j - 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i + 1, j - 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i + 1, j - 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i + 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i + 1, j].R;
                                ajouteurG += (-1) * image.MatricePixel[i + 1, j].G;
                                ajouteurB += (-1) * image.MatricePixel[i + 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j + 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i + 1, j + 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i + 1, j + 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i + 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }
                            MatricePixel[i, j].R = ajouteurR / indiceR;
                            MatricePixel[i, j].G = ajouteurG / indiceG;
                            MatricePixel[i, j].B = ajouteurB / indiceB;

                        }
                    }

                    break;

                case "2":
                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                            int indiceR = 0, indiceG = 0, indiceB = 0;
                            if (image.MatricePixel[i - 1, j - 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i - 1, j - 1].R;
                                ajouteurG += (0) * image.MatricePixel[i - 1, j - 1].G;
                                ajouteurB += (0) * image.MatricePixel[i - 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i - 1, j].R;
                                ajouteurG += (0) * image.MatricePixel[i - 1, j].G;
                                ajouteurB += (0) * image.MatricePixel[i - 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j + 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i - 1, j + 1].R;
                                ajouteurG += (0) * image.MatricePixel[i - 1, j + 1].G;
                                ajouteurB += (0) * image.MatricePixel[i - 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j - 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i, j - 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i, j - 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j] != null)
                            {
                                ajouteurR += 1 * image.MatricePixel[i, j].R;
                                ajouteurG += 1 * image.MatricePixel[i, j].G;
                                ajouteurB += 1 * image.MatricePixel[i, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j + 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i, j + 1].R;
                                ajouteurG += (0) * image.MatricePixel[i, j + 1].G;
                                ajouteurB += (0) * image.MatricePixel[i, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j - 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i + 1, j - 1].R;
                                ajouteurG += (0) * image.MatricePixel[i + 1, j - 1].G;
                                ajouteurB += (0) * image.MatricePixel[i + 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i + 1, j].R;
                                ajouteurG += (0) * image.MatricePixel[i + 1, j].G;
                                ajouteurB += (0) * image.MatricePixel[i + 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j + 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i + 1, j + 1].R;
                                ajouteurG += (0) * image.MatricePixel[i + 1, j + 1].G;
                                ajouteurB += (0) * image.MatricePixel[i + 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }
                            MatricePixel[i, j].R = ajouteurR / indiceR;
                            MatricePixel[i, j].G = ajouteurG / indiceG;
                            MatricePixel[i, j].B = ajouteurB / indiceB;

                        }
                    }

                    break;
                
                case "3":
                    for (int i = 1; i < image.MatricePixel.GetLength(0)-1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1)-1; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                            int indiceR = 0, indiceG = 0, indiceB = 0;
                            if (image.MatricePixel[i-1,j-1] != null)
                            {
                                ajouteurR += image.MatricePixel[i - 1, j - 1].R;
                                ajouteurG += image.MatricePixel[i - 1, j - 1].G;
                                ajouteurB += image.MatricePixel[i - 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j] != null)
                            {
                                ajouteurR += image.MatricePixel[i - 1, j].R;
                                ajouteurG += image.MatricePixel[i - 1, j].G;
                                ajouteurB += image.MatricePixel[i - 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j + 1] != null) 
                            {
                                ajouteurR += image.MatricePixel[i - 1, j + 1].R;
                                ajouteurG += image.MatricePixel[i - 1, j + 1].G;
                                ajouteurB += image.MatricePixel[i - 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j - 1] != null) 
                            {
                                ajouteurR += image.MatricePixel[i, j - 1].R;
                                ajouteurG += image.MatricePixel[i, j - 1].G;
                                ajouteurB += image.MatricePixel[i, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j] != null)
                            {
                                ajouteurR += image.MatricePixel[i, j].R;
                                ajouteurG += image.MatricePixel[i, j].G;
                                ajouteurB += image.MatricePixel[i, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j + 1] != null)
                            {
                                ajouteurR += image.MatricePixel[i, j + 1].R;
                                ajouteurG += image.MatricePixel[i, j + 1].G;
                                ajouteurB += image.MatricePixel[i, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j - 1] != null) 
                            {
                                ajouteurR += image.MatricePixel[i + 1, j - 1].R;
                                ajouteurG += image.MatricePixel[i + 1, j - 1].G;
                                ajouteurB += image.MatricePixel[i + 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j] != null)
                            {
                                ajouteurR += image.MatricePixel[i + 1, j].R;
                                ajouteurG += image.MatricePixel[i + 1, j].G;
                                ajouteurB += image.MatricePixel[i + 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j + 1] != null)
                            {
                                ajouteurR += image.MatricePixel[i + 1, j + 1].R;
                                ajouteurG += image.MatricePixel[i + 1, j + 1].G;
                                ajouteurB += image.MatricePixel[i + 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }
                                              
                            MatricePixel[i, j].R = ajouteurR / indiceR;
                            MatricePixel[i, j].G = ajouteurG / indiceG;
                            MatricePixel[i, j].B = ajouteurB / indiceB;
                            
                        }
                    }
                break;

                case "4": /// Filtre: Repoussage

                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {
                            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                            int indiceR = 0, indiceG = 0, indiceB = 0;
                            if (image.MatricePixel[i - 1, j - 1] != null)
                            {
                                ajouteurR += (-2) * image.MatricePixel[i - 1, j - 1].R;
                                ajouteurG += (-2) * image.MatricePixel[i - 1, j - 1].G;
                                ajouteurB += (-2) * image.MatricePixel[i - 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i - 1, j].R;
                                ajouteurG += (-1) * image.MatricePixel[i - 1, j].G;
                                ajouteurB += (-1) * image.MatricePixel[i - 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i - 1, j + 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i - 1, j + 1].R;
                                ajouteurG += (0) * image.MatricePixel[i - 1, j + 1].G;
                                ajouteurB += (0) * image.MatricePixel[i - 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j - 1] != null)
                            {
                                ajouteurR += (-1) * image.MatricePixel[i, j - 1].R;
                                ajouteurG += (-1) * image.MatricePixel[i, j - 1].G;
                                ajouteurB += (-1) * image.MatricePixel[i, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j] != null)
                            {
                                ajouteurR += 1 * image.MatricePixel[i, j].R;
                                ajouteurG += 1 * image.MatricePixel[i, j].G;
                                ajouteurB += 1 * image.MatricePixel[i, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i, j + 1] != null)
                            {
                                ajouteurR += 1 * image.MatricePixel[i, j + 1].R;
                                ajouteurG += 1 * image.MatricePixel[i, j + 1].G;
                                ajouteurB += 1 * image.MatricePixel[i, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j - 1] != null)
                            {
                                ajouteurR += (0) * image.MatricePixel[i + 1, j - 1].R;
                                ajouteurG += (0) * image.MatricePixel[i + 1, j - 1].G;
                                ajouteurB += (0) * image.MatricePixel[i + 1, j - 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j] != null)
                            {
                                ajouteurR += (1) * image.MatricePixel[i + 1, j].R;
                                ajouteurG += (1) * image.MatricePixel[i + 1, j].G;
                                ajouteurB += (1) * image.MatricePixel[i + 1, j].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (image.MatricePixel[i + 1, j + 1] != null)
                            {
                                ajouteurR += (2) * image.MatricePixel[i + 1, j + 1].R;
                                ajouteurG += (2) * image.MatricePixel[i + 1, j + 1].G;
                                ajouteurB += (2) * image.MatricePixel[i + 1, j + 1].B;
                                indiceR++;
                                indiceG++;
                                indiceB++;

                            }

                            if (ajouteurR > 255)
                            {
                                ajouteurR = 255;
                            }
                            else if (ajouteurR < 0)
                            {
                                ajouteurR = 0;
                            }

                            if (ajouteurG > 255)
                            {
                                ajouteurG = 255;
                            }
                            else if (ajouteurG < 0)
                            {
                                ajouteurG = 0;
                            }

                            if (ajouteurB > 255)
                            {
                                ajouteurB = 255;
                            }
                            else if (ajouteurB < 0)
                            {
                                ajouteurB = 0;
                            }
                            MatricePixel[i, j].R = ajouteurR / indiceR;
                            MatricePixel[i, j].G = ajouteurG / indiceG;
                            MatricePixel[i, j].B = ajouteurB / indiceB;

                        }
                    }
                    break;

            }
            /*
            ///On remplit les coins
            MatricePixel[0, 0] = MatricePixel[1, 1];
            MatricePixel[0, 1] = MatricePixel[1, 1];
            MatricePixel[1, 0] = MatricePixel[1, 1]; /// Coin 1

            MatricePixel[0, image.MatricePixel.GetLength(1)] = MatricePixel[1, image.MatricePixel.GetLength(1)-1];
            MatricePixel[0, image.MatricePixel.GetLength(1) - 1] = MatricePixel[1, image.MatricePixel.GetLength(1) - 1];
            MatricePixel[1, image.MatricePixel.GetLength(1)] = MatricePixel[1, image.MatricePixel.GetLength(1) - 1]; /// Coin 2

            MatricePixel[image.MatricePixel.GetLength(0), 0] = MatricePixel[image.MatricePixel.GetLength(0) - 1, 1];
            MatricePixel[image.MatricePixel.GetLength(0), 1] = MatricePixel[image.MatricePixel.GetLength(0) - 1, 1];
            MatricePixel[image.MatricePixel.GetLength(0) - 1, 0] = MatricePixel[image.MatricePixel.GetLength(0) - 1, 1]; /// Coin 3

            MatricePixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)] = MatricePixel[image.MatricePixel.GetLength(0) - 1, image.MatricePixel.GetLength(1)-1];
            MatricePixel[image.MatricePixel.GetLength(0) - 1, image.MatricePixel.GetLength(1)]= MatricePixel[image.MatricePixel.GetLength(0) - 1, image.MatricePixel.GetLength(1) - 1];
            MatricePixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1) - 1] = MatricePixel[image.MatricePixel.GetLength(0) - 1, image.MatricePixel.GetLength(1) - 1]; /// Coin 4

            for (int i = 2; i < image.MatricePixel.GetLength(0)-2; i++) ///On remplit les côtés
            {
                MatricePixel[i, 0] = MatricePixel[i, 1];
                MatricePixel[i, image.MatricePixel.GetLength(1)] = MatricePixel[i, image.MatricePixel.GetLength(1) - 1];
            }
            for (int j = 2; j < image.MatricePixel.GetLength(1) - 2; j++)
            {
                MatricePixel[0, j] = MatricePixel[1, j];
                MatricePixel[image.MatricePixel.GetLength(0), j] = MatricePixel[image.MatricePixel.GetLength(0) - 1, j];
            }
            **/

            return MatricePixel;
                
        }
     
    }
}

///A montrer
/*
int ajouteur = 0;
                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {

                            ajouteur =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R)/9;
                            if (ajouteur > 255)
                            {
                                MatricePixel[i, j].R = 255;
                            }
                            else if (ajouteur < 0)
                            {
                                MatricePixel[i, j].R = 0;
                            }
                            else if (0< ajouteur && ajouteur < 255)
                            {
                                MatricePixel[i,j].R = Convert.ToByte(ajouteur);
                            }



                            ajouteur =
                                (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G)/9;

                            if (ajouteur > 255)
                            {
                                MatricePixel[i, j].G = 255;
                            }
                            else if (ajouteur < 0)
                            {
                                MatricePixel[i, j].G = 0;
                            }
                            else if (0 < ajouteur && ajouteur < 255)
                            {
                                MatricePixel[i, j].G = Convert.ToByte(ajouteur);
                            }

                            ajouteur =
                                (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B)/9;
                            if (ajouteur > 255)
                            {
                                MatricePixel[i, j].B = 255;
                            }
                            else if (ajouteur < 0)
                            {
                                MatricePixel[i, j].B = 0;
                            }
                            else if (0 < ajouteur && ajouteur < 255)
                            {
                                MatricePixel[i, j].B = Convert.ToByte(ajouteur);
                            }


                        }
                    }

**/