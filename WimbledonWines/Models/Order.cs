using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WimbledonWines.Models
{
    public partial class Order
    {
        //class to track summary and delivery details of an order
        [Key]
        public int OrderId { get; set; }
         [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Town is required")]
        public string Town { get; set; }
        [Required(ErrorMessage = "PostCode is required")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
          ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; } //reorder order date and time
       // public List<OrderDetail> OrderDetails { get; set; }
       public virtual ICollection<OrderDetail> OrderDetails { get; set;  } //provide a one to many relationship to OrderDetails Class
         
        public bool GiftWrap { get; set; }
         [Required(ErrorMessage = "Confirm age")]
        public bool Over18 { get; set; }
         public string PaymentType { get; set; }   //record payment type
         public bool PaypalStatus { get; set; }    
         public string Paypal_Response { get; set; }

         public string FullName
         {
             get { return FirstName + ", " + LastName; } //full name returns a value from cocatinating two properties and because of get 
                                                        // no FullName column will be generated in database
         }
    }

    //the enumerator list of wine types
    
}