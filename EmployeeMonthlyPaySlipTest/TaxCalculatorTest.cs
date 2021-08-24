using Xunit;
using EmployeeMonthlyPaySlip.Model;
using System;
using Moq;
using EmployeeMonthlyPaySlip.Constants;

namespace EmployeeMonthlyPaySlipTest
{
    public class TaxCalculatorTest
    {
        [Theory]
        [InlineData(-1000, 0)]
        [InlineData(20000, 0)]
        [InlineData(60000, 6000)]
        [InlineData(90000, 13000)]
        [InlineData(200000, 48000)]
        public void CalculateIncomeTax_ReturnsCorrectAnnualTax_GivenAnnualSalary(double annualSalary, double incomeTax)
        {
            //Arrange
            var taxCalculator = new TaxCalculator(TaxCalculatorConstants._taxTiers);

            //Act
            var result = taxCalculator.CalculateIncomeTax(annualSalary);

            //Assert
            Assert.Equal(Math.Round(incomeTax, 2), Math.Round(result, 2));

        }
    }
}
