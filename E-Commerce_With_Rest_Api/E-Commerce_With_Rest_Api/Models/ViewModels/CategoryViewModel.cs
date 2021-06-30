using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_With_Rest_Api.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<MainCategory> mainCategories = new List<MainCategory>();
        public List<SubCategory> subCatetories = new List<SubCategory>();
        public List<FinalSubCategory> finalSubCategories = new List<FinalSubCategory>();
    }
}