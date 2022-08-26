using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Authentication.Repositories;
using Domain.Authentication.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;


namespace Infrastructure.Authentication.Repositories
{
    internal class AuthenticationRepository : IAuthenticationRepository
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> signInManag;
        private NavigationManager navigationManager;
        private IDataProtectionProvider _dataProtecter;

        public AuthenticationRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, NavigationManager nav, IDataProtectionProvider dataProtector)
        {
            this._userManager = userManager;
            this._userManager = userManager;
            this.signInManag = signInManager;
            navigationManager = nav;
            _dataProtecter = dataProtector;
        }

        public string EncryptString(string data, string key)
        {
            var protector = _dataProtecter.CreateProtector(key);
            return protector.Protect(data);
        }

        public string Decrypt(string data, string key)
        {
            var protector = _dataProtecter.CreateProtector(key);
            return protector.Unprotect(data);
        }

        public async Task<bool> RegisterRequestAsync(AccountDTO accountData)
        {
            bool success = false;
            var user = new IdentityUser()
            {
                UserName = accountData.Email,
                Email = accountData.Email,  
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, accountData.Password);

            if (result.Succeeded)
            {
                success = true;
            }
            return success;
        }

        public async Task<bool> SignInInternalAsync(string token, bool isPersistent)
        {
            var dataProtector = _dataProtecter.CreateProtector("Login");
            var data = dataProtector.Unprotect(token);
            var parts = data.Split('|');
            var identityUser = await _userManager.FindByIdAsync(parts[0]);

            if (identityUser == null)
            {
                return false;
            }

            var isTokenValid = await _userManager.VerifyUserTokenAsync(identityUser, TokenOptions.DefaultProvider, "Login", parts[1]);

            if (isTokenValid)
            {

                await _userManager.ResetAccessFailedCountAsync(identityUser);
                await signInManag.SignInAsync(identityUser, isPersistent);
                return true;
            }

            return false;
        }

        public async Task<bool> SignInRequestAsync(AccountDTO r, bool isPersistent)
        {
            bool result = false;
            var user = await _userManager.FindByNameAsync(r.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, r.Password) == true)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "Login");
                        string data = user.Id + "|" + token;
                        var protector = _dataProtecter.CreateProtector("Login");
                        var protectedData = protector.Protect(data);
                        navigationManager.NavigateTo("/login?key=" + protectedData, true);
                        result = true;
                    }
                    else
                    {
                        navigationManager.NavigateTo("/confirmAccount/" + EncryptString(r.Email, "confirm"), true);
                    }
                }
            }
            return result;
        }

        public async Task SignOut()
        {
            await signInManag.SignOutAsync();
        }

        public async Task<bool> EmailIsAlreadyRegistered(string email)
        {
            bool isRegistered = false;
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                isRegistered = true;
            }
            return isRegistered;
        }


        public async Task DeleteAccount(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            await _userManager.DeleteAsync(user);
        }
    }
}
