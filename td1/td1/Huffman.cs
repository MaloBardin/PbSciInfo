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
        private Dictionary<string, int> dicofrequences;
        private Dictionary<string, string> dico;
        List<Noeud> feuilles;
        List<Noeud> feuillesavider;
        List<Noeud> noeuds;
        List<Noeud> noeudsavider;


        public Huffman(Noeud racine)
        {
            this.racine = racine;
            dico = new Dictionary<string, string>();
            //Parcours(racine, "");
        }
        public Huffman(Pixel[,] MatricePixel)
        {
            this.MatricePixel = MatricePixel;
            dicofrequences = new Dictionary<string, int>();
            dico = new Dictionary<string, string>();
            feuilles = new List<Noeud>();
            feuillesavider = new List<Noeud>();
            noeuds = new List<Noeud>();
            noeudsavider = new List<Noeud>();
        }
        // parcours de la matrice pour remplir le dico de fréquences
        public void RemplissageDicoFq(Pixel[,] MatricePixel)
        {
            foreach (Pixel p in MatricePixel)
            {
                string strpix = p.ToString();
                if (!dicofrequences.ContainsKey(strpix))
                {
                    dicofrequences.Add(strpix, 1);
                }
                else
                { dicofrequences[strpix]++; }
            }

        }

        // remplissage du dico
        public void RemplissageDico()
        {
            foreach (KeyValuePair<string, int> entree in dicofrequences)
            {
                dico.Add(entree.Key, "");
            }
        }
        //création de tous les noeuds feuilles (aka les pixels)
        public void CreerFeuilles()
        {
            foreach (KeyValuePair<string, int> entry in dicofrequences)
            {
                feuilles.Add(new Noeud(entry.Value, AntiToStringPixel(entry.Key)));
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

                int fq1 = n1.Frequence;
                int fq2 = n2.Frequence;
                int fq = fq1 + fq2;
                Noeud n1g = n1.Gauche;
                Noeud n1d = n1.Droit;
                Noeud n2g = n2.Gauche;
                Noeud n2d = n2.Droit;
                // ajout des noeuds n1 et n2 à la liste des noeuds (pour les garder quelque part)
                noeuds.Add(new Noeud(fq1, n1g, n1d));
                noeudsavider.RemoveAt(noeudsavider.Count - 1);
                noeuds.Add(new Noeud(fq2, n2g, n2d));
                noeudsavider.RemoveAt(noeudsavider.Count - 1);


                //suppression des noeuds n1 et n2 de la liste des noeuds à vider
                noeudsavider.RemoveAt(0);
                noeudsavider.RemoveAt(1);
                //ajout du nouveau noeud à la liste des noeuds à vider
                noeudsavider.Add(new Noeud(fq, n1, n2));

            }
            racine = noeudsavider[0];
            noeuds.Add(racine);
        }

        private int ComparerNoeudsParFrequence(Noeud x, Noeud y)
        {
            return x.Frequence.CompareTo(y.Frequence);
        }


        //récursif, parcours de l'arbre pour remplir le dico
        private void Parcours(Noeud n, string s = "")
        {
            if (n.EstFeuille())
            {
                dico.Add(n.Pix.ToString(), s);
            }
            else
            {
                Parcours(n.Gauche, s + "0");
                Parcours(n.Droit, s + "1");
            }
        }

        // Encodage de l'image
        // On parcourt l'image et on remplace chaque pixel par son code binaire




        
        public void AfficherDico()
        {
            foreach (KeyValuePair<string, string> entry in dico)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }


        public string EncodageImage(Pixel[,] MatricePixel)
        {
            RemplissageDicoFq(MatricePixel);
            RemplissageDico();
            CreerFeuilles();
            CreerArbre();

            Parcours(racine);

            string res = "";

            foreach (Pixel p in MatricePixel)
            {
                res += Convert.ToString(dico[p.ToString()]);
            }
            return res;
        }
        public Pixel[,] Decodage(string resultat, int tailleX, int tailleY)
        {
            Pixel[,] res = new Pixel[tailleX, tailleY];
            int x = 0;
            int y = 0;
            string s = "";
            // parcours de la chaine de caractères
            foreach (char c in resultat)
            {

                s += c;
                foreach (KeyValuePair<string, string> entry in dico)
                {
                    // si la valeur du dico est égale à s, on ajoute la clé correspondante à la matrice
                    if (entry.Value == s)
                    {
                        res[x, y] = AntiToStringPixel(entry.Key);
                        // on réinitialise s pour recommencer à zéro 
                        s = "";
                        // incrémente x ou y en fonction de la position pour se balader dans la matrice
                        // équivalent à une double boucle for imbriquée
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
                }
            }
            return res;
        }
        public void AffichageDicoImage(Pixel[,] MatricePixel)
        {
            RemplissageDicoFq(MatricePixel);
            CreerFeuilles();
            CreerArbre();
            Parcours(racine);
            AfficherDico();
        }
        public void AfficherDicoFq()
        {
            foreach (KeyValuePair<string, int> entry in dicofrequences)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }
        public void AffichageDicoFqImage(Pixel[,] MatricePixel)
        {
            RemplissageDicoFq(MatricePixel);
            AfficherDicoFq();
        }
        public Pixel AntiToStringPixel(string strpix)
        {
            string[] tab = strpix.Split(' ');
            byte r = Convert.ToByte(tab[0].Substring(1));
            byte g = Convert.ToByte(tab[1].Substring(1));
            byte b = Convert.ToByte(tab[2].Substring(1));
            return new Pixel(b, g, r);
        }

    }
}

