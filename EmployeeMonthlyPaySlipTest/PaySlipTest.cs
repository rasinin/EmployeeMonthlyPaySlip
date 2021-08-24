using Moq;
using Xunit;
using EmployeeMonthlyPaySlip.Model;
using System.Collections.ObjectModel;
using EmployeeMonthlyPaySlip.Constants;

namespace EmployeeMonthlyPaySlipTest
{
    public class PaySlipTest
    {
        [Theory]
        [InlineData(60000, 5000)]
        [InlineData(0, 0)]
        public void Should_Return_CorrectMonthlyGrossIncome(double annualSalary, double expectedGrossIncome)
        {
            //Arrange           
            var employee = Mock.Of<IEmployee>(m =>
                               m.EmployeeName == "Mary Song" &&
                               m.AnnualSalary == annualSalary);
           
            var taxCalculator = new Mock<ITaxCalculator>();

            //Act
            var result = new PaySlipMonthly(employee, taxCalculator.Object);

            //Assert
            Assert.Equal(expectedGrossIncome, result.GrossIncome);
        }

        [Theory]
        [InlineData(60000, 500)]
        [InlineData(0, 0)]
        public void Should_Return_CorrectMonthlyIncomeTax(double annualSalary, double expectedIncomeTax)
        {
            //Arrange           
            var employee = Mock.Of<IEmployee>(m =>
                               m.EmployeeName == "Mary Song" &&
                               m.AnnualSalary == annualSalary);
            
            var taxCalculator = new TaxCalculator(TaxCalculatorConstants._taxTiers);

            //Act
            var result = new PaySlipMonthly(employee, taxCalculator);

            //Assert
            Assert.Equal(expectedIncomeTax, result.IncomeTax);
        }

        [Theory]
        [InlineData(60000, 4500)]
        [InlineData(0, 0)]
        public void Should_Return_CorrectMonthlyNetIncome(double annualSalary, double expectedNetIncome)
        {
            //Arrange           
            var employee = Mock.Of<IEmployee>(m =>
                               m.EmployeeName == "Mary Song" &&
                               m.AnnualSalary == annualSalary);

            var taxCalculator = new TaxCalculator(TaxCalculatorConstants._taxTiers);

            //Act
            var result = new PaySlipMonthly(employee, taxCalculator);

            //Assert
            Assert.Equal(expectedNetIncome, result.NetIncome);
        }
    }
}
