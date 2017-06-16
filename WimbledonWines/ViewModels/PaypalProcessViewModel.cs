using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WimbledonWines.Models
{
    public class PaypalProcessViewModel
    {
        public Order order { get; set; }
        public string Invoice_id { get; set; }
        public List<Cart> lst_cart { get; set; }
        public string paypal_email { get; set; }
        public string language_code { get; set; }
        public string currency_code { get; set; }
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }
}