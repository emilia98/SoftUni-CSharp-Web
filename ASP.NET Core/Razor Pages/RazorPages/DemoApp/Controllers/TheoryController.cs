﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class TheoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult Binding()
        {
            return View();
        }

        public IActionResult Filters()
        {
            return View();
        }

        public IActionResult Routing()
        {
            return View();
        }
    }
}