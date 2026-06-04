using E_Learning_Backend.Core.DTOs.ContentDto;

namespace E_Learning_Backend.Core.DTOs.LessonDto
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Describtion { get; set; }
        public List<ContentShowDto> Contents { get; set; } = new();
    }
}
