using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class SizeViewModel
    {
        public ProductSize productSizes { get; set; }
        public List<string> sizelist { get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public Product product { get; set; }
    }
}