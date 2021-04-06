using Core.Dto.GatewayResponses.Repositories;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Gateways.Repositories
{
    /// <summary>
    /// User Repository for accessing user information
    /// </summary>
    public interface IUserRepository
    {
        Task<CreateUserResponse> CreateAsync(User user, string password);
        Task<User> FindByNameAsync(string username);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(string username, string password);
        Task<User> FindByIdAsync(string id);
    }
}
