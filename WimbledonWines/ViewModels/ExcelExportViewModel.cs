using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WimbledonWines.Models;

namespace WimbledonWines.ViewModels
{
    public class ExcelExportViewModel
    {

        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }

        public int Quantity { get; set; }
        public int WineId { get; set; }
        public decimal UnitPrice { get; set; }
        public System.DateTime OrderDate { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

        public virtual Order Order { get; set; }
        public virtual Wine Wine { get; set; }


    }
}