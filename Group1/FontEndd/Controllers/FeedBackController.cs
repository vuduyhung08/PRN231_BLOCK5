using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FontEnd.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly string _rootUrl;

        public FeedBackController(IConfiguration configuration)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
        }

        [HttpGet]
        public IActionResult FeedBack(int studentId, int classId)
        {
            ViewBag.StudentId = studentId;
            ViewBag.ClassId = classId;
            return View("~/Views/Student/FeedBack.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> FeedBack(int studentId, int classId, int? rating, string feedbackText)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Student/FeedBack.cshtml");
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Rating", rating.ToString()),
                    new KeyValuePair<string, string>("FeedbackText", feedbackText)
                });

                string url = $"{_rootUrl}Student/feedback/{studentId}/{classId}";
                HttpResponseMessage response = await httpClient.PostAsync(url, formContent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Feedback added successfully!";
                    return RedirectToAction("Index", "Student"); // Adjust this to your success page or desired action
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
