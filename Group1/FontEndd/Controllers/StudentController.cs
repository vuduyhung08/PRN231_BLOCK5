using FontEndd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text;

namespace FontEnd.Controllers
{
    public class StudentController : Controller
    {
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
                string url = $"{_rootUrl}Student/student/11/classes";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    var root = doc.RootElement;
                    if (root.TryGetProperty("$values", out var valuesArray))
                    {
                        foreach (var item in valuesArray.EnumerateArray())
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
            }
            return View(classes);
        }

        
    }
}
