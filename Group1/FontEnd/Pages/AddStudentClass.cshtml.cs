using FontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FontEnd.Pages
{
    public class AddStudentClassModel : PageModel
    {
        private readonly string _rootUrl;

        public AddStudentClassModel()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _rootUrl = config.GetSection("ApiUrls")["MyApi"];
        }
        [BindProperty]
        public int StudentId { get; set; }

        [BindProperty]
        public int ClassId { get; set; }

        public string? ResponseMessage { get; set; }

        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }

        public async Task OnGetAsync()
        {
            using HttpClient httpClient = new HttpClient();
            string studentUrl = $"{_rootUrl}Student";
            HttpResponseMessage studentResponse = await httpClient.GetAsync(studentUrl);

            string classUrl = $"{_rootUrl}Class";
            HttpResponseMessage classResponse = await httpClient.GetAsync(classUrl);

            if (studentResponse.IsSuccessStatusCode)
            {
                Students = await studentResponse.Content.ReadFromJsonAsync<List<Student>>();
            }
            else
            {
                Students = new List<Student>();
            }

            if (classResponse.IsSuccessStatusCode)
            {
                Classes = await classResponse.Content.ReadFromJsonAsync<List<Class>>();
            }
            else
            {
                Classes = new List<Class>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var request = new
            {
                StudentId = this.StudentId,
                ClassId = this.ClassId
            };
            //var jsonRequest = JsonSerializer.Serialize(request);
            //var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            //using var httpClient = new HttpClient();
            //var response = await httpClient.PostAsync("http://localhost:5224/api/Student/AddStudentClass", content);
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Student/AddStudentClass";
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                ResponseMessage = "Student successfully added to the class.";
            }
            else
            {
                ResponseMessage = $"Error: {response.ReasonPhrase}";
            }

            return Page();
        }
    }
}
