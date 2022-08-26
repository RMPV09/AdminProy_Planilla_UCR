using FluentAssertions;
using Xunit;
using Application.TaxCalculator.Implementations;

namespace Tests.Application
{
    public class TaxCalculatorTest
    {
        TaxCalculatorService taxCalculatorService = new TaxCalculatorService();
        string taxCCSS = "CCSS";
        string taxRent = "Rent";

        [Fact]
        public void GetNoRentTaxes()
        {
            //arrange
            double _grossSalary = 200000.00;
            double expectedCCSSAmount = 21000.00;
            double expectedRentAmount = 0.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetOverF1RentTaxes()
        {
            //arrange
            double _grossSalary = 864000.00;
            double expectedCCSSAmount = 90720.00;
            double expectedRentAmount = 100.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetF2RentTaxes()
        {
            //arrange
            double _grossSalary = 2223000.00;
            double expectedCCSSAmount = 233415.00;
            double expectedRentAmount = 183800.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetOverF3RentTaxes()
        {
            //arrange
            double _grossSalary = 2224000.00;
            double expectedCCSSAmount = 233520.00;
            double expectedRentAmount = 184000.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetF4RentTaxes()
        {
            //arrange
            double _grossSalary = 4445000.00;
            double expectedCCSSAmount = 466725.00;
            double expectedRentAmount = 628200.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetOverF4RentTaxes()
        {
            //arrange
            double _grossSalary = 5445000.00;
            double expectedCCSSAmount = 571725.00;
            double expectedRentAmount = 878200.00;

            //act
            double CCSSAmount = taxCalculatorService.GetTaxAmount(taxCCSS, _grossSalary);
            double RentAmount = taxCalculatorService.GetTaxAmount(taxRent, _grossSalary);

            //assert
            CCSSAmount.Should().Be(expectedCCSSAmount);
            RentAmount.Should().Be(expectedRentAmount);
        }

        [Fact]
        public void GetEmployerSocialCharges()
        {
            //arrange
            double _grossSalary = 328600.00;
            double expectedEmployerSocialChargesAmount = 87079.00;
            double expectedCCSSAmount = 47647.00;
            double expectedOtherInstitutionsAmount = 23823.50;
            double expectedWorkerWarrantiesAmount = 15608.50;

            //act
            double EmployerSocialChargesAmount = taxCalculatorService.GetEmployerSocialCharges(_grossSalary);
            double CCSSAmount = taxCalculatorService.GetCSSSEmployerTaxes(_grossSalary);
            double OtherInstitutionsAmount = taxCalculatorService.GetOtherInstitutionsEmployerTaxes(_grossSalary);
            double WorkerWarrantiesAmount = taxCalculatorService.GetWorkerWarrantiesEmployerTaxes(_grossSalary);

            //assert
            EmployerSocialChargesAmount.Should().NotBe(null);
            CCSSAmount.Should().NotBe(null);
            OtherInstitutionsAmount.Should().NotBe(null);
            WorkerWarrantiesAmount.Should().NotBe(null);
            EmployerSocialChargesAmount.Should().Be(expectedEmployerSocialChargesAmount);
            CCSSAmount.Should().Be(expectedCCSSAmount);
            OtherInstitutionsAmount.Should().Be(expectedOtherInstitutionsAmount);
            WorkerWarrantiesAmount.Should().Be(expectedWorkerWarrantiesAmount);
        }
    }
}
