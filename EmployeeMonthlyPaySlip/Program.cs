using EmployeeMonthlyPaySlip.Constants;
using EmployeeMonthlyPaySlip.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;


namespace EmployeeMonthlyPaySlip
{
    class Program
    {
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>                    
                    services.AddSingleton<ITaxCalculator>(provider => new TaxCalculator(TaxCalculatorConstants._taxTiers)));

        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var taxCalculator = host.Services.CreateScope().ServiceProvider.GetRequiredService<ITaxCalculator>();
            
            Log.Logger = new LoggerConfiguration()                   
                   .WriteTo.Console()
                   .CreateLogger();

                        
            var result = IsValidInput(args);
            if (!result.IsSucess)
            {
                Log.Error(result.Error);
                return;
            }

            string empName = args[0];
            double annualSalary = Double.Parse(args[1]);

            IEmployee employee = new Employee(empName, annualSalary);
           
            Log.Information(
                PaySlipFactory.CreatePaySlip(employee, taxCalculator, out IPaySlip payslip)
                    ? payslip.AsReportString()
                    : $"Unable to generate payslip for {employee.EmployeeName} ");

            Log.CloseAndFlush();
        }


        //Validate the input 
        static (bool IsSucess, string Error) IsValidInput(string[] args)
        {
            string message = string.Empty;

            if (args.Length < 2)
            {
                message = "Missing arguments. Please enter employee name and annual salary." + Environment.NewLine +
                        "Usage: EmployeeMonthlyPaySlip <Employee name> <salaray>";
                return (false, message);
            }

            try
            {
                double salary = Double.Parse(args[1]);
                if (salary < 0)
                {
                    message = "Please enter a positive annual salary.";
                    return (false, message);
                }
            }
            catch (Exception)
            {
                message = "Invalid salary entered. Please enter a positive numeric value for annual salary.";
                return (false, message);
            }

            return (true, message);
        }
    }
}
