using Domain.Employers.Repositories;
using Domain.Employers.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Employers.Implementations
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task CreateEmployerAsync(String email)
        {
            await _employerRepository.CreateEmployerAsync(email);
        }

        public async Task<Employer>? GetEmployerAsync(String email)
        {
            return await _employerRepository.GetEmployerAsync(email);
        }

        public void DeleteEmployer(String email)
        {
            _employerRepository.DeleteEmployer(email);
        }

        public void UpdateEmployer(String email)
        {
            _employerRepository.UpdateEmployer(email);
        }

    }
}
