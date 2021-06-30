using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class ProductSize
    {
        public int ProductSizeID { get; set; }
        public string SizeName { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }

        public virtual Product Product { get; set; }
    }
}