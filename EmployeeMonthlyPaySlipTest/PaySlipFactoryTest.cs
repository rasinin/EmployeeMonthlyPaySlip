using Moq;
using Xunit;
using EmployeeMonthlyPaySlip.Model;

namespace EmployeeMonthlyPaySlipTest
{
    public class PaySlipFactoryTest
    {
        
        [Theory]
        [InlineData("Monthly")]
        public void Should_CreateMonthlyPaySlip(string expectedPeriodName)
        {
            //Arrange
            var employee = new Mock<IEmployee>();
            var taxCalculator = new Mock<ITaxCalculator>();
            
            //Act
            var result = PaySlipFactory.CreatePaySlip(employee.Object, taxCalculator.Object, out IPaySlip payslip);

            //Assert
            Assert.True(result);
            Assert.Equal(expectedPeriodName, payslip.PeriodName);
        }
    }
}
