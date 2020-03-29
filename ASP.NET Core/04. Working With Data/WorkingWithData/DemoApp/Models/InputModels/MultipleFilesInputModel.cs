using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class MultipleFilesInputModel
    {
        [Required]
        public NamesInputModel Names { get; set; }

        [Required]
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
