using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td1
{
    internal class Huffman
    {
        Image dessin;
        Pixel[,] MatricePixel;
        
        private Noeud racine;
        private Dictionary<Pixel, int> dicofrequences;
        private Dictionary<Pixel, string> dico;
        List<Noeud> feuilles;
        List<Noeud> feuillesavider;
        List<Noeud> noeuds;
        List<Noeud> noeudsavider;

        public Huffman(Noeud racine)
        {
            this.racine = racine;
            dico = new Dictionary<Pixel, string>();
            Parcours(racine, "");
        }
        // parcours de la matrice pour remplir le dico de fréquences
        public void RemplissageDicoFq(Pixel[,] MatricePixel)
        {
                    foreach (Pixel p in MatricePixel)
                    {
                        if (!dicofrequences.ContainsKey(p))
                        {
                            dicofrequences.Add(p, 1);
                        }
                        else
                        { dicofrequences[p]++; }
                    }
                    
        }

        // remplissage du dico
        public void RemplissageDico()
        {
            foreach (KeyValuePair<Pixel, int> entree in dicofrequences)
            {
                dico.Add(entree.Key, "");
            }
        }
//création de tous les noeuds feuilles (aka les pixels)
        public void CreerFeuilles()
        {
            foreach (KeyValuePair<Pixel, int> entry in dicofrequences)
            {
                feuilles.Add(new Noeud(entry.Value, entry.Key));
            }
            feuillesavider = feuilles;
            noeuds = feuilles;
            noeudsavider = feuilles;
        }
        //création de l'arbre
        public void CreerArbre()
        {
            while (noeudsavider.Count > 1)
            {
                //tri des noeuds par fréquence
                noeudsavider.Sort(ComparerNoeudsParFrequence);
                //création d'un nouveau noeud avec les deux premiers noeuds de la liste noeudsavider
                Noeud n1 = noeudsavider[0];
                Noeud n2 = noeudsavider[1];
                
                // ajout des noeuds n1 et n2 à la liste des noeuds (pour les garder quelque part)
                noeuds.Add(n1);
                noeuds.Add(n2);

                //suppression des noeuds n1 et n2 de la liste des noeuds à vider
                noeudsavider.Remove(n1);
                noeudsavider.Remove(n2);
                //ajout du nouveau noeud à la liste des noeuds à vider
                noeudsavider.Add(new Noeud(n1.Frequence + n2.Frequence, n1, n2));

            }
            racine = noeudsavider[0];
            noeuds.Add(racine);
        }

        // Comparaison de deux noeuds par leur fréquence
        private int ComparerNoeudsParFrequence(Noeud x, Noeud y)
        {
            return x.Frequence.CompareTo(y.Frequence);
        }
        
        private void Parcours(Noeud n, string s = "")
        {
            if (n.EstFeuille())
            {
                dico.Add(n.Pix, s);
            }
            else
            {
                Parcours(n.Gauche,s + "0");
                Parcours(n.Droit, s + "1");
            }
        }



        // Encodage de l'image
        // On parcourt l'image et on remplace chaque pixel par son code binaire
        
        public string Encodage(Pixel[,] MatricePixel)
        {
            string res = "";

            foreach (Pixel p in MatricePixel)
            {
                res += Convert.ToString(dico[p]);
            }
            return res;
        }

        public Pixel[,] Decodage(string entree, int tailleX, int tailleY)
        {
            Pixel[,] ResPixels = new Pixel[tailleX, tailleY];
            Noeud n = racine;
            int x = 0;
            int y = 0;
            foreach (char c in entree)
            {
                while(n.EstFeuille() == false)
                {
                    if (c == '0')
                    {
                        n = n.Gauche;
                    }
                    else
                    {
                        n = n.Droit;
                    }
                }
                ResPixels[x, y] = n.Pix;
                if (x == tailleX - 1)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
            }
            return ResPixels;
        }
 
        public void AfficherDico()
        {
            foreach (KeyValuePair<Pixel, string> entry in dico)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void AfficherDicoFq()
        {
            foreach (KeyValuePair<Pixel, int> entry in dicofrequences)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }
         
    }
}