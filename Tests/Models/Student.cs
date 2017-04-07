using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tests.Models
{
    
        public class Student
        {


        [Display(Name="Name of Student")]
        [Required(ErrorMessage = "Name is required field")]
       
        public string StudentName { get; set; }

        [Display(Name = "Roll Number")]
        [Required(ErrorMessage ="Roll Number is required field")]
        [StringLength(16, ErrorMessage = "The {0} must be at least {1} characters long.", MinimumLength = 3)]
       
        public string StudentRoll { get; set; }

        


        }
   
}