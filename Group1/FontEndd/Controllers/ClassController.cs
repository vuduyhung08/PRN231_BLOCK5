//using FontEndd.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace FontEndd.Controllers
//{
//    public class ClassController : Controller
//    {
//        private readonly string _rootUrl;

//        public ClassController()
//        {
//            var config = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json")
//                .Build();
//            _rootUrl = config.GetSection("ApiUrls")["MyApi"];
//        }

//        [HttpGet]
//        public async Task<IActionResult> Class()
//        {
//            List<ClassDTO> classes = new List<ClassDTO>();

//            using HttpClient httpClient = new HttpClient();
//            string url = $"{_rootUrl}Class";
//            HttpResponseMessage response = await httpClient.GetAsync(url);
//            if (response.IsSuccessStatusCode)
//            {
//                classes = await response.Content.ReadFromJsonAsync<List<ClassDTO>>();
//            }

//            ViewBag.Classes = classes;
//            return View("~/Views/Admin/Class.cshtml");
//        }

//        [HttpPost]
//        public async Task<IActionResult> Class(Class newClass)
//        {
//            using HttpClient httpClient = new HttpClient();
//            string url = $"{_rootUrl}Class";
//            var jsonContent = new StringContent(JsonSerializer.Serialize(newClass), Encoding.UTF8, "application/json");

//            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);

//            if (response.IsSuccessStatusCode)
//            {
//                return RedirectToAction("Class");
//            }
//            else
//            {
//                string errorContent = await response.Content.ReadAsStringAsync();
//                ModelState.AddModelError(string.Empty, $"An error occurred: {errorContent}");

//                // Reload classes to ensure the data is up to date
//                return await Class();
//            }
//        }
//    }
//}
