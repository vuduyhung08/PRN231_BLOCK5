using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentPage()
        {
            return View();
        }
    }
}
