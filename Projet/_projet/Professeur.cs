using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Professeur :Personne
    {
        public Matiere matieres { get; set; }                                                       // J'ai temporairement enlevé le fait que c'est un tableau

        public Professeur(string Nom, string Prenom, Matiere Matieres) : base(Nom, Prenom) {
            matieres = Matieres;
        }
        
        public Professeur(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

        public Professeur(string Nom, string Prenom, List<Projet> Proj, Matiere Matiere) : base(Nom, Prenom, Proj)
        {
            matieres = Matiere;
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + nom + "\n";
            res = res + "Prénom : " + prenom + "\n";
            res = res + "Liste des matières enseignées : ";
            res = res + matieres;
            res = res + "\nListe des projets en cours : \n";
            int i = 0;
            /*foreach (Projet element in projet)
            {
                res = res + "Projet n°" + i + " : " + projet[i - 1] + " \n";
                i++;
            }*/

            return res;
        }
    }
}
