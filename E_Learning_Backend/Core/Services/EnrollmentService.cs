using AutoMapper;
using E_Learning_Backend.Core.Common;
using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;


namespace E_Learning_Backend.Core.Services
{
    public class EnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrollmentService(IEnrollmentRepository repository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResultRespons<List<CourseDto>>> MyCoureseAsync(string id)
        {
            var courses = await _repository.MyCoursesAsync(id);
            if (courses == null)
                return ResultRespons<List<CourseDto>>.Fail("Student hasnt Enroll");

            var myCourse = _mapper.Map<List<CourseDto>>(courses);

            return ResultRespons<List<CourseDto>>.Ok(myCourse);
        }



        public async Task<ResultRespons> EnrollmentAsync(string userId ,int courseId)
        {
            var exists = await _repository.ExistEnrollAsync(userId, courseId);
            if (exists)
                return ResultRespons.Fail("User has Enroll");

            var enrollment = new Enrollment
            {
                StudentId = userId,
                CourseId = courseId
            };

            await _repository.AddAsync(enrollment);
            await _unitOfWork.SaveChangesAsync();
            return ResultRespons.Ok($"Enroll Success {courseId}");
        }
        public async Task<ResultRespons> UnEnrollmentAsync(string userId, int courseId)
        {
            var exists = await _repository.GetAsync(userId , courseId);

            if (exists == null)
                return ResultRespons.Fail("User hasnt Enroll");

            _repository.Remove(exists);
            await _unitOfWork.SaveChangesAsync();
            return ResultRespons.Ok($"UnEnroll Success {courseId}");
        }
    }
}

