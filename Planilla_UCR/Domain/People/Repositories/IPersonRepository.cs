using System.Threading.Tasks;
using Domain.People.Entities;
using System.Collections.Generic;

namespace Domain.People.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);
        Task<IEnumerable<Person>> GetPersonByEmail(string email);
        void UpdatePerson(Person personInfo);
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetInfoPerson(Person personInfo);
        Task<Person> GetPerson(string personEmail);
    }
}
