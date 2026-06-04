using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Xunit.Sdk;

namespace E_Learning_Backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {

            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<User> AddUserAsync(User user, string password)
        {

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return null;
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Student");

            if (!roleResult.Succeeded)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> CheckPasswordAsync(User user,string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

    public async Task<List<string>> UserRolesAsync(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList(); ;
        }
    }
}
