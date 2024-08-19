using Microsoft.AspNetCore.Identity;

namespace DBfirst.Models
{
    public class User : IdentityUser
    {
        public bool ActiveCode { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
