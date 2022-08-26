using Domain.Core.Repositories;
using Domain.Projects.Repositories;
using Domain.Projects.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Projects.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ProjectDbContext _dbContext;
        
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProjectRepository(ProjectDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateProjectAsync(Project projectInfo)
        {
            _dbContext.Projects.Add(projectInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects.Select(t => new
            Project(t.EmployerEmail, t.ProjectName, t.ProjectDescription, t.MaximumAmountForBenefits,
                    t.MaximumBenefitAmount, t.PaymentInterval, t.IsEnabled)).ToListAsync();
        }

        public async Task<Project> GetProject(string employerEmail, string projectName)
        {
            IList<Project> projectResult = await _dbContext.Projects.Where
                    (e => e.EmployerEmail == employerEmail && 
                    e.ProjectName == projectName && e.IsEnabled == 1).ToListAsync();
            
            Project project = null;
            if (projectResult.Length() > 0)
            {
                project = projectResult.First();
            }
            return project;
        }
        public async Task<Project> GetDisabledProject(string employerEmail, string projectName)
        {
            IList<Project> projectResult = await _dbContext.Projects.Where
                    (e => e.EmployerEmail == employerEmail &&
                    e.ProjectName == projectName && e.IsEnabled == 0).ToListAsync();

            Project project = null;
            if (projectResult.Length() > 0)
            {
                project = projectResult.First();
            }
            return project;
        }

        public async Task<Project> GetProject(string projectName)
        {
            IList<Project> projectResult = await _dbContext.Projects.Where
                    (e => e.ProjectName == projectName).ToListAsync();

            Project project = null;
            if (projectResult.Length() > 0)
            {
                project = projectResult.First();
            }
            return project;
        }

        public async Task<IEnumerable<Project>> GetAllNameProjects(string name)
        {
            {
                var nameList = await _dbContext.Projects.FromSqlRaw("EXEC ProjectNameCheck @name",
                        new SqlParameter("name", name)).ToListAsync();
                return nameList;
            }
        }

        public async Task<IEnumerable<Project>> GetEmployerProyects(string email) 
        {
            IList<Project> projectsResult = await _dbContext.Projects.Where
                        (e => e.EmployerEmail == email && e.IsEnabled==1).ToListAsync();
            return projectsResult;
        }

        public async Task<IEnumerable<Project>> GetEmployerDeactivedProyects(string email)
        {
            IList<Project> projectsResult = await _dbContext.Projects.Where
                        (e => e.EmployerEmail == email && e.IsEnabled == 0).ToListAsync();
            return projectsResult;
        }
        public async Task<IEnumerable<Project>> GetEmployeeProyects(string name)
        {
            IList<Project> projectsResult = await _dbContext.Projects.Where
                        (e => e.ProjectName == name).ToListAsync();
            return projectsResult;
        }
        public void UpdateProject(string projectName, string employerEmail)
        {
            System.FormattableString query = ($@"EXECUTE UpdateProject 
                @ProjectName = {projectName},
                @EmployerEmail = {employerEmail}");

            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public void ModifyProject(Project project, string newProjectName)
        {
            System.FormattableString query = ($@"EXECUTE ModifyProject 
                @ProjectName = {project.ProjectName},
                @EmployerEmail = {project.EmployerEmail},
                @NewProjectName = {newProjectName},
                @NewProjectDescription = {project.ProjectDescription},
                @NewMaximumAmountForBenefits = {project.MaximumAmountForBenefits},
                @NewMaximumBenefitAmount = {project.MaximumBenefitAmount},
                @NewPaymentInterval = {project.PaymentInterval}");

            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public void DisableProject(string projectName, string employerEmail)
        {
            System.FormattableString query = ($@"EXECUTE DisableProject @ProjectName = {projectName}, 
                                               @EmployerEmail = {employerEmail}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public void UpdatePaymentDate(Project project)
        {
            System.FormattableString query = ($@"EXECUTE UpdatePaymentDate 
                        @ProjectName = {project.ProjectName},
                        @EmployerEmail = {project.EmployerEmail},
                        @LastPaymentDate = {project.LastPaymentDate}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }
    }
}