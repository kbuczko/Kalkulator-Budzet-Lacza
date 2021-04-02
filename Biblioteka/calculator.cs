using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class calculator
    {
        double tlumiennoscNadajnik { get; set; }
        double mocNadajnik { get; set; }
        double zyskNadajnik { get; set; }
        double fsl { get; set; }
        double zyskOdbiornik { get; set; }
        double tlumiennoscOdbiornik { get; set; }



        public double calculate(double mocNadajnik, double zyskNadajnik, double tlumiennoscNadajnik, double fsl, double zyskOdbiornik, double tlumiennoscOdbiornik)
        {
            return mocNadajnik + zyskNadajnik - tlumiennoscNadajnik - fsl + zyskOdbiornik - tlumiennoscOdbiornik;
        }

    }
}
