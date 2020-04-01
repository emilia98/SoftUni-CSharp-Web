using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DemoApp.CloudinaryHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class CloudinaryController : Controller
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryController(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"C:\dev\cat.jpeg")
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return this.Redirect("/");
        }

        public IActionResult UploadForm()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadForm(ICollection<IFormFile> files)
        {
            var result = await CloudinaryExtension.UploadAsync(this.cloudinary, files);

            this.ViewData["Links"] = result;

            return this.View();
        }
    }
}