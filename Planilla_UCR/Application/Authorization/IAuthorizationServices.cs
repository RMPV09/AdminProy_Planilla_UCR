using System.Threading.Tasks;

namespace Application.Authorization
{
    public interface IAuthorizationServices
    {
        Task ConfigureRoles();
        Task AssignRole(string email, string role);
        Task RemoveRole(string email, string role);
    }
}
