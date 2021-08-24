# EmployeeMonthlyPaySlip
A simple Console application to generate monthly payslip.
Unit test project included.

## Frameworks and libraries
* Net Core 5.0
* Microsoft.Extensions.DependencyInjections
* Microsoft.Extensions.Hosting
* Serilog - (Sinks.Console - to output to console)

## How to test console application project - EmployeeMonthlyPaySlip
First, install .NET Core 5.0. 

Open the terminal or command prompt at the project root path (/EmployeeMonthlyPaySlip/EmployeeMonthlyPaySlip/) and run the following commands, in sequence:
(cd to the project path). 

Program takes 2 arguments : Employee name and a decimal value as annual salary. If name has spaces, use the full name within brackets. (shown in the example)
```
dotnet restore
dotnet run <Employee Name> <annual salary>
```

e.g dotnet run "Mary Song" 6000

Program validates the input parameters and will give error notifications if arguments are not passed or invalid

* If running directly via Visual studio, make sure to set Application arguments in Debug section of project properties.

## Expected outcome 
If payslip is generated successfully, the following format will output to the console
 ```
  Monthly Payslip for: Employee Name
  Gross Monthly Income : GrossIncome
  Monthly Income Tax: IncomeTax
  Net Monthly Income: NetIncome 
  ```
  e.g
  ```
  Monthly Payslip for: "Mary Song"
  Gross Monthly Income: $5000
  Monthly Income Tax: $500
  Net Monthly Income: $4500
  ```
  
 ###  Assumptions
  * Max range for last tier is double.Max
  * All calculated values are rounded to 2 decimals.
  
 ### Tax tiers and rates used for the calcuation
 Taxable income       | Tax on this income
-------------         | -------------
$0 - $20,000          | $0
$20,001 - $40,000     | 10c for each $1 over $20,000
$40,001 - $80,000     | 20c for each $1 over $40,000
$80,001 - $180,000    | 30c for each $1 over $80,000
$180,001 and over     | 40c for each $1 over $180,000
  
```
For example, for an employee with an annual salary of $60,000:
* gross monthly income
= 60,000 / 12
= 5,000

* monthly income tax
= ((20,000 * 0) + ((40,000 - 20,000) * 0.1) + ((60,000 - 40,000) * 0.2)) / 12
= (0 + (20,000 * 0.1) + (20,000 * 0.2)) / 12
= (0 + 2,000 + 4,000) / 12
= 500
* net monthly income
= 5,000 – 500
= 4,500
```
## How to Unit test project - EmployeeMonthlyPaySlipTest

Open the terminal or command prompt at the project root path (/EmployeeMonthlyPaySlip/EmployeeMonthlyPaySlipTest/) and run the following command:
(cd to the test project path)
```
dotnet test
```    
