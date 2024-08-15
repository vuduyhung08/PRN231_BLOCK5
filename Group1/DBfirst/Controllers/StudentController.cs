using AutoMapper;
using DBfirst.DTOs;
using DBfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BL5_Database_SchoolContext _context;
        private readonly IMapper _mapper;

        public StudentController(BL5_Database_SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            var evaluationsDto = _mapper.Map<IEnumerable<EvaluationDTO>>(student.Evaluations);
            return Ok(evaluationsDto);
        }

    }
}
