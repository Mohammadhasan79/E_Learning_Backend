using AutoMapper;
using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile() 
        {

            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.FullName));
            CreateMap<CreateCourseDto, Course>();

        }
    }
}


