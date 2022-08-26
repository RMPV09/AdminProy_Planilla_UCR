using Application.PaymentCalculator.Implementations;
using Application.Payments.Models;
using Domain.Agreements.Entities;
using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using Domain.Projects.Entities;
using Domain.ReportOfHours.Entities;
using Domain.Subscriptions.Entities;
using Presentation.Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Payments.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        PaymentCalculatorService paymentService = new PaymentCalculatorService();

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task AddPayment(Payment newPayment)
        {
            await _paymentRepository.AddPayment(newPayment);
        }

        public async Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            return await _paymentRepository.GetEmployeeLastPayment(employeeEmail, employerEmail, projectName);
        }

        public async Task<IList<Payment>> GetProjectPayments(Payment payment)
        {
            return await _paymentRepository.GetProjectPayments(payment);
        }

        public async Task<IEnumerable<Payment>> GetEmployeePayments(string email)
        {
            return await _paymentRepository.GetEmployeePayments(email);
        }

        public async Task<IEnumerable<Payment>> GetLastEmployeePayments(string email)
        {
            return await _paymentRepository.GetLastEmployeePayments(email);
        }

        public async Task<IEnumerable<Payment>> GetEmployerPayments(string email)
        {
            return await _paymentRepository.GetEmployerPayments(email);
        }

        public async Task<IEnumerable<Payment>> GetLastEmployerPayments(string email)
        {
            return await _paymentRepository.GetLastEmployerPayments(email);
        }

        public async Task<IEnumerable<Payment>> GetEmployeeLatestPayments(string employeeEmail)
        {
            return await _paymentRepository.GetEmployeeLatestPayments(employeeEmail);
        }

        public async Task<IList<Payment>> GetAllPaymentsStartAndEndDates(string employerEmail, string projectName)
        {
            return await _paymentRepository.GetAllPaymentsStartAndEndDates(employerEmail, projectName);
        }

        public IList<ProjectModel> GetProjectsToPay(IList<Project> employerProjects)
        {
            IList<ProjectModel> pendingProjects = new List<ProjectModel>();
            foreach (Project project in employerProjects)
            {

                var _daysInterval = GetDaysInterval(project.PaymentInterval, project.LastPaymentDate);
                if (project.LastPaymentDate.AddDays(_daysInterval) <= DateTime.Now)
                {
                    ProjectModel _projectModel = new ProjectModel(project.ProjectName, project.EmployerEmail,
                        project.PaymentInterval, project.LastPaymentDate,
                        GetDaysInterval(project.PaymentInterval, project.LastPaymentDate), 0, new List<EmployeeAgreement>());
                    pendingProjects.Add(_projectModel);
                }
            }

            return pendingProjects;
        }

        public int GetDaysInterval(string paymentInterval, DateTime lastPaymentDate)
        {
            int _days = 0;

            switch (paymentInterval)
            {
                case "Semanal":
                    {
                        _days = 7;
                    }
                    break;
                case "Bisemanal":
                    {
                        _days = 15;
                    }
                    break;
                case "Quincenal":
                    {
                        _days = FortnightDays(lastPaymentDate);
                    }
                    break;
                case "Mensual":
                    {
                        DateTime nextMonth = lastPaymentDate.AddMonths(1);
                        TimeSpan t = nextMonth - lastPaymentDate;
                        _days = t.Days;
                    }
                    break;

            }
            return _days;
        }

        private int FortnightDays(DateTime lastPaymentDate)
        {
            int _days;
            if (lastPaymentDate.Day == 14)
            {
                _days = 14;
            }
            else
            {
                if (lastPaymentDate.Day == 28)
                {
                    DateTime nextFortnight = lastPaymentDate.AddMonths(1);
                    nextFortnight = nextFortnight.AddDays(-14);
                    TimeSpan t = nextFortnight - lastPaymentDate;
                    _days = t.Days;
                }
                else
                {
                    if (lastPaymentDate.Day < 14)
                    {
                        _days = 14 - lastPaymentDate.Day;
                    }
                    else
                    {
                        _days = 28 - lastPaymentDate.Day;
                    }
                }
            }
            return _days;
        }

        public double GetWorkedHours(IList<HoursReport> reports)
        {
            double _workedHours = 0;
            foreach (HoursReport hours in reports)
            {
                _workedHours += hours.ReportHours;
            }
            return _workedHours;
        }

        public double GetSalary(Agreement agreement, int daysInterval, IEnumerable<Subscription> subscriptions, IList<HoursReport> reports)
        {
            double salary = GetSalaryByType(agreement, daysInterval, reports);
            double appliedBenefits = GetEmployeeBenefits(subscriptions);
            salary += appliedBenefits;
            return salary;
        }

        private double GetSalaryByType(Agreement agreement, int daysInterval, IList<HoursReport> reports)
        {
            int workedDays = GetWorkedDays((DateTime)agreement.ContractStartDate, daysInterval);
            double grossSalary = 0;
            if (agreement.ContractType == "Tiempo completo")
            {
                grossSalary = paymentService.GetFullTimeSalary(agreement.MountPerHour, workedDays);
            }
            if (agreement.ContractType == "Medio tiempo")
            {
                grossSalary = paymentService.GetPartTimeSalary(agreement.MountPerHour, workedDays);
            }
            if (agreement.ContractType == "Servicios profesionales")
            {
                double workedHours = GetWorkedHours(reports);
                grossSalary = paymentService.GetSalaryPerHours(agreement.MountPerHour, workedHours);
            }
            return grossSalary;
        }

        private double GetEmployeeBenefits(IEnumerable<Subscription> subscriptions)
        {
            double mountOfBenefits = 0;
            foreach (Subscription _subscription in subscriptions.Where(e => e.TypeSubscription == 1))
            {
                mountOfBenefits += _subscription.Cost;
            }
            return mountOfBenefits;
        }

        public int GetWorkedDays(DateTime startDate, int daysInterval)
        {
            DateTime _nextPayment = startDate.AddDays(daysInterval);
            int _workedDays = Convert.ToInt32(daysInterval);
            if (startDate.Month == _nextPayment.Month)
            {
                _workedDays = (_nextPayment - startDate).Days;
            }
            int _workedWeeks = _workedDays / 7;
            _workedDays -= _workedWeeks;
            if (startDate.Date > _nextPayment.Date)
            {
                _workedDays = 0;
            }
            return _workedDays;
        }
    }
}