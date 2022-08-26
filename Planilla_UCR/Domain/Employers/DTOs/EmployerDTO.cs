using System;

namespace Domain.Employers.DTOs
{
    public class EmployersDTO
    {
        public String Email { get; set; }

        public EmployersDTO(String email)
        {
            Email = email;
        }
    }
}
