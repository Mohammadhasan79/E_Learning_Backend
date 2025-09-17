using AutoMapper;
using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;

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
        public async Task<User> RagisterAsync(UserRegisterDto userRegisterDto)
        {
           
            var user = _mapper.Map<User>(userRegisterDto);
            return await _userRepository.AddUserAsync(user, userRegisterDto.Password);
        }
        public async Task<User> LoginAsync(UserLoginDto Dto)
        {
            var user = await _userRepository.GetByUserNameAsync(Dto.UserName);
            var isvalid = await _userRepository.CheckPasswordAsync(user,Dto.Password); 
            if(!isvalid) return null;
            return user;
        }
    }
}
