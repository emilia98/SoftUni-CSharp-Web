using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class ValidationInputModel
    {
        public int Id { get; set; }

        [Required]
        public ValidationNamesInputModel Names { get; set; }

        public int[] Years { get; set; }
    }
}
