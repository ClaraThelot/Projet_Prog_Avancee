using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Matiere
    {
        public string _nom { get; set; }
        private string _code { get; set; }
        private string _UE { get; set; }

        public Matiere(string nom, string code, string UE)
        {
            _nom = nom;
            _code = code;
            _UE = UE;
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "La matière " + _nom + " dont le code est " + _code + "fait partie de l'UE " + _UE;
            return res;
        }
    }
}
