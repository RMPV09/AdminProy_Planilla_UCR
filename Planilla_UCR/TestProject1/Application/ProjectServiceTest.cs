using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Projects.Implementations;
using Application.Projects;
using Moq;
using Xunit;
using System;
using Domain.Projects.Repositories;
using Domain.Projects.Entities;


namespace Tests.Application
{

    public class ProjectServiceTest
    {
        public String EmployerEmail = "leonel@ucr.ac.cr";
        
        public String ProjectName = "Accesorios artesanales";
        
        public String ProjectDescription = "Accesorios artesanales hecos de coco y material recliclado";
        
        public double MaximumAmountForBenefits = 20000.0;
       
        public int MaximumBenefitAmount = 2;
       
        public String PaymentInterval = "quincenal";
        
        public int IsEnabled = 1;
       
        public DateTime LastPaymentDate = DateTime.MinValue;


        [Fact]
        public async Task GetProjectTest()
        {
            //arrange
            var project = new Project(EmployerEmail, ProjectName, ProjectDescription, MaximumAmountForBenefits, MaximumBenefitAmount, PaymentInterval, IsEnabled, LastPaymentDate);
            var mockProjectsRepository = new Mock<IProjectRepository>();
            var projectsService = new ProjectService(mockProjectsRepository.Object);
            mockProjectsRepository.Setup(repo => repo.GetProject(EmployerEmail, ProjectName)).ReturnsAsync(project);
            await projectsService.CreateProjectAsync(project);

            //act
            Project ProjectTest = await projectsService.GetProject(EmployerEmail, ProjectName);

            //assert
            ProjectTest.EmployerEmail.Should().Be(EmployerEmail);
            mockProjectsRepository.Verify(repo => repo.GetProject(EmployerEmail, ProjectName), Times.Once);
        }

        [Fact]
        public async Task GetAllProjectsAsyncTest()
        {
            // arrange
            IEnumerable<Project> projectList = new List<Project>()
            {
                new Project(EmployerEmail, ProjectName, ProjectDescription, MaximumAmountForBenefits, MaximumBenefitAmount, PaymentInterval, IsEnabled, LastPaymentDate)
            };
            var project = new Project(EmployerEmail, ProjectName, ProjectDescription, MaximumAmountForBenefits, MaximumBenefitAmount, PaymentInterval, IsEnabled, LastPaymentDate);
            var mockProjectsRepository = new Mock<IProjectRepository>();
            var projectsService = new ProjectService(mockProjectsRepository.Object);
            mockProjectsRepository.Setup(repo => repo.GetAllProjectsAsync()).ReturnsAsync(projectList);
            await projectsService.CreateProjectAsync(project);

            //act
            IEnumerable<Project> ProjectTest = await projectsService.GetAllProjectsAsync();

            //assert
            ProjectTest.ElementAtOrDefault(0).EmployerEmail.Should().Be(EmployerEmail);
            mockProjectsRepository.Verify(repo => repo.GetAllProjectsAsync(), Times.AtLeastOnce);

        }

        [Fact]
        public async Task GetDisabledProjectTest()
        {
            // arrange
            Project project = new Project(EmployerEmail, ProjectName, ProjectDescription, MaximumAmountForBenefits, MaximumBenefitAmount, PaymentInterval, IsEnabled, LastPaymentDate);

            var mockProjectsRepository = new Mock<IProjectRepository>();
            var projectsService = new ProjectService(mockProjectsRepository.Object);
            mockProjectsRepository.Setup(repo => repo.GetDisabledProject(EmployerEmail,ProjectName)).ReturnsAsync(project);
            await projectsService.GetDisabledProject(EmployerEmail, ProjectName);

            //act
            Project ProjectTest = await projectsService.GetDisabledProject(EmployerEmail, ProjectName);

            //assert
            ProjectTest.EmployerEmail.Should().Be(EmployerEmail);
            mockProjectsRepository.Verify(repo => repo.GetDisabledProject(EmployerEmail, ProjectName), Times.AtLeastOnce);

        }
    }
}
