
using EmployeeMonthlyPaySlip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMonthlyPaySlip.Constants
{
    public static class TaxCalculatorConstants
    {
        public  static List<TaxTier> _taxTiers = new()
        {
            { new TaxTier(0, 20000, 0) },
            { new TaxTier(20001, 40000, 0.1f) },
            { new TaxTier(40001, 80000, 0.2f) },
            { new TaxTier(80001, 180000, 0.3f) },
            { new TaxTier(180001, double.MaxValue, 0.4f) }
        };
    }
}
