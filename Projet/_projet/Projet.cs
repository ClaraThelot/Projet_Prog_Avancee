using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Projet
    {
        private double _duree;
        private bool _sujetLibre;
        private Eleve[] _eleves;
        private Personne[] _intervenants;
        private Matiere[] _matieres;
        private Eleve _chefprojet;

        public Projet(double duree, bool sujetlibre, Eleve[] eleves, Personne[] intervenants, Matiere[] matieres, Eleve chefprojet)
        {
            _duree = duree;
            _sujetLibre = sujetlibre;
            _eleves = eleves;
            _intervenants = intervenants;
            _matieres = matieres;
            _chefprojet = chefprojet;
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "Durée du projet :" + _duree;
            res = res + "Type de sujet :" + _sujetLibre;
            res = res + "Elèves participants :" + _eleves;
            res = res + "Intervenants  " + _intervenants;
            res = res + "Matières concernées :" + _matieres;
            res = res + "Chef de Projet :" + _chefprojet;
            return res;
        }
    }
}
