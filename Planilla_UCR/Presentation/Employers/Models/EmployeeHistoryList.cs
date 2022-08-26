using System;
using System.Collections.Generic;

namespace Presentation.Employers.Models
{
    public class EmployeeHistoryList
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName1 { get; set; }
        public string EmployeeLastName2 { get; set; }
        public string EmployeeEmail { get; set; }
        public string ProjectName { get; set; }
        public int Ssn { get; set; }
        public string ContractType { get; set; }
        public double GrossSalary { get; set; }
        public double TotalBenefits { get; set; }
        public double EmployerSocialCharges { get; set; }
        public double MandatoryEmployeeDeductions { get; set; }
        public double VoluntaryDeductions { get; set; }
        public double EmployeeCost { get; set; }
        public string PaymentDate { get; set; }

        public EmployeeHistoryList()
        {
            this.EmployeeName = "";
            this.EmployeeLastName1 = "";
            this.EmployeeLastName2 = "";
            this.EmployeeEmail = "";
            this.ProjectName = "";
            this.Ssn = 0;
            this.ContractType = "";
            this.GrossSalary = 0.0;
            this.TotalBenefits = 0.0;
            this.EmployerSocialCharges = 0.0;
            this.MandatoryEmployeeDeductions = 0.0;
            this.VoluntaryDeductions = 0.0;
            this.EmployeeCost = 0.0;
            this.PaymentDate = "";
        }

        public EmployeeHistoryList(string employeeName, string employeeLastName1, string employeeLastName2, string projectName, 
                                   string contractType, double grossSalary, double totalBenefits, double employerSocialCharges,
                                   double mandatoryEmployeeDeductions, double voluntaryDeductions,double employeeCost, int ssn,
                                   string paymenDate, string employeeEmail)
        {
            this.EmployeeName = employeeName;
            this.EmployeeLastName1 = employeeLastName1;
            this.EmployeeLastName2 = employeeLastName2;
            this.EmployeeEmail = employeeEmail;
            this.ProjectName = projectName;
            this.Ssn = ssn;
            this.ContractType = contractType;
            this.GrossSalary = grossSalary;
            this.TotalBenefits = totalBenefits;
            this.EmployerSocialCharges = employerSocialCharges;
            this.MandatoryEmployeeDeductions = mandatoryEmployeeDeductions;
            this.VoluntaryDeductions = voluntaryDeductions;
            this.EmployeeCost = employeeCost;
            this.PaymentDate = paymenDate;
        }
        
    }
}
