using Xunit;
using Domain.People.Entities;
using FluentAssertions;

namespace Tests.People
{
    public class PersonTests
    {
        private static string Email = "leonel@ucr.ac.cr";

        private static string Name = "Leonel";

        private static string LastName1 = "Campos";

        private static string LastName2 = "Murillo";

        private static int Ssn = 2821894;

        private static string BankAccount = "CR1631312423523";

        private static string Adress = "SJ, San pedro";

        private static string PhoneNumber = "83355317";

        private static int IsEnabled = 1;


        [Fact]
        public void EmailEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Person(input, Name, LastName1, LastName2, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled);

            //assert
            result.Email.Should().Be(string.Empty);
        }

        [Fact]
        public void NameEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Person(Email, input, LastName1, LastName2, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled);

            //assert
            result.Name.Should().Be(string.Empty);
        }

        [Fact]
        public void NullLastName2ReturnNull()
        {
            //arrange
            string? input = null;

            //act
            var result = new Person(Email, Name, LastName1, input, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled);

            //assert
            result.LastName2.Should().Be(null);
        }
    }
}
