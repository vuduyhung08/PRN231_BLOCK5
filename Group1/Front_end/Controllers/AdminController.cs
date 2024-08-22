using DBfirst.Data.DTOs;
using DBfirst.Models;
using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageActiveStatus()
        {
            return View();
        }

        public IActionResult ManageStudent()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        private readonly string _rootUrl;

        public AdminController(IConfiguration configuration)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
        }

        // GET: /Admin
        public IActionResult Admin()
        {
            return View();
        }

        // GET: /Admin/Class
        [HttpGet]
        public async Task<IActionResult> Class()
        {
            List<ClassDTO> classes = new List<ClassDTO>();

            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                classes = await response.Content.ReadFromJsonAsync<List<ClassDTO>>();
            }

            ViewBag.Classes = classes;
            return View();
        }

        // POST: /Admin/Class
        [HttpPost]
        public async Task<IActionResult> Class(Class newClass)
        {
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
            var jsonContent = new StringContent(JsonSerializer.Serialize(newClass), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Class");
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"An error occurred: {errorContent}");

                // Reload classes to ensure the data is up to date
                return await Class();
            }
        }

        // GET: /Admin/AddStudentClass
        [HttpGet]
        public async Task<IActionResult> AddStudentClass()
        {
            using HttpClient httpClient = new HttpClient();

            // Fetch students
            string studentUrl = $"{_rootUrl}Students";
            HttpResponseMessage studentResponse = await httpClient.GetAsync(studentUrl);
            List<Student> students = new List<Student>();
            if (studentResponse.IsSuccessStatusCode)
            {
                students = await studentResponse.Content.ReadFromJsonAsync<List<Student>>();
            }

            // Fetch classes
            string classUrl = $"{_rootUrl}Class";
            HttpResponseMessage classResponse = await httpClient.GetAsync(classUrl);
            List<Class> classes = new List<Class>();
            if (classResponse.IsSuccessStatusCode)
            {
                classes = await classResponse.Content.ReadFromJsonAsync<List<Class>>();
            }

            // Pass data to the view
            ViewBag.Students = students;
            ViewBag.Classes = classes;

            return View();
        }

        // POST: /Admin/AddStudentClass
        [HttpPost]
        public async Task<IActionResult> AddStudentClass(int studentId, int classId)
        {
            var request = new
            {
                StudentId = studentId,
                ClassId = classId
            };

            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Students/AddStudentClass";
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.ResponseMessage = "Student successfully added to the class.";
            }
            else
            {
                ViewBag.ResponseMessage = $"Error: {response.ReasonPhrase}";
            }

            return await AddStudentClass(); // Re-fetch students and classes for the view
        }
    }
}
