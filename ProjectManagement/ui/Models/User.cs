﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]

        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}