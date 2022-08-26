using System.Threading.Tasks;

namespace Domain.Authorization.Repositories
{
    public interface IAuthorizationRepository
    {
        Task ConfigureRoles();
        Task AssignRole(string email, string role);
        Task RemoveRole(string email, string role);
    }
}
