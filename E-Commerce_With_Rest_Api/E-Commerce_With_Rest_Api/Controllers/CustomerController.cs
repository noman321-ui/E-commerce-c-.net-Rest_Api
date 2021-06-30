using E_Commerce.ReportContent;
using E_Commerce_With_Rest_Api.Attributes;
using E_Commerce_With_Rest_Api.Models;
using E_Commerce_With_Rest_Api.Models.ViewModels;
using E_Commerce_With_Rest_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        private ReviewRepository reviewModel = new ReviewRepository();
        private ProductOrderRepository productorder = new ProductOrderRepository();
        private TempOrderProductRepository tempproductorder = new TempOrderProductRepository();

        [Route("api/customer/updateInfoDuringCheckout")]
        public IHttpActionResult PUT(Customer customer)
        {
            customer.UserType = "customer";
            customerRepository.Update(customer);
            return Ok("Success");
        }

        [Route("api/customer/GetDetails/{id}"), BasicAuthentication]
        public IHttpActionResult Get(int id)
        {  
            return Ok(customerRepository.Get(id));
        }


        [Route("api/customer/updateImage/{id}")]
        public HttpResponseMessage PUT(int id)
        {
            String filename = "";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];

                    var filePath = HttpContext.Current.Server.MapPath("~/content/image/" + postedFile.FileName);
                    filename += postedFile.FileName;
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }
                Customer customer = customerRepository.Get(id);
                customer.ImageFile = filename;
                customerRepository.Update(customer);
                result = Request.CreateResponse(HttpStatusCode.OK, customer);
            }

            return result;

        }


        [Route("api/customer/updateCustomerInfo/{id}")]
        public IHttpActionResult PutupdateCustomerInfo(Customer customer)
        {
            
            customer.UserType = "customer";
            customerRepository.Update(customer);
            return Ok(customer);

        }
        [Route("api/customer/GetOrderReportData/{id}")]
        public IHttpActionResult GetOrderReportData(int id)
        {
            try
            {
                var c = productorder.GetAll();
                var x2 = c.Where(x1 => x1.CustomerID == id && x1.ProductHistory.MainCategory.Category_name == "Men").Count();
            }catch(Exception exc)
            {

            }
           
            int MenCategory = (productorder.GetAll()).Where(x => x.CustomerID == id && x.ProductHistory.MainCategory.Category_name == "Men").Count();
            int WomenCategory = (productorder.GetAll()).Where(x => x.CustomerID == id && x.ProductHistory.MainCategory.Category_name == "Women").Count();
            int LifeStyleCategory = (productorder.GetAll()).Where(x => x.CustomerID == id && x.ProductHistory.MainCategory.Category_name == "Life Style").Count();


            Ratio obj = new Ratio();
            obj.MenCategory = MenCategory;
            obj.WomenCategory = WomenCategory;
            obj.LifeStyleCategory = LifeStyleCategory;

            return Json(obj);
        }


        [Route("api/customer/UpdatePassword")]
        public IHttpActionResult Post(ChangePasswordViewModel customer)
        {
            Customer realcustomer = customerRepository.Get(customer.CustomerID);
            if (realcustomer.password == customer.password)
            {
                realcustomer.password = customer.newpassword;
                customerRepository.Update(realcustomer);
            }
            return Ok("success");
        }


        [Route("api/customer/GetTotalOrders/{id}")]
        public IHttpActionResult GetTotalOrders(int id)
        {
            return Ok(productorder.getordersbycid(id));
        }
        [Route("api/customer/GetPendingOrders/{id}")]
        public IHttpActionResult GetPendingOrders(int id)
        {
            var i = tempproductorder.gettempordersbycid(id);
            return Ok(tempproductorder.gettempordersbycid(id));
        }

        [Route("api/customer/reviewlist/{id}")]
        public IHttpActionResult Getreviewlist(int id)
        {
            return Ok(customerRepository.Get(id).Reviews);
        }

        [Route("api/customer/SaleVsRegularOrderReport")]
        public IHttpActionResult Post()
        {

            var chartData = new object[3];
            chartData[0] = new object[]{
                    "Order Product Type",
                    "Count Amount"
                };

            int saleProductOrderCount = productorder.GetAll().Where(x => x.ProductHistory.SaleHistory != null && x.CustomerID == LoginController.userid).Count();
            int RegularProductOrderCount = productorder.GetAll().Where(x => x.ProductHistory.SaleHistory == null && x.CustomerID == LoginController.userid).Count();
            chartData[1] = new object[] { "Sale Product Order", saleProductOrderCount };
            chartData[2] = new object[] { "Regular Product Order", RegularProductOrderCount };
            
            return Json(chartData);
        }
    }
}
