using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class SizeListVieModel
    {
        public List<string> sizelist { get; set; }
        public List<string> counlist { get; set; }
        public string id { get; set; }
    }
}