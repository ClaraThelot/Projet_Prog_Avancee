﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _InstanceEleve;
using _InstanceExterieur;
using _InstanceLivrable;
using _InstanceMatiere;
using _InstanceProjet;
using _InstanceRole;
using _InstancieProf;
using _projet;

namespace RechercheLibre
{
    public class Program
    {
        static void Main(string[] args)
        { }
      
        public static void Recherche()
        {
            Console.WriteLine("Veuillez saisir ce que vous recherchez");
            string recherche = Console.ReadLine();
            List<Exterieur> Exte = new List<Exterieur>();
            Exte = _InstanceExterieur.Program.instancieIntervenantE(); // Pareil avec les intervenants exté
            List<Professeur> Prof = new List<Professeur>();
            Prof = _InstancieProf.Program.instancieProfesseur();
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Eleve> Eleves = new List<Eleve>();
            Eleves = _InstanceEleve.Program.instancieEleve();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet(); // On instancie la liste des projets.
            List<Livrable> Livrables = new List<Livrable>();
            Livrables = _InstanceLivrable.Program.instancieLivrable();

            
            foreach (Eleve element in Eleves)
            {
                int nombre;
                if (int.TryParse(recherche, out nombre))                        //Vérification pour voir si la conversion en int est possible
                {
                    if (int.Parse(recherche) == element._promo)
                    {
                        Console.WriteLine(element.ToString());
                    }
                }
                
                if (recherche == element._prenom|| recherche == element._nom||recherche== element._annee)
                {
                   element.Affichage(element);
                }
            }
            
            foreach (Exterieur element in Exte)
            {
                if (recherche == element._nom || recherche ==element._prenom || recherche ==element._metier || recherche ==element._entreprise)
                {
                    element.Affichage(element);
                }
            }

            foreach (Matiere element in Matieres)
            {
                if (recherche == element._nom || recherche ==element._code || recherche ==element._UE)
                {
                    element.Affichage(element);
                }
            }

            foreach (Professeur element in Prof)
            {
                if (recherche == element._nom|| recherche == element._prenom)
                {
                    element.Affichage(element);
                }
            }

            foreach (Livrable element in Livrables)
            {
                if (recherche == element._type|| recherche == element._echeance)
                {
                    Console.WriteLine(element.ToString());
                }
            }
            
            foreach (Projet element in Projets)
            {
                if (recherche == element._nomProjet)
                {
                    Console.WriteLine(element.ToString());
                }
                
                double nombre;
                if (double.TryParse(recherche, out nombre))                        //Vérification pour voir si la conversion en int est possible
                {
                    if (double.Parse(recherche) == element._duree|| double.Parse(recherche) == element._note)
                    {
                        Console.WriteLine(element.ToString());
                    }
                }
                
                // Pas sûre que ces deux paragraphes soient utiles
                if (recherche=="Sujet achevé"&& element._sujetAcheve==true)
                { Console.WriteLine(element.ToString()); }

                if(recherche=="Sujet libre"&& element._sujetLibre==true)
                { Console.WriteLine(element.ToString()); }
            }

        }
    }
}

