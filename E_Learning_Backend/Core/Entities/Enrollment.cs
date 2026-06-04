namespace E_Learning_Backend.Core.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public User Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsCompelete { get; set; } = false;  

    }
}
