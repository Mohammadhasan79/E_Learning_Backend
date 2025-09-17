using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Services;
using E_Learning_Backend.Core.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Learning_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserService userService, RoleManager<IdentityRole> roleManager)
        {
            //_userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            //var existingUser = new User { UserName = user.UserName, Email = user.Email, EmailConfirmed = true, FullName = user.FullName, role = user.Role };
            //var roleExist = await _roleManager.RoleExistsAsync(user.Role);
            //if (!roleExist) return BadRequest("Role Not Exist");
            var validator = new UserRegisterValidator();
            var result = validator.Validate(user);
            if (!result.IsValid) return BadRequest(result.Errors);
             var UserAdd = await _userService.RagisterAsync(user);
            if (UserAdd == null) return BadRequest("Registration failed");
            return Ok("User Registered Successfully");
            //await _userManager.AddToRoleAsync(existingUser, existingUser.role);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            var validator = new UserLoginValidator();
            var result = validator.Validate(user);
            var User = await _userService.LoginAsync(user);
            if (User == null) return Unauthorized("Ivalid ");


            //Generate Token by JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SuperSecretKeyForJWTMyProjectIsElearnforfunandmylearn");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Id),
                    new Claim(ClaimTypes.Name,User.UserName),
                    new Claim(ClaimTypes.Role,User.role)
                }
                ),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token)});
        }

    }
}
