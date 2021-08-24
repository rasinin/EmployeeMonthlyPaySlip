using System.Collections.Generic;
using System.Linq;

namespace EmployeeMonthlyPaySlip.Model
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IReadOnlyCollection<TaxTier> _taxTiers;

        public TaxCalculator(IReadOnlyCollection<TaxTier> taxTiers)
        {
            _taxTiers = taxTiers;
        }

       
        public double CalculateIncomeTax(double annualSalary)
        {
            return _taxTiers
                .Where(tier => tier.Min <= annualSalary)
                .Select(filteredTier =>
                {
                    return annualSalary > filteredTier.Max
                        ? (filteredTier.Max - filteredTier.Min + 1) * filteredTier.Rate
                        : (annualSalary - filteredTier.Min + 1) * filteredTier.Rate;
                })
                .Sum();           
           
        }
    }
}
