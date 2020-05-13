﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _InstanceProjet;
using _InstancieProf;
using _AffichageListes;
using _InstancePersonne;
using _projet;
using System.IO;

namespace Ajout
{
    public class Program
    {
        static void Main(string[] args)
        { }
        public void AfficheEleves()
        {
            Console.WriteLine("Voilà la liste des élèves répertoriés !");
            List<Eleve> TousEleves2 = new List<Eleve>();
            TousEleves2 = _InstancePersonne.Program.instancieEleve();
            foreach (Eleve element in TousEleves2)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous sélectionnez cet elève, tapez " + TousEleves2.IndexOf(element));
            }
        }
        
        public static bool MenuAjout()
        {

            int totalLignes = File.ReadLines("Projets.txt").Count();                                     //Permettra d'identifier le projet
            Console.WriteLine("Bienvenue sur le menu des ajouts !");
            Console.WriteLine("Vous allez pouvoir créer un projet. D'abord, saisissez-en le nom.");
            string nom = Console.ReadLine();
            string ligne = nom + "*";
            Console.WriteLine("Saisissez la durée du projet (Tapez un nombre, en mois)");
            ligne = ligne + Console.ReadLine() + "*";
            Console.WriteLine("Si vous laissez de la liberté à vos élèves et que votre sujet est libre, tapez 'oui', sinon, tapez 'non'");
            string libre = Console.ReadLine();
            if (libre == "oui") { ligne = ligne + "true*"; }
            else { ligne = ligne + "false*"; }
            Console.WriteLine("Mais dîtes moi, vous ne parlez pas d'un sujet déjà achevé ? (tapez 'si' ou 'non')");
            string fini = Console.ReadLine();
            if (fini == "si")
            {
                Console.WriteLine("Quelle note avez-vous attribué à ces élèves acharnés ?");
                string note = Console.ReadLine();
                ligne = ligne + note + "*true*";
            }
            else
            {
                ligne = ligne + "0*false*";
            }
            //Sélection des matières :
            List<Matiere> TousMatieres = new List<Matiere>();
            TousMatieres = _InstanceMatiere.Program.instancieMatiere();
            Console.WriteLine("Combien de matières concernent ce projet ?");
            int NbM = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbM + 1; i++)
            {
                Console.WriteLine("Tapez le code associé à la matière du projet.");
                //Affichage des élèves ->  à factoriser avec celle d'en dessous
                Console.WriteLine("Voilà la liste matières !");
                foreach (Matiere element in TousMatieres)
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous sélectionnez cette matière, tapez " + TousMatieres.IndexOf(element));
                }
                int numerochoisi = int.Parse(Console.ReadLine()); // fin de la fonction à factoriser

