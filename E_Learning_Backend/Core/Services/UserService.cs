using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace E_Learning_Backend.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<string> RagisterAsync(UserRegisterDto userRegisterDto)
        {

            var user = _mapper.Map<User>(userRegisterDto);
            if (user == null)
                return null;

            var result = await _userRepository.AddUserAsync(user, userRegisterDto.PasswordHash);
            if (result == null)
                return null;
            var token = await GenerateToken(result);
            if (token == null) return null;
            return token;
        }



        public async Task<string> LoginAsync(UserLoginDto Dto)
        {
            var user = await _userRepository.GetByUserNameAsync(Dto.UserName);
            if (user == null)
                return null;
            var isvalid = await _userRepository.CheckPasswordAsync(user, Dto.Password);
            if (!isvalid) return null;

            var token = await GenerateToken(user);
            return token;
        }



        private async Task<string> GenerateToken(User user) {

            var roles = await _userRepository.UserRolesAsync(user);

        //Generate Token by JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("SuperSecretKeyForJWTMyProjectIsElearnforfunandmylearn");
            var claim = new List<Claim>
            {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim("Display Name",user.FullName)
            };
            claim.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
