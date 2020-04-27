using System;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        [Required]
        [MinLength(30)]
        [StringLength(800)]
        public string Code { get; set; }

        [Required]
        [Range(0, 300)]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}