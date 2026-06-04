namespace E_Learning_Backend.Core.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Describtion { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Content> Contents { get; set; }

    }
}
