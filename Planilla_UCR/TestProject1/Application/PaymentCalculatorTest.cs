using FluentAssertions;
using Xunit;
using Application.PaymentCalculator.Implementations;

namespace Tests.Application
{

    public class PaymentCalculatorTest
    {
        private double _mountPerHour = 1500;
        private int _workedDays = 16;
        private int _workedHours = 24;
        private double _fullTimeSalary = 192000;
        private double _partTimeSalary = 96000;
        private double _perHoursSalary = 36000;

        [Fact]
        public void GetProjectHoursReport()
        {
            //arrange
            var paymentCalculatorService = new PaymentCalculatorService();

            //act
            var grossSalaryFT = paymentCalculatorService.GetFullTimeSalary(_mountPerHour, _workedDays);
            var grossSalaryHT = paymentCalculatorService.GetPartTimeSalary(_mountPerHour, _workedDays);
            var grossSalaryPT = paymentCalculatorService.GetSalaryPerHours(_mountPerHour, _workedHours);

            //assert
            grossSalaryFT.Should().Be(_fullTimeSalary);
            grossSalaryHT.Should().Be(_partTimeSalary);
            grossSalaryPT.Should().Be(_perHoursSalary);
        }
    }
}
