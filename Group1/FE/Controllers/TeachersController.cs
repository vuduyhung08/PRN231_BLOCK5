using Microsoft.AspNetCore.Mvc;

namespace FE.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
