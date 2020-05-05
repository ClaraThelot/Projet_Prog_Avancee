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
            /*List<Eleve> Eleves = new List<Eleve>();
            int counter = 0;
            string line;
            string nom; string prenom; string annee; int promo; int TD;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("Eleves.txt");
            char separateur = '/';
            while ((line = file.ReadLine()) != null)
            {
                String[] str = line.Split(separateur);
                counter++;
                 nom = str[0];  prenom = str[1];  annee = str[2];  promo = int.Parse(str[3]);  TD = int.Parse(str[4]);
                Eleve eleve = new Eleve(nom, prenom, annee, promo, TD);
                Eleves.Add(eleve);
            }
            foreach(Eleve element in Eleves)
            {
                Console.WriteLine(element.ToString());
            }*/
            List<Matiere> Matieres = new List<Matiere>();
            int compte = 0;
            string ligne;
            string nomm; string code; string ue;
            // Read the file and display it line by line.  
            System.IO.StreamReader fichier = new System.IO.StreamReader("Matieres.txt");
            char separateurs = '/';
            while ((ligne = fichier.ReadLine()) != null)
            {
                String[] str = ligne.Split(separateurs);
                compte++;
                nomm = str[0]; code = str[1]; ue = str[2]; 
                Matiere matiere = new Matiere(nomm, code, ue);
                Matieres.Add(matiere);
            }
           /* foreach (Matiere element in Matieres)
            {
                Console.WriteLine(element.ToString());
            }*/
            List<Professeur> Prof = new List<Professeur>();
            int compte2 = 0;
            string ligne2;
            string nomP; string prénomP; string mat; Matiere mate;
            // Read the file and display it line by line.  
            System.IO.StreamReader fichier2 = new System.IO.StreamReader("Professeurs.txt");
            char separateurP = '/';
            while ((ligne2 = fichier2.ReadLine()) != null)
            {
                String[] str = ligne2.Split(separateurs);
                compte2++;
                int elementi = 0;
                int choix = 0;
                nomP=str[0]; prénomP = str[1];  mat=str[2];
                foreach(Matiere element in Matieres)
                {
                    if (element._nom==mat)
                    {
                        choix = elementi;
                    }
                    else
                    {
                        
                    }
                    elementi += 1;
                }
                mate = Matieres[choix];
                Professeur profe = new Professeur(nomP, prénomP, mate);
                Prof.Add(profe);
            }
            foreach (Professeur element in Prof)
            {
                Console.WriteLine(element.ToString());
            }

        }
    }
}
