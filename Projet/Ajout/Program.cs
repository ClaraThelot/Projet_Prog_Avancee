using System;
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
                Console.WriteLine("Occupons-nous de la matière n°" + i);
                Console.WriteLine("Voulez vous sélectionner la matière parmi une liste ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom de la matière, faîtes le !");
                string choixM = Console.ReadLine();
                if (choixM == "oui")
                {
                    Console.WriteLine("Tapez le code associé à la matière n°" + i + "du projet.");
                    Console.WriteLine("Voilà la liste des matières !");
                    _AffichageListes.Program.EnSavoirPlusMat(TousMatieres);
                    Console.WriteLine("Si la matière que vous voulez sélectionner n'apparaît pas à l'écran, il va falloir la créer ! Dans ce cas, tapez 000");

                    int numerochoisi = int.Parse(Console.ReadLine());
                    if(numerochoisi==000)
                    {
                        Console.WriteLine("C'est parti pour la création de matière !");
                        int totalLignesM = File.ReadLines("Matieres.txt").Count();
                        Console.WriteLine("Comment s'appelle cette nouvelle matière ?");
                        string nvlLigneM = Console.ReadLine();
                        string nomchoisiM = nvlLigneM;
                        Console.WriteLine("Quelle est son numéro associé ?");
                        string num = Console.ReadLine();
                        nvlLigneM = nvlLigneM + "*" + num;
                        Console.WriteLine("A quelle UE appartient-elle ?");
                        string UE = Console.ReadLine();
                        nvlLigneM = nvlLigneM + "*" + UE + "*";
                        Matiere nvlMatiere = new Matiere(nomchoisiM,num, UE);
                        TousMatieres.Add(nvlMatiere);
                        _AffichageListes.Program.CreaCode("Matieres.txt", nvlLigneM);
                        ligne = ligne + "A" + nomchoisiM + "*";
                    }
                    if (numerochoisi != 000)
                    {
                        foreach (Matiere element in TousMatieres)
                        {
                            if (numerochoisi == TousMatieres.IndexOf(element))
                            {
                                ligne = ligne + "A" + TousMatieres[numerochoisi]._nom + "*";
                            }
                        }
                    }
                }
                else
                {
                    foreach(Matiere element in TousMatieres)
                    {
                        if(choixM==element._nom)
                        {
                            ligne = ligne + "A" + choixM + "*";
                        }
                    }
                }
            }
            List<Eleve> participant = new List<Eleve>();
            //Sélection des élèves
            Console.WriteLine("Combien d'élèves travaillent sur ce projet ?");
            List<Eleve> TousEleves2 = new List<Eleve>();
            TousEleves2 = _InstancePersonne.Program.instancieEleve();
            int NbE = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbE + 1; i++)
            {
                Console.WriteLine("Occupons-nous de l'élève n°" + i);
                Console.WriteLine("Voulez vous sélectionner l'élève parmi une liste ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) de l'élève, faîtes le !");
                string choixE = Console.ReadLine();
                if (choixE == "oui")
                {
                    Console.WriteLine("Tapez le code associé à l'élève du projet.");
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                    _AffichageListes.Program.EnSavoirPlusE(TousEleves2);
                    Console.WriteLine("Si l'élève que vous voulez sélectionner n'apparaît pas à l'écran, il va falloir le créer ! Dans ce cas, tapez creer");

                    int numerochoisiE = int.Parse(Console.ReadLine());
                    if (numerochoisiE == 000)
                    {
                        Console.WriteLine("C'est parti pour la création d'élève !");
                        int totalLignesE = File.ReadLines("Eleves.txt").Count();
                        Console.WriteLine("Quel est le nom de famille de cet élève ?");
                        string nvlLigneE = Console.ReadLine();
                        string nomchoisiE = nvlLigneE;
                        Console.WriteLine("Son prénom ?");
                        string prenom = Console.ReadLine();
                        nvlLigneE = nvlLigneE + "*" + prenom;
                        Console.WriteLine("Son année actuelle ?");
                        string annee = Console.ReadLine();
                        nvlLigneE = nvlLigneE + "*" + annee + "*";
                        Console.WriteLine("Sa promo ?");
                        string promotion = Console.ReadLine();
                        nvlLigneE = nvlLigneE + promotion + "*";
                        int numpromo = int.Parse(promotion);
                        Console.WriteLine("Son groupe de TD ?");
                        string gp = Console.ReadLine();
                        nvlLigneE = nvlLigneE  + gp + "*";
                        int groupe = int.Parse(gp);
                        Eleve nvlEleve = new Eleve(nomchoisiE,prenom,annee,numpromo,groupe);
                        TousEleves2.Add(nvlEleve);
                        participant.Add(nvlEleve);
                        _AffichageListes.Program.CreaCode("Eleves.txt", nvlLigneE);
                        ligne = ligne + "E" + nomchoisiE + "*";
                    }
                    foreach (Eleve element in TousEleves2)
                    {
                        if (numerochoisiE == TousEleves2.IndexOf(element))
                        {
                            participant.Add(TousEleves2[numerochoisiE]);
                            ligne = ligne + "E" + TousEleves2[numerochoisiE]._nom + "*";
                        }
                    }
                }
                else
                {
                    foreach (Eleve element in TousEleves2)
                    {
                        if (choixE == element._nom)
                        {
                            participant.Add(element);
                            ligne = ligne + "E" + choixE + "*";
                        }
                    }
                }
            }

            // Sélection des intervenants
            Console.WriteLine("Combien d'extérieurs interviennent sur ce projet ?");
            List<Exterieur> TousExte = new List<Exterieur>();
            TousExte = _InstancePersonne.Program.instancieIntervenantE();
            int NbI = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbI + 1; i++)
            {
                Console.WriteLine("Occupons-nous de l'intervenant extérieur n°" + i);
                Console.WriteLine("Voulez vous sélectionner l'intervenant parmi une liste ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) de l'intervenant, faîtes le !");
                string choixI = Console.ReadLine();
                if (choixI == "oui")
                {
                    Console.WriteLine("Tapez le code associé à l'extérieur du projet.");
                    Console.WriteLine("Voilà la liste des extérieurs répertoriés !");
                    _AffichageListes.Program.EnSavoirPlusEx(TousExte);
                    int numerochoisi1 = int.Parse(Console.ReadLine());
                    foreach (Exterieur element in TousExte)
                    {
                        if (numerochoisi1 == TousExte.IndexOf(element))
                        {
                            ligne = ligne + "P" + TousExte[numerochoisi1]._nom + "*";
                        }
                    }
                }
                else
                {
                    foreach(Exterieur element in TousExte)
                    {
                        if (choixI == element._nom) ligne = ligne + "P" + choixI + "*";
                    }
                }
            }
            //Séléction du chef de projet :
            Console.WriteLine("Tapez le code associé au chef du projet.");
            Console.WriteLine("Voilà la liste des élèves participant !");
            _AffichageListes.Program.EnSavoirPlusE(participant);
            int numerochoisi4 = int.Parse(Console.ReadLine()); 
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
                _AffichageListes.Program.CreaCode("Livrables.txt", nv);
            }

            //Sélection des profs
            Console.WriteLine("Combien de professeurs gèrent ce projet ?");
            List<Professeur> TousProfs = new List<Professeur>();
            TousProfs = _InstancePersonne.Program.instancieProfesseur();
            int NbProf = int.Parse(Console.ReadLine());
            for (int i = 1; i < NbProf + 1; i++)
            {
                Console.WriteLine("Occupons-nous du professeur n°" + i);
                Console.WriteLine("Voulez vous sélectionner le professeur parmi une liste ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) du professeur, faîtes le !");
                string choixP = Console.ReadLine();
                if (choixP == "oui")
                {
                    Console.WriteLine("Tapez le code associé au premier professeur du projet.");
                    Console.WriteLine("Voilà la liste des professeurs répertoriés !");
                    foreach (Professeur element in TousProfs)
                    {
                        Console.Write(element._nom);
                        Console.WriteLine("     Si vous sélectionnez ce professeur, tapez " + TousProfs.IndexOf(element));
                    }
                    int numerochoisi2 = int.Parse(Console.ReadLine()); 
                    foreach (Professeur element in TousProfs)
                    {
                        if (numerochoisi2 == TousProfs.IndexOf(element))
                        {
                            ligne = ligne + "M" + TousProfs[numerochoisi2]._nom;
                        }
                    }
                }
                else
                {
                    foreach (Professeur element in TousProfs)
                    {
                        if (choixP == element._nom)
                        {
                            ligne = ligne + "M" + element._nom+'*';
                        }
                    }
                }
            }
            //Ecriture dans le fichier Projets.txt
            string ecrire = totalLignes + "*" + ligne;
            _AffichageListes.Program.CreaCode("Projets.txt", ecrire);
            //Affichage de la création 
            Console.Clear();
            Console.WriteLine("Vous avez créé le projet suivant !");
            List<Projet> bdd = new List<Projet>();
            bdd = _InstanceProjet.Program.instancieProjet();
            Projet ajout = bdd.Last();
            ajout.Affichage(ajout);
            return true;

            }
        }
    
}

