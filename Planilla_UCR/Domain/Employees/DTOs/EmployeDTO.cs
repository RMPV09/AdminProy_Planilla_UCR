using System;

namespace Domain.Employees.DTOs
{
    public class EmployeeDTO
    {
        public String Email { get; set; }
        public EmployeeDTO(String email)
        {
            Email = email;
        }
    }
}
