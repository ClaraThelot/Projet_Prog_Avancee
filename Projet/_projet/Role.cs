using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    class Role
    {
        private string _nom;
        private string _code;
        private Personne _personne;

        public Role(string nom, string code, Personne personne)
        {
            _nom = nom;
            _code = code;
            _personne = personne;
        }
    }
}
