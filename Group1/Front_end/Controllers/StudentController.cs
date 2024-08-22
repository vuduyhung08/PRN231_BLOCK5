using DBfirst.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult StudentPage()
        {
            var jwtToken = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized(); 
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("hiUAHSDUIOHIAOHUIOhihaiosdhf8uh29873yh9dsahfjkasldnf28937rhjasknfasdu9fh908ujnfkdlsanf81237949yhHNFAKJDNF0849HTFNL");
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken2 = (JwtSecurityToken)validatedToken;
                var userRole = jwtToken2.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole != "Student") 
                {
                    return Unauthorized(); 
                }

                return View();
            }
            catch
            {
                return Unauthorized(); 
            }
        }

        private readonly string _rootUrl;

        public StudentController(IConfiguration configuration)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
        }

        public async Task<IActionResult> Student(int studentId)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{_rootUrl}Students/student/1002/classes";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    foreach (var item in doc.RootElement.EnumerateArray())
                    {
                        classes.Add(new ClassDTO
                        {
                            ClassId = item.GetProperty("classId").GetInt32(),
                            ClassName = item.GetProperty("className").GetString(),
                            TeacherId = item.GetProperty("teacherId").GetInt32(),
                            SubjectId = item.GetProperty("subjectId").GetInt32()
                        });
                    }
                }
            }
            return View(classes);
        }


        [HttpGet]
        public IActionResult FeedBack(int studentId, int classId)
        {
            ViewBag.StudentId = studentId;
            ViewBag.ClassId = classId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FeedBack(int studentId, int classId, int? rating, string feedbackText)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Rating", rating.ToString()),
                    new KeyValuePair<string, string>("FeedbackText", feedbackText)
                });

                string url = $"{_rootUrl}Students/feedback/{studentId}/{classId}";
                HttpResponseMessage response = await httpClient.PostAsync(url, formContent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Feedback added successfully!";
                    return RedirectToAction("Student", new { studentId = studentId }); // Redirect to the student's classes page
                }
                else
                {
                    TempData["Error"] = await response.Content.ReadAsStringAsync();
                    return View("~/Views/Student/FeedBack.cshtml");
                }
            }
        }
    }
}
