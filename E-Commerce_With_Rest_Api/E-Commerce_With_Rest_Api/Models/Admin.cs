using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string PhoneNum { get; set; }
        public string ImageFile { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        List<Link> links = new List<Link>();
        public List<Link> Links
        {
            get { return links; }
        }
    }
}