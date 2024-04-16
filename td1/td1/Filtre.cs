using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Filtre
    {
        Image image;
        Image imagefiltre;
        
        public Filtre(Image image)
        {
            this.image = image;
        }
        /*
        public Image Main(string[] args)
        {
            imagefiltre.MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)];

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
                            int[,] Matricefiltre = { { 1, 0, -1 }, { 0, 0, 0 }, { -1, 0, 1 } };
                            imagefiltre.MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)];
                            for (int i = 1; i < image.MatricePixel.GetLength(0); i++)
                            {
                                for (int j = 1; j < image.MatricePixel.GetLength(1); j++)
                                {
                                    //imagefiltre.MatricePixel = 
                                }
                            }
                            break;

                        case "2":
                            int[,] Matricefiltre = { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
                            break;

                        case "3":
                            int[,] Matricefiltre = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
                            break;

                    }
                    break;

                case "2":


                    Matricefiltre[0, 0] = 0;
                    Matricefiltre[0, 1] = 0;
                    Matricefiltre[0, 2] = 0;
                    Matricefiltre[1, 0] = -1;
                    Matricefiltre[1, 1] = 1;
                    Matricefiltre[1, 2] = 0;
                    Matricefiltre[2, 0] = 0;
                    Matricefiltre[2, 1] = 0;
                    Matricefiltre[2, 2] = 0;
                    break;

                case "3":
                    for (int i = 1; i < image.MatricePixel.GetLength(0)-1; i++)
                    {
                        for(int j= 1; j < image.MatricePixel.GetLength(1)-1; j++)
                        {
                            imagefiltre.MatricePixel[i, j] = 
                                (image.MatricePixel[i - 1, j - 1] + image.MatricePixel[i - 1, j] + image.MatricePixel[i - 1, j + 1]
                                + image.MatricePixel[i, j - 1] + image.MatricePixel[i, j] + image.MatricePixel[i, j + 1]
                                + image.MatricePixel[i + 1, j - 1] + image.MatricePixel[i + 1, j] + image.MatricePixel[i + 1, j + 1]) / 9;
                        }
                    }
                    break;

                case "4":
                    Matricefiltre[0, 0] = -2;
                    Matricefiltre[0, 1] = -1;
                    Matricefiltre[0, 2] = 0;
                    Matricefiltre[1, 0] = -1;
                    Matricefiltre[1, 1] = 1;
                    Matricefiltre[1, 2] = 1;
                    Matricefiltre[2, 0] = 0;
                    Matricefiltre[2, 1] = 1;
                    Matricefiltre[2, 2] = 2;
                break;
            }

            return imagefiltre;
        }
        */

    }
}

