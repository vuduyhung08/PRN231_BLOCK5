using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FontEnd.Models;

namespace FontEnd.Pages
{
    public class ClassModel : PageModel
    {
        private readonly string _rootUrl;

        public ClassModel()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _rootUrl = config.GetSection("ApiUrls")["MyApi"];
        }

        [BindProperty]
        public Class NewClass { get; set; } = new Class();
        public List<ClassDTO> Classes { get; set; }

        public async Task OnGetAsync()
        {
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Classes = await response.Content.ReadFromJsonAsync<List<ClassDTO>>();
            }
            else
            {
                Classes = new List<ClassDTO>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
            var jsonContent = new StringContent(JsonSerializer.Serialize(NewClass), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                // Reload the classes after successful post
                await OnGetAsync();
                return Page(); // Reload the same page to show updated data
            }
            else
            {
                // Read the response content to get error details
                string errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"An error occurred: {errorContent}");

                // Reload the classes to ensure the data is up to date
                await OnGetAsync();
                return Page();
            }
        }

    }
}
