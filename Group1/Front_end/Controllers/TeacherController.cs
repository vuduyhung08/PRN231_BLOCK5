﻿using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
