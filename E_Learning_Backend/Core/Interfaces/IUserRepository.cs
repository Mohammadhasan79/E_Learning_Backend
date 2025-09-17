using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUserNameAsync(string userName);
        Task<User> AddUserAsync(User user, string password);
        Task<bool> CheckPasswordAsync(User user,string password);
    }
}
