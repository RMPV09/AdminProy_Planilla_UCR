
namespace Application.TaxCalculator
{
    public interface ITaxCalculatorService
    {
        public double GetRentTax(double grossSalary);
        public double GetCSSTax();
        public double GetTaxPercentage(string taxName, double grossSalary);
        public double GetTaxAmount(string taxName, double grossSalary);
        public double GetEmployerSocialCharges(double grossSalary);
        public double GetCSSSEmployerTaxes(double grossSalary);
        public double GetOtherInstitutionsEmployerTaxes(double grossSalary);
        public double GetWorkerWarrantiesEmployerTaxes(double grossSalary);
    }
}
