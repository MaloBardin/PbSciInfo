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
        Pixel[,] Matricefiltre = new Pixel[3,3];
        public Filtre(Image image, Image imagefiltre)
        {
            this.image = image;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Quel filtre souhaitez-vous?:");
            string num = Console.ReadLine();
            switch(num)
            {
                case "1":
                    Console.WriteLine("Quel degré de détection de contour voulez-vous?");
                    string degre = Console.ReadLine();
                    switch (degre)
                    {
                        case "1":
                            Matricefiltre = []
                        break;
                    }
                break;



            }
        }
        
        
        switch

    }
}
