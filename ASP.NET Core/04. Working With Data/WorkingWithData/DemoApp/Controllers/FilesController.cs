using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(FileInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return View(input);
            }

            using(var fileStream = new FileStream(@"C:\dev\file.pdf", FileMode.Create))
            {
                await input.CV.CopyToAsync(fileStream);
            }

            return this.Redirect("/");
        }

        public IActionResult UploadMultipleFiles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadMultipleFiles(MultipleFilesInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var expectedExtensions = new[] { ".pdf", ".doc", ".docx" };
            var files = input.Files.Where(f => f.Length > 0);

            foreach(var file in files)
            {
                if (expectedExtensions.Any(x => file.FileName.EndsWith(x)))
                {
                    using (var fileStream = new FileStream(@"C:\dev\" + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            return this.Redirect("/");
        }

        public IActionResult Download()
        {
            // Download(string fileName)
            // POTENTIALLY DANGEROUS -> escape the fileName (remove '.', '\', etc)
            return this.PhysicalFile(@$"C:\dev\file.pdf", "application/pdf");
        }
    }
}