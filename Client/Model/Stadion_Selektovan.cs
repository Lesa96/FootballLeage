using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Stadion_Selektovan
    {
        public Stadion S { get; set; }
        public string Naziv_stadiona { get; set; }
        public ObservableCollection<string> Nazivi_klubova { get; set; }
        public bool IsSelected { get; set; }

        public Stadion_Selektovan()
        {

        }
    }
}
