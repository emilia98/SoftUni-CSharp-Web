using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Simple(int id)
        {
            var data = new Dictionary<string, int>();
            data.Add("Id", id);
            return Json(data); ;
        }

        public IActionResult InputModel([FromQuery] TestInputModel input)
        {
            return Json(input);
        }

        public IActionResult InnerInputModel([FromQuery] OuterInputModel input, [FromHeader] string accept)
        {

            return Json(new { input, accept});
        }
    }
}