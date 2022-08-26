using System;

namespace Domain.People.DTOs
{
    public class PersonDTO
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String LastName1 { get; set; }
        public String LastName2 { get; set; }
        public int Ssn { get; set; }
        public String BankAccount { get; set; }
        public String Adress { get; set; }
        public String PhoneNumber { get; set; }
        public int IsEnabled { get; set; }

        public PersonDTO(String email, String name, String lastName1, String lastName2, int id, String bankAccount,
                          String adress, String phoneNumber, int isEnabled)
        {
            Email = email;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Ssn = id;
            BankAccount = bankAccount;
            Adress = adress;
            PhoneNumber = phoneNumber;
            IsEnabled = isEnabled;
        }
    }
}
