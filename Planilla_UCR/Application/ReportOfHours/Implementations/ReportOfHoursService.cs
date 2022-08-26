using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using Domain.ReportOfHours.Repositories;

namespace Application.ReportOfHours.Implementations
{
    public class ReportOfHoursService : IReportOfHoursService
    {
        private readonly IHoursReportRepository _reportRepository;

        public ReportOfHoursService(IHoursReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            await _reportRepository.CreateReportAsync(report);
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            return await _reportRepository.GetAllReportsAsync(email);
        }

        public async Task<bool> HasReportAsync(HoursReport report)
        {
            return await _reportRepository.HasReportAsync(report);
        }

        public async Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate) 
        { 
            return await _reportRepository.GetEmployeeReports(hoursReport, endDate);
        }

        public Task UpdateReport(HoursReport report)
        {
            return _reportRepository.UpdateReport(report);
        }

        public async Task<IEnumerable<HoursReport>> GetProjectHoursReport(string projectName, string employeeEmail, string employerEmail)
        {
            return await _reportRepository.GetProjectHoursReport(projectName, employeeEmail, employerEmail);
        }
    }
}
