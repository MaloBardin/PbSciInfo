using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace td1
{
    internal class Image
    {

        Pixel[,] matricePixel;
        byte[] header;
        int tailleX;
        int tailleY;
        int tailleFichier;
        int tailleImage;

        public Pixel[,] MatricePixel
        {
            get { return matricePixel; }
            set { matricePixel = value; }
        }

        public byte[] Header
        {
            get { return header; }
            set { header = value; }
        }

        public int TailleX
        {
            get { return tailleX; }
            set { tailleX = value; }
        }
        public int TailleY
        {
            get { return tailleY; }
            set { tailleY = value; }
        }

        public int TailleFichier
        {
            get { return tailleFichier; }
            set { tailleFichier = value; }
        }

        public int TailleImage
        {
            get { return tailleImage; }
            set { tailleImage = value; }
        }



        public Image()
        {
            // création vide
        }

        public Pixel PixelEnGris(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B) / 3;
            gris.R = valeur;
            gris.G = valeur;
            gris.B = valeur;
            return gris;
        }

        public Pixel PixelEnNoir(Pixel couleur)
        {
            Pixel gris = couleur;
            int valeur = (couleur.R + couleur.G + couleur.B) / 3;
            if (valeur < 125)
            {
                gris.R = 0; gris.B=0; gris.G = 0;
            } else
            {
                gris.R = 255; gris.B = 255; gris.G = 255;
            }
            return gris;
        }


        public Image ImageEnNoir(Image dessin)

        {
            Pixel[,] pixelNoir = new Pixel[dessin.MatricePixel.GetLength(0), dessin.MatricePixel.GetLength(1)];

            for (int i = 0; i < dessin.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < dessin.MatricePixel.GetLength(1); j++)
                {
                    pixelNoir[i, j] = PixelEnNoir(dessin.MatricePixel[i, j]);
                }
            }

            dessin.MatricePixel = pixelNoir;

            return dessin;
        }


        public Image ImageEnGris(Image dessin)

        {
            Pixel[,] pixelGris = new Pixel[dessin.MatricePixel.GetLength(0), dessin.MatricePixel.GetLength(1)];

            for (int i = 0; i < dessin.MatricePixel.GetLength(0); i++)
            {
                for (int j = 0; j < dessin.MatricePixel.GetLength(1); j++)
                {
                    pixelGris[i, j] = PixelEnGris(dessin.MatricePixel[i, j]);
                }
            }

            dessin.MatricePixel = pixelGris;

            return dessin;
        }



        public Image(Pixel[,] MatricePixel, byte[] Header, int tailleX, int tailleY, int tailleFichier, int tailleImage)
        { 
            this.MatricePixel = MatricePixel;
            this.Header = Header;
            this.tailleX = tailleX;
            this.tailleY = tailleY;
            this.tailleFichier = tailleFichier;
            this.tailleImage = tailleImage;
        }


        public byte[] Int2ToByte(int nombre)

        {
            byte[] byteTab = new byte[4];
            byteTab[0] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[1] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[2] = (byte)(nombre % 256);
            nombre = nombre / 256;
            byteTab[3] = (byte)(nombre % 256);

            return byteTab;
        }

        public int Byte2Int(byte[] tabByte)
        {
            int resultat = 0;
            resultat = resultat + tabByte[0] * 1;
            resultat = resultat + tabByte[1] * 256;
            resultat = resultat + tabByte[2] * 256 * 256;
            resultat = resultat + tabByte[3] * 256 * 256 * 256;
            return resultat;
        }


        public void RotationDegre(int degre)
        {
           
            double rad = degre * Math.PI / 180.0;

            // Calcul des dimensions de l'image de sortie
            // nouvelle taille x = taille x * |cos(rad)| + taille y * |sin(rad)|
            // nouvelle taille y = taille x * |sin(rad)| + taille y * |cos(rad)|


            int nvtailleX = Convert.ToInt32(tailleX * Math.Abs(Math.Cos(rad)) + tailleY * Math.Abs(Math.Sin(rad)));
            int nvtailleY = Convert.ToInt32(tailleX * Math.Abs(Math.Sin(rad)) + tailleY * Math.Abs(Math.Cos(rad)));

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
            int centreX = tailleX / 2;
            int centreY = tailleY / 2;

            // Calcul des coordonnées du centre de l'image de sortie
            int nvcentreX = nvtailleX / 2;
            int nvcentreY = nvtailleY / 2;


            // Parcourir tous les pixels de l'image d'entrée et les placer dans l'image de sortie
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    // Calcul des coordonnées du pixel dans l'image de sortie
                    // nouveau x = (x - centreX) * cos(rad) - (y - centreY) * sin(rad) + nvcentreX
                    // nouveau y = (x - centreX) * sin(rad) + (y - centreY) * cos(rad) + nvcentreY
                    // on rajoute les nouveaux centres pour recentrer l'image autour du centre et pas en 0,0

                    int nvx = Convert.ToInt32(((x - centreX) * Math.Cos(rad) - (y - centreY) * Math.Sin(rad) + nvcentreX));
                    int nvy = Convert.ToInt32(((x - centreX) * Math.Sin(rad) + (y - centreY) * Math.Cos(rad) + nvcentreY));

                    // Copier le pixel de l'image d'entrée dans l'image de sortie si les coordonnées sont valides
                    if (nvx >= 0 && nvx < nvtailleX && nvy >= 0 && nvy < nvtailleY)
                    {
                        imageTournee[nvx, nvy] = MatricePixel[x, y];
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
            MatricePixel = imageTournee;

        }













        public void Agrandissement(int CoefAggrandissement)
        {
            
            Pixel[,] matriceAgrandie = new Pixel[tailleX * CoefAggrandissement, tailleY * CoefAggrandissement];//on créée une matrice agarandie

            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++) //balade matrice classique
                {
                    for (int k = 0; k < CoefAggrandissement; k++) 
                    {
                        for (int l = 0; l < CoefAggrandissement; l++)
                        {
                            matriceAgrandie[i * CoefAggrandissement + l, j * CoefAggrandissement + k] = MatricePixel[i, j];
                        }
                    }
                }
            }

            tailleX = tailleX * CoefAggrandissement;
            tailleY = tailleY * CoefAggrandissement;
            MatricePixel = matriceAgrandie; //on change notre matrice ainsi que les tailles de l'image
        }



        public Pixel[,] Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);
            Header = new byte[54];

            for (int i = 0; i < 54; i++)
            {
                Header[i] = fichier[i];
            }


            Console.WriteLine();
            tailleX = BitConverter.ToInt32(fichier, 18);// LITTLE INDIAN SVPPP
            tailleY = BitConverter.ToInt32(fichier, 22);// LITTLE INDIAN SVPPP
            Console.WriteLine("Largeur de l'image : " + tailleX);
            Console.WriteLine("Hauteur de l'image : " + tailleY);
            MatricePixel = new Pixel[tailleX, tailleY];
            int TailleMatriceX = 0;
            int TailleMatriceY = 0;
            int a = 54;
            for (int y=0; y < tailleY; y++)
            {
                for (int x=0; x < tailleX; x++)
                {
                    MatricePixel[x, y] = new Pixel(fichier[a], fichier[a+1], fichier[a+2]);
                    a = a + 3;
                }
            }
            return MatricePixel;
        }

        public void CorrigerImageApresModif(Image ImageACorriger)
        {

            // taille fichier
            // offset
            // largeur et longueur déja update 
            // nombre bits
            // taille image

            ImageACorriger.tailleX = ImageACorriger.MatricePixel.GetLength(0);

            ImageACorriger.tailleY = ImageACorriger.MatricePixel.GetLength(1);

            ImageACorriger.tailleFichier = tailleX * tailleY * 3 + 54;

            ImageACorriger.tailleImage = ImageACorriger.tailleFichier - 54;


            // FAIRE OFFSET

        }

        public byte[] BuildLeBonHeader(Image ImageAvecLeHeader)
        {
            byte[] newHeader = new byte[54]; // creation d'un tab de byte vide
            newHeader[0] = 66; newHeader[1] = 77; // les deux lettres BM pour bitmap


            byte[] tailleFichierBytes = Int2ToByte(ImageAvecLeHeader.tailleFichier); // t fichier
            Array.Copy(tailleFichierBytes, 0, newHeader, 2, 4);

            for (int i = 6; i < 10; i++)
            {
                newHeader[i] = 0;
            }

            newHeader[10] = 54;
            for (int i = 11; i < 14; i++)
            {
                newHeader[i] = 0;
            }

            newHeader[14] = 40; newHeader[15] = 0; newHeader[16] = 0; newHeader[17] = 0;

            // FLOU AVEC LE 40

            byte[] tailleXBytes = Int2ToByte(ImageAvecLeHeader.tailleX);
            Array.Copy(tailleXBytes, 0, newHeader, 18, 4); // on copie la taillex
            byte[] tailleYBytes = Int2ToByte(ImageAvecLeHeader.tailleY);
            Array.Copy(tailleYBytes, 0, newHeader, 22, 4); // on copie la tailley

            newHeader[26] = 1; newHeader[27] = 0; //nombre plan constant à 1

            newHeader[28] = 24; newHeader[29] = 0; // constant car 24 bits/pixels

            for (int i = 30; i < 34; i++)
            {
                newHeader[i] = 0; // compression =0
            }

            byte[] tailleImageBytes = Int2ToByte(ImageAvecLeHeader.tailleImage);
            Array.Copy(tailleImageBytes, 0, newHeader, 34, 4); // taille image

            newHeader[38] = 0; newHeader[39] = 0; newHeader[40] = 0; newHeader[41] = 0;
            newHeader[42] = 0; newHeader[43] = 0; newHeader[44] = 0; newHeader[45] = 0;

            return newHeader;
        }

        public void SauvegardeImage(string wantedFileName, Image Imagesauvegardee)
        {
            // Construction du header du fichier BMP
            byte[] header = BuildLeBonHeader(Imagesauvegardee);

            // Création du tableau de bytes pour le fichier BMP en incluant le header
            byte[] fichier = new byte[header.Length + (Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3)];

            // Copie du header dans le tableau fichier
            Array.Copy(header, fichier, header.Length);



            int a = header.Length; // Position de début des données de pixel dans le fichier BMP

            // Copie des données de pixel dans le fichier BMP
            for (int j = 0; j < Imagesauvegardee.tailleY; j++)
            {
                for (int i = 0; i < Imagesauvegardee.tailleX; i++)
                {
                    // Copie des composantes de couleur dans le bon ordre (BGR)
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].B);
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].G);
                    fichier[a++] = Convert.ToByte(Imagesauvegardee.MatricePixel[i, j].R);
                }
            }

            // Écriture du fichier BMP
            File.WriteAllBytes(wantedFileName + ".bmp", fichier);
        }

    }
}