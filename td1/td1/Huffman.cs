﻿using System;
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

                // ajout des noeuds n1 et n2 à la liste des noeuds (pour les garder quelque part)
                noeuds.Add(new Noeud(n1.Frequence, n1.Gauche, n1.Droit));
                noeuds.Add(new Noeud(n2.Frequence, n2.Gauche, n2.Droit));


                //suppression des noeuds n1 et n2 de la liste des noeuds à vider
                noeudsavider.RemoveAt(0);
                noeudsavider.RemoveAt(1);
                //ajout du nouveau noeud à la liste des noeuds à vider
                noeudsavider.Add(new Noeud(n1.Frequence + n2.Frequence, n1, n2));

            }
            racine = noeudsavider[0];
            noeuds.Add(racine);
        }

        private int ComparerNoeudsParFrequence(Noeud x, Noeud y)
        {
            return x.Frequence.CompareTo(y.Frequence);
        }



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
            foreach (char c in resultat)
            {
                string s = "";
                s += c;
                foreach (KeyValuePair<string, string> entry in dico)
                {
                    if (entry.Value == s)
                    {
                        res[x, y] = AntiToStringPixel(entry.Key);
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

