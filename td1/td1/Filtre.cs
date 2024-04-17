using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Filtre
    {/**
        Image image;
        Image imagefiltre;
        
        public Filtre(Image image)
        {
            this.image = image;
        }
        
        public Image Filtrerimage(Image image)
        {
            imagefiltre.MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)];
            imagefiltre.Header = image.Header;
            Console.WriteLine("Quel filtre souhaitez-vous?:");
            string num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    Console.WriteLine("Quel degré de détection de contour voulez-vous?");
                    string degre = Console.ReadLine();
                    switch (degre)
                    {
                        case "1":
                            int[,] Matricefiltre11 = { { 1, 0, -1 }, { 0, 0, 0 }, { -1, 0, 1 } };
                            for (int i = 1; i < image.MatricePixel.GetLength(0); i++)
                            {
                                for (int j = 1; j < image.MatricePixel.GetLength(1); j++)
                                {
                                    //imagefiltre.MatricePixel = 
                                }
                            }
                            break;

                        case "2":
                            int[,] Matricefiltre12 = { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
                            break;

                        case "3":
                            int[,] Matricefiltre13 = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
                            break;

                    }
                    break;

                case "2":

                    int[,] Matricefiltre2 = { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };

                    break;

                case "3":
                    for (int i = 1; i < image.MatricePixel.GetLength(0)-1; i++)
                    {
                        for(int j= 1; j < image.MatricePixel.GetLength(1)-1; j++)
                        {
                            imagefiltre.MatricePixel[i, j].R = 
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                            imagefiltre.MatricePixel[i, j].G =
                                (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;

                            imagefiltre.MatricePixel[i, j].B =
                                (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                        }
                    }
                    break;

                case "4":
                    int[,] Matricefiltre4 = { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
                break;
            }
            
            return imagefiltre;
        }
        */

    }
}

