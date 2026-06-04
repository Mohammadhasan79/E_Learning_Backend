using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace E_Learning_Backend.Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;
        //private readonly IMemoryCache _memoryCache;

        public LessonRepository(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            //_memoryCache = memoryCache;
        }
        public async Task<IEnumerable<Lesson>> GetByCourseIdAsync(int courseId)
        {
            //string cacheKey = $"lessons_course_{courseId}";
            //if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<Lesson> result))
            //{
            //    Console.WriteLine($"[CACHE] Data for course {courseId} fetched from cache.");
            //    return result;
            //}
            //Console.WriteLine($"[DB] Data for course {courseId} fetched from database.");
            var lessons = await _context.Lessons.Include(n => n.Contents).Where(n=> n.CourseId == courseId).ToListAsync();
            //_memoryCache.Set(cacheKey, lessons, new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            //    SlidingExpiration = TimeSpan.FromMinutes(2)
            //});
            return lessons;
        }
        public async Task<Lesson?> GetByIdAsync(int id)
        {
            return await _context.Lessons.Include(n => n.Contents).FirstOrDefaultAsync(n => n.Id == id); 
        }
        public async Task<Lesson> AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            //_memoryCache.Remove($"lessons_course_{lesson.CourseId}");
            return lesson;
        }
        public async Task<bool> UpdateAsync(Lesson lesson)
        {
            if (lesson == null) return false;
            _context.Lessons.Update(lesson);
            var result = await _context.SaveChangesAsync();
            //_memoryCache.Remove($"lessons_course_{lesson.CourseId}");

            return result > 0;
        }
        public async Task<bool> DeleteAsync(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
            var result = await _context.SaveChangesAsync();
            //_memoryCache.Remove($"lessons_course_{lesson.CourseId}");

            return result > 0;
        }
    }
}
