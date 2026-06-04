using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetByStudentIdAsync(string studentId);
        Task<Enrollment> GetAsync(string studentId,int courseId);
        Task<Enrollment> AddAsync(Enrollment enrollment);
        Task<bool> UpdateAsync(Enrollment enrollment);
        Task<bool> DeleteAsync(Enrollment enrollment);
    }
}
