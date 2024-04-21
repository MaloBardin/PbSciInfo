using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        public Image()
        {
            // création vide
        }
        public Image(Pixel[,] MatricePixel, byte[] Header, int tailleX, int tailleY, int tailleFichier, int tailleImage, int nombreBits, int decalage)
        { 
            this.MatricePixel = MatricePixel;
            this.Header = Header;
            this.tailleX = tailleX;
            this.tailleY = tailleY;
            this.tailleFichier = tailleFichier;
            this.tailleImage = tailleImage;
            this.nombreBits=nombreBits;
            this.decalage = decalage;
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

        public void Agrandissement(int coefficient)
        {
            int largeurApresCoef = this.tailleX * coefficient;
            int hauteurApresCoef = this.tailleY * coefficient;

            Pixel[,] MatriceAgrandie = new Pixel[largeurApresCoef,hauteurApresCoef];

            for (int i=0; i< largeurApresCoef; i++)
            {
                for (int j = 0; j < hauteurApresCoef; j++)
                {
                    int posX = i  / coefficient;
                    int posY = j / coefficient;
                    MatriceAgrandie[i, j] = this.MatricePixel[i/coefficient,j/coefficient];
                }
            }
                



            this.MatricePixel = MatriceAgrandie;
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