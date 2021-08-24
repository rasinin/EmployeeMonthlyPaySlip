
namespace EmployeeMonthlyPaySlip.Model
{
    /// <summary>
    /// Each tax tier defines the income range and its rate 
    /// e.g $20,001 - $40,000 10c for each $1 over $20,000
    /// Min 20,001, Max $40,000, Rate 10c
    /// </summary>
    public class TaxTier
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public float Rate { get; set; }

        public TaxTier(double min, double max, float rate)
        {
            Min = min;
            Max = max;
            Rate = rate;
        }
    }
}
