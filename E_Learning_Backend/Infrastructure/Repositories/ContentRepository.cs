using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Backend.Infrastructure.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly AppDbContext _context;
        public ContentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Content?> GetByIdAsync(int id)
        {
            return await _context.Contents.FirstOrDefaultAsync(n => n.Id == id);
        }
        public async Task<Content> AddAsync(Content content)
        {
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();
            return content;
        }
        public async Task<bool> UpdateAsync(Content content)
        {
            if (content == null) return false;
            _context.Contents.Update(content);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<bool> DeleteAsync(Content content)
        {
            _context.Contents.Remove(content);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
