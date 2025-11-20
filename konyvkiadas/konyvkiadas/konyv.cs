using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvkiadas
{
    internal class konyv
    {
        public int ev { get; }
        public int negyedev { get; }
        public string szaramazas { get; }
        public string nev { get; }
        public int kiadas { get; }
        public konyv(int ev,int negyedev,string szaramazas, string nev,int kiadas) 
        {
            this.ev = ev;
            this.negyedev = negyedev;
            this.szaramazas = szaramazas;
            this.nev = nev;
            this.kiadas = kiadas;

        }

    }
}
