using System;

namespace Domain.Employers.Entities
{
    public class Employer
    {
        public String Email { get; }

        public Employer(String email)
        {
            Email = email;
        }
    }
}
