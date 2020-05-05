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
            List<Eleve> Eleves = new List<Eleve>();
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
            }
        }
    }
}
