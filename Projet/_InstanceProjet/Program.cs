using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _InstanceEleve;
using _InstanceExterieur;
using _InstanceMatiere;
using _InstanceLivrable;


namespace _InstanceProjet
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<Projet> instancieProjet()
        {
            char separateur = '*';
            string ligneP;
            List<Projet> Projets = new List<Projet>();
            string nom;
            int duree;
            bool sujetlibre;
            double note;
            bool acheve;
            List<Livrable> llivrable = new List<Livrable>();
            List<Eleve> eparticipant = new List<Eleve>();
            List<Exterieur> pparticipant = new List<Exterieur>();
            List<Matiere> matconcernee = new List<Matiere>();
            Eleve chef = new Eleve();
            System.IO.StreamReader file4 = new System.IO.StreamReader("Projets.txt");
            while ((ligneP = file4.ReadLine()) != null)
            {
                String[] information = ligneP.Split(separateur);
                nom = information[0];
                duree = int.Parse(information[1]);
                sujetlibre = bool.Parse(information[2]);
                note = double.Parse(information[3]);
                acheve = bool.Parse(information[4]);
                int elementi = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                int choix = 0;
                List<Matiere> Matieres = new List<Matiere>();
                Matieres = _InstanceMatiere.Program.instancieMatiere();
                List<Eleve> Eleves = new List<Eleve>();
                Eleves = _InstanceEleve.Program.instancieEleve();
                List<Livrable> Livrables = new List<Livrable>();
                Livrables = _InstanceLivrable.Program.instancieLivrable();
                List<Exterieur> Exterieurs = new List<Exterieur>();
                Exterieurs = _InstanceExterieur.Program.instancieIntervenantE();
                foreach (Matiere element in Matieres)
                {
                    if (element._nom == information[5])
                    {
                        choix = elementi;
                    }
                    elementi++;
                }
                matconcernee.Add(Matieres[choix]);

                for (int i = 6; i < information.Length; i++)
                {
                    if (information[i][0] == 'E')
                    {
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        int start = 1;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Eleve element in Eleves)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        eparticipant.Add(Eleves[choix2]);
                    }
                    if (information[i][0] == 'P')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Exterieur element in Exterieurs)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        pparticipant.Add(Exterieurs[choix2]);
                    }
                    if (information[i][0] == 'L')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string echeanceprojet = information[i].Substring(start);
                        foreach (Livrable element in Livrables)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._echeance == echeanceprojet)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        llivrable.Add(Livrables[choix2]);
                    }
                    if (information[i][0] == 'C')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Eleve element in Eleves)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        chef = Eleves[choix2];
                    }
                }
                Projet ajout = new Projet(nom, duree, sujetlibre, note, acheve, llivrable, eparticipant, pparticipant, matconcernee, chef);
                Projets.Add(ajout);
            }
            return Projets;
        }
    }
}
