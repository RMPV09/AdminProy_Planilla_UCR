using Domain.Projects.Entities;
using Domain.Projects.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _projectRepository.CreateProjectAsync(project);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }
        
        public async Task<IEnumerable<Project>> GetAllNameProjects(string name)
        {
            return await _projectRepository.GetAllNameProjects(name);
        }
        
        public async Task<Project> GetProject(string employerEmail, string projectName)
        {
            return await _projectRepository.GetProject(employerEmail, projectName);
        }

        public async Task<Project> GetProject(string projectName)
        {
            return await _projectRepository.GetProject(projectName);
        }
        public async Task<Project> GetDisabledProject(string employerEmail, string projectName)
        {
            return await _projectRepository.GetDisabledProject(employerEmail, projectName);
        }

        public async Task<IEnumerable<Project>> GetEmployerProyects(string email) 
        { 
            return await _projectRepository.GetEmployerProyects(email);
        }
        public async Task<IEnumerable<Project>> GetEmployerDeactivedProyects(string email)
        {
            return await _projectRepository.GetEmployerDeactivedProyects(email);
        }

        public async Task<IEnumerable<Project>> GetEmployeeProyects(string email)
        {
            return await _projectRepository.GetEmployeeProyects(email);
        }

        public void ModifyProject(Project project, string newProjectName)
        {
             _projectRepository.ModifyProject(project, newProjectName);
        }

        public void DisableProject(string projectName, string employerEmail)
        {
            _projectRepository.DisableProject(projectName, employerEmail);
        }

        public void UpdatePaymentDate(Project project) 
        { 
            _projectRepository.UpdatePaymentDate(project);
        }

        public void UpdateProject(string projectName, string employerEmail)
        {
            _projectRepository.UpdateProject(projectName, employerEmail);
        }
    }
}