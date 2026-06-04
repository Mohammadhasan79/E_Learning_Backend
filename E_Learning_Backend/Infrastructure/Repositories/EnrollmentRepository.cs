//using E_Learning_Backend.Core.Entities;
//using E_Learning_Backend.Core.Interfaces;
//using E_Learning_Backend.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//namespace E_Learning_Backend.Infrastructure.Repositories
//{
//    public class EnrollmentRepository : IEnrollmentRepository
//    {
//        public readonly AppDbContext _context;
//        public EnrollmentRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Enrollment>> GetByStudentIdAsync(string studentId)
//        {
//            return await _context.Enrollments.Include(x=>x.Course).Where(x => x.StudentId == studentId).ToListAsync();
//        }
//        public async Task<Enrollment> GetAsync(string studentId, int courseId)
//        {

//        }
//        public async Task<Enrollment> AddAsync(Enrollment enrollment)
//        {

//        }
//        public async Task<bool> UpdateAsync(Enrollment enrollment)
//        {

//        }
//        public async Task<bool> DeleteAsync(Enrollment enrollment)
//        {

//        }
//    }
//}
