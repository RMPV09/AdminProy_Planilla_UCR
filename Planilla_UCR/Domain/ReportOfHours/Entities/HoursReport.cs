using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ReportOfHours.Entities
{
    [Table("ReportOfHours")]
    public class HoursReport
    {
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String EmployeeEmail { get; set; }
        public DateTime? ReportDate { get; set; }
        public double ReportHours { get; set; }
        public int Approved { get; set; }

        public HoursReport(String employerEmail, String projectName, String employeeEmail,
            DateTime? reportDate, float reportedHours, int approved)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            EmployeeEmail = employeeEmail;
            ReportDate = reportDate;
            ReportHours = reportedHours;
            Approved = approved;    
        }

        public HoursReport()
        {
        }
    }
}
