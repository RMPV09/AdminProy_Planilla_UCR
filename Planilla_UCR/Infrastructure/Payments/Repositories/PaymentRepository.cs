using Domain.Core.Repositories;
using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Payments.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PaymentRepository(PaymentDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            IEnumerable<Payment> payments = await _dbContext.Payments.Where(e => e.EmployeeEmail == employeeEmail &&
            e.EmployerEmail == employerEmail && e.ProjectName == projectName).OrderByDescending(pay => pay.EndDate).ToListAsync();
            Payment lastPay = payments.FirstOrDefault();
            return lastPay;
        }

        public async Task AddPayment(Payment newPayment)
        {
            _dbContext.Payments.Add(newPayment);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IList<Payment>> GetProjectPayments(Payment payment)
        {
            IList<Payment> payments = await _dbContext.Payments.Where(e => e.EmployerEmail == payment.EmployerEmail
            && e.ProjectName == payment.ProjectName && e.StartDate == payment.StartDate && e.EndDate == payment.EndDate).ToListAsync();
            return payments;
        }

        public async Task<IEnumerable<Payment>> GetEmployeePayments(string email)
        {
            var employeePaymentList = await _dbContext.Payments.FromSqlRaw("EXEC GetEmployeePayments @employeeEmail",
                 new SqlParameter("employeeEmail", email)).ToListAsync();
            return employeePaymentList;
        }

        public async Task<IEnumerable<Payment>> GetLastEmployeePayments(string email)
        {
            IList<Payment> employeePaymentList = await _dbContext.Payments.Where(e =>
            e.EmployeeEmail == email).OrderByDescending(pay => pay.EndDate).Take(10).ToListAsync();

            return employeePaymentList;
        }

        public async Task<IEnumerable<Payment>> GetEmployerPayments(string email)
        {
            var employerPaymentList = await _dbContext.Payments.Where(e => e.EmployerEmail == email).ToListAsync();
            return employerPaymentList;
        }

        public async Task<IEnumerable<Payment>> GetLastEmployerPayments(string email)
        {
            IList<Payment> employerPaymentList = await _dbContext.Payments.Where(e =>
            e.EmployerEmail == email).OrderByDescending(pay => pay.EndDate).Take(10).ToListAsync();

            return employerPaymentList;
        }

        public async Task<IEnumerable<Payment>> GetEmployeeLatestPayments(string email)
        {
            var employeePaymentList = await _dbContext.Payments.FromSqlRaw("EXEC GetEmployeeFiveLatestPayments @employeeEmail",
                 new SqlParameter("employeeEmail", email)).ToListAsync();
            return employeePaymentList;
        }
        public async Task<IList<Payment>> GetAllPaymentsStartAndEndDates(string employerEmail, string projectName) {
            SqlParameter myEmployerEmail = new SqlParameter("@employerEmail", employerEmail);
            SqlParameter myProjectName = new SqlParameter("@projectName", projectName);

            var paymentList = await _dbContext.Payments.FromSqlRaw("EXEC GetAllPaymentsStartAndEndDates {0},{1}",
               myEmployerEmail, myProjectName).ToListAsync();
            return paymentList;
        }

    }
}