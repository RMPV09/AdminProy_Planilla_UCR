using Domain.Employers.Entities;
using System;
using System.Threading.Tasks;


namespace Application.Employers
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(String email);
        Task<Employer>? GetEmployerAsync(String email);
        void DeleteEmployer(string email);
        void UpdateEmployer(string email);
    }
}