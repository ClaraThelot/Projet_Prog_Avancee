using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Exterieur : Personne
    {
        public string metier { get; set; }
        public string entreprise { get; set; }

        public Exterieur (string Nom, string Prenom, string Metier, string Entreprise) : base (Nom, Prenom) {
            metier = Metier;
            entreprise = Entreprise;
        }

        public Exterieur(string Nom, string Prenom, Projet[] Proj) : base(Nom, Prenom, Proj) { }

        public Exterieur(string Nom, string Prenom, Projet[] Proj, string Metier, string Entreprise) : base(Nom, Prenom, Proj)
        {
            metier = Metier;
            entreprise = Entreprise;
        }
        public override string ToString()
        {
            string res = "";
            res = res + "Nom : " + nom + "\n";
            res = res + "Prénom : " + prenom + "\n";
            res = res + "Métier : " + metier + "\n";
            res = res + "Lieu d'emploi en dehors de l'ENSC : " + entreprise + "\n";
            res = res + "Liste des projets en cours : \n";
            /*for (int i = 1; i < projet.Length + 1; i++)
            {
                res = res + "Projet n°" + i + " : " + projet[i - 1] + "/n";
            }*/

            return res;
        }
    }
}
