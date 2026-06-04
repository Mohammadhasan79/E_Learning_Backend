using AutoMapper;
using E_Learning_Backend.Core.Common;
using E_Learning_Backend.Core.DTOs.ContentDto;
using E_Learning_Backend.Core.DTOs.LessonDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Learning_Backend.Core.Services
{
    public class LessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;
        public LessonService(ILessonRepository lessonRepository,IMapper mapper,IEnrollmentRepository enrollmentRepository)
        {
            _lessonRepository = lessonRepository;
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
        public async Task<ResultRespons<IEnumerable<LessonDto>>> GetLessonsByCourseIdAndUserIdAsync(string userId,int courseId)
        {
            var isEnroll =await _enrollmentRepository.ExistEnrollAsync(userId, courseId);

            if (!isEnroll)
                return ResultRespons<IEnumerable<LessonDto>>.Fail("Forbid");

            var lessons = await _lessonRepository.GetByCourseIdAsync(courseId);
            return ResultRespons<IEnumerable<LessonDto>>.Ok(_mapper.Map<IEnumerable<LessonDto>>(lessons));
        }
        public async Task<IEnumerable<LessonDto>> GetLessonsByCourseIdAsync(int courseId)
        {
            var lessons = await _lessonRepository.GetByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<LessonDto>>(lessons);
        }
        public async Task<LessonDto?> GetLessonByIdAsync(int id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            return _mapper.Map<LessonDto?>(lesson);
        }
        public async Task<Lesson> CreateLessonAsync(int courseId,CreateLessonDto Dto)
        {
            var create = _mapper.Map<Lesson>(Dto);
            create.CourseId = courseId;
            return await _lessonRepository.AddAsync(create);
        }
        public async Task<bool> UpdateAsync(int id,CreateLessonDto? CreatelessonDto)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            if (lesson == null) return false;
            _mapper.Map(CreatelessonDto, lesson);
            return await _lessonRepository.UpdateAsync(lesson);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            if (lesson == null) return false;
            return await _lessonRepository.DeleteAsync(lesson);
        }
    }
}
