using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosarlabda
{
    internal class kosar
    {
        public string hazai { get;}
        public string idegen{ get; }
        public string helyszin{ get;}
        public string idopont { get; }
        public int hazai_pont { get; }
        public int idegen_pont { get; }
        public kosar(string sor)
        {
            string[] sor1 = sor.Split(";");
            hazai= sor1[0];
            idegen= sor1[1];
            hazai_pont= int.Parse(sor1[2]);
            idegen_pont = int.Parse(sor1[3]);
            helyszin= sor1[4];
            idopont = sor1[5];
        }
    }

}
