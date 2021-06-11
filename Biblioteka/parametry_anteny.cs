using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class parametry_anteny
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public double zysk_dBi { get; set; }

        public int czestotliwosc_MHz { get; set; }

        public int id_zlacza { get; set; }
    }

    public class parametry_anteny_moc
    {
        public int id { get; set; }
        public double moc { get; set; }
    }
    public class parametry_anteny_zysk
    {
        public string nazwa { get; set; }
        public double zysk_dBi { get; set; }
    }
}
