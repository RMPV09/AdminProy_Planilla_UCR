using System;
using System.Collections.Generic;
using Domain.Subscriptions.Entities;

namespace Application.PaymentCalculator.Implementations
{
    public class PaymentCalculatorService : IPaymentCalculatorService
    {
        double FullTimeHours = 8.0;
        double PartTimeHours = 4.0;

        public double GetFullTimeSalary(double mountPerHour, int workedDay)
        {
            return (FullTimeHours * Convert.ToDouble(workedDay)) * mountPerHour;
        }

        public double GetPartTimeSalary(double mountPerHour, int workedDay)
        {
            return (PartTimeHours * Convert.ToDouble(workedDay)) * mountPerHour;
        }

        public double GetSalaryPerHours(double mountPerHour, double workedHours)
        {
            return mountPerHour * workedHours;
        }

        public IList<Subscription> ApplyDeductions(double netSalary, IList<Subscription> deductions)
        {
            IList<Subscription> _deductionsNotPaid = new List<Subscription>();
            bool firstNotPaid = false;
            foreach (var item in deductions)
            {
                if (netSalary - item.Cost <= 0)
                {
                    if (!firstNotPaid)
                    {
                        firstNotPaid = true;
                    }
                    else
                    {
                        _deductionsNotPaid.Add(item);
                    }
                }
                else
                {
                    netSalary -= item.Cost;
                }
            }
            return _deductionsNotPaid;
        }

        public double DeductionsCost(IList<Subscription> deductions)
        {
            double cost = 0;
            foreach (var item in deductions)
            {
                cost += item.Cost;
            }
            return cost;
        }
    }
}