                foreach (Matiere element in TousMatieres)
                {
                    if (numerochoisi == TousMatieres.IndexOf(element))
                    {
                        ligne = ligne +"A"+ TousMatieres[numerochoisi]._nom + "*";
                    }
                }
            }

            List<Eleve> participant = new List<Eleve>();

            //Sélection des élèves
            Console.WriteLine("Combien d'élèves travaillent sur ce projet ?");
            int NbE = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbE + 1; i++)
            {
                Console.WriteLine("Tapez le code associé à l'élève du projet.");
                //Affichage des élèves ->  à factoriser avec celle d'en dessous
                 Console.WriteLine("Voilà la liste des élèves répertoriés !");
                 List<Eleve> TousEleves2 = new List<Eleve>();
                 TousEleves2 = _InstancePersonne.Program.instancieEleve();
                 foreach (Eleve element in TousEleves2)
                 {
                     Console.Write(element._nom);
                     Console.WriteLine("     Si vous sélectionnez cet elève, tapez " + TousEleves2.IndexOf(element));
                 }
                //_AffichageListes.Program.AfficheEleves();
                int numerochoisi3 = int.Parse(Console.ReadLine()); // fin de la fonction à factoriser

                foreach (Eleve element in TousEleves2)
                {
                    if (numerochoisi3 == TousEleves2.IndexOf(element))
                    {
                        participant.Add(TousEleves2[numerochoisi3]);
                        ligne = ligne + "E" + TousEleves2[numerochoisi3]._nom + "*";
                    }
                }

            }

            // Sélection des intervenants
            Console.WriteLine("Combien d'extérieurs interviennent sur ce projet ?");
            int NbI = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbI + 1; i++)
            {
                Console.WriteLine("Tapez le code associé à l'extérieur du projet.");
                //Affichage des élèves ->  à factoriser avec celle d'en dessous
                Console.WriteLine("Voilà la liste des extérieurs répertoriés !");
                List<Exterieur> TousExte= new List<Exterieur>();
                TousExte = _InstancePersonne.Program.instancieIntervenantE();
                foreach (Exterieur element in TousExte)
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous sélectionnez cet elève, tapez " + TousExte.IndexOf(element));
                }
                int numerochoisi1 = int.Parse(Console.ReadLine()); // fin de la fonction à factoriser

                foreach (Exterieur element in TousExte)
                {
                    if (numerochoisi1 == TousExte.IndexOf(element))
                    {
                        ligne = ligne + "P" + TousExte[numerochoisi1]._nom + "*";
                    }
                }

            }
            //Séléction du chef de projet :
            Console.WriteLine("Tapez le code associé au chef du projet.");
            //Affichage des élèves ->  à factoriser avec celle d'en dessous
            Console.WriteLine("Voilà la liste des élèves !");
            foreach (Eleve element in participant)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous sélectionnez cet elève, tapez " + participant.IndexOf(element));
            }
            int numerochoisi4 = int.Parse(Console.ReadLine()); // fin de la fonction à factoriser

            foreach (Matiere element in TousMatieres)
            {
                if (numerochoisi4 == TousMatieres.IndexOf(element))
                {
                    ligne = ligne +"C"+ participant[numerochoisi4]._nom + "*";
                }
            }

            //Séléction des Livrables
            Console.WriteLine("Combien de livrables sont attendus dans ce projet ?");
            int NbL = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbL + 1; i++)
            {
                Console.WriteLine("Quel est le nom de votre livrable ?");
                string _nom = Console.ReadLine();
                Console.WriteLine("Quelle est l'échéance de ce livrable ? (de la forme AAAA/MM/JJ)");
                string _date = Console.ReadLine();
                string nv = _nom + "*" + _date + "*" + totalLignes + "*";
                try
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("Rôles.txt", append: true))
                    {

                        writer.Write("\r\n" +nv );
                    }
                }
                catch (Exception exp)
                {
                    Console.Write("Erreur");
                }

            }

            //Sélection des profs
            Console.WriteLine("Combien de professeurs gèrent ce projet ?");
            int NbProf = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbProf + 1; i++)
            {
                Console.WriteLine("Tapez le code associé au premier professeur du projet.");
                //Affichage des profs ->  à factoriser avec celle d'en dessous
                Console.WriteLine("Voilà la liste des professeurs répertoriés !");
                List<Professeur> TousProfs = new List<Professeur>();
                TousProfs = _InstancePersonne.Program.instancieProfesseur();
                foreach (Professeur element in TousProfs)
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous sélectionnez ce professeur, tapez " + TousProfs.IndexOf(element));
                }
                int numerochoisi2 = int.Parse(Console.ReadLine()); // fin de la fonction à factoriser

                foreach (Professeur element in TousProfs)
                {
                    if (numerochoisi2 == TousProfs.IndexOf(element))
                    {
                        ligne = ligne + "M" + TousProfs[numerochoisi2]._nom ;
                    }
                }

            }


                //Ecriture dans le fichier Projets.txt
                string fileName = "Projets.txt";
            // Création du code :
            string ecrire = totalLignes + "*" + ligne;
            try
                {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, append: true))
                {
                  
                    writer.Write("\r\n"+ecrire);
                }
                }
                catch (Exception exp)
                {
                    Console.Write("Erreur");
            }
            //Affichage de la création 
            Console.Clear();
            Console.WriteLine("Vous avez créer le projet suivant !");
            List<Projet> bdd = new List<Projet>();
            bdd = _InstanceProjet.Program.instancieProjet();
            Projet ajout = bdd.Last();
            ajout.Affichage(ajout);
            return true;

            }
        }
    
}

