using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public System.DateTime date { get; set; }
        public decimal totalAmount { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string PayMentMethod { get; set; }

        
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}