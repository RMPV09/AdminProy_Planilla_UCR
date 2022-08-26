using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.ReportOfHours.Implementations;
using Moq;
using Xunit;
using System;
//Proyectos
using Domain.ReportOfHours.Repositories;
using Domain.ReportOfHours.Entities;

namespace Tests.Application
{

    public class ReportOfHoursServiceTest
    {
        List<HoursReport> reportsList = new List<HoursReport>
        {
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", DateTime.Now, 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", DateTime.Now.AddDays(1), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", DateTime.Now.AddDays(2), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", DateTime.Now.AddDays(5), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", DateTime.Now.AddDays(8), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 2", "mau@ucr.ac.cr", DateTime.Now.AddDays(8), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 2", "mau@ucr.ac.cr", DateTime.Now.AddDays(8), 5, 0),
            new HoursReport("leonel@ucr.ac.cr", "Proyecto 3", "mau@ucr.ac.cr", DateTime.Now.AddDays(8), 5, 0)
        };

        private string _projectName = "Proyecto 1";
        private string _employeeEmail = "mau@ucr.ac.cr";
        private string _employerEmail = "leonel@ucr.ac.cr";


        public HoursReport report = new HoursReport("leonel@ucr.ac.cr", "Proyecto 3", "mau@ucr.ac.cr", DateTime.Now.AddDays(8), 5, 0);

        [Fact]
        public async Task GetProjectHoursReport()
        {
            //arrange
            var mockHoursReportRepository = new Mock<IHoursReportRepository>();
            var hoursReportService = new ReportOfHoursService(mockHoursReportRepository.Object);
            mockHoursReportRepository.Setup(repo => repo.GetProjectHoursReport("Proyecto 1", "mau@ucr.ac.cr", "leonel@ucr.ac.cr")).ReturnsAsync(reportsList.Where(
                e=> e.ProjectName == _projectName && e.EmployeeEmail == _employeeEmail && e.EmployerEmail == _employerEmail));

            //act
            var reports = await hoursReportService.GetProjectHoursReport(_projectName, _employeeEmail, _employerEmail);

            //assert
            mockHoursReportRepository.Verify(repo => repo.GetProjectHoursReport(_projectName, _employeeEmail, _employerEmail), Times.Once);
            reports.Count().Should().Equals(4);
        }

        [Fact]
        public async Task UpdateReport()
        {
            //arrange
            var mockHoursReportRepository = new Mock<IHoursReportRepository>();
            var hoursReportService = new ReportOfHoursService(mockHoursReportRepository.Object);
            mockHoursReportRepository.Setup(repo => repo.UpdateReport(report));

            //act
            await hoursReportService.CreateReportAsync(report);
            report.Approved = 1;
            await hoursReportService.UpdateReport(report);

            //assert
            report.Approved.Should().Be(1);
            mockHoursReportRepository.Verify(thesisRepo => thesisRepo.UpdateReport(report), Times.Once);
        }
    }
}
