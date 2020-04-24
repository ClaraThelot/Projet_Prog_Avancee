using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Eleve : Personne
    {
        public int annee;
        public int promo;
        public int groupeTD;

        public Eleve(string Nom, string Prenom, Projet[] Proj) : base(Nom, Prenom, Proj) { }

        public Eleve(string Nom, string Prenom, Projet[] Proj, int Annee, int Promo, int Groupe) : base (Nom, Prenom, Proj)
        {
            annee = Annee;
            promo = Promo;
            groupeTD = Groupe;
        }
        public virtual string ToString()
        {
            string res = "";
            res = res + "Nom : " + nom + "/n";
            res = res + "Prénom : " + prenom + "/n";
            res = res + "Année : " + annee + "/n";
            res = res + "Promo " + promo+"/n";
            res = res + "Groupe de TD : " + groupeTD + "/n";
            res = res + "Liste des projets en cours : /n";
            for (int i = 1; i < projet.Length + 1; i++)
            {
                res = res + "Projet n°" + i + " : " + projet[i - 1] + "/n";
            }

            return res;
        }
    }
}
