using System;
using System.Collections.Generic;

namespace FontEnd.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public int? SubjectId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
