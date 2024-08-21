using Microsoft.AspNetCore.Mvc;
using DBfirst.DataAccess;
using DBfirst.Models;
using System.Linq;
using static DBfirst.Controllers.EvaluationsController;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Project_B5DBContext _context;

        public StudentsController(Project_B5DBContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.Students
                                   .Select(s => new StudentDTO
                                   {
                                       StudentId = s.StudentId,
                                       Name = s.Name
                                   })
                                   .ToList();

            return Ok(students);
        }

        public class StudentDTO
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
        }


    }
}
