using Microsoft.AspNetCore.Mvc;
using DBfirst.DataAccess;
using DBfirst.Models;
using System.Linq;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly Project_B5DBContext _context;

        public SubjectsController(Project_B5DBContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public IActionResult Get()
        {
            var subjects = _context.Subjects
                                   .Select(s => new SubjectDTO
                                   {
                                       SubjectId = s.SubjectId, 
                                       SubjectName = s.SubjectName
                                   })
                                   .ToList();

            return Ok(subjects);
        }

        public class SubjectDTO
        {
            public int SubjectId { get; set; } // Có thể trả về SubjectId nếu cần
            public string? SubjectName { get; set; }
        }

    }
}
