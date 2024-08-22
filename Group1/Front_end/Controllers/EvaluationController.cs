using DBfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_end.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5224/api/Evaluations";
        private readonly string _subjectsApiUrl = "http://localhost:5224/api/Subjects/viewallsubject";
        private readonly string _studentsApiUrl = "http://localhost:5224/api/Students";

        public EvaluationController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var evaluations = JsonConvert.DeserializeObject<IEnumerable<EvaluationDTO>>(jsonString);

            return View(evaluations);
        }


        // GET: Evaluations/Create
        public async Task<IActionResult> Create()
        {
            var subjects = await FetchSubjectsAsync();
            var students = await FetchStudentsAsync();

            if (subjects == null || !subjects.Any() || students == null || !students.Any())
            {
                return View("Error"); // Hoặc xử lý lỗi theo cách khác
            }

            var model = new CreateEditEvaluationDTO
            {
                Subjects = subjects,
                Students = students
            };

            return View(model);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var evaluation = JsonConvert.DeserializeObject<EvaluationDTO>(jsonString);

            var subjects = await FetchSubjectsAsync();
            var students = await FetchStudentsAsync();

            if (evaluation == null || subjects == null || students == null)
            {
                return View("Error");
            }

            var model = new CreateEditEvaluationDTO
            {
                Grade = evaluation.Grade,
                AdditionExplanation = evaluation.AdditionExplanation, // SubjectName used as AdditionExplanation
                StudentId = evaluation.StudentId,
                Subjects = subjects,
                Students = students
            };

            return View(model);
        }

        // Method to fetch subjects
        private async Task<IEnumerable<Subject>> FetchSubjectsAsync()
        {
            var response = await _httpClient.GetAsync(_subjectsApiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new List<Subject>(); // Return empty list if request fails
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Subject>>(jsonString);
        }

        // Method to fetch students
        private async Task<IEnumerable<Student>> FetchStudentsAsync()
        {
            var response = await _httpClient.GetAsync(_studentsApiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new List<Student>(); // Return empty list if request fails
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Student>>(jsonString);
        }
    }

    // DTO for Index view
    public class EvaluationDTO
    {
        public int EvaluationId { get; set; }
        public int Grade { get; set; }
        public string AdditionExplanation { get; set; } // SubjectName
        public string SubjectName { get; set; } // Will hold the same value as AdditionExplanation
        public string StudentName { get; set; }
        public int StudentId { get; set; }
    }

    // DTO for Create and Edit views
    public class CreateEditEvaluationDTO
    {
        public int Grade { get; set; }
        public string AdditionExplanation { get; set; } // SubjectName
        public int StudentId { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
