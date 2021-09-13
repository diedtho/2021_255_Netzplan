using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_255_Netzplan
{
    public class Vorgang
    {
        public string vorgangBuchstb { get; set; }
        public string beschreibung { get; set; }
        public string dauerInTagen { get; set; }
        public string vorgaenger { get; set; }

        public Vorgang()
        {

        }
        public Vorgang(string vorg, string beschreib, string dauerTage, string vorgaeng)
        {
            vorgangBuchstb = vorg;
            beschreibung = beschreib;
            dauerInTagen = dauerTage;
            vorgaenger = vorgaeng;
        }
    }


}
