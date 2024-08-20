using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBfirst.Models
{
    public partial class Student
    {
        public Student()
        {
            Evaluations = new HashSet<Evaluation>();
            StudentDetails = new HashSet<StudentDetail>();
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool? IsRegularStudent { get; set; }
        public string? AccountId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        [JsonIgnore]
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }

    }
}
