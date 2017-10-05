using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROS.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Food Taste")]
        public string rating { get; set; }
        [Display(Name = "Speaking and Communication skills")]
        public string communication { get; set; }
        [Display(Name = "Interiors")]
        public string Interiors { get; set; }
        [Display(Name = "Service in Time")]
        public string syllabus { get; set; }
        [Display(Name = "Clean and Neatness")]
        public string extraactivities { get; set; }
    }
}