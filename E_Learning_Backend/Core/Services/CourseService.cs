using AutoMapper;
using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_Learning_Backend.Core.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var Courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(Courses);
        }
        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var Course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(Course);
        }
        public async Task<Course> CreateCourseAsync(CreateCourseDto Dto,string instructorId)
        {
            var Course = _mapper.Map<Course>(Dto);
            Course.InstructorId = instructorId;
            return await _courseRepository.AddAsync(Course);
        }
        public async Task UpdateCourseAsync(int id , CreateCourseDto Dto)
        {
            var Course = await _courseRepository.GetByIdAsync (id);
            if (Course == null) throw new Exception("Course not found");

            _mapper.Map(Dto, Course);
            await _courseRepository.UpdateAsync(Course);
        }
        public async Task DeleteCourseAsync(int id)
        {
            var Course = await _courseRepository.GetByIdAsync(id);
            if (Course != null)
                await _courseRepository.DeleteAsync(Course);
        }
    }
}
