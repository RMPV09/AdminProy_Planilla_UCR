using Domain.ReportOfHours.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ReportOfHours
{
    public interface IReportOfHoursService
    {
        Task CreateReportAsync(HoursReport report);
        Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email);
        Task<bool> HasReportAsync(HoursReport report);
        Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate);
        Task UpdateReport(HoursReport report);
        Task<IEnumerable<HoursReport>> GetProjectHoursReport(string projectName, string employeeEmail, string employerEmail);
    }
}
