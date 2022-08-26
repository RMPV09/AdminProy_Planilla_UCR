using System;

namespace Domain.Subscribes.DTOs
{
    public class SubscribeDTO
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String SubscriptionName { get; set; }
        public double Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public SubscribeDTO(String employeeEmail, String employerEmail,
            String projectName,String subscriptionName,
            double cost, DateTime startDate, DateTime endDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            SubscriptionName = subscriptionName;
            Cost = cost;
            StartDate = startDate;
            EndDate = endDate;
        }

        public SubscribeDTO(String employeeEmail, String employerEmail,
            String projectName, String subscriptionName,
            double cost, DateTime startDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            SubscriptionName = subscriptionName;
            Cost = cost;
            StartDate = startDate;
            EndDate = null;
        }
    }
}
