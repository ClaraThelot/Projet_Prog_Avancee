using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Eleve : Personne
    {
            public string _annee;
            public int _promo;
            public int _groupeTD;

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

