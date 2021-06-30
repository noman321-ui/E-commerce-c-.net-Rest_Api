using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderID { get; set; }
        public int ProductHistoryId { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductHistory ProductHistory { get; set; }
       
        public virtual ICollection<Profit> Profits { get; set; }
    }
}