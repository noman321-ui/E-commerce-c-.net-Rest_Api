using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class SaleHistory
    {
        public int SaleHistoryID { get; set; }
        public string Amount { get; set; }
        public System.DateTime StartDate { get; set; }

        
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
    }
}