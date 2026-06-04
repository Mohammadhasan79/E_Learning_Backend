using E_Learning_Backend.Core.Entities;

namespace E_Learning_Backend.Core.Interfaces
{
    public interface IContentRepository
    {
        Task<Content?> GetByIdAsync(int id);
        Task<Content> AddAsync(Content content);
        Task<bool> UpdateAsync(Content content);
        Task<bool> DeleteAsync(Content content);
    }
}
