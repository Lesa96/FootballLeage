using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Navijac_Selektovan
    {
        public Navijac N { get; set; }
        public ObservableCollection<string> Nazivi_klubova { get; set; }
        public bool IsSelected { get; set; }

        public Navijac_Selektovan()
        {

        }
    }
}
