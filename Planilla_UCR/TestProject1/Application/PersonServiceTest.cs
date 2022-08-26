using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.People.Implementations;
using Application.People;
using Moq;
using Xunit;
using System;
//Proyectos
using Domain.People.Repositories;
using Domain.People.Entities;

namespace Tests.Application
{

    public class PersonServiceTest
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
        public async Task GetPersonTest()
        {
            //arrange
            var person = new Person(Email, Name, LastName1, LastName2, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled);
            var mockPeopleRepository = new Mock<IPersonRepository>();
            var peopleService = new PersonService(mockPeopleRepository.Object);
            mockPeopleRepository.Setup(repo => repo.GetPerson(Email)).ReturnsAsync(person);
            await peopleService.CreatePersonAsync(person);

            //act
            Person PeopleTest = await peopleService.GetPerson(Email);

            //assert
            PeopleTest.Email.Should().Be(Email);
            mockPeopleRepository.Verify(repo => repo.GetPerson(Email), Times.Once);
        }
        [Fact]
        public async Task GetAllPeopleAsyncTest() 
        {
            // arrange
            IEnumerable<Person> people = new List<Person>()
            {
                new Person(Email, Name, LastName1, LastName2, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled)
            };
            var person = new Person(Email, Name, LastName1, LastName2, Ssn, BankAccount, Adress, PhoneNumber, IsEnabled);
            var mockPeopleRepository = new Mock<IPersonRepository>();
            var peopleService = new PersonService(mockPeopleRepository.Object);
            mockPeopleRepository.Setup(repo => repo.GetAllPeopleAsync()).ReturnsAsync(people);
            await peopleService.CreatePersonAsync(person);

            //act
            IEnumerable<Person> PeopleTest = await peopleService.GetAllPeopleAsync();

            //assert
            PeopleTest.ElementAtOrDefault(0).Email.Should().Be(Email);
            mockPeopleRepository.Verify(repo => repo.GetAllPeopleAsync(), Times.AtLeastOnce);

        }
    }
}
