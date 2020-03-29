using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class ValidationNamesInputModel
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
