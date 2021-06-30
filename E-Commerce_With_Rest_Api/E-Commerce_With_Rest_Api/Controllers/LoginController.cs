using E_Commerce_With_Rest_Api.Models;
using E_Commerce_With_Rest_Api.Models.ViewModels;
using E_Commerce_With_Rest_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    [RoutePrefix("api/logins")]
    public class LoginController : ApiController
    {
        public static int adminid = 0;
        public static int managerid = 0;
        public static int userid = 0;

        public static string username = "";

        public static string ausername = "";
        public static string musername = "";
        public static string cusername = "";

        private CustomerRepository customerRepository = new CustomerRepository();
        private ManagerRepository managerrepo = new ManagerRepository();
        private AdminRepository adminRepository = new AdminRepository();
        [HttpPost]
        public IHttpActionResult Index(LoginViewModel loginViewModel)
        {

            Customer user = customerRepository.validateLogin(loginViewModel.Username, loginViewModel.Password);
            Admin auser = adminRepository.adminValidateLogin(loginViewModel.Username, loginViewModel.Password);
            Manager muser = managerrepo.managerValidateLogin(loginViewModel.Username, loginViewModel.Password);


            if (auser != null)
            {
                username = auser.Username;
                ausername = auser.Username;
                musername = "";
                cusername = "";

                

                managerid = 0;
                userid = 0;
                adminid = auser.AdminID;
                return Ok(auser);
            }
            else if (muser != null)
            {
                username = muser.Username;

                ausername = "";
                musername = muser.Username;
                cusername = "";

                adminid = 0;
                userid = 0;
                managerid = muser.ManagerID;
                return Ok(muser);
            }
            else if (user != null)
            {
                username = user.Username;

                ausername = "";
                musername = "";
                cusername = user.Username;

                adminid = 0;
                managerid = 0;
                userid = user.CustomerID;
                return Ok(user);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
