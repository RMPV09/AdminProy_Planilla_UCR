using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Payments.Implementations;
using Moq;
using Xunit;
using Domain.Payments.Repositories;
using Domain.Payments.Entities;
using LanguageExt;
using Presentation.Payments.Models;
using Domain.Projects.Entities;

namespace Tests.Application
{
    public class PaymentServiceTest
    {
        List<Payment> paymentsList = new List<Payment>
        {
            new Payment("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", 86000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(15)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 2", "mau@ucr.ac.cr", 153600, DateTime.Now.AddDays(1),DateTime.Now.AddDays(25)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 3", "mau@ucr.ac.cr", 16000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(3)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 4", "mau@ucr.ac.cr", 75000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(14)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 5", "mau@ucr.ac.cr", 86000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(15)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 6", "mau@ucr.ac.cr", 186000, DateTime.Now.AddDays(1), DateTime.Now.AddDays(28)),
        };

        private String _employerEmail = "leonel@ucr.ac.cr";

        [Fact]
        public void GetEmployerPayments()
        {

            //arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);
            mockPaymentRepository.Setup(repo => repo.GetEmployerPayments("leonel@ucr.ac.cr")).ReturnsAsync(paymentsList.Where(
                e => e.EmployerEmail == _employerEmail));

            //act
            var employerPaymentTest = paymentService.GetEmployerPayments(_employerEmail);

            //assert
            mockPaymentRepository.Verify(repo => repo.GetEmployerPayments(_employerEmail), Times.Once);
            employerPaymentTest.Count().Should().Equals(5);
        }

        [Fact]
        public void GetProjectsToPayTest()
        {
            double passedDays = -20;
            //arrange
            var paymentService = new PaymentService(null);
            List<Project> projectList = new List<Project>
            {
                new Project("leonel@ucr.ac.cr", "Proyecto 1", " ", 12, 12, "Semanal", 1, DateTime.Now.AddDays(passedDays)),
                new Project("leonel@ucr.ac.cr", "Proyecto 2", " ", 12, 12, "Mensual", 1, DateTime.Now.AddDays(passedDays)),
                new Project("leonel@ucr.ac.cr", "Proyecto 3", " ", 12, 12, "Quincenal", 1, DateTime.Now.AddDays(passedDays)),
                new Project("leonel@ucr.ac.cr", "Proyecto 4", " ", 12, 12, "Bisemanal", 1, DateTime.Now.AddDays(passedDays)),
            };

            //act
            IList<ProjectModel> pendingProjects = paymentService.GetProjectsToPay(projectList);

            //assert
            pendingProjects.Length().Should().Be(3);
        }

        [Fact]
        public void GetEmployeeLatestPayment()
        {
            //arrange
            string _employeeEmail = "mau@ucr.ac.cr";
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);
            mockPaymentRepository.Setup(repo => repo.GetEmployeeLatestPayments("mau@ucr.ac.cr")).ReturnsAsync(paymentsList.Where(
                e => e.EmployerEmail == _employeeEmail));

            //act
            var lastestPaymentTest = paymentService.GetEmployeeLatestPayments(_employeeEmail);

            //assert
            mockPaymentRepository.Verify(repo => repo.GetEmployeeLatestPayments(_employeeEmail), Times.Once);
            lastestPaymentTest.Count().Should().Equals(5);
        }

    }
}
