using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace td1
{
    internal class Huffman
    {
        private Noeud racine;
        private Dictionary<int, Pixel> dico;

        public Huffman(Noeud racine)
        {
            this.racine = racine;
            dico = new Dictionary<int, Pixel>();
            Parcours(racine, "");
        }

       /* private void Parcours(Noeud n, string s)
        {
            if (n.EstFeuille())
            {
                dico.Add(n.Valeur, s);
            }
            else
            {
                Parcours(n.Gauche, s + "0");
                Parcours(n.Droit, s + "1");
            }
        }

        public string Encodage(byte[] data)
        {
            string res = "";
            foreach (byte b in data)
            {
                res += dico[b];
            }
            return res;
        }

        public byte[] Decodage(string data)
        {
            List<byte> res = new List<byte>();
            Noeud n = racine;
            foreach (char c in data)
            {
                if (c == '0')
                {
                    n = n.Gauche;
                }
                else
                {
                    n = n.Droit;
                }
                if (n.EstFeuille())
                {
                    res.Add(n.Valeur);
                    n = racine;
                }
            }
            return res.ToArray();
        }
    }
}
*/