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
    public class CartController : ApiController
    {
        private CustomerRepository customermodel = new CustomerRepository();
        private ProductRepository product = new ProductRepository();
        private ProductSizeRepository productsizeModel = new ProductSizeRepository();
        private OrderRepository OrderModel = new OrderRepository();
        private ProductOrderRepository OrderProductModel = new ProductOrderRepository();
        // GET: Cart
        [Route("api/cart/index")]
        public IHttpActionResult Get()
        {
            
            List<CartViewModel> model = ProductController.cartviewlist;
           
            for (int x = 0; x < model.Count; x++)
            {
                if (product.Get(model[x].product.ProductId) == null)
                {
                    model[x].outOfStock = "Out Of Stock";
                }
                else
                {
                    model[x].outOfStock = "";
                }
            }
            return Ok(model);
        }

        [Route("api/cart/Checkout/{id}")]
        public IHttpActionResult Get(int id)
        {
           
            CheckOutViewModel checkOutViewModel = new CheckOutViewModel();
            checkOutViewModel.customer = customermodel.Get(id);
            List<CartViewModel> cartViewModels = ProductController.cartviewlist;
            checkOutViewModel.cartproductlist = cartViewModels;
            return Ok(checkOutViewModel);
            

        }
    }
}
