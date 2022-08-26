using Domain.Core.Repositories;
using Domain.ReportOfHours.Repositories;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.ReportOfHours.Repositories
{
    internal class HoursReportRepository : IHoursReportRepository
    {
        private readonly HoursReportDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public HoursReportRepository(HoursReportDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            _dbContext.HoursReport.Add(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<bool> HasReportAsync(HoursReport report)
        {
            bool hasReport = true;
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == report.EmployeeEmail && e.EmployerEmail == 
                     report.EmployerEmail && e.ReportDate.Value.Date == report.ReportDate.Value.Date && 
                     e.ProjectName == report.ProjectName).ToListAsync();
            if(reports.Length() == 0)
            {
                hasReport = false;
            }
            return hasReport;
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == email).ToListAsync();
            return reports;
        }

        public async Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate)
        {
            IList<HoursReport> reports = await _dbContext.HoursReport.Where
                (e=> e.EmployeeEmail == hoursReport.EmployeeEmail &&
                 (endDate >= e.ReportDate && e.ReportDate >= hoursReport.ReportDate) && e.Approved == 1).ToListAsync();
            return reports;
        }

        public async Task UpdateReport(HoursReport updateReport)
        {
            System.FormattableString query = ($@"EXECUTE ApproveHoursReport 
            @EmployerEmail = {updateReport.EmployerEmail}, @ProjectName = {updateReport.ProjectName},
            @ReportDate = {updateReport.ReportDate}, @EmployeeEmail = {updateReport.EmployeeEmail}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<IEnumerable<HoursReport>> GetProjectHoursReport(string projectName, string employeeEmail, string employerEmail)
        {
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where(e => e.EmployeeEmail == employeeEmail).ToListAsync();
            reports = reports.Where(e => e.Approved == 0 && e.ProjectName == projectName && e.EmployerEmail == employerEmail);
            reports = reports.OrderByDescending(report => report.ReportDate);
            return reports;
        }
    }
}
