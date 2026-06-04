using AutoMapper;
using E_Learning_Backend.Core.DTOs.ContentDto;
using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Mappings
{
    public class ContentProfile : Profile
    {
        public ContentProfile() 
        {
            CreateMap<Content, ContentShowDto>();
            CreateMap<CreateContentDto, Content>();
        }
    }
}
