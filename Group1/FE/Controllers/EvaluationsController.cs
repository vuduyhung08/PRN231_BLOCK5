using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DBfirst.Models;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace FE.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5224/api/Evaluations";
        private readonly string _subjectsApiUrl = "http://localhost:5224/api/Subjects"; // Adjust URL as needed

        public EvaluationsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Create()
        {
            // Fetch subjects from API
            var response = await _httpClient.GetAsync(_subjectsApiUrl);
            if (!response.IsSuccessStatusCode)
            {
                // Handle error (e.g., show an error message in the view)
                return View("Error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var subjects = JsonConvert.DeserializeObject<IEnumerable<Subject>>(jsonString);

            var model = new CreateEvaluationDTO
            {
                Subjects = subjects // Populate subjects
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,Grade,SubjectId,StudentId")] CreateEvaluationDTO evaluation)
        {
            if (ModelState.IsValid)
            {
                string jsonSerial = JsonConvert.SerializeObject(evaluation);
                var content = new StringContent(jsonSerial, Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync(_apiUrl, content);

                // Check for success status
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Failed to create evaluation.");
            }

            // Fetch subjects again if model state is invalid
            var response = await _httpClient.GetAsync(_subjectsApiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            var subjects = JsonConvert.DeserializeObject<IEnumerable<Subject>>(jsonString);

            evaluation.Subjects = subjects;
            return View(evaluation);
        }

        public class CreateEvaluationDTO
        {
            public int EvaluationId { get; set; }
            public int Grade { get; set; }
            public int SubjectId { get; set; }
            public int StudentId { get; set; }
            public IEnumerable<Subject> Subjects { get; set; }
        }
    }
}
