using System;

namespace Infrastructure.Subscriptions.Model
{
    public class SubscriptionModel
    {
        public String SubscriptionName { get; set; }
        public String SubscriptionDescription { get; set; }
        public double Cost { get; set; }
        public int TypeSubscription { get; set; }
        public int IsEnabled { get; set; }

        public SubscriptionModel(String subscriptionName,
            String subscriptionDescription, double cost, int typeSubscription, int isEnabled)
        {
            SubscriptionName = subscriptionName;
            SubscriptionDescription = subscriptionDescription;
            Cost = cost;
            TypeSubscription = typeSubscription;
            IsEnabled = isEnabled;
        }
    }
}
