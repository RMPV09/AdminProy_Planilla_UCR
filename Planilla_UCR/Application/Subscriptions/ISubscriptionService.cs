using Domain.Subscriptions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Application.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetAllDeductionsAsync();
        Task<IEnumerable<Subscription>> GetAllBenefictsAsync();
        void CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName);
        Task<IEnumerable<Subscription>> GetDeductionsByProject(string employerEmail, string projectName);
        Task<IEnumerable<Subscription>> GetBenefitsByProject(string employerEmail, string projectName);
        void ModifySubscription(Subscription subscription, string newName);
        void DeleteSubscription(Subscription subscription);
        Task<IEnumerable<Subscription>> GetBenefitsByEmployee(string employeeEmail, string projectName);
        Task<IList<Subscription>> GetDeductionsByEmployee(string employeeEmail, string projectName);
        void DisabledSubscription(Subscription subscription);
    }
}