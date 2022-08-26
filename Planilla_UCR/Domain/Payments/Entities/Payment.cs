using System;

namespace Domain.Payments.Entities
{
    public class Payment
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public double GrossSalary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Payment(String employeeEmail, String employerEmail,
            String projectName, double grossSalary, DateTime startDate, DateTime endDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            GrossSalary = grossSalary;
        }
    }
}
