using Domain.People.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.People
{
    public interface IPersonService
    {
        Task CreatePersonAsync(Person personInfo);
        Task<IEnumerable<Person>> GetPersonByEmail(string email);
        void UpdatePerson(Person personInfo);
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetInfoPerson(Person personInfo);
        Task<Person> GetPerson(string personEmail);
    }
}
