using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROS.Models
{
    public class RestaurantTable
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Number of the table")]
        [RegularExpression(@"[A-Za-z0-9]{4,}")]
        [Display(Name = "Restaurant Table Number")]
        public string Name { get; set; }
        [ForeignKey("restaurant")]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant restaurant { get; set; } 
    }
}