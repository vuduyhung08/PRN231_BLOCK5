using DBfirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BL5_PRN231_ProjectContext _projectContext;

        public StudentController(BL5_PRN231_ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        [HttpGet]
        public IActionResult get()
        {
            var list = _projectContext.Students.Select(s => new 
            {
                Studentid = s.StudentId,
                Name = s.Name,
                Age = s.Age,
                IsRegularStudent = s.IsRegularStudent
            });

            return Ok(list);
        }

        [HttpGet("student/{studentId}/classes")]
        public async Task<IActionResult> GetClassesForStudent(int studentId)
        {
            var student = await _projectContext.Students
                .Include(s => s.Classes) // Đảm bảo bao gồm các lớp mà sinh viên đăng ký
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu sinh viên không tồn tại
            }

            var studentClasses = student.Classes.Select(c => new
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                TeacherId = c.TeacherId,
                SubjectId = c.SubjectId
            }).ToList();

            return Ok(studentClasses);
        }






        [HttpPost("AddStudentClass")]
        public IActionResult AddStudentClass([FromBody] AddStudentClassRequest request)
        {
            var classEntity = _projectContext.Classes
                .FirstOrDefault(c => c.ClassId == request.ClassId);

            if (classEntity == null)
            {
                return NotFound("Class not found.");
            }

            var studentEntity = _projectContext.Students
                .FirstOrDefault(s => s.StudentId == request.StudentId);

            if (studentEntity == null)
            {
                return NotFound("Student not found.");
            }

            if (classEntity.Students.Any(s => s.StudentId == request.StudentId))
            {
                return BadRequest("Student is already enrolled in this class.");
            }

            classEntity.Students.Add(studentEntity);

            try
            {
                _projectContext.SaveChanges();
                return Ok($"Student {request.StudentId} has been added to class {request.ClassId}.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding student to class: {ex.Message}");
            }
        }





        [HttpPost("feedback/{StudentId}/{ClassId}")]
        public IActionResult PostFeedBack(int StudentId, int ClassId, [FromForm] FeedBackDTO feedback)
        {
            // Kiểm tra xem sinh viên có tồn tại hay không
            var student = _projectContext.Students
                .FirstOrDefault(s => s.StudentId == StudentId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Kiểm tra xem sinh viên có tham gia lớp học này không
            var classStudent = _projectContext.Classes
                .FirstOrDefault(c => c.ClassId == ClassId && c.Students.Any(s => s.StudentId == StudentId));

            if (classStudent == null)
            {
                return NotFound("Student is not enrolled in this class.");
            }

            // Kiểm tra xem sinh viên đã đánh giá lớp học này chưa
            var existingFeedback = _projectContext.Feedbacks
                .FirstOrDefault(f => f.ClassId == ClassId && f.StudentId == StudentId);

            if (existingFeedback != null)
            {
                return BadRequest("Student has already provided feedback for this class.");
            }

            // Thêm đánh giá (feedback) cho lớp học
            var feedbackEntity = new Feedback
            {
                StudentId = StudentId,
                ClassId = ClassId,
                Rating = feedback.Rating,
                FeedbackText = feedback.FeedbackText,
                CreatedDate = DateTime.Now
            };

            _projectContext.Feedbacks.Add(feedbackEntity);
            _projectContext.SaveChanges();

            return Ok("Add thành công");
        }


    }
}
