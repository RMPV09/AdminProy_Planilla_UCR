using System;


namespace Domain.Projects.Entities
{
    public class Project
    {
        public String EmployerEmail { set; get; }
        
        public String ProjectName { set; get; }
       
        public String ProjectDescription { set; get; }
        
        public double MaximumAmountForBenefits { set; get; }
        
        public int MaximumBenefitAmount { set; get; }
        
        public String PaymentInterval { set; get; }
        
        public int IsEnabled { set; get; }
        
        public DateTime LastPaymentDate { get; set; }
        
        public Project(String employerEmail, String projectName,
                        String projectDescription, double maximumAmountForBenefits,
                        int maximumBenefitAmount, String paymentInterval, int isEnabled)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            MaximumAmountForBenefits = maximumAmountForBenefits;
            MaximumBenefitAmount = maximumBenefitAmount;
            PaymentInterval = paymentInterval;
            IsEnabled = isEnabled;
            LastPaymentDate = DateTime.Now;
        }

        public Project(String employerEmail, String projectName,
                String projectDescription, double maximumAmountForBenefits,
                int maximumBenefitAmount, String paymentInterval, int isEnabled,
                DateTime lastPaymentDate)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            MaximumAmountForBenefits = maximumAmountForBenefits;
            MaximumBenefitAmount = maximumBenefitAmount;
            PaymentInterval = paymentInterval;
            IsEnabled = isEnabled;
            LastPaymentDate = lastPaymentDate;
        }
    }
}
