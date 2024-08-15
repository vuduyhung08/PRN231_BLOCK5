using System;
using System.Collections.Generic;

namespace DBfirst.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public int? SubjectId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
