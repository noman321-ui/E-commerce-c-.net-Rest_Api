using E_Commerce_With_Rest_Api.Models;
using E_Commerce_With_Rest_Api.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    public class RegistrationController : ApiController
    {
        private static int cid  = 0;
        private CustomerRepository customerRepository = new CustomerRepository();
        [Route("api/registration/create")]
        public IHttpActionResult Post(Customer customer)
        {
            if (customerRepository.GetByName(customer.Username))
            {
                
                return StatusCode(HttpStatusCode.NoContent);
            }
            
            customer.ImageFile = "0";
            customer.UserType = "customer";
            customerRepository.Insert(customer);
            cid = customer.CustomerID;
            return Ok(customer);

        }

        [Route("api/registration/AddImage")]
        public HttpResponseMessage Post()
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
                Customer customer = customerRepository.Get(cid);
                customer.ImageFile = filename;
                customerRepository.Update(customer);
                result = Request.CreateResponse(HttpStatusCode.Created, customer);
            }

            return result;

        }
    }
}
