using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Projet
    {
        private string _nomProjet { get; }
        private double _duree { get; set; }
        private bool _sujetLibre{ get; set; }
        private Eleve[] _eleves { get; set; }
        private Personne[] _intervenants { get; set; }
        private Matiere[] _matieres { get; set; }
        private Eleve _chefprojet { get; set; }
        private bool _sujetAcheve { get; set; }
        private double _note { get; set; }

        public Projet(string nom, double duree, bool sujetlibre, double note, bool sujetAcheve, Eleve[] eleves, Personne[] intervenants, Matiere[] matieres, Eleve chefprojet)
        {
            _nomProjet = nom;
            _duree = duree;
            _sujetLibre = sujetlibre;
            _eleves = eleves;
            _intervenants = intervenants;
            _matieres = matieres;
            _chefprojet = chefprojet;
            _sujetAcheve = sujetAcheve;
            _note = note;
        }
        public void ajoutEleve (Eleve E1)
        {
            for(int i=0; i<_eleves.Length; i++)
            {
                if(_eleves[i]!=null) { _eleves[i] = E1; } //Si le tableau n'est pas vide, on ajoute un l'élève considéré 
            }
        }
        public void supprimeEleve(Eleve E1)
        {
            for(int i=0; i<_eleves.Length;i++)
            { if (_eleves[i] == E1) _eleves[i] = null; } // Supprime un élève, par contre laisse un trou dans le tableau à l'endroit considéré
        }

        public void ajoutMatiere(Matiere M1)
        {
            for (int i = 0; i < _matieres.Length; i++)
            {
                if (_matieres[i] != null) { _matieres[i] = M1; }
            }
        }
      
       public void supprimeMatiere(Matiere M1)
        {
            for (int i = 0; i < _matieres.Length; i++)
            { if (_matieres[i] == M1) _matieres[i] = null; } 
        }

   
        public void ajoutIntervenant(Exterieur Ex1)
        {
            for (int i = 0; i < _intervenants.Length; i++)
            {
                if (_intervenants[i] != null) { _intervenants[i] = Ex1; }
            }
        }

        public void supprimeIntervenant(Exterieur Ex1)
        {
            for (int i = 0; i < _intervenants.Length; i++)
            { if (_intervenants[i] == Ex1) _intervenants[i] = null; }
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "Nom du projet : " + _nomProjet + "\n";
            res = res + "Durée du projet :" + _duree + "\n";
            res = res + "Type de sujet :" + _sujetLibre + "\n";
            res = res + "Elèves participants :" + _eleves + "\n";
            res = res + "Intervenants  " + _intervenants + "\n";
            res = res + "Matières concernées :" + _matieres + "\n";
            res = res + "Chef de Projet :" + _chefprojet + "\n";
            res = res + "Sujet Achevé : " + _sujetAcheve + "\n";
            if (_sujetAcheve == true) res = res + "Note : " + _note + "\n";
            return res;
        }

    }
}
