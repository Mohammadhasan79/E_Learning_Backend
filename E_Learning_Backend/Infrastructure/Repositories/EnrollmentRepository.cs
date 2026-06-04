using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Infrastructure.Data;
using E_Learning_Backend.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Backend.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> MyCoursesAsync(string id)
        {
            return await _context.Enrollments
                .Where(a => a.StudentId == id)
                .Select(a =>a.Course).ToListAsync();
        }

        public async Task<bool> ExistEnrollAsync(string userId, int courseId)
        {
            return await _context.Enrollments
            .AnyAsync(x => x.StudentId == userId && x.CourseId == courseId);
        }

        public async Task<Enrollment?> GetAsync(string userId, int courseId)
        {
            return await _context.Enrollments
            .FirstOrDefaultAsync(x => x.StudentId == userId && x.CourseId == courseId);
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
        }


        public void Remove(Enrollment enrollment)
        {        
            _context.Enrollments.Remove(enrollment);
        }
    }
}
