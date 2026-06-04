using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<List<Course>> MyCoursesAsync(string id);
        Task AddAsync(Enrollment enrollment);
        void Remove(Enrollment enrollment);
        Task<bool> ExistEnrollAsync(string userId, int courseId);
        Task<Enrollment?> GetAsync(string userId, int courseId);
    }
}
