using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Professeur :Personne
    {
        public Matiere _matieres { get; set; }                                                       // J'ai temporairement enlevé le fait que c'est un tableau

        public Professeur(string Nom, string Prenom, Matiere Matieres) : base(Nom, Prenom) {
            _matieres = Matieres;
        }
        
        public Professeur(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

        public Professeur(string Nom, string Prenom, List<Projet> Proj, Matiere Matiere) : base(Nom, Prenom, Proj)
        {
            _matieres = Matiere;
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + _nom + "\n";
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Liste des matières enseignées : ";
            res = res + _matieres;
            res = res + "\nListe des projets en cours : \n";
            int i = 0;
            /*foreach (Projet element in _projet)
            {
                res = res + "Projet n°" + i + " : " + _projet[i - 1] + " \n";
                i++;
            }*/

            return res;
        }
    }
}
