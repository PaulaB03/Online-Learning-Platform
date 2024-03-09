using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Instructor
    {
        [Key]
        [ForeignKey("User")]
        public string InstructorId { get; set; }
        public string? Department { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
