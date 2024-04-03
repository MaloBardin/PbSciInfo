using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Agrandissement
    {
        public void MultiplicationMatrice(Image ImageEnCours, int CoefAggrandissement)
        {
            //modif de l'header pour mettre la bonne taille
            /*int tailleX = BitConverter.ToInt32(ImageEnCours.Header[18]);
            int tailleY = BitConverter.ToInt32(ImageEnCours.Header[22]);
            ImageEnCours.Header[18] = tailleX * CoefAggrandissement;
            ImageEnCours.Header[22] = tailleY * CoefAggrandissement; // A FINIR*/

        }


    }
}
