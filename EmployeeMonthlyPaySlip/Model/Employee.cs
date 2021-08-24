namespace EmployeeMonthlyPaySlip.Model
{
    public class Employee : IEmployee
    {
        public Employee(string name, double annualSalary)
        {
            EmployeeName = name;
            AnnualSalary = annualSalary;
        }
        public string EmployeeName { get; set; }
        public double AnnualSalary { get; set; }
    }
}
