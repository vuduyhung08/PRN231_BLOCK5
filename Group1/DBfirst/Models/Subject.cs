using System;
using System.Collections.Generic;

namespace DBfirst.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
