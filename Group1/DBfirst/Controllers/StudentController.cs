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
        [HttpPost]
        public IActionResult addStudentClass(int sId, int cId)
        {
            // Kiểm tra xem lớp học có tồn tại không
            var classEntity = _projectContext.Classes
                .FirstOrDefault(c => c.ClassId == cId);

            if (classEntity == null)
            {
                return NotFound("Class not found.");
            }

            // Kiểm tra xem sinh viên có tồn tại không
            var studentEntity = _projectContext.Students
                .FirstOrDefault(s => s.StudentId == sId);

            if (studentEntity == null)
            {
                return NotFound("Student not found.");
            }

            // Kiểm tra xem sinh viên đã tham gia lớp này chưa
            if (classEntity.Students.Any(s => s.StudentId == sId))
            {
                return BadRequest("Student is already enrolled in this class.");
            }

            // Thêm sinh viên vào lớp
            classEntity.Students.Add(studentEntity);

            _projectContext.SaveChanges();

            return Ok($"Student {sId} has been added to class {cId}.");
        }

        [HttpPost("{StudentId}/feedback")]
        public IActionResult PostFeedBack(int cId, int sId, [FromForm] Feedback feedback)
        {
            // Kiểm tra xem sinh viên có tham gia lớp học này không
            var classStudent = _projectContext.Feedbacks
                .FirstOrDefault(cs => cs.ClassId == cId && cs.StudentId == sId);

            if (classStudent == null)
            {
                return NotFound("Student is not enrolled in this class.");
            }

            // Thêm đánh giá (feedback) cho lớp học
            feedback.ClassId = cId;
            feedback.StudentId = sId;
            feedback.CreatedDate = DateTime.Now;

            _projectContext.Feedbacks.Add(feedback);
            _projectContext.SaveChanges();

            return Ok(feedback);
        }
    }
}
