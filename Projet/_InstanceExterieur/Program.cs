using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _InstanceExterieur
{
    public class Program
    {
        static void Main(string[] args)
        {
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
