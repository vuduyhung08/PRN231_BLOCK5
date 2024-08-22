using DBfirst.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentPage()
        {
            return View();
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
                string url = $"{_rootUrl}Students/student/10/classes";
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
