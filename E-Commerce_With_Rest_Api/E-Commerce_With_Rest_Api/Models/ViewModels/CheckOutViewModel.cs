﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public Customer customer { set; get; }
        public List<CartViewModel> cartproductlist { set; get; }
    }
}