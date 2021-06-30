using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Description { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string ReviewTitle { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}