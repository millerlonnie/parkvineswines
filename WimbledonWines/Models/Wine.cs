using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 


namespace WimbledonWines.Models
{
    public class Wine
    {
         //primary key automatically incremented
        [Key]
        public int Id { get; set; } //getter and setter properties

        [Required] //paramter cannot be a null value
        [StringLength(25, ErrorMessage = "Name must be shorter than 25 characters")]
        public string WineName { get; set; }

        [Range(10,200)] //allows to set minimum and maximum price/ values
        [DisplayFormat(DataFormatString = "{0:c}")] //displaying price in £ pounds format
        public decimal Price { get; set; }

        [Range(2000,2015)]// minimum and maximum year
        public int YearOfBottling { get; set; }

       [Range(0.08,0.22, ErrorMessage ="Alcholpercentage must be between 0.08 and 0.22 decimal")]
       [DisplayFormat(DataFormatString = "{0:P}")]
        public double AlcoholPercentage { get; set; }

         [Required] 
        public string ImagePath { get; set; }

        [DataType(DataType.MultilineText)] //generates a text area 
        public string Description { get; set; }

        public WineType WineType { get; set; } //object of class wine type

        
       
        
        [Display(Name ="Winery Name")] //being user friendly: displaying Winery instead of WineryID
        public string WineryName { get; set; }
        
        //setting a 1-* relationshio between the Wine and winery
       // public virtual Winery Winery { get; set; }// its a foreign key from winery > uses public virtual  Winery, references winery id pk



       
        
       // winery foreign key.
      public virtual   Winery  Winery { get; set; }
        
    } //////////////////////

    //the enumerator list of wine types
    public enum WineType 
    {

        Red, White, Rose, Sparkling, Champagne, FineWine, Fortifed, Other
    }

    }///////////////////////////////////////////////
