namespace E_Learning_Backend.Core.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Type { get; set; } = "Video";//Video PDF Text
        public string Url { get; set; } = string.Empty;
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

    }
}
