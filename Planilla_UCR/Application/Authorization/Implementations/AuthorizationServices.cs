using System.Threading.Tasks;
using Domain.Authorization.Repositories;

namespace Application.Authorization.Implementations
{
    public class AuthorizationService : IAuthorizationServices
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        public AuthorizationService(IAuthorizationRepository authorization) {
            _authorizationRepository = authorization;
        }
        public async Task ConfigureRoles() {
            await _authorizationRepository.ConfigureRoles();
        }
        public async Task AssignRole(string email, string role){
            await _authorizationRepository.AssignRole(email,role);
        }
        public async Task RemoveRole(string email, string role){
            await _authorizationRepository.RemoveRole(email, role);
        }
    }
}
