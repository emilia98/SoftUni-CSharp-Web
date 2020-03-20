using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.VIewModels.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewModel()
        {
            var data = new IndexViewModel
            {
                Message = "ViewModel",
                Year = DateTime.UtcNow.Year
            };

            return View(data);
        }

        public IActionResult ViewDataDemo()
        {
            this.ViewData["Message"] = "ViewData";
            this.ViewData["Year"] = DateTime.UtcNow.Year;
            return View();
        }

        public IActionResult ViewBagDemo()
        {
            this.ViewBag.Message = "ViewBag";
            this.ViewBag.Year = DateTime.UtcNow.Year;
            return View();
        }

        //TODO: Action for comparing values of ViewData and ViewBag (in the given order)
    }
}