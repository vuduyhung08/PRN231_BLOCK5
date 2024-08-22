namespace DBfirst.Data.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool? IsRegularStudent { get; set; }
        public List<StudentDetailDTO> StudentDetails { get; set; }

    }

}
