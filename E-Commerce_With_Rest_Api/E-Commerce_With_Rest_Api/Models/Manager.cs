using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ImageFIle { get; set; }
        public decimal Salary { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }
    }
}