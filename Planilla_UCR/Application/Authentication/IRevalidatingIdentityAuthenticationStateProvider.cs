using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Components.Authorization;

namespace Application.Authentication
{
    public interface IRevalidatingIdentityAuthenticationStateProvider<TUser> : IDisposable where TUser : class
    {
        Task<bool> ValidateAuthenticationStateAsync(
            AuthenticationState authenticationState, CancellationToken cancellationToken);
        Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal);
     }
}
