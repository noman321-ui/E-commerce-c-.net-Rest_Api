using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models
{
    public class Profit
    {
        public int ProfitID { get; set; }
        public int OrderProductId { get; set; }
        public decimal ProfitAmount { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
    }
}