using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Program
    {

        static List<Eleve> instancieEleve()
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
        static List<Matiere> instancieMatiere()
        {
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
            return Matieres;
        }
        static List<Professeur> instancieProfesseur()
        {
            char separateur = '*';
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = instancieMatiere();
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
                mate = Matieres[choix];
                Professeur profe = new Professeur(nomprof, prénomprof, mate);
                Prof.Add(profe);
            }
            return Prof;
        }

        static List<Exterieur> instancieIntervenantE()
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
        static List<Livrable> instancieLivrable()
        {
            char separateur = '*';
            List<Livrable> Livrables = new List<Livrable>();
            string ligneL;
            string type;
            string echeance;
            System.IO.StreamReader file3 = new System.IO.StreamReader("Livrables.txt");
            while ((ligneL = file3.ReadLine()) != null)
            {
                String[] information = ligneL.Split(separateur);
                type = information[0];
                echeance = information[1];
                Livrable liv = new Livrable(type, echeance);
                Livrables.Add(liv);
            }
            return Livrables;
        }
        static List<Projet> instancieProjet()
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
            List <Exterieur> pparticipant = new List<Exterieur>();
            List <Matiere> matconcernee = new List<Matiere>();
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
                Matieres = instancieMatiere();
                List<Eleve> Eleves = new List<Eleve>();
                Eleves = instancieEleve();
                List<Livrable> Livrables = new List<Livrable>();
                Livrables = instancieLivrable();
                List<Exterieur> Exterieurs = new List<Exterieur>();
                Exterieurs = instancieIntervenantE();
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
                    Console.WriteLine("A présent, tapez le mot-clef unique que vous souhaitez rechercher dans la base");
                    return false;
                case "2":
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                    List<Eleve> Eleves = new List<Eleve>();
                    Eleves = instancieEleve();
                    Console.WriteLine("1A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "1A") Console.WriteLine(element._nom);  }
                    Console.WriteLine("2A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "2A") Console.WriteLine(element._nom); }
                    Console.WriteLine("3A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "3A") Console.WriteLine(element._nom); }
                    Console.WriteLine("Eleves ayant un autre statut :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee != "1A" && element._annee != "2A" && element._annee != "3A")Console.WriteLine(element._nom); }
                    return true;
                case "3":
                    Console.WriteLine("Voilà la liste des intervenants extérieurs répertoriés !");
                    List<Exterieur> Exte = new List<Exterieur>();
                    Exte = instancieIntervenantE();
                    foreach (Exterieur element in Exte)
                    { Console.WriteLine(element._nom); }
                        return true;

                case "4":
                    List<Professeur> Prof = new List<Professeur>();
                    Prof = instancieProfesseur();
                    Console.WriteLine("Vous avez choisi de rechercher des professeurs !");
                    Console.WriteLine("Si vous voulez les voir s'afficher par matière, tapez 1, si vous les voulez par nom, tapez 2 !");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            List<Matiere> MatiereEnseignee = new List<Matiere>();
                            MatiereEnseignee = instancieMatiere();
                            foreach(Matiere element in MatiereEnseignee)
                            {
                                Console.WriteLine("Matière enseignée : " + element._nom);
                                foreach (Professeur prof in Prof)
                                {
                                    if (prof._matieres._nom == element._nom) Console.WriteLine(prof._nom); //Pour l'instant ne marche que pcq le _matieres des Profs n'est pas une liste mais un singleton
                                }
                            }
                            return true;
                        case "2":
                            foreach (Professeur prof in Prof)
                            {
                                Console.WriteLine(prof._nom); //Pour l'instant pas d'ordre alphabétique
                            }
                            return true;
                        default: return false;
                    }
                case "5":
                    List<Projet> Proj = new List<Projet>();
                    Proj = instancieProjet();
                    foreach(Projet element in Proj)
                    { Console.WriteLine(element._nomProjet); }
                    return true;
                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            // Même procédé avec la liste des professeurs à partir du fichier Professeurs.txt
            /*  List<Professeur> Prof = new List<Professeur>();
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
                  Livrable liv = new Livrable(type,echeance);
                  Livrables.Add(liv);
              }

              // Même procédé avec les projets grâce au fichier Projets.txt
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
              Eleve chef = new Eleve() ;
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
                  Projets.Add(ajout);*/
            /* foreach (Projet element in Projets)
             { Console.WriteLine(element.ToString()); }*/
            bool showMenu = true;

              /*while (showMenu)                                                                                        //Affichage du menu défini plus haut
                {*/
                showMenu = Menu();
                    /*Console.Clear();
                }*/

            }
        }
    }
