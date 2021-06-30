using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class ProductSizeHistory
    {
        public int ProductSizeHistoryID { get; set; }
        public string SizeName { get; set; }
        public int ProductHistoryId { get; set; }
        public int Count { get; set; }

        public virtual ProductHistory ProductHistory { get; set; }
    }
}