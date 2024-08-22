using DBfirst.DataAccess;
using DBfirst.Models;
using DBfirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly Project_B5DBContext _context;
        private readonly EmailService _emailService;

        public EvaluationsController(Project_B5DBContext context, EmailService service)
        {
            _context = context;
            _emailService = service;
        }

        [HttpPost("/SendGrade")]
        public async Task<IActionResult> SendGrade()
        {
            List<Student> students = _context.Students
                .Include(s => s.User)
                .Include(s => s.Evaluations)
                .Where(s => s.User.Email != null)
                .ToList();
            foreach (Student student in students){
                await _emailService.SendGradeAsync(student.User.Email, student);
            }
            return Ok("Send grade to all students successfully!");
        }
    }
}
