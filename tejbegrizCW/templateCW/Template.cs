using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace templateNev
{
    internal class Template
    {
        public string nev;
        public string nem;
        public string reszleg;
        public int belepesEv;
        public int ber;

        public Dolgozo(string nev, string nem, string reszleg, int belepesEv, int ber)
        {
            this.nev = nev;
            this.nem = nem;
            this.reszleg = reszleg;
            this.belepesEv = belepesEv;
            this.ber = ber;
        }
        public override string ToString()
        {
            return this.nev;
        }
    }
}
