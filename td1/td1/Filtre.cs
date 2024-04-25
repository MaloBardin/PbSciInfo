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
            Pixel[,] MatricePixel = new Pixel[image.TailleX, image.TailleY]; 

            for (int i = 0; i < image.TailleX; i++)
            {
                for (int j = 0; j < image.TailleY; j++)
                {
                    MatricePixel[i, j] = new Pixel(0, 0, 0); /// On initialise notre matrice de sorte a qu'il soit rempli de pixels noirs
                }
            }

            Console.SetCursorPosition(25,7); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:");
            int coeff = Convert.ToInt32(Console.ReadLine());
            while (coeff % 2 == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(25,7); Console.WriteLine("Erreur, votre matrice n'est pas impair.");
                Console.SetCursorPosition(25,8); Console.WriteLine("Veuillez entrer la taille de la matrice souhaitée:");
                coeff = Convert.ToInt32(Console.ReadLine());
            }
            int copy = coeff;
            int a = 0;
            while (coeff !=1)
            {
                coeff -= 2;
                a++;
            }
            Console.Clear();
            Console.WriteLine("Super! votre matrice ("+copy+"x"+copy+") fonctionne avec notre programme");
                
            Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
            Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
            Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
            Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
            Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
            Console.SetCursorPosition(15, 13); Console.Write("Quel filtre souhaitez-vous?");
            Console.SetCursorPosition(15, 14); string answern = Console.ReadLine();
            while (answern != "1" && answern != "2" && answern != "3" && answern != "4") 
            {
                Console.Clear();
                Console.SetCursorPosition(25, 7); Console.WriteLine("Vos choix sont:");
                Console.SetCursorPosition(25, 8); Console.WriteLine("1.Détection de contour");
                Console.SetCursorPosition(25, 9); Console.WriteLine("2.Renforcement des bords");
                Console.SetCursorPosition(25, 10); Console.WriteLine("3.Flou");
                Console.SetCursorPosition(25, 11); Console.WriteLine("4.Repoussage");
                Console.SetCursorPosition(15, 13); Console.WriteLine("Votre choix n'est pas valide. Veuillez réessayer:");
                Console.SetCursorPosition(15, 14); answern = Console.ReadLine();
            }
            Console.Clear();
            switch (answern)                    
            {          
                case "1": /// Filtre: Détection de contour                                          
                    int[,] MatriceConvContour = new int[copy, copy];
                    if (copy != 3 && copy != 5)                          
                    {                           
                        for (int i = 0; i < copy; i++)
                        {                             
                            for (int j = 0; j < copy; j++)                            
                            {                             
                                Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);                  
                                MatriceConvContour[i, j] = Convert.ToInt32(Console.ReadLine());                           
                                Console.Clear();                                   
                            }                               
                        }      
                    }
                            if (copy == 3) 
                            {
                                Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                                Thread.Sleep(3000);
                                MatriceConvContour = new int[,]
                                {
                                   {-1,-1,-1},
                                   {-1, 8,-1},
                                   {-1,-1,-1}
                                };
                            }
                            if (copy == 5)
                            {
                                Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                                Thread.Sleep(3000);
                                MatriceConvContour = new int[,]
                                {
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0, 4, 0, 0},
                                   { 0, 0,-1, 0, 0},
                                   { 0, 0,-1, 0, 0},
                                };
                            }

                            for (int i = a; i < image.TailleX - a; i++)
                                {
                                    for (int j = a; j < image.TailleY - a; j++)
                                    {
                                        int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;
                                  
                                        for (int k = -a; k <= a; k++)
                                        {
                                            for (int l = -a; l <= a; l++)
                                            {
                                                ajouteurR += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += MatriceConvContour[a + k, a + l] * image.MatricePixel[i + k, j + l].B;                                           
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
                            Console.Clear();

                            int[,] MatriceConvRenfort = new int[copy, copy];
                            if (copy != 3)
                            {
                                for (int i = 0; i < copy; i++)
                                {
                                    for (int j = 0; j < copy; j++)
                                    {
                                        Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);
                                        MatriceConvRenfort[i, j] = Convert.ToInt32(Console.ReadLine());
                                        Console.Clear();
                                    }
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                                Thread.Sleep(3000);
                                MatriceConvRenfort = new int[,]
                                {
                                   { 0, 0, 0},
                                   {-1, 1, 0},
                                   { 0, 0, 0}
                                };
                            }

                            for (int i = a; i < image.TailleX - a; i++)
                            {
                                for (int j = a; j < image.TailleY - a; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                    for (int k = -a; k <= a; k++)
                                    {
                                        for (int l = -a; l <= a; l++)
                                        {
                                                ajouteurR += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += MatriceConvRenfort[a + k, a + l] * image.MatricePixel[i + k, j + l].B;                                           
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
                                    
                                    
                                    MatricePixel[i, j].R = ajouteurR / (copy*copy);
                                    MatricePixel[i, j].G = ajouteurG / (copy*copy);
                                    MatricePixel[i, j].B = ajouteurB / (copy*copy);

                                }
                            }
                        break;

                        case "4": /// Filtre: Repoussage
                            Console.Clear();

                            int[,] MatriceConvRepoussage = new int[copy, copy];
                            if (copy != 3 )
                            {
                                for (int i = 0; i < copy; i++)
                                {
                                    for (int j = 0; j < copy; j++)
                                    {
                                        Console.WriteLine("Veuillez saisir la valeur de la ligne" + i + " et de la colonne " + j);
                                        MatriceConvRepoussage[i, j] = Convert.ToInt32(Console.ReadLine());
                                        Console.Clear();
                                    }
                                }
                            }
                            else
                            {
                               Console.SetCursorPosition(25, 7); Console.WriteLine("On a déjà une matrice filtre pour (3x3)");
                               Thread.Sleep(3000);
                               MatriceConvRepoussage = new int[,] 
                               { 
                                   {-2,-1, 0},                                 
                                   {-1, 1, 1},                                
                                   { 0, 1, 2} 
                               };
                            }
                            for (int i = 1; i < image.MatricePixel.GetLength(0) - 1; i++)
                            {
                                for (int j = 1; j < image.MatricePixel.GetLength(1) - 1; j++)
                                {
                                    int ajouteurR = 0, ajouteurG = 0, ajouteurB = 0;

                                        for (int k = -a; k <= a; k++)
                                        {
                                            for (int l = -a; l <= a; l++)
                                            {
                                                ajouteurR += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].R;
                                                ajouteurG += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].G;
                                                ajouteurB += MatriceConvRepoussage[a + k, a + l] * image.MatricePixel[i + k, j + l].B;
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
            }
            return MatricePixel;
                
        }
     
    }
}