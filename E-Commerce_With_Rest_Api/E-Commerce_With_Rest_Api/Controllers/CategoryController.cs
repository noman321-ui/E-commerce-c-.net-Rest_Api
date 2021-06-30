using E_Commerce_With_Rest_Api.Models.ViewModels;
using E_Commerce_With_Rest_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private MainCategoryRepository mainCategoryRepository = new MainCategoryRepository();
        private SubCategoryRepository subCategoryRepository = new SubCategoryRepository();
        private FinalSubCategoryRepository finalSubCategoryRepository = new FinalSubCategoryRepository();
        [HttpGet]
        public IHttpActionResult NavBar()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.mainCategories = mainCategoryRepository.GetAll();
            categoryViewModel.subCatetories = subCategoryRepository.GetAll();
            categoryViewModel.finalSubCategories = finalSubCategoryRepository.GetAll();
            return Ok(mainCategoryRepository.GetAll());
        }
    }
}
