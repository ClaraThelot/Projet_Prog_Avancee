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
        private DateTime _echeance;

        public Livrable( string type, DateTime echeance)
        {
            _type = type;
            _echeance = echeance;
        }

    }
}
