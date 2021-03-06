using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class kabel
    {
        int id { get; set; }
        double czestotliwosc { get; set; }
        string nazwa { get; set; }
        double wartosc { get; set; }

        public string kabel_opis
        {
            get
            {
                return $"{czestotliwosc} {nazwa} {wartosc}";
            }
        }
    }
}
