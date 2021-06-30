using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class SizeListViewModel
    {
        public List<SizeName> sizelist { get; set; }
        public List<CountName> counlist { get; set; }
        public int id { get; set; }
    }
}