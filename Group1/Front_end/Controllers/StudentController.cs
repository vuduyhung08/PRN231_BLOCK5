using DBfirst.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
<<<<<<< HEAD
=======
using System.Net.Http.Headers;
>>>>>>> Khang
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
<<<<<<< HEAD

        public StudentController(IConfiguration configuration)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
=======
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetTokenFromCookie()
        {
            // Get the JWT token from the cookie
            return _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];
>>>>>>> Khang
        }

        public async Task<IActionResult> Student(int studentId)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            using (HttpClient httpClient = new HttpClient())
            {
<<<<<<< HEAD
                string url = $"{_rootUrl}Students/student/1002/classes";
=======
                string url = $"{_rootUrl}Students/student/{studentId}/classes";
                string token = GetTokenFromCookie();
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
>>>>>>> Khang
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
<<<<<<< HEAD
=======

            ViewBag.StudentId = studentId;
>>>>>>> Khang
            return View(classes);
        }


<<<<<<< HEAD
=======


>>>>>>> Khang
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
<<<<<<< HEAD
=======
                string token = GetTokenFromCookie();
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
>>>>>>> Khang
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
