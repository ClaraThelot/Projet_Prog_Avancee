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
            
        public Eleve(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

            public Eleve(string Nom, string Prenom, List<Projet> Proj, string Annee, int Promo, int Groupe) : base(Nom, Prenom, Proj)
            {
                _annee = Annee;
                _promo = Promo;
                _groupeTD = Groupe;
            }

        public void ajoutProjet(Projet P1)
        {
            int i = 0;
            int place = 0;
            foreach(Projet element in projet)
            {
                if (projet[i] != null) { place = i; }
                i++;
            }
            projet[place] = P1;

        }
        public void supprimeProjet(Projet P1)
        {
            int i = 0;
            int place = 0;
            foreach (Projet element in projet)
            {
                if (projet[i] == P1) { place = i; }
                i++;
            }
                projet[place] = null; 
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
                int i = 0;
                /*foreach(Projet element in projet)
                {
                    res = res + "Projet n°" + i + " : " + projet[i].ToString() + "\n";
                    i++;
                }*/

                return res;
            }
        }
    }

