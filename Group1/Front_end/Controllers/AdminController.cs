using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
