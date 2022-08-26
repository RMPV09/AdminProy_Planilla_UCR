
namespace Application.TaxCalculator.Implementations
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly double SEM = 5.50;
        private readonly double IVM = 4.0;
        private readonly double POPULAR_BANK_APPORT = 1.0;

        double endF1 = 863000.00;
        double endF2 = 1267000.00;
        double endF3 = 2223000.00;
        double endF4 = 4445000.00;

        public TaxCalculatorService()
        {

        }

        public double GetRentTax(double grossSalary)
        {
            double rentTax = 0;
            if (grossSalary <= endF1)
            {
                rentTax = 0;
            }
            else
            {
                if (endF1 <= grossSalary)
                {
                    if (endF2 > grossSalary)
                    {
                        double excedent = grossSalary - endF1;
                        rentTax += excedent * 0.1;
                    }
                    else
                    {
                        double excedent = endF2 - endF1;
                        rentTax += excedent * 0.1;
                    }
                }
                if (endF2 <= grossSalary)
                {
                    if (endF3 > grossSalary)
                    {
                        double excedent = grossSalary - endF2;
                        rentTax += excedent * 0.15;
                    }
                    else
                    {
                        double excedent = endF3 - endF2;
                        rentTax += excedent * 0.15;
                    }
                }
                if (endF3 <= grossSalary)
                {
                    if (endF4 > grossSalary)
                    {
                        double excedent = grossSalary - endF3;
                        rentTax += excedent * 0.20;
                    }
                    else
                    {
                        double excedent = endF4 - endF3;
                        rentTax += excedent * 0.20;
                    }
                }
                if (endF4 < grossSalary)
                {
                    double excedent = grossSalary - endF4;
                    rentTax += excedent * 0.25;
                }
            }

            return rentTax;
        }

        public double GetCSSTax()
        {
            double cssTax = SEM + IVM + POPULAR_BANK_APPORT;
            return cssTax;
        }

        public double GetTaxPercentage(string taxName, double grossSalary)
        {
            double taxPercentage = 0;
            if (taxName == "CCSS")
            {
                taxPercentage = GetCSSTax();
            }
            else
            {
                taxPercentage = GetRentTax(grossSalary);
            }
            return taxPercentage;
        }

        public double GetTaxAmount(string taxName, double grossSalary)
        {
            double taxAmount;
            if (taxName == "CCSS")
            {
                taxAmount = grossSalary * (GetCSSTax() / 100);
            }
            else
            {
                double amount = GetRentTax(grossSalary);
                taxAmount = amount;
            }
            return taxAmount;
        }
        public double GetEmployerSocialCharges(double grossSalary)
        {
            double employerSocialCharges = 0;
            employerSocialCharges += GetCSSSEmployerTaxes(grossSalary);
            employerSocialCharges += GetOtherInstitutionsEmployerTaxes(grossSalary);
            employerSocialCharges += GetWorkerWarrantiesEmployerTaxes(grossSalary);
            return employerSocialCharges;
        }

        public double GetCSSSEmployerTaxes(double grossSalary)
        {
            return grossSalary * 0.145;
        }

        public double GetOtherInstitutionsEmployerTaxes(double grossSalary)
        {
            return grossSalary * 0.0725;
        }

        public double GetWorkerWarrantiesEmployerTaxes(double grossSalary)
        {
            return grossSalary * 0.0475;
        }
    }
}