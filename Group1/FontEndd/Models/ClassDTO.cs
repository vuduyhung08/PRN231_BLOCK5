using System.ComponentModel.DataAnnotations;

namespace FontEndd.Models
{
    public class ClassDTO
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }


    }
}
