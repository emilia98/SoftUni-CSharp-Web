using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class JobFormInputModel
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
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Невалидно ЕГН!")]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Experience")]
        [Range(1, int.MaxValue)]
        public int YearsOfExperience { get; set; }

        [Display(Name = "Candidate Type")]
        public CandidateType CandidateType { get; set; }
    }

    public enum CandidateType
    {
        JuniorDeveloper = 1,
        RegularDeveloper = 2,
        SeniorDeveloper = 3,
        JuniorQA = 4
    }
}
