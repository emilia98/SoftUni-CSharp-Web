using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class TheoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XhrRequest()
        {
            return View();
        }
    }
}