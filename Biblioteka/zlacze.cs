using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class zlacze
    {
        int id { get; set; }
        string symbol { get; set; }
        double tlumiennosc { get; set; }

        public string zlacze_opis
        {
            get
            {
                return $"{symbol} {tlumiennosc}";
            }
        }
    }
}
