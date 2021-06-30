using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class CartMethodViewModel
    {
        public int productid { get; set; }

        public int quantity { get; set; }

        public string sizename { get; set; }
    }
}