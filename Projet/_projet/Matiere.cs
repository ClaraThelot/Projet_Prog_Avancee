using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Matiere
    {
        public string _nom;
        private string _code;
        private string _UE;

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
