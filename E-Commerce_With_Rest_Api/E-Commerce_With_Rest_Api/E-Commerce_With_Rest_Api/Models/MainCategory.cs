using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class MainCategory
    {
        public int MainCategoryId { get; set; }
        public string Category_name { get; set; }

        
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        
        public virtual ICollection<SubCategory> SubCatetories { get; set; }
    }
}