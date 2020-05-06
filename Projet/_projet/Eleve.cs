using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Eleve : Personne
    {
            public string _annee{ get; set; }
            public int _promo { get; set; }
            public int _groupeTD { get; set; }
        public Eleve() { }

        public Eleve(string Nom, string Prenom, string annee, int promo, int groupeTD) : base (Nom, Prenom) {
            _annee = annee;
            _promo = promo;
            _groupeTD = groupeTD;
        }
            
        public Eleve(string Nom, string Prenom, Projet[] Proj) : base(Nom, Prenom, Proj) { }

            public Eleve(string Nom, string Prenom, Projet[] Proj, string Annee, int Promo, int Groupe) : base(Nom, Prenom, Proj)
            {
                _annee = Annee;
                _promo = Promo;
                _groupeTD = Groupe;
            }

        public void ajoutProjet(Projet P1)
        {
            for (int i = 0; i < projet.Length; i++)
            {
                if (projet[i] != null) { projet[i] = P1; }
            }
        }
        public void supprimeProjet(Projet P1)
        {
            for (int i = 0; i < projet.Length; i++)
            { if (projet[i] == P1) projet[i] = null; }
        }
        public override string ToString()
            {
                string res = "";
                res = res + "Nom : " + nom + "\n";
                res = res + "Prénom : " + prenom + "\n";
                res = res + "Année : " + _annee + "\n";
                res = res + "Promo " + _promo + "\n";
                res = res + "Groupe de TD : " + _groupeTD + "\n";
                res = res + "Liste des projets en cours : \n";
                /*for (int i = 1; i < projet.Length + 1; i++)
                {
                    res = res + "Projet n°" + i + " : " + projet[i - 1] + "/n";
                }*/

                return res;
            }
        }
    }

