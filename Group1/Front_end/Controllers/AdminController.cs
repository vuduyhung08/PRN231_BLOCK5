using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageActiveStatus()
        {
            return View();
        }
        public IActionResult ManageStudent()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
