using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WimbledonWines.Models;

namespace WimbledonWines.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Title { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}