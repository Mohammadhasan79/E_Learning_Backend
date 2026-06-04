using Microsoft.AspNetCore.Identity;

namespace E_Learning_Backend.Core.Entities
{
    public class User : IdentityUser//<long>
    {
        public string FullName { get; set; }
    }
}
