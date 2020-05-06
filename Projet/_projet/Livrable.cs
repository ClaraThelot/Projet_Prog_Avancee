using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Livrable
    {
        private string _type;
        private string _echeance;

        public Livrable( string type, string echeance)
        {
            _type = type;
            _echeance = echeance;
        }
        public override string ToString()
        {
            string res = "";
            res = res + "Le livrable : " + _type + "\n";
            res = res + " est à rendre poour le : " + _echeance + "\n";
            return res;
        }

    }
}
