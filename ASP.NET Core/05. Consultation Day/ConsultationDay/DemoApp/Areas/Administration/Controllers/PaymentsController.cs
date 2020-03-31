using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
