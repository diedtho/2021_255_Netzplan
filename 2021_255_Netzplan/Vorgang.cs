using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_255_Netzplan
{
    public class Vorgang
    {
        public char vorgangBuchstb { get; set; }
        public string beschreibung { get; set; }
        public int dauerInTagen { get; set; }
        public List<char> vorgaenger { get; set; }
        public string strVorg { get; set; }
        public List<char> nachfolger { get; set; }
        public string strNachf { get; set; }
        public int faz { get; set; }
        public int fez { get; set; }
        public int saz { get; set; }
        public int sez { get; set; }
        public int gp { set; get; }
        public int fp { set; get; }

        public Vorgang()
        {

        }
        public Vorgang(char vorg, string beschreib, int dauerTage, List<char> vorgaengr, List<char> nachfolgr)
        {
            vorgangBuchstb = vorg;
            beschreibung = beschreib;
            dauerInTagen = dauerTage;
            vorgaenger = vorgaengr;
            nachfolger = nachfolgr;
        }
    }


}
