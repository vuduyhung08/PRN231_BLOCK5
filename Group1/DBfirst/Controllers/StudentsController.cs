using AutoMapper;
using DBfirst.Data.DTOs;
using DBfirst.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Project_B5DBContext _context;
        private readonly IMapper _mapper;
        public StudentsController(Project_B5DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = _context.Students
                                   .Select(s => new StudentDTOs
                                   {
                                       StudentId = s.StudentId,
                                       Name = s.Name
                                   })
                                   .ToList();

            return Ok(students);
        }

        public class StudentDTOs
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
        }

        // GET: api/student/{studentId}
        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentDTO>> GetStudentProfile(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.StudentDetails)
                .Where(s => s.StudentId == studentId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = _mapper.Map<StudentDTO>(student);
            return Ok(studentDto);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudent(int studentId, StudentDTO studentDto)
        {
            if (studentId != studentDto.StudentId)
            {
                return BadRequest("Student ID mismatch");
            }

            var student = await _context.Students
                .Include(s => s.StudentDetails) // Bao gồm StudentDetails nếu cần
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            // Ánh xạ từ DTO vào entity
            _mapper.Map(studentDto, student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(studentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Trả về HTTP 204 No Content khi cập nhật thành công
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        // GET: api/student/{studentId}/scores
        [HttpGet("{studentId}/scores")]
        public async Task<ActionResult<IEnumerable<EvaluationDTO>>> GetStudentScores(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.Evaluations)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }
            try
            {
                var evaluationsDto = _mapper.Map<IEnumerable<EvaluationDTO>>(student.Evaluations);
                return Ok(evaluationsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}