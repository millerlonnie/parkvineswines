using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 


namespace WimbledonWines.Models
{
    public class GoogleLocation
    {
        [Key]
        public int LocationID { get; set; }
         [Required]
        public string Title { get; set; }
         [Required]
        public string Lat { get; set; }
         [Required]
        public string Long { get; set; }
         [Required]
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}