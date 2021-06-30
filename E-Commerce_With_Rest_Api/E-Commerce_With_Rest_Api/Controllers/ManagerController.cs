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
    public class ManagerController : ApiController
    {
        private TempOrderProductRepository temporderProductRepository = new TempOrderProductRepository();
        private TempOrderRepository temporderrepo = new TempOrderRepository();
        private OrderRepository orderrepo = new OrderRepository();
        private ProductOrderRepository productorderrepo = new ProductOrderRepository();
        private ProfitRepository profitrepo = new ProfitRepository();
        private CustomerRepository customerrepo = new CustomerRepository();
        private ManagerRepository managerRepository = new ManagerRepository();
        private ProductRepository productrepo = new ProductRepository();
        private ProductHistoryRepository producthis = new ProductHistoryRepository();

        [Route("api/manager/index")]
        public IHttpActionResult Get()
        {
            var i = temporderProductRepository.GetAll();
            return Ok(temporderProductRepository.GetAll());
        }

        [Route("api/manager/confirmorder/{id}")]
        public IHttpActionResult Post(int id)
        {
             
            TempOrderProduct temporderProduct = temporderProductRepository.Get(id);
            var pid = temporderProduct.ProductID;
            TempOrder torder = temporderrepo.Get(Convert.ToInt32(temporderProductRepository.Get(id).TempOrderId));
            
            temporderProductRepository.Delete(temporderProductRepository.Get(id).TempOrderProductID);
            temporderrepo.Delete(Convert.ToInt32(torder.TempOrderId));


            Order order = new Order();
            order.date = DateTime.Now;
            order.PayMentMethod = torder.PayMentMethod;
            order.Quantity = torder.Quantity;
            order.Size = torder.Size;
            order.totalAmount = torder.totalAmount;
            orderrepo.Insert(order);


            OrderProduct orderProduct = new OrderProduct();
           
            orderProduct.ProductHistoryId = producthis.GetByProductNameCategory(productrepo.Get(Convert.ToInt32(pid)).Product_name, productrepo.Get(Convert.ToInt32(pid)).MainCategoryId).ProductHistoryId;
            orderProduct.CustomerID = temporderProduct.CustomerID;
            orderProduct.OrderID = order.OrderID;
            productorderrepo.Insert(orderProduct);

            Profit profit = new Profit();

            ProductHistory phis = producthis.Get(orderProduct.ProductHistoryId);
            profit.OrderProductId = orderProduct.OrderProductId;
            if (phis.Sale != null)
            {
                var p = (double)phis.UnitPrice;
                var v = Convert.ToDouble(phis.Sale.Amount) / 100;
                var c1 = (p - (p * v));
                profit.ProfitAmount = ((decimal)c1 - phis.Cost) * order.Quantity;
            }
            else
            {
                profit.ProfitAmount = (phis.UnitPrice - phis.Cost) * order.Quantity;
            }


            profitrepo.Insert(profit);

            return Ok("success");
        }

        [Route("api/manager/deleteOrder/{id}")]
        public IHttpActionResult PostdeleteOrder(int id)
        {
            TempOrderProduct temporderProduct = temporderProductRepository.Get(id);
            TempOrder torder = temporderrepo.Get(Convert.ToInt32(temporderProductRepository.Get(id).TempOrderId));
            temporderProductRepository.Delete(temporderProductRepository.Get(id).TempOrderProductID);
            temporderrepo.Delete(torder.TempOrderId);

            return Ok("success");
        }


    }
}
