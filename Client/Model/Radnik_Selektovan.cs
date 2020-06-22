using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Radnik_Selektovan
    {
        public Obezbedjenje Radnik { get; set; }
        public ObservableCollection<string> Klub_Stadion_Nazivi { get; set; }
        public bool IsSelected { get; set; }

        public Radnik_Selektovan()
        {

        }
    }
}
