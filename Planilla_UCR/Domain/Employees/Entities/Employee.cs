using System;

namespace Domain.Employees.Entities
{
    public class Employee
    {
        public String Email { get; set; }
        public Employee(String email)
        {
            Email = email;
        }
    }
}
