using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIntroMVC.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Json(string username)
        {
            if(!String.IsNullOrEmpty(username)) 
            {
                return this.Json(new { Username = username });
            }

            return this.View();
        }

        public IActionResult PhysicalFile()
        {
            string path = @"C:\Users\Emilia\Desktop\bulgaria_flag.png";
            return this.PhysicalFile(path, "image/png");
        }

        public IActionResult Redirect()
        {
            return this.RedirectToAction("Home", "Home");
        }
    }
}
