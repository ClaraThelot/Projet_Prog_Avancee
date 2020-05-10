using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Role
    {
        public string _nom;
        public string _code;
        public Personne _personne;
        public Projet _projet;

        
        public Role(string nom, string code)
        {
            _nom = nom;
            _code = code;
        }
        public Role(string nom, string code, Personne personne, Projet projet)
        {
            _nom = nom;
            _code = code;
            _personne = personne;
            _projet = projet;
        }
        public override string ToString()
        {
            string res = "";
            res = res + "La personne "+_personne+"assume comme rôle "+_nom+" au sein du projet "+_projet+".\n";
            return res;
        }
    }
}
