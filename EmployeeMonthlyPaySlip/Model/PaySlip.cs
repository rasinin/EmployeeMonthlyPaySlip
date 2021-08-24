using System;

namespace EmployeeMonthlyPaySlip.Model
{
    /// <summary>
    /// Created a base class to encapsulate common logic. Currently supporting Monthly pay slips
    /// Later can add weekly or fortnightly pay slips if needed.
    /// </summary>
    public class PaySlip : IPaySlip

    {
        public virtual int PeriodNumber => 1;
        public virtual string PeriodName => "Annual";
        public string Name { get; }
        public double GrossIncome { get; }
        public double IncomeTax { get; }
        public double NetIncome { get => GrossIncome - IncomeTax; }

        public PaySlip(IEmployee employee, ITaxCalculator taxCalculator)
        {
            Name = employee.EmployeeName;
            GrossIncome = Math.Round(employee.AnnualSalary / PeriodNumber, 2);
            IncomeTax = Math.Round(taxCalculator.CalculateIncomeTax(employee.AnnualSalary) / PeriodNumber, 2);

        }

        
        public string AsReportString()
        {
            return Environment.NewLine + 
                   $"{PeriodName} Payslip for: {Name}" + Environment.NewLine +
                   $"Gross {PeriodName} Income : {GrossIncome}" + Environment.NewLine +
                   $"{PeriodName} Income Tax: {IncomeTax}" + Environment.NewLine +
                   $"Net {PeriodName} Income: {NetIncome}";

        }
    }
}
