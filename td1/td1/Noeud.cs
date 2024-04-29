using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Noeud
    {
        private int frequence;
        private Noeud gauche;
        private Noeud droit;
        private Pixel pix;
        //constructeur pour les feuilles
        public Noeud(int frequence, Pixel pix)
        {
            this.frequence = frequence;
            this.pix = pix;
        }
        //constructeur pour les noeuds internes
        public Noeud(int frequence, Noeud gauche, Noeud droit)
        {
            this.frequence = frequence;
            this.gauche = gauche;
            this.droit = droit;
        }
        
        public int Frequence
        {
            get { return frequence; }
            set { frequence = value; }
        }

        public Noeud Gauche
        {
            get { return gauche; }
            set { gauche = value; }
        }

        public Noeud Droit
        {
            get { return droit; }
            set { droit = value; }
        }

        public Pixel Pix
        {
            get { return pix; }
            set { pix = value; }
        }

        public bool EstFeuille()
        {
            return gauche == null && droit == null;
        }

    }
}
