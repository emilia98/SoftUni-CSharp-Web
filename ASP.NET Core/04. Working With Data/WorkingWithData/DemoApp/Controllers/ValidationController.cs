using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models.InputModels;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class ValidationController : Controller
    {
        private readonly ICityService service;

        public ValidationController(ICityService service)
        {
            this.service = service;
        }

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
            var model = new JobFormInputModel
            {
                University = "SoftUni",
                Cities = this.service.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult JobForm(JobFormInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                input.Cities = this.service.GetAll();
                return this.View(input);
            }

            return Json(input);
        }
    }
}