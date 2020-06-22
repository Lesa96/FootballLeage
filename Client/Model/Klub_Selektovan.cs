using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Klub_Selektovan
    {
        public Klub K { get; set; }
        public string Naziv_lige { get; set; }
        public string Trener { get; set; }
        public int Broj_Navijaca { get; set; }
        public float Prosecna_Starost { get; set; }
        public bool IsSelected { get; set; }

        public Klub_Selektovan()
        {

        }
    }
}
