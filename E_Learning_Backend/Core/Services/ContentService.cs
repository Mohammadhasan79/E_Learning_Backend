using AutoMapper;
using E_Learning_Backend.Core.DTOs.ContentDto;
using E_Learning_Backend.Core.DTOs.LessonDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;

namespace E_Learning_Backend.Core.Services
{
    public class ContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        public ContentService(IContentRepository contentRepository, IMapper mapper, IEnrollmentRepository enrollmentRepository)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        public async Task<List<ContentShowDto?>> GetContentByLessonIdAsync(int lessonId)
        {
            var content = await _contentRepository.GetByLessonIdAsync(lessonId);
            return _mapper.Map<List<ContentShowDto?>>(content);
        }
        public async Task<ContentShowDto?> GetContentByIdAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            return _mapper.Map<ContentShowDto?>(content);
        }
        public async Task<Content> CreateContentAsync(int lessonId, CreateContentDto Dto)
        {
            var create = _mapper.Map<Content>(Dto);
            create.LessonId = lessonId;
            return await _contentRepository.AddAsync(create);
        }
        public async Task<bool> UpdateAsync(int id, CreateContentDto? createContentDto)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null) return false;
            _mapper.Map(createContentDto, content);
            return await _contentRepository.UpdateAsync(content);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null) return false;
            return await _contentRepository.DeleteAsync(content);
        }
    }
}
