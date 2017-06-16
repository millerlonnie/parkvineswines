using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WimbledonWines.Models
{
    public class Winery
    {
          [Key]
        public int Id { get; set; }//geter and set properties 

        [Required] //required field
        [StringLength(30)]
        public string Name { get; set; }


        //enuemarator class providing a list of choices
        public Country Country { get; set; }

        public virtual ICollection<Wine>Wines { get; set; }// Navigation property  ...ICollection is used on many * , eg a list of wines

    }

    //the enumerator list of countries
    public enum Country
    {

        Germany, France, Italy, Poland, India, SouthAfrica, UK, Netheralnds, Belgium, Other
    }


    }
