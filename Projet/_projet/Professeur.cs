﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _projet
{
    public class Professeur : Personne
    {
        public List<Matiere> _matieres { get; set; }                                                       // J'ai temporairement enlevé le fait que c'est un tableau

        public Professeur(string Nom, string Prenom, List<Matiere> Matieres) : base(Nom, Prenom) {
            _matieres = Matieres;
        }
        
        public Professeur(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

        public Professeur(string Nom, string Prenom, List<Projet> Proj, List<Matiere> Matiere) : base(Nom, Prenom, Proj)
        {
            _matieres = Matiere;
        }
        /*public void ajoutProjet(Projet P1)
        {
            _projet.Add(P1);
        }*/
        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + _nom + "\n";
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Liste des matières enseignées : ";
            int comptemat = 0;
            foreach(Matiere element in _matieres)
            {
                res = res + "Matière n°" + (comptemat + 1) + " : " + element._nom + "\n";
            }
            res = res + _matieres;
            res = res + "\nListe des projets en cours : \n";
            int i = 0;
            foreach (Projet element in _projet)
            {
                res = res + "Projet n°" + (i+1) + " : " + element._nomProjet + " \n";
                i++;
            }

            return res;
        }
    }
}
