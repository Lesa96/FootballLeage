using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Liga_Selektovan 
    {
        public Liga L { get; set; }
        public string Naziv_lige { get; set; }
        public double Prosecna_Vrednost_Klubova { get; set; }
        public string SelectedItem { get; set; }

        public Liga_Selektovan()
        {

        }

        public int getIDLige()
        {
            return L.id_lige;
        }
    }
}
