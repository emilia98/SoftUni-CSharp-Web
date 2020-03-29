using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class FileInputModel
    {
        [Required]
        public NamesInputModel Names { get; set; }

        [Required]
        public IFormFile CV { get; set; }
    }
}
