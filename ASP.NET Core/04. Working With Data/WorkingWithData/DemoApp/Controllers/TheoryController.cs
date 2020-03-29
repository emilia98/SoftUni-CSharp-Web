using System;
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

        public IActionResult ModelBinding()
        {
            return View();
        }

        public IActionResult CustomModelBinder()
        {
            return View();
        }

        public IActionResult Validation()
        {
            return View();
        }

        public IActionResult CustomValidation()
        {
            return View();
        }

        public IActionResult Files()
        {
            return View();
        }
    }
}