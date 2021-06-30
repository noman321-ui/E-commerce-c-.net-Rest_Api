using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}