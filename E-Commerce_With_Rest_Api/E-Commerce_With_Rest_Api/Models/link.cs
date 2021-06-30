using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Link
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string Relation { get; set; }
    }
}