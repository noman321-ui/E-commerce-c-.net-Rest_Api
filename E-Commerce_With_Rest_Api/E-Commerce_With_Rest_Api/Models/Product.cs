using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int MainCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageFile { get; set; }
        public decimal Cost { get; set; }
        public Nullable<int> SaleID { get; set; }
        public Nullable<int> FinalSubCategoryID { get; set; }
        public string Product_name { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public string SizeCategory { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<int> OnHand { get; set; }

        public virtual FinalSubCategory FinalSubCategory { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual SubCategory SubCatetory { get; set; }
       
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
       
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TempOrderProduct> TempOrderProducts { get; set; }
    }
}