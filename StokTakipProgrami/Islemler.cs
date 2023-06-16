using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipProgrami
{
    static class Islemler
    {
        public static double DoubleYap(string deger)
        {
            double result;
            double.TryParse(deger ,NumberStyles.Currency,CultureInfo.CurrentUICulture.NumberFormat,out result);
            return result;
        }
    }
}
