﻿using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models.InputModels
{
    public class NamesInputModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
