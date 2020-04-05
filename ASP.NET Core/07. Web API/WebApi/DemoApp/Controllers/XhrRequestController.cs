using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class XhrRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JsonTest()
        {
            return this.Json(new { FirstName = "Niki", LastName = "Kostov" });
        }

        public IActionResult Xhr()
        {
            return View();
        }

        public IActionResult ParseJson()
        {
            return View();
        }
    }
}