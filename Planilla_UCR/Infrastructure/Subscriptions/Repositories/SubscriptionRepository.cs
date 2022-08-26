using Domain.Core.Repositories;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using Infrastructure.Subscriptions.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Subscriptions.Repositories
{
    internal class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly SubscriptionDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public SubscriptionRepository(SubscriptionDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<Subscription>> GetAllDeductionsAsync()
        {
            return await _dbContext.Subscriptions.FromSqlRaw("EXEC GetAllDeductions").ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllBenefictsAsync()
        {
            return await _dbContext.Subscriptions.FromSqlRaw("EXEC GetAllBenefits").ToListAsync();
        }

        public void CreateSubscriptionAsync(Subscription subscription)
        {
            System.FormattableString query = ($@"EXECUTE AddSuscription 
                @EmployerEmail = {subscription.EmployerEmail}, @ProjectName = {subscription.ProjectName},
                @SubscriptionName = {subscription.SubscriptionName}, @ProviderName = {subscription.ProviderName},
                @SubscriptionDescription = {subscription.SubscriptionDescription}, @Cost = {subscription.Cost},
                @TypeSubscription = {subscription.TypeSubscription}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.SubscriptionName == subscriptionName 
                && e.ProjectName == projectName).ToListAsync();
            Subscription subscription = null;
            if (subscriptionResult.Length() > 0)
            {
                subscription = subscriptionResult.First();
            }
            return subscription;
        }

        public async Task<IEnumerable<Subscription>> GetDeductionsByProject(string employerEmail, string projectName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName 
                && e.TypeSubscription == 0 && e.IsEnabled == 1).ToListAsync();
            return subscriptionResult;
        }

        public async Task<IEnumerable<Subscription>> GetBenefitsByProject(string employerEmail, string projectName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName
                && e.TypeSubscription == 1 && e.IsEnabled == 1).ToListAsync();
            return subscriptionResult;
        }

        public void ModifySubscription(Subscription subscription, string newName)
        {
            System.FormattableString query = ($@"EXECUTE ModifySubscription 
                @EmployerEmail = {subscription.EmployerEmail}, @ProjectName = {subscription.ProjectName},
                @SubscriptionName = {subscription.SubscriptionName},
                @NewSubscriptionName = {newName}, @ProviderName = {subscription.ProviderName},
                @SubscriptionDescription = {subscription.SubscriptionDescription}, @Cost = {subscription.Cost},
                @TypeSubscription = {subscription.TypeSubscription}, @IsEnabled = {subscription.IsEnabled}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public void DeleteSubscription(Subscription subscription) 
        {
            System.FormattableString query = ($@"EXECUTE DeleteSubscription 
                @EmployerEmail = {subscription.EmployerEmail}, @ProjectName = {subscription.ProjectName},
                @SubscriptionName = {subscription.SubscriptionName}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<IEnumerable<Subscription>> GetBenefitsByEmployee(string employeeEmail, string projectName)
        {
            return await _dbContext.Subscriptions.FromSqlRaw("EXEC GetBenefitsByEmployee @EmployeeEmail," +
                " @ProjectName",
                new SqlParameter("EmployeeEmail", employeeEmail),
                new SqlParameter("ProjectName", projectName)).ToListAsync();
        }
        public async Task<IList<Subscription>> GetDeductionsByEmployee(string employeeEmail, string projectName)
        {
            IList<SubscriptionModel> subscriptionModels = await _dbContext.SubscriptionsModel.FromSqlRaw("EXEC GetDeductionsByEmployee @EmployeeEmail," +
                " @ProjectName",
                new SqlParameter("EmployeeEmail", employeeEmail),
                new SqlParameter("ProjectName", projectName)).ToListAsync();
            IList<Subscription> deductions = new List<Subscription>();
            foreach (SubscriptionModel subscriptionModel in subscriptionModels) 
            {
                Subscription subscription = new Subscription("",projectName,subscriptionModel.SubscriptionName,
                    "", subscriptionModel.SubscriptionDescription, subscriptionModel.Cost, 
                    subscriptionModel.TypeSubscription, 1);
                deductions.Add(subscription);
            }
            return deductions;
        }

        public void DisabledSubscription(Subscription subscription) 
        {
            System.FormattableString query = ($@"EXECUTE DisabledSubscription 
                @EmployerEmail = {subscription.EmployerEmail}, @ProjectName = {subscription.ProjectName},
                @SubscriptionName = {subscription.SubscriptionName}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }
    }
}