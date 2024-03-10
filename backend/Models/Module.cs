using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int CourseId { get; set; }
        [ForeignKey("CourseId")]
        [JsonIgnore]
        public virtual Course? Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
