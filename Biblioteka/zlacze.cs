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
        public double tlumiennosc { get; set; }

        public int id_kab { get; set; }

        /*public string zlacze_opis
        {
            get
            {
                return $"{symbol} {tlumiennosc}";
            }
        }*/
    }
}
