using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace td1
{
    internal class Image
    {

        
        public Pixel[,] MatricePixel;
        public byte[] Header;
        public int tailleX;
        public int tailleY;
        public int tailleFichier;
        public int tailleImage;
        public int nombreBits;
        public int decalage;// ENELVER PUBLIC

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



        public Pixel[,] Lecture(string filename)
        {
            byte[] fichier = File.ReadAllBytes(filename);
            Header = new byte[54];


            for (int i = 0; i < 54; i++)
            {
                Header[i] = fichier[i];
            }
            Console.WriteLine();
            tailleX = BitConverter.ToInt32(fichier, 18); // LITTLE INDIAN SVPPP
            tailleY = BitConverter.ToInt32(fichier, 22);
            Console.WriteLine("Largeur de l'image : " + tailleX);
            Console.WriteLine("Hauteur de l'image : " + tailleY);
            MatricePixel = new Pixel[tailleX, tailleY];
            int TailleMatriceX = 0;
            int TailleMatriceY = 0;
            for (int i = 54; i < fichier.Length; i = i + 3)
            {
                if (TailleMatriceY >= tailleY)
                {
                    TailleMatriceX++; //on augmente de 1 la hauteur
                    TailleMatriceY = 0; //on remet x a 0

                    if (TailleMatriceX >= tailleX)
                    {

                        break; // on detecte la fin de l'image (on est en dehors des limites de l'image)
                    }
                }

                MatricePixel[TailleMatriceX, TailleMatriceY] = new Pixel(fichier[i], fichier[i + 1], fichier[i + 2]);
                TailleMatriceY++; // on incremente pour aller a droite automatiquement

            }




            return MatricePixel;
        }

    
        public void PrintImage(string filename) { 
        
            Console.WriteLine("\n\n\n fichier image Matrice");
            for (int i = 0; i < tailleY; i++)
            {
                for (int j = 0; j < tailleX; j++)
                {

                    Console.Write(MatricePixel[j, i].R + " ");
                    Console.Write(MatricePixel[j, i].G + " ");
                    Console.Write(MatricePixel[j, i].B + " ");
                }
                Console.WriteLine();
            }




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

            Array.Copy(newHeader, 2, Int2ToByte(ImageAvecLeHeader.tailleFichier),0,4);

           
            ImageAvecLeHeader.tailleX=ImageAvecLeHeader.MatricePixel.GetLength(0);
            ImageAvecLeHeader.tailleY=ImageAvecLeHeader.MatricePixel.GetLength(1); // on remet la bonne taille au cas ou


            Array.Copy(Int2ToByte(ImageAvecLeHeader.MatricePixel.GetLength(0)), 0, cacao, 18, 4);
            Array.Copy(Int2ToByte(ImageAvecLeHeader.MatricePixel.GetLength(1)), 0, cacao, 22, 4);
            byte[] tailleImage = Int2ToByte((ImageAvecLeHeader.tailleX * ImageAvecLeHeader.tailleY * 3));
            Array.Copy(tailleImage, 0 , cacao, 37, 4);


            return cacao;
        }










        public void SauvegardeImage(string wantedFileName, string file, Image Imagesauvegardee)
        {
            // Construction du header du fichier BMP
            byte[] header = BuildLeBonHeader(Imagesauvegardee);
            Imagesauvegardee.Header = header; // on update avec notre nouvel header
            // Création du tableau de bytes pour le fichier BMP en incluant le header
            byte[] fichier = new byte[header.Length + (Imagesauvegardee.MatricePixel.GetLength(0) * Imagesauvegardee.MatricePixel.GetLength(1) * 3)];

            // Copie du header dans le tableau fichier
            Array.Copy(header,0, fichier,0, header.Length);


            int a = 54; // Position de début des données de pixel dans le fichier BMP

            // Copie des données de pixel dans le fichier BMP
            for (int i = 0; i < Imagesauvegardee.tailleX; i++)
            {
                for (int j = 0; j < Imagesauvegardee.tailleY; j++)
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