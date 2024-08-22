using Microsoft.AspNetCore.Mvc;
using DBfirst.DataAccess;
using DBfirst.Models;
using System.Linq;
using static DBfirst.Controllers.EvaluationsController;
using Microsoft.EntityFrameworkCore;
using DBfirst.Data.DTOs;
using AutoMapper;

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

        [HttpGet("viewstudentdetail")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.StudentDetails)
                .ToListAsync();

            var studentDtos = students.Select(student => new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                IsRegularStudent = student.IsRegularStudent,
                Address = student.StudentDetails.FirstOrDefault()?.Address,
                AdditionalInformation = student.StudentDetails.FirstOrDefault()?.AdditionalInformation
            }).ToList();

            return Ok(studentDtos);
        }

        // POST: api/Students
        [HttpPost("createstudent")]
        public async Task<ActionResult<Student>> CreateStudent(CreateStudentDto createStudentDto)
        {
            var student = _mapper.Map<Student>(createStudentDto);

            // Add the new student to the context
            _context.Students.Add(student);

            // Save changes to the database to generate the StudentId
            await _context.SaveChangesAsync();

            // Now that the StudentId is generated, update the StudentId in each StudentDetail
            foreach (var detail in student.StudentDetails)
            {
                detail.StudentId = student.StudentId;
            }

            // Save changes to the database to persist the StudentDetail updates
            await _context.SaveChangesAsync();

            // Return the newly created student object or a relevant response
            return Ok(new { student.StudentId, student.Name });
        }

        // PUT: api/Students/{id}
        [HttpPut("editstudent")]
        public async Task<IActionResult> EditStudent(int id, EditStudentDto studentDto)
        {
            var student = await _context.Students
                .Include(s => s.StudentDetails)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentDto.Name;
            student.Age = studentDto.Age;
            student.IsRegularStudent = studentDto.IsRegularStudent;

            var studentDetail = student.StudentDetails.FirstOrDefault();
            if (studentDetail != null)
            {
                studentDetail.Address = studentDto.Address;
                studentDetail.AdditionalInformation = studentDto.AdditionalInformation;
            }

            _context.Entry(student).State = EntityState.Modified;
            _context.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}