using System;

namespace Presentation.Employers.Models
{
    public class ProjectHistorical
    {
        public string EmployerEmail { get; set; }
        public string EmployeeEmail { get; set; }
        public string ProjectName { get; set; }
        public string PaymentFrecuency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double GrossSalary { get; set; }
        public double Benefits { get; set; }
        public double EmployerCharges { get; set; }
        public double ObligatoryDeductions { get; set; }
        public double VoluntaryDeductions { get; set; }
        public double EmployerCost { get; set; }

        public ProjectHistorical()
        {
            EmployerEmail = String.Empty;
            EmployeeEmail = String.Empty;
            ProjectName = String.Empty;
            PaymentFrecuency = String.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            GrossSalary = 0;
            Benefits = 0;
            EmployerCharges = 0;
            ObligatoryDeductions = 0;
            VoluntaryDeductions = 0;
            EmployerCost = 0;
        }

        public ProjectHistorical(string employerEmail, string employeeEmail,
            string projectName, string paymentFrecuency, DateTime startDate,
            DateTime endDate, double grossSalary, double benefits, double employerCharges,
            double obligatoryDeductions, double voluntaryDeductions, double employerCost)
        {
            EmployerEmail = employerEmail;
            EmployeeEmail = employeeEmail;
            ProjectName = projectName;
            PaymentFrecuency = paymentFrecuency;
            StartDate = startDate;
            EndDate = endDate;
            GrossSalary = grossSalary;
            Benefits = benefits;
            EmployerCharges = employerCharges;
            ObligatoryDeductions = obligatoryDeductions;
            VoluntaryDeductions = voluntaryDeductions;
            EmployerCost = employerCost;
        }
    }
}