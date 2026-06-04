using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Services;
using E_Learning_Backend.Core.Validator;
using Microsoft.AspNetCore.Authorization;
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
        public AuthController(UserService userService, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
             var UserAdd = await _userService.RagisterAsync(user);

            if (UserAdd == null) return BadRequest("Register faild");

            return Ok(UserAdd);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            var token = await _userService.LoginAsync(user);
            if (User == null) return Unauthorized("Invalid ");
            return Ok(token);
        }

    }
}
