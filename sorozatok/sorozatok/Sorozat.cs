using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorozatok
{
    internal class Sorozat
    {
        public DateOnly? Datum { get; }
        public string Nev { get; }
        public string Epizod { get; }
        public int Hossz { get; }
        public bool Latta { get; }

        public Sorozat(string d,string n,string e,string h,string l)
        {
            //if (d == "NI") { Datum = null; }
            //else Datum = DateOnly.Parse(d);
            Datum = d == "NI" ? null : DateOnly.Parse(d);
            Nev = n;
            Epizod = e;
            Hossz = int.Parse(h);
            Latta = l=="1" ? true : false;
        }
    }
}
