using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        // Removed this validations, because of hashing the password
        // [MinLength(6)]
        // [StringLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}