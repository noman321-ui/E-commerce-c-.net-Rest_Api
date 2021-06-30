using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public string Amount { get; set; }
        public System.DateTime StartDate { get; set; }

        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
       
        public virtual ICollection<Product> Products { get; set; }
    }
}