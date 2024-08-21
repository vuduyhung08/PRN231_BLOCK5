using DBfirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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





        [HttpPost("feedback")]
        public IActionResult PostFeedBack(int cId, int sId, [FromForm] FeedBackDTO feedback)
        {
            // Kiểm tra xem sinh viên có tồn tại hay không
            var student = _projectContext.Students
                .FirstOrDefault(s => s.StudentId == sId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Kiểm tra xem sinh viên có tham gia lớp học này không
            var classStudent = _projectContext.Classes
                .FirstOrDefault(c => c.ClassId == cId && c.Students.Any(s => s.StudentId == sId));

            if (classStudent == null)
            {
                return NotFound("Student is not enrolled in this class.");
            }

            // Kiểm tra xem sinh viên đã đánh giá lớp học này chưa
            var existingFeedback = _projectContext.Feedbacks
                .FirstOrDefault(f => f.ClassId == cId && f.StudentId == sId);

            if (existingFeedback != null)
            {
                return BadRequest("Student has already provided feedback for this class.");
            }

            // Thêm đánh giá (feedback) cho lớp học
            var feedbackEntity = new Feedback
            {
                StudentId = sId,
                ClassId = cId,
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
