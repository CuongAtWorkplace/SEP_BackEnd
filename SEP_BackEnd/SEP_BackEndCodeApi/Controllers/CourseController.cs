﻿using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
