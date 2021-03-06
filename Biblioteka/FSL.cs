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
        public double odleglosc { get; set; }
        public int czestotliwosc { get; set; }
        public double wartosc { get; set; }


        public string Wartosci
        {
            get
            {
                return $"{odleglosc} {czestotliwosc} {wartosc}";
            }
        }
            
    }
}
