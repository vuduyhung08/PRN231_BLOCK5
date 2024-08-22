using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class MinhAdminController : Controller
    {
        public IActionResult ManageActiveStatus()
        {
            return View();
        }
    }
}
