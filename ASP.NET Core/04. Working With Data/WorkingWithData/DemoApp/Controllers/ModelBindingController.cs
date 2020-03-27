using System.Collections.Generic;
using DemoApp.Models.InputModels;
using DemoApp.Services;
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

        public IActionResult FromServiceAttribute([FromServices]IYearsService years)
        {
            return Json(years.GetLastYears(5));
        }

        // Parameter tampering
        public IActionResult Bind([Bind("Names")]OuterInputModel input)
        {
            return Json(input);
        }

        public IActionResult CustomModelBinder(CustomModelBinderInputModel input)
        {
            return Json(input);
        }

        public IActionResult CustomModelBinderProvider(CustomModelBinderInputModel input)
        {
            return Json(input);
        }
    }
}