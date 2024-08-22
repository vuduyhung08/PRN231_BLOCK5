using DBfirst.Data.DTOs;
using DBfirst.Models;
using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
<<<<<<< HEAD
=======
using System.Net.Http.Headers;
>>>>>>> Khang
using System.Text;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var jwtToken = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("hiUAHSDUIOHIAOHUIOhihaiosdhf8uh29873yh9dsahfjkasldnf28937rhjasknfasdu9fh908ujnfkdlsanf81237949yhHNFAKJDNF0849HTFNL");
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken2 = (JwtSecurityToken)validatedToken;
                var userRole = jwtToken2.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole != "Adminstrator")
                {
                    return Unauthorized();
                }

                return View();
            }
            catch
            {
                return Unauthorized();
            }
        }

        public IActionResult ManageActiveStatus()
        {
            var jwtToken = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("hiUAHSDUIOHIAOHUIOhihaiosdhf8uh29873yh9dsahfjkasldnf28937rhjasknfasdu9fh908ujnfkdlsanf81237949yhHNFAKJDNF0849HTFNL");
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken2 = (JwtSecurityToken)validatedToken;
                var userRole = jwtToken2.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole != "Adminstrator")
                {
                    return Unauthorized();
                }

                return View();
            }
            catch
            {
                return Unauthorized();
            }
        }

        public IActionResult ManageStudent()
        {
            var jwtToken = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("hiUAHSDUIOHIAOHUIOhihaiosdhf8uh29873yh9dsahfjkasldnf28937rhjasknfasdu9fh908ujnfkdlsanf81237949yhHNFAKJDNF0849HTFNL");
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken2 = (JwtSecurityToken)validatedToken;
                var userRole = jwtToken2.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole != "Adminstrator")
                {
                    return Unauthorized();
                }

                return View();
            }
            catch
            {
                return Unauthorized();
            }
        }
        public IActionResult Index()
        {
            var jwtToken = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("hiUAHSDUIOHIAOHUIOhihaiosdhf8uh29873yh9dsahfjkasldnf28937rhjasknfasdu9fh908ujnfkdlsanf81237949yhHNFAKJDNF0849HTFNL");
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken2 = (JwtSecurityToken)validatedToken;
                var userRole = jwtToken2.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                if (userRole != "Adminstrator")
                {
                    return Unauthorized();
                }

                return View();
            }
            catch
            {
                return Unauthorized();
            }
        }
        private readonly string _rootUrl;
<<<<<<< HEAD

        public AdminController(IConfiguration configuration)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
        }


        // GET: /Admin/Class
=======
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _rootUrl = configuration.GetSection("ApiUrls")["MyApi"];
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetTokenFromCookie()
        {
            // Get the JWT token from the cookie
            return _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];
        }

        //Admin/Class
>>>>>>> Khang
        [HttpGet]
        public async Task<IActionResult> Class()
        {
            List<ClassDTO> classes = new List<ClassDTO>();

            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
<<<<<<< HEAD
=======

            string token = GetTokenFromCookie();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

>>>>>>> Khang
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                classes = await response.Content.ReadFromJsonAsync<List<ClassDTO>>();
            }

            ViewBag.Classes = classes;
            return View();
        }

<<<<<<< HEAD
        // POST: /Admin/Class
=======
        //Admin/Class
>>>>>>> Khang
        [HttpPost]
        public async Task<IActionResult> Class(Class newClass)
        {
            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Class";
            var jsonContent = new StringContent(JsonSerializer.Serialize(newClass), Encoding.UTF8, "application/json");

<<<<<<< HEAD
=======
            string token = GetTokenFromCookie();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

>>>>>>> Khang
            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Class");
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"An error occurred: {errorContent}");

                // Reload classes to ensure the data is up to date
                return await Class();
            }
        }

<<<<<<< HEAD
        // GET: /Admin/AddStudentClass
=======
        //Admin/AddStudentClass
>>>>>>> Khang
        [HttpGet]
        public async Task<IActionResult> AddStudentClass()
        {
            using HttpClient httpClient = new HttpClient();

<<<<<<< HEAD
            // Fetch students
            string studentUrl = $"{_rootUrl}Students";
=======
            string studentUrl = $"{_rootUrl}Students";
            string token = GetTokenFromCookie();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
>>>>>>> Khang
            HttpResponseMessage studentResponse = await httpClient.GetAsync(studentUrl);
            List<Student> students = new List<Student>();
            if (studentResponse.IsSuccessStatusCode)
            {
                students = await studentResponse.Content.ReadFromJsonAsync<List<Student>>();
            }

            // Fetch classes
            string classUrl = $"{_rootUrl}Class";
            HttpResponseMessage classResponse = await httpClient.GetAsync(classUrl);
            List<Class> classes = new List<Class>();
            if (classResponse.IsSuccessStatusCode)
            {
                classes = await classResponse.Content.ReadFromJsonAsync<List<Class>>();
            }

            // Pass data to the view
            ViewBag.Students = students;
            ViewBag.Classes = classes;

            return View();
        }

<<<<<<< HEAD
        // POST: /Admin/AddStudentClass
=======
        //Admin/AddStudentClass
>>>>>>> Khang
        [HttpPost]
        public async Task<IActionResult> AddStudentClass(int studentId, int classId)
        {
            var request = new
            {
                StudentId = studentId,
                ClassId = classId
            };

            using HttpClient httpClient = new HttpClient();
            string url = $"{_rootUrl}Students/AddStudentClass";
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

<<<<<<< HEAD
=======
            string token = GetTokenFromCookie();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

>>>>>>> Khang
            HttpResponseMessage response = await httpClient.PostAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.ResponseMessage = "Student successfully added to the class.";
            }
            else
            {
                ViewBag.ResponseMessage = $"Error: {response.ReasonPhrase}";
            }

<<<<<<< HEAD
            return await AddStudentClass(); // Re-fetch students and classes for the view
=======
            return await AddStudentClass();
>>>>>>> Khang
        }
    }
}
