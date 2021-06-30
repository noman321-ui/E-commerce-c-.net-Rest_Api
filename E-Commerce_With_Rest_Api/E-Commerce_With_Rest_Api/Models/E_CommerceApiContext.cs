using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class E_CommerceApiContext:DbContext
    {
        public E_CommerceApiContext():base("name=E_CommerceApiContext")
        {

        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FinalSubCategory> FinalSubCategories { get; set; }
        public virtual DbSet<MainCategory> MainCategories { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<ProductHistory> ProductHistories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductSizeHistory> ProductSizeHistories { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SubCategory> SubCatetories { get; set; }
        public virtual DbSet<Profit> Profits { get; set; }
        public virtual DbSet<SaleHistory> SaleHistories { get; set; }
        public virtual DbSet<TempOrder> TempOrders { get; set; }
        public virtual DbSet<TempOrderProduct> TempOrderProducts { get; set; }
    }
}