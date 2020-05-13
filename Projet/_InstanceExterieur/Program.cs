﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _InstancePersonne
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<Professeur> instancieProfesseur()
        {
            char separateur = '*';
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Professeur> Prof = new List<Professeur>();
            string ligne2;
            string nomprof;
            string prénomprof;
            string mat;
            List<Matiere> mate=new List<Matiere>();
            System.IO.StreamReader fichier2 = new System.IO.StreamReader("Professeurs.txt");
            while ((ligne2 = fichier2.ReadLine()) != null)
            {
                String[] information = ligne2.Split(separateur);
                int elementi = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                int choix = 0;                                                          // Cet entier permettra de retenir le numéro de l'élément correspondant à la matière recherchée
                nomprof = information[0];
               prénomprof = information[1];
                mat = information[2];
                foreach (Matiere element in Matieres)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                {
                    if (element._nom == mat)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                    {
                        choix = elementi;
                    }

                    elementi += 1;
                }
                mate.Add(Matieres[choix]);
                Professeur profe = new Professeur(nomprof, prénomprof, mate);
                Prof.Add(profe);
            }
            return Prof;
        }
        public static List<Eleve> instancieEleve()
        {
            char separateur = '*';
            List<Eleve> Eleves = new List<Eleve>();
            string line;
            string nomeleve;
            string prenomeleve;
            string annee;
            int promo;
            int TD;
            System.IO.StreamReader file = new System.IO.StreamReader("Eleves.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] information = line.Split(separateur);
                nomeleve = information[0];
                prenomeleve = information[1];
                annee = information[2];
                promo = int.Parse(information[3]);                                          //Pour ces deux lignes, un transtypage est nécessaire pour pouvoir construire l'objet à partir de la lecture du fichier
                TD = int.Parse(information[4]);
                Eleve eleve = new Eleve(nomeleve, prenomeleve, annee, promo, TD);
                Eleves.Add(eleve);
            }
            return Eleves;
        }

        public static List<Exterieur> instancieIntervenantE()
        {
            char separateur = '*';
            List<Exterieur> Exterieurs = new List<Exterieur>();
            string ligneE;
            string nomexterieur;
            string prenomexterieur;
            string metier;
            string entreprise;
            System.IO.StreamReader file2 = new System.IO.StreamReader("Exterieurs.txt");
            while ((ligneE = file2.ReadLine()) != null)
            {
                String[] information = ligneE.Split(separateur);
                nomexterieur = information[1];
                prenomexterieur = information[0];
                metier = information[2];
                entreprise = information[3];
                Exterieur exte = new Exterieur(nomexterieur, prenomexterieur, metier, entreprise);
                Exterieurs.Add(exte);
            }
            return Exterieurs;
        }
    }
}
