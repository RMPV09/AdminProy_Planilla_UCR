using Domain.Payments.Entities;
using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Payments.Repositories
{
    public interface IPaymentRepository
    {
        Task AddPayment(Payment newPayment);
        Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName);
        Task<IList<Payment>> GetProjectPayments(Payment payment);
        Task<IEnumerable<Payment>> GetEmployeePayments(string email);
        Task<IEnumerable<Payment>> GetLastEmployeePayments(string email);
        Task<IEnumerable<Payment>> GetEmployerPayments(string email);
        Task<IEnumerable<Payment>> GetLastEmployerPayments(string email);
        Task<IEnumerable<Payment>> GetEmployeeLatestPayments(string employeeEmail);
        Task<IList<Payment>> GetAllPaymentsStartAndEndDates(string employerEmail, string projectName);
    }
}
