using DemoApp.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class JobFormInputModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public NamesInputModel Names { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [EGNValidation]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Experience")]
        [Range(1, int.MaxValue)]
        public int YearsOfExperience { get; set; }

        [Required]
        [Display(Name = "Candidate Type")]
        public CandidateType CandidateType { get; set; }

        [Required]
        [Display(Name = "Cities")]
        public int City { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(int.Parse(this.Egn.Substring(0, 2)) != this.DateOfBirth.Year % 100)
            {
                yield return new ValidationResult("Годината на раждане и ЕГН-то не са валидна комбинация!");
            }
        }
    }
}
