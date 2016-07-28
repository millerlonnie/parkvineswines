using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WimbledonWines.Models
{
    public class OrderDetail
    {

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int WineId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } //enumerator 
          
        public virtual Order Order { get; set; } //foreign key relationship

       //public virtual ICollection<Wine> Wines { get; set; } //an order may contain many wines
        public virtual Wine Wine { get; set; }//eneables us to aceess all wine details sucah as wine name to be desiplayed isntead of wine id
         
    }

    public enum OrderStatus
    {
        Select_Option, Shipped, Payment_Error, Delivered, On_BackOrder, Cancelled, Open, Other
    }
}