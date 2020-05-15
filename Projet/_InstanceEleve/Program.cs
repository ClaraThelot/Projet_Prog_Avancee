using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _AffichageListes // Pour factoriser les codes d'affichage des différentes listes
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static void AfficheParAn(string annee, List <Eleve> ListeE)
        {
            Console.WriteLine(annee+" :");
            foreach (Eleve element in ListeE)
            {
                if (element._annee == annee)
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + ListeE.IndexOf(element));
                }
            }
        }
        public static void ProjetparPromo(int prom,List<Projet>ListeP)
        {
            foreach (Projet element in ListeP)
            {
                if (element._chefprojet._promo == prom)
                {
                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + ListeP.IndexOf(element));
                }
            }
        }
        public static void EnSavoirPlusEx(List<Exterieur> ListeE)
        {
            foreach (Exterieur element in ListeE)
            {
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez sélectionner cet intervenant en particulier, tapez " + ListeE.IndexOf(element));
                }
            }
        }
        public static void EnSavoirPlusMat(List<Matiere> ListeM)
        {
            foreach (Matiere element in ListeM)
            {
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez sélectionner cette matière en particulier, tapez " + ListeM.IndexOf(element));
                }
            }
        }
        public static void EnSavoirPlusE(List<Eleve> ListeE)
        {
            foreach (Eleve element in ListeE)
            {
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez sélectionner cet élève en particulier, tapez " + ListeE.IndexOf(element));
                }
            }
        }
        public static void CreaCode(string file, string ligne)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file, append: true))
                {

                    writer.Write("\r\n" + ligne);
                }
            }
            catch (Exception exp)
            {
                Console.Write("Erreur");
            }
        }

    }
}
