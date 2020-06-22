using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Vlasnik_Selektovan
    {
        public Vlasnik V { get; set; }
        public string Naziv_vlasnika { get; set; }
        public ObservableCollection<string> Nazivi_klubova { get; set; }
        public bool IsSelected { get; set; }

        public Vlasnik_Selektovan()
        {

        }
    }
}
