using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class calculator
    {
        double tlumiennoscNadajnik;
        double mocNadajnik;
        double zyskNadajnik;
        double fsl;
        double zyskOdbiornik;
        double tlumiennoscOdbiornik;

        public double calculate(double tlumiennoscNadajnik, double mocNadajnik, double zyskNadajnik, double fsl, double zyskOdbiornik, double tlumiennoscOdbiornik)
        {
            return mocNadajnik + zyskNadajnik - tlumiennoscNadajnik - fsl + zyskOdbiornik - tlumiennoscOdbiornik;
        }

    }
}
