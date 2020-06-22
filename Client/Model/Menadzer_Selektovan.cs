using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Menadzer_Selektovan
    {
        public Menadzer M { get; set; }
        public ObservableCollection<string> Nazivi_igraca { get; set; }
        public bool IsSelected { get; set; }

        public Menadzer_Selektovan()
        {

        }
    }
}
