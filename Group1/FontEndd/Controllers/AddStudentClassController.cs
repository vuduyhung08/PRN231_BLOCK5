    //using FontEndd.Models;
    //using Microsoft.AspNetCore.Mvc;
    //using System.Net.Http;
    //using System.Text;
    //using System.Text.Json;
    //using System.Threading.Tasks;
    //using Microsoft.Extensions.Configuration;

    //namespace FontEndd.Controllers
    //{
    //    public class AddStudentClassController : Controller
    //    {
    //        private readonly string _rootUrl;
    //        [BindProperty]
    //        public int StudentId { get; set; }

    //        [BindProperty]
    //        public int ClassId { get; set; }
    //        public AddStudentClassController(IConfiguration configuration)
    //        {
    //            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
    //        }

    //        [HttpGet]
    //        public async Task<IActionResult> AddStudentClass()
    //        {
    //            using HttpClient httpClient = new HttpClient();

    //            // Fetch students
    //            string studentUrl = $"{_rootUrl}Student";
    //            HttpResponseMessage studentResponse = await httpClient.GetAsync(studentUrl);
    //            List<Student> students = new List<Student>();
    //            if (studentResponse.IsSuccessStatusCode)
    //            {
    //                students = await studentResponse.Content.ReadFromJsonAsync<List<Student>>();
    //            }

    //            // Fetch classes
    //            string classUrl = $"{_rootUrl}Class";
    //            HttpResponseMessage classResponse = await httpClient.GetAsync(classUrl);
    //            List<Class> classes = new List<Class>();
    //            if (classResponse.IsSuccessStatusCode)
    //            {
    //                classes = await classResponse.Content.ReadFromJsonAsync<List<Class>>();
    //            }

    //            // Pass data to the view
    //            ViewBag.Students = students;
    //            ViewBag.Classes = classes;

    //            return View("~/Views/Admin/AddStudentClass.cshtml");
    //        }

    //        [HttpPost]
    //        public async Task<IActionResult> AddStudentClass(int studentId, int classId)
    //        {
    //            var request = new
    //            {
    //                StudentId = this.StudentId,
    //                ClassId = this.ClassId
    //            };

    //            using HttpClient httpClient = new HttpClient();
    //            string url = $"{_rootUrl}Student/AddStudentClass";
    //            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

    //            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);
    //            if (response.IsSuccessStatusCode)
    //            {
    //                ViewBag.ResponseMessage = "Student successfully added to the class.";
    //            }
    //            else
    //            {
    //                ViewBag.ResponseMessage = $"Error: {response.ReasonPhrase}";
    //            }

    //            return await AddStudentClass(); // Re-fetch students and classes for the view
    //        }
    //    }
    //}
