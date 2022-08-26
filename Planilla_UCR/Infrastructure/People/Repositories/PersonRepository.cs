using Domain.Core.Repositories;
using Domain.People.Entities;
using Domain.People.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;


namespace Infrastructure.People.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PersonRepository(PersonDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreatePersonAsync(Person personInfo)
        {
            _dbContext.Persons.Add(personInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonByEmail(string email)
        {
            var peopleList = await _dbContext.Persons.FromSqlRaw("EXEC GetPersonByEmail @email",
                new SqlParameter("email", email)).ToListAsync();
            return peopleList;
        }
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _dbContext.Persons.Select(t => new
            Person(t.Email, t.Name, t.LastName1, t.LastName2, t.Ssn,
                t.BankAccount, t.Adress, t.PhoneNumber, t.IsEnabled)).ToListAsync();
        }

        public void UpdatePerson(Person personInfo)
        {
            System.FormattableString query = ($@"EXECUTE UpdatePerson @EmailPerson = {personInfo.Email}, 
                @NewName = {personInfo.Name}, @NewLastName1 = {personInfo.LastName1}, @NewLastName2 = {personInfo.LastName2}, 
                @NewSSN = {personInfo.Ssn}, @NewBankAccount = {personInfo.BankAccount}, @NewAdress = {personInfo.Adress}, 
                @NewPhoneNumber = {personInfo.PhoneNumber}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<Person?> GetInfoPerson(Person personInfo)
        {
            IList<Person> personInfoResult = await _dbContext.Persons.FromSqlRaw("EXEC GetInfoPerson @EmailPerson",
                  new SqlParameter("@EmailPerson", personInfo.Email)).ToListAsync();
            Person infoPerson = null;
            if (personInfoResult.Length() > 0)
            {
                infoPerson = personInfoResult.First();
            }
            return infoPerson;
        }
        public async Task<Person> GetPerson(string personEmail)
        {
            IList<Person> personResult = await _dbContext.Persons.Where
                (e => e.Email == personEmail).ToListAsync();

            Person person = null;
            if (personResult.Length() > 0)
            {
                person = personResult.First();
            }
            return person;
        }
    }
}
