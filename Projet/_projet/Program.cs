using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Faire une fonction éventuellement

            char separateur = '*';                                                             // Définition du caractère séparateur (utile lors de l'analyse de fichier)
            // Création de la liste des matières à partir du fichier Matieres.txt
            List<Matiere> Matieres = new List<Matiere>();                                       //Initialisation de la liste
            string ligne;
            string nommatiere; string code; string ue;
            System.IO.StreamReader fichier = new System.IO.StreamReader("Matieres.txt");       //Lecture du fichier
            while ((ligne = fichier.ReadLine()) != null)                                       //Analyse ligne par ligne
            {
                String[] information = ligne.Split(separateur);                              // Création d'un tableau contenant chaque élément de la ligne ( un élément est délimité par deux slashs)
                nommatiere = information[0];                                                  // Affectation des différents éléments définissant une matière                                    
                code = information[1];
                ue = information[2];
                Matiere matiere = new Matiere(nommatiere, code, ue);                          // Construction de la matière 
                Matieres.Add(matiere);                                                        // Ajout de la matière créée à la liste des matières
            }

            // Même procédé avec la liste des élèves à partir du fichier Eleves.txt 
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

            // Même procédé avec la liste des professeurs à partir du fichier Professeurs.txt
            List<Professeur> Prof = new List<Professeur>();
            string ligne2;
            string nomprof;
            string prénomprof;
            string mat;
            Matiere mate; 
            System.IO.StreamReader fichier2 = new System.IO.StreamReader("Professeurs.txt");
            while ((ligne2 = fichier2.ReadLine()) != null)
            {
                String[] information = ligne2.Split(separateur);
                int elementi = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                int choix = 0;                                                          // Cet entier permettra de retenir le numéro de l'élément correspondant à la matière recherchée
                nomprof=information[0];
                prénomprof = information[1];
                mat =information[2];
                foreach(Matiere element in Matieres)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                {
                    if (element._nom==mat)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                    {
                        choix = elementi;
                    }
                    else
                    {
                        
                    }
                    elementi += 1;
                }
                mate = Matieres[choix];
                Professeur profe = new Professeur(nomprof, prénomprof, mate);
                Prof.Add(profe);
            }

            // Même procédé avec les extérieurs grâce au fichier Exterieurs.txt
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
                nomexterieur = information[0];
                prenomexterieur = information[1];
                metier = information[2];
                entreprise= information[3];
                Exterieur exte = new Exterieur(nomexterieur, prenomexterieur, metier, entreprise);
                Exterieurs.Add(exte);
            }

            // Même procédé avec les livrables grâce au fichier Livrables.txt
            List<Livrable> Livrables = new List<Livrable>();
            string ligneL;
            string type;
            string echeance;
            System.IO.StreamReader file3 = new System.IO.StreamReader("Livrables.txt");
            while ((ligneL= file3.ReadLine()) != null)
            {
                String[] information = ligneL.Split(separateur);
                type= information[0];
                echeance = information[1];
                DateTime rendu = DateTime.Parse(echeance);
                Console.WriteLine(echeance); Console.WriteLine(rendu);
                /*Livrable liv = new Livrable(type,rendu);
                Livrables.Add(liv);*/
            }
            /*
            foreach (Exterieur element in Exterieurs)
            {
                Console.WriteLine(element.ToString());
            }*/
        }
    }
}
