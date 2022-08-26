using System;
using System.Collections.Generic;

namespace Presentation.Employees.Models
{
    public class PaymentHistoryModel
    {
        public string ProjectName { get; set; }
        public string ContractType { get; set; }
        public string PaymentDate { get; set; }
        public string GrossSalary { get; set; }
        public string LegalDeductions { get; set; }
        public string VoluntaryDeductions { get; set; }
        public string NetSalary { get; set; }

        public PaymentHistoryModel()
        {
            ProjectName = "";
            ContractType = "";
            PaymentDate = "";
            GrossSalary = "";
            LegalDeductions = "";
            VoluntaryDeductions = "";
            NetSalary = "";
        }

        public PaymentHistoryModel(string projectName, string contractType,
            string paymentDate,string grossSalary, string legalDeductions,
            string voluntaryDeductions, string netSalary)
        {
            ProjectName = projectName;
            ContractType = contractType;
            PaymentDate = paymentDate;
            GrossSalary = grossSalary;
            LegalDeductions = legalDeductions;
            VoluntaryDeductions = voluntaryDeductions;
            NetSalary = netSalary;
        }
    }
}
