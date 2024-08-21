using FontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace FontEnd.Pages
{
    public class StudentModel : PageModel
    {
        private readonly string _rootUrl;

        public StudentModel()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _rootUrl = config.GetSection("ApiUrls")["MyApi"];
        }

        public List<ClassDTO> Classes { get; set; }

        public async Task OnGetAsync(int studentId)
        {
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Student/student/11/classes";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("$values", out var valuesArray))
                {
                    Classes = new List<ClassDTO>();
                    foreach (var item in valuesArray.EnumerateArray())
                    {
                        Classes.Add(new ClassDTO
                        {
                            ClassId = item.GetProperty("classId").GetInt32(),
                            ClassName = item.GetProperty("className").GetString(),
                            TeacherId = item.GetProperty("teacherId").GetInt32(),
                            SubjectId = item.GetProperty("subjectId").GetInt32()
                        });
                    }
                }
                else
                {
                    Classes = new List<ClassDTO>();
                }
            }
        }
    }
}
