using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Personne
    {
        public string nom { get ; set; }
        public string prenom { get; set; }
        public Projet[] projet { get; set; }

        public Personne()
        {
            nom = "didier";
            prenom = "didier";
        }
        public Personne(string Nom, string Prenom)
        {
            nom = Nom;
            prenom = Prenom;
        }

        public Personne(string Nom, string Prenom, Projet[] Proj)
        {
            nom = Nom;
            prenom = Prenom;
            projet = Proj;
        }
        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + nom + "\n" ;
            res = res + "Prénom : " + prenom + "\n";
            res = res + "Liste des projets en cours : \n";
            /*for (int i = 1; i < projet.Length + 1; i++)
            {
                res = res + "Projet n°" + i + " : " + projet[i - 1] + "/n";
            }*/

            return res;
        }
    }
}
