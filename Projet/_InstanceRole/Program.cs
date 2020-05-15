using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _InstanceProjet;
using _InstancePersonne;
using Rattachement;
using _InstancieProf;

namespace _InstanceRole
{
    public  class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        public static int CompteProjet()
        {
            int max = 0;
            List<Projet> Proj = _InstanceProjet.Program.instancieProjet();
            foreach(Projet element in Proj)
            {
                if (int.Parse(element._code) > max) max = int.Parse(element._code);
            }
            return max;
        }
        
        public static void AffichageProj(Projet proj)
        { Console.WriteLine("Nom du projet : " + proj._nomProjet + "\n");
            Console.WriteLine("Durée du projet : " + proj._duree + " mois \n");
            if (proj._sujetLibre == true) Console.WriteLine("Sujet imposé" +"\r\n");
            Console.WriteLine("Eleves participant : ");
            foreach (Eleve element in proj._eleves)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez 0" + proj._eleves.IndexOf(element));
            }
    Console.WriteLine("\r\n");
            Console.WriteLine("Intervenants participant : ");
            foreach (Exterieur element in proj._intervenants)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez 1" + proj._intervenants.IndexOf(element));
            }
Console.WriteLine("\r\n");
            Console.WriteLine("Professeurs intervenants : \n");
            foreach(Professeur element in proj._professeurs)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez 2" + proj._professeurs.IndexOf(element));
            }
            Console.WriteLine("\r\nDétail des rôles de chacun des intervenants");
            Role.RattacheRole(proj._code);

            Console.WriteLine(" \r\nMatières concernées :");
            foreach(Matiere element in proj._matieres)
            { Console.WriteLine(element._nom); } 
            Console.WriteLine("\r\n");
            Console.WriteLine("Chef de projet : "+ proj._chefprojet._nom+ "     Si vous voulez en savoir plus sur cet élève, tapez 0" + proj._eleves.IndexOf(proj._chefprojet));
            Console.WriteLine("Les livrables sont les suivants : "); 
            foreach (Livrable element in proj._livrables)
            {
                Console.WriteLine(element._type+" ("+element._echeance+")");
            }
            Console.WriteLine("\n");
            if (proj._sujetAcheve == true)
            {
                Console.WriteLine("Statut du projet : achevé");
                Console.WriteLine("Note : " + proj._note);
            }
            else { Console.WriteLine("Statut du sujet : en cours"); }

            string saisienum = Console.ReadLine();
            string determiner = saisienum.Substring(0, 1);
            saisienum = saisienum.Substring(1);
            int numerochoisi = int.Parse(saisienum);

            if (determiner == "0")
            {
                List<Eleve> Eleves = Rattachement.Program.RattacheEleve();
                foreach (Eleve el in Eleves)
                {
                    foreach (Eleve element in proj._eleves)
                    {
                        if (el == element)
                        {
                            if (numerochoisi == proj._eleves.IndexOf(element)) Console.WriteLine(element.ToString());
                        }
                    }
                }
            }
            else
            {
                if (determiner == "1")
                {
                    foreach (Exterieur element in proj._intervenants)
                    { if (numerochoisi == proj._intervenants.IndexOf(element)) Console.WriteLine(element.ToString()); }
                }
                else
                {
                    if (determiner == "2")
                    {
                        foreach (Professeur element in proj._professeurs)
                        {
                            if (numerochoisi == proj._professeurs.IndexOf(element)) Console.WriteLine(element.ToString());
                        }
                    }
                    else Console.WriteLine("Désolée, nous ne pouvons afficher cela, vous avez du faire une erreur !");
                }
            }
        }
        public static List<Role> instancieRole()
        {
            char separateur = '*';
            List<Role> Roles = new List<Role>();
            string nom;
            string code;
            string line;
            string nompersonne;
            Projet projet = new Projet();
            Personne personne = new Personne();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet(); // On instancie la liste des projets. 
            List<Exterieur> Exte = new List<Exterieur>();
            Exte = _InstancePersonne.Program.instancieIntervenantE(); // Pareil avec les intervenants exté
            List<Professeur> Prof = new List<Professeur>();
            Prof = _InstancePersonne.Program.instancieProfesseur();

            System.IO.StreamReader file = new System.IO.StreamReader("Rôles.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] information = line.Split(separateur);
                nom = information[0];
                code = information[1];
                nompersonne = information[2];
               /* foreach (Projet element in Projets)
                {
                    if (code == element._code) projet = element;
                }
                foreach (Exterieur element in Exte)
                {
                    if (nompersonne == element._nom) personne = element;
                }
                foreach (Professeur element in Prof)
                {
                    if (nompersonne == element._nom) personne = element;
                }*/
                Role role = new Role(nom, code, nompersonne);
                Roles.Add(role);
            }
            return Roles;
        }
    }
    
}
