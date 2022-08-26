
using Domain.LegalDeductions.Entities;
using Domain.Subscriptions.Entities;
using Domain.People.Entities;
using System.Collections.Generic;

namespace Application.Email
{
    public interface IEmailServices
    {
        public void SendConfirmationEmail(string message, string destiny);
        public void SendFiredEmployeeEmail(EmailObject emailData);
        public void SendLastPayEmail(EmailObject emailData, IList<string> rows, IList<Subscription> deductions, IList<LegalDeduction> legalDeductions);
        public void SendPaymentBreakdownEmail(EmailObject emailData, IList<LegalDeduction> summaryTable, IList<LegalDeduction> salariesTable, IList<LegalDeduction> deductionTable, IList<LegalDeduction> benefitsTable);
        public void SendIncreaseBenefitsEmail(EmailObject emailData);
        public void SendDecreaseBenefitsEmail(EmailObject emailData);
        public void SendOverbenefitsEmployeesEmail(IList<string> summaryEmailEmployees, IList<string> summaryNameEmployees, EmailObject emailData);
        public void SendEmployeeBenefitNotification(EmailObject emailData, string benefitName);
        public void SendEmployerBenefitNotification(EmailObject emailData, IList<Person> employeesEmail, string benefitName);
        public void ReactivateAccountEmail(string message, string destiny);
        public void SendDeletedSubscriptionEmail(EmailObject emailData, string subscriptionName);
        public void SendQuittingEmailToEmployee(EmailObject emailData, IList<string> employeeInfo);
        public void SendQuittingEmailToEmployer(EmailObject emailData, IList<string> employeeInfo);

    }
}
