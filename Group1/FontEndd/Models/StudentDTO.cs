using System.ComponentModel.DataAnnotations;

namespace FontEndd.Models
{
    public class StudentDTO
    {
        [Key]
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool? IsRegularStudent { get; set; }

    }
}
