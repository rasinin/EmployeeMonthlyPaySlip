using System;

namespace EmployeeMonthlyPaySlip.Model
{
    /// <summary>
    /// Factory class to create concrete payslips.
    /// I haven't done any other types of payslip types like weekly or fortnightly in this solution
    /// In the future add a input param to decide what type to return
    /// </summary>
    public class PaySlipFactory
    {
       
        public static bool CreatePaySlip(IEmployee employee, ITaxCalculator taxCalculator, out IPaySlip paySlip)
        {
            paySlip = new PaySlipMonthly(employee, taxCalculator);
            
            return true;
        }
    }
}
