using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class UserProject
    {
        public Repository.User User { get; set; }

        public Repository.Project Project { get; set; }

        [Display(Name="Status")]
        public Boolean isActive {get;set;}

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime AssignedDate  { get; set; }

    }
}