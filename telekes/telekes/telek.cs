using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telekes
{
    internal class telek
    {
        public string adoszam { get; }
        public string utca { get; }
        public string hazszam { get; }
        public string adosav { get; }
        public int terulet { get;}
        public static int[] adosavok = new int[3];
        public telek(string adoszam,string utca,string hazszam,string adosav, string terulet ) 
        {
            this.adoszam = adoszam;
            this.utca = utca;
            this.hazszam = hazszam;
            this.adosav = adosav;
            this.terulet = int.Parse(terulet);
        }
        int ado()
        {

        }
    }
}
