
namespace EmployeeMonthlyPaySlip.Model
{
    public interface IPaySlip
    {
        public int PeriodNumber { get; }
        public string PeriodName { get; }
        public string Name { get; }
        public double GrossIncome { get; }

        public double IncomeTax { get; }

        public double NetIncome { get; }

        public string AsReportString();
    }
}
