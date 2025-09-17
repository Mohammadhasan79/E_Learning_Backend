using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Learning_Backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    public async Task<User> GetByUserNameAsync(string userName)
        {

            return await _userManager.FindByNameAsync(userName);
        }
    public async Task<User> AddUserAsync(User user,string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded) return null;
            return user;
        }
    public async Task<bool> CheckPasswordAsync(User user,string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
