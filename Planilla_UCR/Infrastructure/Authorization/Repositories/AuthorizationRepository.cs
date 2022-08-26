using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Authorization.Repositories;

namespace Infrastructure.Authorization.Repositories
{
    internal class AuthorizationRepository : IAuthorizationRepository
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;

        public AuthorizationRepository(RoleManager<IdentityRole> roleM, UserManager<IdentityUser> userM) {
            roleManager = roleM;
            userManager = userM;
        }

        public async Task ConfigureRoles() {
            string[] roleNames = { "Employer", "Employee"};
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async Task AssignRole(string email, string role) {
            await ConfigureRoles();
            var roleExist = await roleManager.RoleExistsAsync(role);
            var user = await userManager.FindByEmailAsync(email);
            if (roleExist && user != null)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
        public async Task RemoveRole(string email, string role) {
            var roleExist = await roleManager.RoleExistsAsync(role);
            var user = await userManager.FindByEmailAsync(email);
            if (roleExist && user != null)
            {
                await userManager.RemoveFromRoleAsync(user, role);
            }
        }
    }

}
