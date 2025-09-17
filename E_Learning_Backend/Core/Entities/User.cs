using Microsoft.AspNetCore.Identity;

namespace E_Learning_Backend.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string role { get; set; }
    }
}
