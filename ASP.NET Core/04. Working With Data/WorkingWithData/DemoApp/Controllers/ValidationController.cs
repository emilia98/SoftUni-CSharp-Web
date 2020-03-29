using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelValidation(ValidationInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return Json(this.ModelState);
            }

            return Json(input);
        }

        public IActionResult InnerModelValidation(ValidationNamesInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return Json(this.ModelState);
            }

            return Json(input);
        }

        public IActionResult JobForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JobForm(JobFormInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return Json(input);
        }
    }
}