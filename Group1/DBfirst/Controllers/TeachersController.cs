using DBfirst.DataAccess;
using DBfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly Project_B5DBContext _context;

        public TeachersController(Project_B5DBContext context)
        {
            _context = context;
        }

        [HttpPost("ChangeSubject")]
        public IActionResult ChangeSubject([FromODataUri] int teacherId, [FromForm] int subjectId)
        {
            var teacher = _context.Teachers.SingleOrDefault(t => t.TeacherId == teacherId);

            if (teacher == null)
            {
                return NotFound();
            }

            teacher.SubjectId = subjectId;
            _context.SaveChanges();

            return Ok(teacher);
        }
    }
}