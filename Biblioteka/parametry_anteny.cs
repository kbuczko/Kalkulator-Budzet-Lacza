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
        public string rodzaj { get; set; }
        public double zysk { get; set; }
        public double moc { get; set; }
        public int id_kabla { get; set; }
        public int id_zlacza { get; set; }
        public int czy_nad { get; set; }

        /*public string parametry_anteny_opis
        {
            get
            {
                return $"{rodzaj} {zysk} {moc} {id_kabla} {id_zlacza} {czy_nad}";
            }
        }*/
    }
    public class parametry_anteny_moc
    {
        public string rodzaj { get; set; }
        public double moc { get; set; }
    }
    public class parametry_anteny_zysk
    {
        public string rodzaj { get; set; }
        public double zysk { get; set; }
    }
}
