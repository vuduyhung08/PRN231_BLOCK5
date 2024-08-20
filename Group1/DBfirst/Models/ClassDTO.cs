using System.ComponentModel.DataAnnotations;

namespace DBfirst.Models
{
    public class ClassDTO
    {
        [Key]
        public string ClassName { get; set; } = null!;
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
