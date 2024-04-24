﻿using System;
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
        
        public async Pixel[,] Filtrerimage(Image image)
        {
            Image imagefiltrer;
            Pixel[,] MatricePixel = new Pixel[image.MatricePixel.GetLength(0), image.MatricePixel.GetLength(1)]; 

            for (int i = 0; i < image.TailleX; i++)
            {
                for (int j = 0; j < image.TailleY; j++)
                {
                    MatricePixel[i, j] = new Pixel(0, 0, 0); /// On initialise notre matrice de sorte a qu'il soit rempli de pixels noirs
                }
            }


            Console.SetCursorPosition(25, 7); Console.WriteLine("Quel sorte de filtre souhaitez-vous?"); /// On demande quel sorte de filtre l'utilisateur souhaite utiliser
            Console.SetCursorPosition(15, 8); Console.WriteLine("Vos choix sont:");
            Console.SetCursorPosition(15, 9); Console.WriteLine("1. (3x3)");
            Console.SetCursorPosition(15, 10); Console.WriteLine("2. (5x5)");
            Console.SetCursorPosition(15, 11); Console.WriteLine("3. (7x7)");
            Console.SetCursorPosition(15, 12); Console.WriteLine("4. (nxn)");
            string num = Console.ReadLine();
            switch (num)
            {   
                case "1":
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi: (3x3)");
                    
                    Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                    Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                    Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                    Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                    Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                    Console.SetCursorPosition(15, 13);Console.Write("Quel filtre souhaitez-vous?");
                    string answer3 = Console.ReadLine();
                    switch (answer3)
                    {
                        case "1": /// Filtre: Détection de contour
                          for (int i = 1; i < image.TailleX - 1; i++)
                          {
                             for (int j = 1; j < image.TailleY - 1; j++)
                             {
                                int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                for (int k = -1; k <= 1; k++)
                                {
                                    for (int l = -1; l <= 1; l++)
                                    {
                                            if (k == 0 && l == 0)
                                            {
                                                ajouteurR += 8 * image.MatricePixel[i, j].R;
                                                ajouteurG += 8 * image.MatricePixel[i, j].G;
                                                ajouteurB += 8 * image.MatricePixel[i, j].B;
                                            }
                                            else
                                            {
                                                ajouteurR -= image.MatricePixel[i + k, j + l].R;
                                                ajouteurG -= image.MatricePixel[i + k, j + l].G;
                                                ajouteurB -= image.MatricePixel[i + k, j + l].B;
                                            }

                                    }
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                             }
                          }

                        break;

                        case "2":// Filtre: Renforcement des bords
                            for (int i = 1; i < image.TailleX - 1; i++)
                            {
                                for (int j = 1; j < image.TailleY - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                                               
                                    ajouteurR += image.MatricePixel[i, j].R;                                   
                                    ajouteurG += image.MatricePixel[i, j].G;                                    
                                    ajouteurB += image.MatricePixel[i, j].B;
                                    
                                    ajouteurR -= image.MatricePixel[i , j - 1].R;                                    
                                    ajouteurG -= image.MatricePixel[i , j - 1].G;                                    
                                    ajouteurB -= image.MatricePixel[i , j - 1].B;
                                            
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }

                            break;

                        case "3": /// Filtre: Flou
                            for (int i = 1; i < image.TailleX - 1; i++)
                            {
                                for (int j = 1; j < image.TailleY - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -1; k <= 1; k++)
                                    {
                                        for (int l = -1; l <= 1; l++)
                                        {
                                                ajouteurR += image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += image.MatricePixel[i + k, j + l].B;
                                        }
                                    }
                                    MatricePixel[i, j].R = ajouteurR / 9;
                                    MatricePixel[i, j].G = ajouteurG / 9;
                                    MatricePixel[i, j].B = ajouteurB / 9;

                                }
                            }


                            break;

                        case "4": /// Filtre: Repoussage

                            for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                            {
                                for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                                    if (image.MatricePixel[i - 1, j - 1] != null)
                                    {
                                        ajouteurR += (-2) * image.MatricePixel[i - 1, j - 1].R;
                                        ajouteurG += (-2) * image.MatricePixel[i - 1, j - 1].G;
                                        ajouteurB += (-2) * image.MatricePixel[i - 1, j - 1].B;

                                    }

                                    if (image.MatricePixel[i - 1, j] != null)
                                    {
                                        ajouteurR += (-1) * image.MatricePixel[i - 1, j].R;
                                        ajouteurG += (-1) * image.MatricePixel[i - 1, j].G;
                                        ajouteurB += (-1) * image.MatricePixel[i - 1, j].B;

                                    }

                                    if (image.MatricePixel[i - 1, j + 1] != null)
                                    {
                                        ajouteurR += (0) * image.MatricePixel[i - 1, j + 1].R;
                                        ajouteurG += (0) * image.MatricePixel[i - 1, j + 1].G;
                                        ajouteurB += (0) * image.MatricePixel[i - 1, j + 1].B;

                                    }

                                    if (image.MatricePixel[i, j - 1] != null)
                                    {
                                        ajouteurR += (-1) * image.MatricePixel[i, j - 1].R;
                                        ajouteurG += (-1) * image.MatricePixel[i, j - 1].G;
                                        ajouteurB += (-1) * image.MatricePixel[i, j - 1].B;

                                    }

                                    if (image.MatricePixel[i, j] != null)
                                    {
                                        ajouteurR += 1 * image.MatricePixel[i, j].R;
                                        ajouteurG += 1 * image.MatricePixel[i, j].G;
                                        ajouteurB += 1 * image.MatricePixel[i, j].B;

                                    }

                                    if (image.MatricePixel[i, j + 1] != null)
                                    {
                                        ajouteurR += 1 * image.MatricePixel[i, j + 1].R;
                                        ajouteurG += 1 * image.MatricePixel[i, j + 1].G;
                                        ajouteurB += 1 * image.MatricePixel[i, j + 1].B;

                                    }

                                    if (image.MatricePixel[i + 1, j - 1] != null)
                                    {
                                        ajouteurR += (0) * image.MatricePixel[i + 1, j - 1].R;
                                        ajouteurG += (0) * image.MatricePixel[i + 1, j - 1].G;
                                        ajouteurB += (0) * image.MatricePixel[i + 1, j - 1].B;
                                    }

                                    if (image.MatricePixel[i + 1, j] != null)
                                    {
                                        ajouteurR += (1) * image.MatricePixel[i + 1, j].R;
                                        ajouteurG += (1) * image.MatricePixel[i + 1, j].G;
                                        ajouteurB += (1) * image.MatricePixel[i + 1, j].B;
                                    }

                                    if (image.MatricePixel[i + 1, j + 1] != null)
                                    {
                                        ajouteurR += (2) * image.MatricePixel[i + 1, j + 1].R;
                                        ajouteurG += (2) * image.MatricePixel[i + 1, j + 1].G;
                                        ajouteurB += (2) * image.MatricePixel[i + 1, j + 1].B;
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }
                            break;
                    }
                break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi: (5x5)");

                    Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                    Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                    Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                    Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                    Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                    Console.SetCursorPosition(15, 13); Console.Write("Quel filtre souhaitez-vous?");
                    string answer5 = Console.ReadLine();
                    switch (answer5)
                    {
                        case "1": /// Filtre: Détection de contour
                            for (int i = 2; i < image.TailleX - 2; i++)
                            {
                                for (int j = 2; j < image.TailleY - 2; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    ajouteurR += 4 * image.MatricePixel[i, j].R;
                                    ajouteurG += 4 * image.MatricePixel[i, j].G;
                                    ajouteurB += 4 * image.MatricePixel[i, j].B;

                                    ajouteurR -= image.MatricePixel[i + 2, j].R;
                                    ajouteurG -= image.MatricePixel[i + 2, j].G;
                                    ajouteurB -= image.MatricePixel[i + 2, j].B;

                                    ajouteurR -= image.MatricePixel[i - 1, j].R;
                                    ajouteurG -= image.MatricePixel[i - 1, j].G;
                                    ajouteurB -= image.MatricePixel[i - 1, j].B;

                                    ajouteurR -= image.MatricePixel[i + 1, j].R;
                                    ajouteurG -= image.MatricePixel[i + 1, j].G;
                                    ajouteurB -= image.MatricePixel[i + 1, j].B;

                                    ajouteurR -= image.MatricePixel[i + 2, j].R;
                                    ajouteurG -= image.MatricePixel[i + 2, j].G;
                                    ajouteurB -= image.MatricePixel[i + 2, j].B;

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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }

                            break;

                        case "2": /// Filtre: Renforcement des bords
                            for (int i = 2; i < image.TailleX - 2; i++)
                          {
                             for (int j = 2; j < image.TailleY - 2; j++)
                             {
                                int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                for (int k = -2; k <= 2; k++)
                                {
                                    for (int l = -2; l <= 2; l++)
                                    {
                                            if (k == 0 && l == 0)
                                            {
                                                ajouteurR += 8 * image.MatricePixel[i, j].R;
                                                ajouteurG += 8 * image.MatricePixel[i, j].G;
                                                ajouteurB += 8 * image.MatricePixel[i, j].B;
                                            }
                                            else
                                            {
                                                if((k == -1 || k == 0 || k == 1) && (l == -1 || l == 0 || l == 1))
                                                {
                                                ajouteurR += 2 * image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += 2 * image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += 2 * image.MatricePixel[i + k, j + l].B;
                                                }

                                                if((k == -2 || k == 0 || k == 2) && (l == -2 || l == 0 || l == 2))
                                                {
                                                ajouteurR -= image.MatricePixel[i + k, j + l].R;
                                                ajouteurG -= image.MatricePixel[i + k, j + l].G;
                                                ajouteurB -= image.MatricePixel[i + k, j + l].B;
                                                }
                                            }
                                                
                                            

                                    }
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                             }
                          }
                            break;

                        case "3": /// Filtre: Flou
                            for (int i = 2; i < image.TailleX - 2; i++)
                            {
                                for (int j = 2; j < image.TailleY - 2; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -2; k <= 2; k++)
                                    {
                                        for (int l = -2; l <= 2; l++)
                                        {
                                            ajouteurR += image.MatricePixel[i + k, j + l].R;
                                            ajouteurG += image.MatricePixel[i + k, j + l].G;
                                            ajouteurB += image.MatricePixel[i + k, j + l].B;
                                        }
                                    }
                                    MatricePixel[i, j].R = ajouteurR / 25;
                                    MatricePixel[i, j].G = ajouteurG / 25;
                                    MatricePixel[i, j].B = ajouteurB / 25;

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
                break;
                    
                
                case "3":
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi: (7x7)");

                    Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                    Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                    Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                    Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                    Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                    Console.SetCursorPosition(15, 13); Console.Write("Quel filtre souhaitez-vous?");
                    string answer7 = Console.ReadLine();
                    switch (answer7)
                    {
                        case "1": /// Filtre: Détection de contour
                            for (int i = 2; i < image.TailleX - 2; i++)
                            {
                                for (int j = 2; j < image.TailleY - 2; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    ajouteurR += 4 * image.MatricePixel[i, j].R;
                                    ajouteurG += 4 * image.MatricePixel[i, j].G;
                                    ajouteurB += 4 * image.MatricePixel[i, j].B;

                                    ajouteurR -= image.MatricePixel[i + 2, j].R;
                                    ajouteurG -= image.MatricePixel[i + 2, j].G;
                                    ajouteurB -= image.MatricePixel[i + 2, j].B;

                                    ajouteurR -= image.MatricePixel[i - 1, j].R;
                                    ajouteurG -= image.MatricePixel[i - 1, j].G;
                                    ajouteurB -= image.MatricePixel[i - 1, j].B;

                                    ajouteurR -= image.MatricePixel[i + 1, j].R;
                                    ajouteurG -= image.MatricePixel[i + 1, j].G;
                                    ajouteurB -= image.MatricePixel[i + 1, j].B;

                                    ajouteurR -= image.MatricePixel[i + 2, j].R;
                                    ajouteurG -= image.MatricePixel[i + 2, j].G;
                                    ajouteurB -= image.MatricePixel[i + 2, j].B;

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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }

                            break;

                        case "2": /// Filtre: Renforcement des bords
                            for (int i = 2; i < image.TailleX - 2; i++)
                            {
                                for (int j = 2; j < image.TailleY - 2; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -2; k <= 2; k++)
                                    {
                                        for (int l = -2; l <= 2; l++)
                                        {
                                            if (k == 0 && l == 0)
                                            {
                                                ajouteurR += 8 * image.MatricePixel[i, j].R;
                                                ajouteurG += 8 * image.MatricePixel[i, j].G;
                                                ajouteurB += 8 * image.MatricePixel[i, j].B;
                                            }
                                            else
                                            {
                                                if ((k == -1 || k == 0 || k == 1) && (l == -1 || l == 0 || l == 1))
                                                {
                                                    ajouteurR += 2 * image.MatricePixel[i + k, j + l].R;
                                                    ajouteurG += 2 * image.MatricePixel[i + k, j + l].G;
                                                    ajouteurB += 2 * image.MatricePixel[i + k, j + l].B;
                                                }

                                                if ((k == -2 || k == 0 || k == 2) && (l == -2 || l == 0 || l == 2))
                                                {
                                                    ajouteurR -= image.MatricePixel[i + k, j + l].R;
                                                    ajouteurG -= image.MatricePixel[i + k, j + l].G;
                                                    ajouteurB -= image.MatricePixel[i + k, j + l].B;
                                                }
                                            }



                                        }
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }
                            break;

                        case "3": /// Filtre: Flou
                            for (int i = 3; i < image.TailleX - 3; i++)
                            {
                                for (int j = 3; j < image.TailleY - 3; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -3; k <= 3; k++)
                                    {
                                        for (int l = -3; l <= 3; l++)
                                        {
                                            ajouteurR += image.MatricePixel[i + k, j + l].R;
                                            ajouteurG += image.MatricePixel[i + k, j + l].G;
                                            ajouteurB += image.MatricePixel[i + k, j + l].B;
                                        }
                                    }
                                    MatricePixel[i, j].R = ajouteurR / 49;
                                    MatricePixel[i, j].G = ajouteurG / 49;
                                    MatricePixel[i, j].B = ajouteurB / 49;

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
                break;

                case "4":
                Console.SetCursorPosition(25,7); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:")
                int coeff = Convert.ToInt32(Console.ReadLine());
                while (coeff % 2 = 0)
                {
                Console.Clear();
                Console.SetCursorPosition(25,7); Console.WriteLine("Erreur, votre matrice ne fonctionne pas.")
                Console.SetCursorPosition(25,8); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:")
                coeff = Convert.ToInt32(Console.ReadLine());
                }
                int a = 0;
                while (coeff !=1)
                {
                    coeff -= 2;
                    a++;
                }
                Console.Clear();
                Console.WriteLine("Super! votre matrice ("+coeff+"x"+coeff+") fonctionne avec notre programme");
                
                    Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                    Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                    Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                    Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                    Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                    Console.SetCursorPosition(15, 13); Console.Write("Quel filtre souhaitez-vous?");
                    string answern = Console.ReadLine();
                    switch (answern)
                    {
                        case "1": /// Filtre: Détection de contour
                          for (int i = a; i < image.TailleX - a; i++)
                          {
                             for (int j = a; j < image.TailleY - a; j++)
                             {
                                int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                for (int k = -a; k <= a; k++)
                                {
                                    for (int l = -a; l <= a; l++)
                                    {
                                            if (k == 0 && l == 0)
                                            {
                                                ajouteurR += 8 * image.MatricePixel[i, j].R;
                                                ajouteurG += 8 * image.MatricePixel[i, j].G;
                                                ajouteurB += 8 * image.MatricePixel[i, j].B;
                                            }
                                            else
                                            {
                                                ajouteurR -= image.MatricePixel[i + k, j + l].R;
                                                ajouteurG -= image.MatricePixel[i + k, j + l].G;
                                                ajouteurB -= image.MatricePixel[i + k, j + l].B;
                                            }

                                    }
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                             }
                          }

                        break;

                        case "2":// Filtre: Renforcement des bords
                            for (int i = 1; i < image.TailleX - 1; i++)
                            {
                                for (int j = 1; j < image.TailleY - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                                               
                                    ajouteurR += image.MatricePixel[i, j].R;                                   
                                    ajouteurG += image.MatricePixel[i, j].G;                                    
                                    ajouteurB += image.MatricePixel[i, j].B;
                                    
                                    ajouteurR -= image.MatricePixel[i , j - 1].R;                                    
                                    ajouteurG -= image.MatricePixel[i , j - 1].G;                                    
                                    ajouteurB -= image.MatricePixel[i , j - 1].B;
                                            
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }

                            break;

                        case "3": /// Filtre: Flou
                            for (int i = a; i < image.TailleX - a; i++)
                            {
                                for (int j = a; j < image.TailleY - a; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -a; k <= a; k++)
                                    {
                                        for (int l = -a; l <= a; l++)
                                        {
                                                ajouteurR += image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += image.MatricePixel[i + k, j + l].B;
                                        }
                                    }
                                    MatricePixel[i, j].R = ajouteurR / a*a;
                                    MatricePixel[i, j].G = ajouteurG / a*a;
                                    MatricePixel[i, j].B = ajouteurB / a*a;

                                }
                            }


                            break;

                        case "4": /// Filtre: Repoussage

                            for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                            {
                                for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                                    if (image.MatricePixel[i - 1, j - 1] != null)
                                    {
                                        ajouteurR += (-2) * image.MatricePixel[i - 1, j - 1].R;
                                        ajouteurG += (-2) * image.MatricePixel[i - 1, j - 1].G;
                                        ajouteurB += (-2) * image.MatricePixel[i - 1, j - 1].B;

                                    }

                                    if (image.MatricePixel[i - 1, j] != null)
                                    {
                                        ajouteurR += (-1) * image.MatricePixel[i - 1, j].R;
                                        ajouteurG += (-1) * image.MatricePixel[i - 1, j].G;
                                        ajouteurB += (-1) * image.MatricePixel[i - 1, j].B;

                                    }

                                    if (image.MatricePixel[i - 1, j + 1] != null)
                                    {
                                        ajouteurR += (0) * image.MatricePixel[i - 1, j + 1].R;
                                        ajouteurG += (0) * image.MatricePixel[i - 1, j + 1].G;
                                        ajouteurB += (0) * image.MatricePixel[i - 1, j + 1].B;

                                    }

                                    if (image.MatricePixel[i, j - 1] != null)
                                    {
                                        ajouteurR += (-1) * image.MatricePixel[i, j - 1].R;
                                        ajouteurG += (-1) * image.MatricePixel[i, j - 1].G;
                                        ajouteurB += (-1) * image.MatricePixel[i, j - 1].B;

                                    }

                                    if (image.MatricePixel[i, j] != null)
                                    {
                                        ajouteurR += 1 * image.MatricePixel[i, j].R;
                                        ajouteurG += 1 * image.MatricePixel[i, j].G;
                                        ajouteurB += 1 * image.MatricePixel[i, j].B;

                                    }

                                    if (image.MatricePixel[i, j + 1] != null)
                                    {
                                        ajouteurR += 1 * image.MatricePixel[i, j + 1].R;
                                        ajouteurG += 1 * image.MatricePixel[i, j + 1].G;
                                        ajouteurB += 1 * image.MatricePixel[i, j + 1].B;

                                    }

                                    if (image.MatricePixel[i + 1, j - 1] != null)
                                    {
                                        ajouteurR += (0) * image.MatricePixel[i + 1, j - 1].R;
                                        ajouteurG += (0) * image.MatricePixel[i + 1, j - 1].G;
                                        ajouteurB += (0) * image.MatricePixel[i + 1, j - 1].B;
                                    }

                                    if (image.MatricePixel[i + 1, j] != null)
                                    {
                                        ajouteurR += (1) * image.MatricePixel[i + 1, j].R;
                                        ajouteurG += (1) * image.MatricePixel[i + 1, j].G;
                                        ajouteurB += (1) * image.MatricePixel[i + 1, j].B;
                                    }

                                    if (image.MatricePixel[i + 1, j + 1] != null)
                                    {
                                        ajouteurR += (2) * image.MatricePixel[i + 1, j + 1].R;
                                        ajouteurG += (2) * image.MatricePixel[i + 1, j + 1].G;
                                        ajouteurB += (2) * image.MatricePixel[i + 1, j + 1].B;
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
                                    MatricePixel[i, j].R = ajouteurR;
                                    MatricePixel[i, j].G = ajouteurG;
                                    MatricePixel[i, j].B = ajouteurB;

                                }
                            }
                            break;
                    }
              
            }

            ///On remplit les coins
            MatricePixel[0, 0] = MatricePixel[1, 1];
            MatricePixel[0, 1] = MatricePixel[1, 1];
            MatricePixel[1, 0] = MatricePixel[1, 1]; /// Coin 1

            /*
            MatricePixel[0, image.tailleY] = MatricePixel[1, image.tailleY - 1];
            MatricePixel[0, image.tailleY - 1] = MatricePixel[1, image.tailleY - 1];
            MatricePixel[1, image.tailleY] = MatricePixel[1, image.tailleY - 1]; /// Coin 2

            MatricePixel[image.tailleX, 0] = MatricePixel[image.tailleX - 1, 1];
            MatricePixel[image.tailleX, 1] = MatricePixel[image.tailleX - 1, 1];
            MatricePixel[image.tailleX - 1, 0] = MatricePixel[image.tailleX - 1, 1]; /// Coin 3

            MatricePixel[image.tailleX, image.tailleY] = MatricePixel[image.tailleX - 1, image.tailleY - 1];
            MatricePixel[image.tailleX - 1, image.tailleY] = MatricePixel[image.tailleX - 1, image.tailleY - 1];
            MatricePixel[image.tailleX, image.tailleY - 1] = MatricePixel[image.tailleX - 1, image.tailleY - 1]; /// Coin 4
            
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
            */
            

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



case "1":
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
    for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
    {
        for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
        {
            int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
            int indiceR = 0, indiceG = 0, indiceB = 0;
            if (image.MatricePixel[i - 1, j - 1] != null)
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
**/