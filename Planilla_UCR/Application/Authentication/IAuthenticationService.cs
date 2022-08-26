using System.Threading.Tasks;
using Domain.Authentication.DTOs;

namespace Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterRequestAsync(AccountDTO accountData);
        Task<bool> SignInRequestAsync(AccountDTO accountData, bool isPersistent);
        Task<bool> SignInInternalAsync(string token, bool isPersistent);
        string EncryptString(string data, string key);
        string Decrypt(string data, string key);
        Task SignOut();
        Task<bool> EmailIsAlreadyRegistered(string email);
        Task DeleteAccount(string email);
    }
}
