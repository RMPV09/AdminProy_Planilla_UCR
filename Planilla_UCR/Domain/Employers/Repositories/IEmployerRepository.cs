using Domain.Employers.Entities;
using Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Employers.Repositories
{
    public interface IEmployerRepository
    {
        Task CreateEmployerAsync(String email);
        Task<Employer>? GetEmployerAsync(String email);
        void DeleteEmployer(string email);
        void UpdateEmployer(string email);
    }
}
