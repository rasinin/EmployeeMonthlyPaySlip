
using System.Collections.Generic;

namespace EmployeeMonthlyPaySlip.Model
{
    public interface ITaxCalculator
    {
                
        double CalculateIncomeTax(double annualSalary);
        
    }
}
