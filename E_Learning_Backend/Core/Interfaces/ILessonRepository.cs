using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetByCourseIdAsync(int courseId);
        Task<Lesson?> GetByIdAsync(int id);
        Task<Lesson> AddAsync(Lesson lesson);
        Task<bool> UpdateAsync(Lesson lesson);
        Task<bool> DeleteAsync(Lesson lesson);
    }
}
