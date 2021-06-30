using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    public class LogoutController : ApiController
    {
        [Route("api/logout/clear")]
        public IHttpActionResult Get()
        {
            LoginController.ausername = "";
            LoginController.musername = "";
            LoginController.cusername = "";


            LoginController.managerid = 0;
            LoginController.userid = 0;
            LoginController.adminid = 0;

            LoginController.username = "";
            return Ok("SUCCESS");
        }
    }
}
