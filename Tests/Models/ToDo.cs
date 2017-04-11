using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tests.Models
{
    public class ToDo
    {
        [Display(Name = "Task Number")]
        [Required(ErrorMessage = "Name is required field")]

        public string TaskNumber { get; set; }

        [Display(Name = "Description of Task")]
        [Required(ErrorMessage = "Description is required field")]
       

        public string TaskDescription { get; set; }

    }
}