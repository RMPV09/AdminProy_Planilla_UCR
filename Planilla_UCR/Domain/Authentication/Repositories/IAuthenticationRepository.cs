using Domain.Authentication.DTOs;
using System.Threading.Tasks;

namespace Domain.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<bool> RegisterRequestAsync(AccountDTO accountData);
        Task<bool> SignInRequestAsync(AccountDTO accountData , bool isPersistent);
        Task<bool> SignInInternalAsync(string token, bool isPersistent);
        string EncryptString(string data, string key);
        string Decrypt(string data, string key);
        public Task SignOut();
        Task<bool> EmailIsAlreadyRegistered(string email);
        Task DeleteAccount(string email);
    }
}
