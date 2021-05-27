using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class kabel
    {
        public int id { get; set; }
        public double czestotliwosc_MHz { get; set; }
        public string symbol { get; set; }
        public double tlumiennosc_db1m { get; set; }

       /* public string kabel_opis
        {
            get
            {
                return $"{czestotliwosc} {nazwa} {wartosc}";
            }
        }*/
    }
}
