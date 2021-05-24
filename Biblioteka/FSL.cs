using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class FSL
    {
        public int id { get; set; }
        public double id_odl { get; set; }
        public int id_czest { get; set; }
        public double wartosc { get; set; }


        /*public string Wartosci
        {
            get
            {
                return $"{id} {odleglosc} {czestotliwosc} {wartosc}";
            }
        }*/
            
    }
    public class FSL2
    {
        public double id_odl { get; set; }
        public int id_czest { get; set; }
        public double wartosc { get; set; }
    }
}
