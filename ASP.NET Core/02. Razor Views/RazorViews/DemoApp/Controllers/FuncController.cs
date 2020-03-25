using System;
using DemoApp.ViewModels.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class FuncController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Section()
        {
            return View();
        }

        public IActionResult HtmlHelpers()
        {
            IndexViewModel model = new IndexViewModel
            {
                Message = "Hello!",
                Year = DateTime.UtcNow.Year
            };
            return View(model);
        }

        public IActionResult TagHelpers()
        {
            IndexViewModel model = new IndexViewModel
            {
                Message = "Hello!",
                Year = DateTime.UtcNow.Year
            };
            return View(model);
        }

        public IActionResult CustomTagHelper()
        {
            return View();
        }

        public IActionResult PartialViews()
        {
            ViewData["Demo"] = "Here";
            return View();
        }

        public IActionResult ViewComponents()
        {
            return View();
        }
    }
}