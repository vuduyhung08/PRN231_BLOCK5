using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FontEnd.Pages
{
    public class FeedBackModel : PageModel
    {
        private readonly string _rootUrl;

        public FeedBackModel()
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
        [BindProperty]
        public int? Rating { get; set; }
        [BindProperty]
        public string FeedbackText { get; set; } = null!;

        public void OnGet(int studentId, int classId)
        {
            StudentId = studentId;
            ClassId = classId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Rating", Rating.ToString()),
                    new KeyValuePair<string, string>("FeedbackText", FeedbackText)
                });

                string url = $"{_rootUrl}Student/feedback/{StudentId}/{ClassId}";
                HttpResponseMessage response = await httpClient.PostAsync(url, formContent);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Feedback added successfully!";
                    return RedirectToPage(); // Redirect to the same page or a success page
                }
                else
                {
                    ViewData["Error"] = await response.Content.ReadAsStringAsync();
                    return Page();
                }
            }
        }
    }
}
