using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Sudija_Selektovan
    {
        public Sudija S { get; set; }
        public string Naziv_sudije { get; set; }
        public string Liga_Sudije { get; set; }
        public bool IsSelected { get; set; }

        public Sudija_Selektovan()
        {

        }

        public int getIDSudije()
        {
            return S.id_sudije;
        }
    }
}
