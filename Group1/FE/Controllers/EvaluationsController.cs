using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static DBfirst.Controllers.SubjectsController;
using System.Text;

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
        var model = new CreateEvaluationViewModel
        {
            Subjects = await FetchSubjectsAsync()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Grade,AdditionExplanation,StudentId")] CreateEvaluationViewModel evaluation)
    {
        if (ModelState.IsValid)
        {
            var subject = await FetchSubjectByNameAsync(evaluation.AdditionExplanation);
            var evaluationDto = new EvaluationDto
            {
                Grade = evaluation.Grade,
                AdditionExplanation = evaluation.AdditionExplanation, // Chứa SubjectName
                StudentId = evaluation.StudentId
            };

            string jsonSerial = JsonConvert.SerializeObject(evaluationDto);
            var content = new StringContent(jsonSerial, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(_apiUrl, content);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to create evaluation.");
        }

        evaluation.Subjects = await FetchSubjectsAsync();
        return View(evaluation);
    }

    private async Task<IEnumerable<SubjectDto>> FetchSubjectsAsync()
    {
        var response = await _httpClient.GetAsync(_subjectsApiUrl);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<SubjectDto>>(jsonString);
    }

    private async Task<SubjectDto> FetchSubjectByNameAsync(string subjectName)
    {
        var subjects = await FetchSubjectsAsync();
        return subjects.FirstOrDefault(s => s.SubjectName == subjectName);
    }
}

public class EvaluationDto
{
    public int Grade { get; set; }
    public string AdditionExplanation { get; set; }
    public int StudentId { get; set; }
}

public class SubjectDto
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
}

public class CreateEvaluationViewModel
{
    public int Grade { get; set; }
    public string AdditionExplanation { get; set; } // Đây là SubjectName
    public int StudentId { get; set; }
    public IEnumerable<SubjectDto> Subjects { get; set; } // Danh sách các môn học
}

