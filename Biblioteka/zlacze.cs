using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class zlacze
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public double tlumiennosc_db { get; set; }

        public int czestotliwosc_MHz { get; set; }

        /*public string zlacze_opis
        {
            get
            {
                return $"{symbol} {tlumiennosc}";
            }
        }*/
    }
}
