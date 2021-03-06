using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class parametry_anteny
    {
        int id { get; set; }
        string rodzaj { get; set; }
        double zysk { get; set; }
        double moc { get; set; }
        int id_kabla { get; set; }
        int id_zlacza { get; set; }

        public string parametry_anteny_opis
        {
            get
            {
                return $"{rodzaj} {zysk} {moc} {id_kabla} {id_zlacza}";
            }
        }
    }
}
