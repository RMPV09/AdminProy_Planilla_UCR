using System;

namespace Domain.Subscriptions.DTOs
{
    public class SubscriptionDTO
    {
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String SubscriptionName { get; set; }
        public String ProviderName { get; set; }
        public String SubscriptionDescription { get; set; }
        public double Cost { get; set; }
        public int TypeSubscription { get; set; }
        public int IsEnabled { get; set; }

        public SubscriptionDTO(String employerEmail, String projectName,
            String subscriptionName, String providerName, 
            String subscriptionDescription, double cost, int typeSubscription, int isEnabled)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            SubscriptionName = subscriptionName;
            ProviderName = providerName;
            SubscriptionDescription = subscriptionDescription;
            Cost = cost;
            TypeSubscription = typeSubscription;
            IsEnabled = isEnabled;
        }
    }
}
