using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gere_Csanád_Console
{
    public class Konyvtar
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iskola/*szerzo*/ { get; set; }
        public string datum/*kiadas_ev*/ { get; set; }
        public string verseny /* konyvtar */ { get; set; }
        public int szazalek { get; set; }

        public Konyvtar(string[] sor)
        {
            this.id = int.Parse(sor[0]);
            this.name = sor[1];
            this.iskola = sor[2];
            this.datum = sor[3];
            this.verseny = sor[4];
            this.szazalek = int.Parse(sor[5]);
        }

        public static List<Konyvtar> ReadFile()
        {
            List<Konyvtar> konyv = new List<Konyvtar>();
            File.ReadAllLines("students.csv").ToList().Skip(1).ToList().ForEach(l =>
            {
                konyv.Add(new Konyvtar(l.Split(",")));
            });
            return konyv;
        }
    }
}
