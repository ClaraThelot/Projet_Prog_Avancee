﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _AffichageListes;
using _InstanceProjet;
using _projet;
using _InstancePersonne;
using _InstancieProf;
using _InstanceMatiere;

namespace Rattachement
{
    public class Program
    {
        public static List<Eleve> RattacheEleve()
        {
            List<Eleve> Eleves = new List<Eleve>();
            Eleves = _InstancePersonne.Program.instancieEleve();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet();
            foreach (Eleve element in Eleves)                                       // Parcourt tous les élèves
            {
                foreach (Projet p in Projets)                                       //Parcourt tous les projets
                {
                    foreach (Eleve e in p._eleves)
                    {
                        if (e._nom == element._nom)                                 //Cherche la correspondance pour rattacher les projets aux élèves
                        {
                            element.ajoutProjet(p);
                        }
                    }
                }
            }
            return Eleves;
        }
        
        public static List<Exterieur> RattacheExte()
        {
            List < Exterieur > exterieur= new List<Exterieur>();
            exterieur = _InstancePersonne.Program.instancieIntervenantE();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet();
        foreach(Exterieur element in exterieur)
        {
            foreach(Projet p in Projets)
            {
                foreach(Exterieur e in p._intervenants)
                {
                    if(e._nom==element._nom)
                    {
                        element.ajoutProjet(p);
                    }
                }
            }
        }
        return exterieur;
    }
        public static List<Professeur> RattacheProf()
        {
            List<Professeur> professeur= new List<Professeur>();
            professeur = _InstancePersonne.Program.instancieProfesseur();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet();
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            foreach (Professeur element in professeur)
            {
                foreach (Projet p in Projets)
                {
                    foreach (Professeur e in p._professeurs)
                    {
                        if (e._nom == element._nom)element.ajoutProjet(p);
                    }
                }
                foreach(Matiere m in Matieres)
                {
                    foreach(Matiere mprof in element._matieres)
                    {
                        if (mprof == m) element.ajoutMatiere(m);
                    }
                }
            }
            return professeur;
        }
        static void Main(string[] args)
        {
        }
    }
}
