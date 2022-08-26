using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Agreements.Implementations;
using Application.Agreements;
using Moq;
using Xunit;
using System;
using Domain.Agreements.Repositories;
using Domain.Agreements.Entities;

namespace Tests.Application
{

    public class AgreementServiceTest
    {
        private static string EmployeeEmail = "jeremy@ucr.ac.cr";

        private static string EmployerEmail = "mau@ucr.ac.cr";

        private static string ProjectName = "Accesorios artesanales";

        private static DateTime ContractStartDate = new DateTime(2022, 08, 02);

        private static string ContractType = "Tiempo completo";

        private static int MountPerHour = 1500;

        private static DateTime ContractFinishDate = new DateTime(2022, 09, 02);

        private static int IsEnabled = 1;

        private static string Justification = string.Empty;


        [Fact]
        public async Task GetContracteeTest()
        {
            //arrange
            var agreement = new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification);
            var mockAgreementRepository = new Mock<IAgreementRepository>();
            var agreementService = new AgreementService(mockAgreementRepository.Object);
            mockAgreementRepository.Setup(repo => repo.GetContractee(agreement)).ReturnsAsync(agreement);
            await agreementService.CreateAgreementAsync(agreement);
            //act
            Agreement? AgreementTest = await agreementService.GetContractee(agreement);
            //assert
            AgreementTest.EmployeeEmail.Should().Be(EmployeeEmail);
            AgreementTest.Should().NotBeNull();
            mockAgreementRepository.Verify(repo => repo.GetContractee(agreement), Times.Once);
        }

        [Fact]
        public async Task GetAllAgreementsByProjectAndEmployerTest()
        {
            //arrange
            var agreementObject = new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification);
            IEnumerable<Agreement?> agreement = new List<Agreement>
			{
				new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification)
			};
			var mockAgreementRepository = new Mock<IAgreementRepository>();
            var agreementService = new AgreementService(mockAgreementRepository.Object);
            mockAgreementRepository.Setup(repo => repo.GetAllAgreementsByProjectAndEmployer(ProjectName, EmployerEmail)).ReturnsAsync(agreement);
            await agreementService.CreateAgreementAsync(agreementObject);

            //act
            IEnumerable<Agreement?> AgreementTest = await agreementService.GetAllAgreementsByProjectAndEmployer(ProjectName, EmployerEmail);

            //assert
            AgreementTest.Should().NotBeNull();
            AgreementTest.ElementAtOrDefault(0).EmployeeEmail.Should().Be(EmployeeEmail);
            mockAgreementRepository.Verify(repo => repo.GetAllAgreementsByProjectAndEmployer(ProjectName, EmployerEmail), Times.Once);
        }

        [Fact]
        public async Task GetProjectAgreementsTest()
        {
            //arrange
            var agreementObject = new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification);
            IList <Agreement> agreement = new List<Agreement>
            {
                new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification)
            };
            var mockAgreementRepository = new Mock<IAgreementRepository>();
            var agreementService = new AgreementService(mockAgreementRepository.Object);
            mockAgreementRepository.Setup(repo => repo.GetProjectAgreements(ProjectName, EmployerEmail)).ReturnsAsync(agreement);
            await agreementService.CreateAgreementAsync(agreementObject);

            //act
            IEnumerable<Agreement?> AgreementTest = await agreementService.GetAllAgreementsByProjectAndEmployer(ProjectName, EmployerEmail);

            //assert
            AgreementTest.Should().NotBeNull();
            mockAgreementRepository.Verify(repo => repo.GetAllAgreementsByProjectAndEmployer(ProjectName, EmployerEmail), Times.Once);
        }

        [Fact]
        public async Task GetErasableAgreeementsTest() 
        {
            //arrange
            var agreementObject = new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification);
            IList<Agreement> agreement = new List<Agreement>
            {
                new Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractStartDate, ContractType, MountPerHour, ContractFinishDate, IsEnabled, Justification)
            };
            var mockAgreementRepository = new Mock<IAgreementRepository>();
            var agreementService = new AgreementService(mockAgreementRepository.Object);
            mockAgreementRepository.Setup(repo => repo.GetErasableAgreeements(EmployeeEmail)).ReturnsAsync(agreement);
            await agreementService.CreateAgreementAsync(agreementObject);

            //act
            IEnumerable<Agreement?> AgreementTest = await agreementService.GetErasableAgreeements(EmployeeEmail);

            //assert
            AgreementTest.ElementAtOrDefault(0).ProjectName.Should().NotBeNull();
            AgreementTest.ElementAtOrDefault(0).EmployerEmail.Should().Be(EmployerEmail);
            mockAgreementRepository.Verify(repo => repo.GetErasableAgreeements(EmployeeEmail), Times.Once);
        } 
    }
}