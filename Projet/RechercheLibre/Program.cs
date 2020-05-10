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

            foreach (Eleve element in Eleves)
            {
                if (recherche == element._nom)
                {
                    Console.WriteLine(element.ToString());
                }
                int nombre;
                if (int.TryParse(recherche, out nombre))                        //Vérification pour voir si la conversion en int est possible
                {
                    if (int.Parse(recherche) == element._promo)

                    {
                        Console.WriteLine(element.ToString());
                    }
                }
                if (recherche == element._prenom)
                {
                    Console.WriteLine(element.ToString());
                }
                if (recherche == element._annee)
                {
                    Console.WriteLine(element.ToString());
                }
            }

        }
    }
}

