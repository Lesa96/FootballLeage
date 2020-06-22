using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Poseduje_Selektovan
    {
        public Poseduje P { get; set; }
        public string Klub_Stadion_Nazivi { get; set; }
        public string Naziv_Stadiona { get; set; }
        public bool IsSelected { get; set; }

        public Poseduje_Selektovan()
        {

        }
    }
}
