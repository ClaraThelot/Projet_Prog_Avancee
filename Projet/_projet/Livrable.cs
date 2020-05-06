using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Livrable
    {
        private string _type { get; set; }
        public string _echeance { get; set; }

        public Livrable( string type, string echeance)
        {
            _type = type;
            _echeance = echeance;
        }
        public override string ToString()
        {
            string res = "";
            res = res + "Le livrable : " + _type + "\n";
            res = res + " est à rendre pour le : " + _echeance + "\n";
            return res;
        }

    }
}
