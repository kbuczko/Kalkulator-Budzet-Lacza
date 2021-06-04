using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class tl_materialow
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public double tlumiennosc { get; set; }

        public double grubosc_cm { get; set; }

        public double czestotliwosc_MHz { get; set; }

        /* public string material
         {
             get
             {
                 return $"{id} {nazwa} {wartosc}";
             }
         }*/

    }
    public class tl_materialow2
    {
        public string nazwa { get; set; }
        public double tlumiennosc { get; set; }

        public double grubosc_cm { get; set; }

        public int czestotliwosc_MHz { get; set; }
    }
}
