using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageFile { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }

        
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        
        public virtual ICollection<Report> Reports { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; }
        
        public virtual ICollection<TempOrderProduct> TempOrderProducts { get; set; }
    }
}