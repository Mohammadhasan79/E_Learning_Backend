using AutoMapper;
using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserRegisterDto, User>();
        }
    }
}
