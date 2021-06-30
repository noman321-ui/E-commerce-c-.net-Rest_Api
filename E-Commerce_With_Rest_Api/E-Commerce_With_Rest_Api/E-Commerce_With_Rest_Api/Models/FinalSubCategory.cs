using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class FinalSubCategory
    {
        public int FinalSubCategoryId { get; set; }
        public string FinalSubCate_name { get; set; }
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCatetory { get; set; }
      
        public virtual ICollection<ProductHistory> ProductHistories { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}