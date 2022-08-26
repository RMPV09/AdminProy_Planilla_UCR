using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Subscriptions.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>>GetAllDeductionsAsync()
        {
            return await _subscriptionRepository.GetAllDeductionsAsync();
        }
        public async Task<IEnumerable<Subscription>> GetAllBenefictsAsync()
        {
            return await _subscriptionRepository.GetAllBenefictsAsync();
        }

        public void CreateSubscriptionAsync(Subscription subscription)
        {
            _subscriptionRepository.CreateSubscriptionAsync(subscription);
        }

        public async Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName)
        {
            return await _subscriptionRepository.GetSubscription(employerEmail, projectName, subscriptionName);
        }

        public async Task<IEnumerable<Subscription>> GetDeductionsByProject(string employerEmail, string projectName) {
            return await _subscriptionRepository.GetDeductionsByProject(employerEmail, projectName);
        }

        public async Task<IEnumerable<Subscription>> GetBenefitsByProject(string employerEmail, string projectName)
        {
            return await _subscriptionRepository.GetBenefitsByProject(employerEmail, projectName);
        }

        public void ModifySubscription(Subscription subscription, string newName)
        {
            _subscriptionRepository.ModifySubscription(subscription, newName);
        }

        public void DeleteSubscription(Subscription subscription) 
        { 
            _subscriptionRepository.DeleteSubscription(subscription);
        }

        public async Task<IEnumerable<Subscription>> GetBenefitsByEmployee(string employeeEmail, string projectName) 
        {
            return await _subscriptionRepository.GetBenefitsByEmployee(employeeEmail, projectName);
        }
        public async Task<IList<Subscription>> GetDeductionsByEmployee(string employeeEmail, string projectName) 
        {
            return await _subscriptionRepository.GetDeductionsByEmployee(employeeEmail, projectName);
        }

        public void DisabledSubscription(Subscription subscription) 
        { 
            _subscriptionRepository.DisabledSubscription(subscription);
        }
    }
}