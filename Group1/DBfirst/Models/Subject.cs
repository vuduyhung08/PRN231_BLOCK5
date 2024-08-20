using System;
using System.Collections.Generic;

namespace DBfirst.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
