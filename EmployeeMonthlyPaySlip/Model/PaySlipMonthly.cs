using System;

namespace EmployeeMonthlyPaySlip.Model
{
    public class PaySlipMonthly : PaySlip
    {
        public override int PeriodNumber => 12;
        public override string PeriodName => "Monthly";

        public PaySlipMonthly(IEmployee employee, ITaxCalculator taxCalculator) : base(employee, taxCalculator)
        {
        }
    }
}
