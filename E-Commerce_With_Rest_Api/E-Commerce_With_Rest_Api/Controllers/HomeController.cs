using E_Commerce_With_Rest_Api.Models;
using E_Commerce_With_Rest_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    
    public class HomeController : ApiController
    {
        private CustomerRepository customerrepo = new CustomerRepository();
        private MainCategoryRepository mainCategoryRepository = new MainCategoryRepository();
        private SubCategoryRepository subCategoryRepository = new SubCategoryRepository();
        private FinalSubCategoryRepository finalSubCategoryRepository = new FinalSubCategoryRepository();
        
        [Route("api/getProducts/{id}/{category}")]
        public IHttpActionResult getProducts(int id, int category)
        {
            /*Session["admin"] = null;
            Session["adminLoginID"] = null;
            Session["adminUserName"] = null;
            Session["paymentmethod"] = null;*/
            if (category == 1)
            {
                mainCategoryRepository.Get(id);
                return Ok(mainCategoryRepository);
            }
            else if (category == 2)
            {
                subCategoryRepository.Get(id);
                return Ok(subCategoryRepository);
            }
            else
            {
                finalSubCategoryRepository.Get(id);
                return Ok(finalSubCategoryRepository);
            }

        }
        [Route("api/home/manCategories/{id}")]
        public IHttpActionResult Get(int id)
        {
            //Session["admin"] = null;
            //Session["adminLoginID"] = null;
            //Session["adminUserName"] = null;
            //Session["paymentmethod"] = null;
            
            return Ok(mainCategoryRepository.Get(id));
        }

        [Route("api/home/womenCategories/{id}")]
        public IHttpActionResult GetwomenCategories(int id)
        {
          
            return Ok(mainCategoryRepository.Get(id));
        }


        //[HttpGet]
        //public ActionResult womenCategories(int id)
        //{
        //    Session["admin"] = null;
        //    Session["adminLoginID"] = null;
        //    Session["adminUserName"] = null;
        //    Session["paymentmethod"] = null;
        //    return View(mainCategoryRepository.Get(id));
        //}

        //[HttpGet]
        //public ActionResult lifestylesCategories(int id)
        //{
        //    Session["admin"] = null;
        //    Session["adminLoginID"] = null;
        //    Session["adminUserName"] = null;
        //    Session["paymentmethod"] = null;
        //    return View(mainCategoryRepository.Get(id));
        //}

        //[HttpGet]
        //public ActionResult saleProducts(int id)
        //{
        //    Session["admin"] = null;
        //    Session["adminLoginID"] = null;
        //    Session["adminUserName"] = null;
        //    Session["paymentmethod"] = null;
        //    return View(mainCategoryRepository.Get(id));
        //}
    }
}
