using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Fractale
    {
        public Fractale()
        {

        }
        public Pixel[,] FractaleMandelbrot(int tailleX, int tailleY, int nbIterations, byte bleu, byte vert, byte rouge, bool chaleur)
        {
            // on met les tailles données comme multiple de 4 au cas où
            while (tailleX % 4 != 0)
            {
                tailleX++;
            }
            while (tailleY % 4 != 0)
            {
                tailleY++;
            }
            //création de la matrice
            Pixel[,] matrice = new Pixel[tailleX, tailleY];


            // définition du centre de l'image
            int centreX = 2 * tailleX / 3; //on décale le x à 2/3 pour que ce soit plus joli
            int centreY = tailleY / 2;
            
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    //on définit les coordonnées de z
                    // z est un nombre complexe de la forme reelZ + i*imZ et z0 est le point de départ
                    // z0 est une constante

                    double reelZ = 1.5 * (x - centreX) / (0.5 * tailleX);
                    double imZ = (y - centreY) / (0.5 * tailleY);
                    double reelZ0 = reelZ;
                    double imZ0 = imZ;
                    int i = 0;
                    while (i < nbIterations && reelZ * reelZ + imZ * imZ < 4) // on teste si le module de z est inférieur à 2 et si on a pas dépassé le nombre d'itérations
                    {
                        // récurrence de Mandelbrot (zn+1 = zn^2 + z0)
                        double reelZTemp = reelZ; // on stocke reelZ dans une variable temporaire pour ne pas écraser la valeur de reelZ dans le calcul de imZ
                        reelZ = reelZTemp * reelZTemp - imZ * imZ + reelZ0;
                        imZ = 2 * reelZTemp * imZ + imZ0; 
                        
                        i++;
                    }
                    // on passe au coloriage de la matrice

                    // si on a dépassé le nombre d'itérations (c'est à dire si le module a toujours été inférieur à 4), on noircit le pixel
                    if (i == nbIterations) 
                    {
                        matrice[x, y] = new Pixel(0, 0, 0);
                    }
                    // sinon on colorie le pixel 
                    else
                    {
                        if (chaleur == false) // si on ne veut pas de dégradé de couleur
                        {
                            matrice[x, y] = new Pixel(bleu, vert, rouge);
                        }
                        else // si on veut un dégradé de couleur en fonction du nombre d'itérations
                        {
                            // on définit la couleur rouge en fonction du nombre d'itérations pour donner un sens de chaleur quand on s'approche du noir
                            byte degrade = Convert.ToByte(i * 255 / nbIterations);
                            matrice[x, y] = new Pixel(bleu, vert, degrade);
                        }
     
                    }
                }
            }

            return matrice;
        }

        


        }
    }

