using Domain.Subscribes.Entities;
using Domain.Subscriptions.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Subscribes.Repositories
{
    public interface ISubscribeRepository
    {
        int CreateSubscribe(Subscribe subscription, int typeSubscription);
        Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName);
        Task<IEnumerable<Subscription>> GetSubscriptionCostsByDate(Subscribe searchSubscription);
        Task<IEnumerable<Subscribe>> GetDeductionsByEmployee(string employeeEmail, string projectName);
        Task<IEnumerable<Subscription>> GetSubscribes(Subscribe searchSubscription);
        Task<IEnumerable<Subscribe>> GetBenefitsByEmployee(string employeeEmail, string projectName);
        void AddSubscribe(Subscribe subscription);
        void DeleteSubscribe(Subscribe subscription);
    }
}
