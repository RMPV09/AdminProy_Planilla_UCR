using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Employees.Entities;
using Domain.People.Entities;

namespace Application.Employees
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(String email);
        Task<IEnumerable<Employee>> GetEmployeeByEmail(string email);
        Task<IEnumerable<Person>> GetAllEmployees(string projectName);
        Task<IEnumerable<Person>> GetProjectEmployees(string projectName, string employerEmail);
    }
}
