using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.ViewModels.Data;
using DemoApp.ViewModels.Demo;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewsCapabilities()
        {
            this.ViewData["Path"] = this.HttpContext.Request.Path;
            this.HttpContext.Response.Cookies.Append("My-Cookie", "Some value");
            return View();
        }

        public IActionResult ViewModelIEnumerable()
        {
            IEnumerable<string> names = new List<string> { "Niki", "Stoyan" };
            return View(names);
        }

        public IActionResult ViewModelClass()
        {
            var model = new IndexViewModel()
            {
                Message = "Hello World!",
                Year = DateTime.UtcNow.Year,
                Names = new List<string> { "Niki", "Stoyan" }
            };

            return View("ViewModelClass", model);
        }

        public IActionResult ShowViewAnotherFolder()
        {
            return View("~/Views/Data/Diff.cshtml");
        }

        public IActionResult HtmlRaw()
        {
            var model = new IndexViewModel()
            {
                Message = "<strong>Hello</strong>",
                Year = DateTime.UtcNow.Year,
                Description = "<script>alert('hacked')</script>"
            };

            return View(model);
        }

        public IActionResult Hacks()
        {
            DemoViewModel model = new DemoViewModel
            {
                Year = DateTime.UtcNow.Year,
                Products = new List<string>()
            };

            if(DateTime.UtcNow.Minute % 2 == 0)
            {
                model.Products = new List<string>
                {
                    "Eggs", "Milk", "Cucumbers"
                };
            };
   
            return View(model);
        }

        public IActionResult Directives()
        {
            IndexViewModel model = new IndexViewModel
            {
                Names = new List<string>
                {
                    "niki", "stoyan"
                }
            };

            return View(model);
        }

        public IActionResult ChangeLayout()
        {
            return View();
        }

        public IActionResult SpecialFiles()
        {
            return View();
        }

        public IActionResult Comments()
        {
            return View();
        }
    }
}