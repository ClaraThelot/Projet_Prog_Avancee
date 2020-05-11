using System;
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
using _projet;
using RechercheLibre;
using Rattachement;

namespace Menu
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Menu();

        }
        static bool Menu()
        {
            Console.WriteLine("Bienvenue sur votre application de recherche de projets de l'ENSC ! \nComment souhaitez-vous effectuer votre recherche ?\n");
            Console.WriteLine("Si vous voulez faire une recherche libre, tapez d'abord 1 sur votre clavier numérique !");
            Console.WriteLine("Si vous voulez parcourir les élèves, tapez 2");
            Console.WriteLine("Si vous voulez parcourir les intervenants extérieurs, tapez 3");
            Console.WriteLine("Si vous voulez parcourir les professeurs, tapez 4");
            Console.WriteLine("Si vous voulez parcourir les projets, tapez 5");// On va se limiter à ça pour l'instant

            switch (Console.ReadLine())
            {
                case "1":
                    RechercheLibre.Program.Recherche();
                    //Console.WriteLine("A présent, tapez le mot-clef unique que vous souhaitez rechercher dans la base");
                    return false;
                case "2":
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                    List<Eleve> Eleves = new List<Eleve>();
                    Eleves = Rattachement.Program.RattacheEleve();
                    Console.WriteLine("1A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "1A")
                        {
                            Console.Write(element._nom);
                            Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez "+Eleves.IndexOf(element));
                        }
                    }
                    Console.WriteLine("2A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "2A")
                        {
                            Console.Write(element._nom);
                            Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                        }
                    }
                    Console.WriteLine("3A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "3A")
                        {
                            Console.Write(element._nom);
                            Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                        }
                    }
                    Console.WriteLine("Eleves ayant un autre statut :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee != "1A" && element._annee != "2A" && element._annee != "3A")
                        {
                            Console.Write(element._nom);
                            Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element)+ "\r\n");
                        }
                    }
                    int numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                    foreach (Eleve element in Eleves)
                    { if (numerochoisi == Eleves.IndexOf(element)) Console.WriteLine(element.ToString()); }
                    return true;
                case "3":
                    Console.WriteLine("Voilà la liste des intervenants extérieurs répertoriés !");
                    List<Exterieur> Exte = new List<Exterieur>();
                    Exte = Rattachement.Program.RattacheExte();
                    foreach (Exterieur element in Exte)
                    {
                        Console.Write(element._nom);
                        Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez " + Exte.IndexOf(element));
                    }
                    numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                    foreach (Exterieur element in Exte)
                    { if (numerochoisi == Exte.IndexOf(element)) Console.WriteLine(element.ToString()); }
                    return true;

                case "4":
                    List<Professeur> Prof = new List<Professeur>();
                    Prof = Rattachement.Program.RattacheProf();
                    Console.WriteLine("Vous avez choisi de rechercher des professeurs !");
                    Console.WriteLine("Si vous voulez les voir s'afficher par matière, tapez 1, si vous les voulez par nom, tapez 2 !");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            List<Matiere> MatiereEnseignee = new List<Matiere>();
                            MatiereEnseignee = _InstanceMatiere.Program.instancieMatiere();
                            foreach (Matiere element in MatiereEnseignee)
                            {
                                Console.WriteLine("Matière enseignée : " + element._nom);
                                foreach (Professeur prof in Prof)
                                {
                                    if (prof._matieres._nom == element._nom)
                                    {
                                        Console.Write(prof._nom);
                                        Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez " + Prof.IndexOf(prof));
                                    }//Pour l'instant ne marche que pcq le _matieres des Profs n'est pas une liste mais un singleton
                                }
                            }
                            numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Professeur element in Prof)
                            { if (numerochoisi == Prof.IndexOf(element)) Console.WriteLine(element.ToString()); }
                            return true;
                        case "2":
                            foreach (Professeur prof in Prof)
                            {
                                Console.Write(prof._nom);
                                Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez " + Prof.IndexOf(prof));//Pour l'instant pas d'ordre alphabétique
                            }
                            numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Professeur element in Prof)
                            { if (numerochoisi == Prof.IndexOf(element)) Console.WriteLine(element.ToString()); }
                            return true;
                        default: return false;
                    }
                   
                case "5":
                    List<Projet> Proj = new List<Projet>();
                    Proj = _InstanceProjet.Program.instancieProjet();
                    foreach (Projet element in Proj)
                    {
                        Console.Write(element._nomProjet);
                        Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                    }
                    numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                    foreach (Projet element in Proj)
                    { if (numerochoisi == Proj.IndexOf(element)) element.Affichage(element); }
                    return true;
                default:
                    return false;
            }
        }
    }
}
    

