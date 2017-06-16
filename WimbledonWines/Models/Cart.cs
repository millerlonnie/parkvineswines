using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WimbledonWines.Models
{
    public class Cart
    {

        [Key] //set primay key fot recordID
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int WineId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }//auto generate date
        public virtual Wine Wine { get; set; } // allwows inheritance , acts as foreign key accessing data from another model, here we had to access the wine id. NB: the name has to match in the parent class
    }
}