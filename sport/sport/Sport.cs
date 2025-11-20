using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace sport
{
    internal class Sport
    {
        public string sportag { get; }
        public string haza { get;}
        public string vendeg { get; }
        public int Hfelido { get; set; }
        public int Vfelido { get; set; }
        public int Hveg { get; set; }
        public int Vveg { get; set; }
        public Sport(string sportag,string haza,string vendeg) 
        {
            this.sportag = sportag;
            this.haza = haza;
            this.vendeg = vendeg;
        }
    }
}
