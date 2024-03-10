using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonId { get; set; }
        public string Name { get; set;}
        public string? Content { get; set;}
        public required int ModuleId { get; set;}
        [ForeignKey("ModuleId")]
        [JsonIgnore]
        public virtual Module? Module { get; set;}
    }
}
