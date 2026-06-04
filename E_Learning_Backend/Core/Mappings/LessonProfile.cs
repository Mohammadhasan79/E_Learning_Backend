using AutoMapper;
using E_Learning_Backend.Core.DTOs.ContentDto;
using E_Learning_Backend.Core.DTOs.LessonDto;
using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Mappings
{
    public class LessonProfile : Profile
    {
        public LessonProfile() 
        {
            CreateMap<Lesson, LessonDto>();
            CreateMap<Content,ContentShowDto>();
            CreateMap<CreateLessonDto, Lesson>();
                
        }
    }
}
