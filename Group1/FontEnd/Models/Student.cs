using System;
using System.Collections.Generic;

namespace FontEnd.Models
{
    public partial class Student
    {
        public Student()
        {
            Evaluations = new HashSet<Evaluation>();
            Feedbacks = new HashSet<Feedback>();
            StudentDetails = new HashSet<StudentDetail>();
            Classes = new HashSet<Class>();
            Subjects = new HashSet<Subject>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool? IsRegularStudent { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
