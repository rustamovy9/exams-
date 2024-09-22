using Infrustracture.Models;

namespace Infrustracture.Services.UsersService;

public interface IUserService
{
    Task<bool> CreateUserAsync(Users users);
    Task<bool> UpdateUserAsync(Users users);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<Users?> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<Users>> GetUsersAsync();
}