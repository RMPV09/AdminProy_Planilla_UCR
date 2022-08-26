using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using LanguageExt;
using Application.Agreements.Implementations;
using Application.Agreements;
using Domain.Agreements.Repositories;
using Domain.Agreements.Entities;

namespace Tests.Application
{
    public class GetEmployerAgreementsTest
    {

        List<Agreement> agreementsList = new List<Agreement>
        {
            new Agreement("leonel@ucr.ac.cr", "mau@ucr.ac.cr", "Projecto 1",  DateTime.Now.AddDays(1), "Medio tiempo", 1500, DateTime.Now.AddDays(15), 1, ""),
            new Agreement("leonel@ucr.ac.cr", "mau@ucr.ac.cr", "Projecto 2",  DateTime.Now.AddDays(1), "Tiempo completo", 1300, DateTime.Now.AddDays(25), 1, ""),
            new Agreement("leonel@ucr.ac.cr", "mau@ucr.ac.cr", "Projecto ",  DateTime.Now.AddDays(1),  "Servicios profesionales", 1200, DateTime.Now.AddDays(15), 1, ""),
        };

        private String _employerEmail = "mau@ucr.ac.cr";


        [Fact]
        public async Task GetEmployerAgreements()
        {
            //arrange
            var mockAgreementRepository = new Mock<IAgreementRepository>();
            var agreementService = new AgreementService(mockAgreementRepository.Object);
            mockAgreementRepository.Setup(repo => repo.GetEmployerAgreements("mau@ucr.ac.cr")).ReturnsAsync(agreementsList.Where(
                e => e.EmployerEmail == _employerEmail));

            //act
            var agreementTest = agreementService.GetEmployerAgreements(_employerEmail);

            //assert
            mockAgreementRepository.Verify(repo => repo.GetEmployerAgreements(_employerEmail), Times.Once);
            agreementTest.Count().Should().Equals(3);
        }
    }
}
