using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Filtre
    {/**
        public Image image;
        public Pixel[,] Matricepixel;

        public Filtre(Image image)
        {
            this.image = image;
        }
        
        public Pixel[,] Filtrerimage(Image image)
        {
            Image imagefiltrer;
            Pixel[,] MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)]; ;
            for (int i = 0; i < image.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < image.MatricePixel.GetLength(1); j++)
                {
                    MatricePixel[i, j] = new Pixel(0, 0, 0);
                }
            }
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
                    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                    {
                        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                        {

                            MatricePixel[i, j].R =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                            MatricePixel[i, j].G =
                                (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;

                            MatricePixel[i, j].B =
                                (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                            if (MatricePixel[i, j].R > 255)
                            {
                                MatricePixel[i, j].R = 255;
                            }
                            if (MatricePixel[i, j].G > 255)
                            {
                                MatricePixel[i, j].G = 255;
                            }
                            if (MatricePixel[i, j].B > 255)
                            {
                                MatricePixel[i, j].B = 255;
                            }
                            if (MatricePixel[i, j].R < 0)
                            {
                                MatricePixel[i, j].R = 0;
                            }
                            if (MatricePixel[i, j].G < 0)
                            {
                                MatricePixel[i, j].G = 0;
                            }
                            if (MatricePixel[i, j].B < 0)
                            {
                                MatricePixel[i, j].B = 0;
                            }
                            if (i == 1 && j == 1)
                            {
                                MatricePixel[0, 0].R =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                                MatricePixel[0, 0].G =
                                   (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;


                                MatricePixel[0, 0].B =
                                   (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                            }
                            if (i == image.MatricePixel.GetLength(0) - 1 && j == 1)
                            {
                                MatricePixel[image.MatricePixel.GetLength(0), 0].R =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                                MatricePixel[image.MatricePixel.GetLength(0), 0].G =
                                   (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;


                                MatricePixel[image.MatricePixel.GetLength(0), 0].B =
                                   (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                            }
                            if (i == 1 && j == image.MatricePixel.GetLength(1) - 1)
                            {
                                MatricePixel[0, image.MatricePixel.GetLength(1)].R =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                                MatricePixel[0, image.MatricePixel.GetLength(1)].G =
                                   (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;


                                MatricePixel[0, image.MatricePixel.GetLength(1)].B =
                                   (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                            }
                            if (i == image.MatricePixel.GetLength(0) - 1 && j == image.MatricePixel.GetLength(1) - 1)
                            {
                                MatricePixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)].R =
                                (image.MatricePixel[i - 1, j - 1].R + image.MatricePixel[i - 1, j].R + image.MatricePixel[i - 1, j + 1].R
                                + image.MatricePixel[i, j - 1].R + image.MatricePixel[i, j].R + image.MatricePixel[i, j + 1].R
                                + image.MatricePixel[i + 1, j - 1].R + image.MatricePixel[i + 1, j].R + image.MatricePixel[i + 1, j + 1].R) / 9;

                                MatricePixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)].G =
                                   (image.MatricePixel[i - 1, j - 1].G + image.MatricePixel[i - 1, j].G + image.MatricePixel[i - 1, j + 1].G
                                + image.MatricePixel[i, j - 1].G + image.MatricePixel[i, j].G + image.MatricePixel[i, j + 1].G
                                + image.MatricePixel[i + 1, j - 1].G + image.MatricePixel[i + 1, j].G + image.MatricePixel[i + 1, j + 1].G) / 9;


                                MatricePixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)].B =
                                   (image.MatricePixel[i - 1, j - 1].B + image.MatricePixel[i - 1, j].B + image.MatricePixel[i - 1, j + 1].B
                                + image.MatricePixel[i, j - 1].B + image.MatricePixel[i, j].B + image.MatricePixel[i, j + 1].B
                                + image.MatricePixel[i + 1, j - 1].B + image.MatricePixel[i + 1, j].B + image.MatricePixel[i + 1, j + 1].B) / 9;
                            }

                        }
                    }
                    for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                    {
                        MatricePixel[0, j].R = MatricePixel[1, j].R;
                        MatricePixel[0, j].G = MatricePixel[1, j].G;
                        MatricePixel[0, j].B = MatricePixel[1, j].B;

                    }
                    break;

                case "4":
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

                break;

            }
            return MatricePixel;
                
        }
     */   
    }
}

