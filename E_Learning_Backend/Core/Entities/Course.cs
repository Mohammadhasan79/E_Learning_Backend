
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Backend.Core.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public User Instructor { get; set; }

    }
}
