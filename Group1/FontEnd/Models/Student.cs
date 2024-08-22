using System;
using System.Collections.Generic;

namespace FontEnd.Models
{
    public partial class Student
    {
        

        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool? IsRegularStudent { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
