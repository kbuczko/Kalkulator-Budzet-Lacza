using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Urzadzenie
    {

        public int id { get; set; }

        public string nazwa { get; set; }
        public double moc { get; set; }

        public int id_kabla { get; set; }
        //public string nazwa_kabla { get; set; }
        public int id_zlacza { get; set; }
        //public string nazwa_zlacza { get; set; }

        public string nazwa_anteny { get; set; }
        public int id_anteny { get; set; }

        public double czulosc { get; set; }
    }
}
