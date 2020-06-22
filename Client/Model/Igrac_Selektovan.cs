using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Igrac_Selektovan
    {
        public Igrac igrac { get; set; }
        public string Prethodni_klub { get; set; }
        public string Ime_Prezime { get; set; }
        public ObservableCollection<string> Transferi { get; set; }
        public bool IsSelected { get; set; }

        public Igrac_Selektovan()
        {

        }
    }
}
