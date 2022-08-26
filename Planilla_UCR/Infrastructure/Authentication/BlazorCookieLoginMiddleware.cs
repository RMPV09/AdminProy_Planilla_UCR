using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Domain.Authentication.Repositories;

namespace Infrastructure.Authentication
{
    public class BlazorCookieLoginMiddleware<TUser> where TUser : class
    {
        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationRepository auth)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = context.Request.Query["key"];

                var result = await auth.SignInInternalAsync(key, true);

                if (result)
                {
                    context.Response.Redirect("/");
                    return;
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else if (context.Request.Path.StartsWithSegments("/logout"))
            {
                await auth.SignOut();
                context.Response.Redirect("/");
                return;
            }
            else if (context.Request.Path.StartsWithSegments("/delete"))
            {
                await auth.SignOut();
                await  auth.DeleteAccount(context.User.Identity.Name);
                context.Response.Redirect("/");
                return;
            }
            await _next.Invoke(context);
        }
    }
}
