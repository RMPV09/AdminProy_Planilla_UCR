using Xunit;
using Domain.Subscriptions.Entities;
using FluentAssertions;

namespace Tests.Domain
{
    public class SubscriptionTests
    {
        private static string EmployerEmail = "leonel@ucr.ac.cr";

        private static string ProjectName = "Accesorios artesanales";

        private static string SubscriptionName = "Almuerzos Pagados";

        private static string ProviderName = "Delicia Urbana";

        private static string SubscriptionDescription = "Se brindan almuerzos todos los días";

        private static double Cost = 50000;

        private static int TypeSubscription = 1;

        private static int IsEnabled = 1;

        [Fact]
        public void SubscriptionNameEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Subscription(EmployerEmail,
                ProjectName,
                input,
                ProviderName,
                SubscriptionDescription,
                Cost,
                TypeSubscription,
                IsEnabled);

            //assert
            result.SubscriptionName.Should().Be(string.Empty);
        }

    }
}
