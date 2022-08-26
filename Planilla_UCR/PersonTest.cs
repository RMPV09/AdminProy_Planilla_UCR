using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ResearchRepository.Domain.People.Entities;
using FluentAssertions;
using ResearchRepository.Domain.People;


namespace UnitTests.Domain.PeopleContext
{
    public class PersonTests
    {
        private static string Email = "email@ucr.ac.cr";

        private static string FirstName = "Nombre";

        private static string FirstLastName = "Apellido1";

        private static string SecondLastName = "Apellido2";

        private static string Country = "Pais";

        [Fact]
        public void CountryEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Person(Email, FirstName, FirstLastName, SecondLastName, input);

            //assert
            result.Country.Should().Be(string.Empty);
        }

        [Fact]
        public void NameEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Person(Email, input, FirstLastName, SecondLastName, Country);

            //assert
            result.FirstName.Should().Be(string.Empty);
        }

        [Fact]
        public void NullCountryReturnNull()
        {
            //arrange
            string? input = null;

            //act
            var result = new Person(Email, FirstName, FirstLastName, SecondLastName, input);

            //assert
            result.Country.Should().Be(null);
        }

        [Fact]
        public void NullNameReturnNull()
        {
            //arrange
            string? input = null;

            //act
            var result = new Person(Email, input, FirstLastName, SecondLastName, Country);

            //assert
            result.FirstName.Should().Be(null);
        }

        [Fact]
        public void NewPersonWithoutAcademicProfile()
        {
            // act
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);

            // assert
            person.AcademicProfile.Should().Be(null);
        }


        [Fact]
        public void AllNameMatchesPersonName()
        {
            var person = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);
            person.AllName().Should().BeEquivalentTo(FirstName + " " + FirstLastName + " " + SecondLastName);
        }

        [Fact]
        public void EmailStringReturnsSameString()
        {

            //act
            var result = new Person(Email, FirstName, FirstLastName, SecondLastName, Country);

            //assert
            result.Email.Should().Be(Email);
        }

    }
}
