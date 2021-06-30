using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategory_name { get; set; }
        public int MainCategoryId { get; set; }

        
        public virtual ICollection<FinalSubCategory> FinalSubCategories { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
       
        public virtual ICollection<Product> Products { get; set; }
    }
}