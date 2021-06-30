using E_Commerce_With_Rest_Api.Models;
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
    public class OrderController : ApiController
    {
        
       
        private ProductRepository productrepo = new ProductRepository();
        private ProductSizeRepository productsizeModel = new ProductSizeRepository();
        private ProfitRepository profitrepo = new ProfitRepository();
        private OrderRepository OrderModel = new OrderRepository();
        private CustomerRepository customerepo = new CustomerRepository();
        private ProductOrderRepository OrderProductModel = new ProductOrderRepository();
        private TempOrderRepository temporderrepo = new TempOrderRepository();
        private TempOrderProductRepository temporderproductrepo = new TempOrderProductRepository();
        private ProductHistoryRepository productHistory = new ProductHistoryRepository();

        [Route("api/order/UpdateOrderInformation/{id}")]
        public IHttpActionResult Get(int id, string paymentmethod)
        {
            var x = ProductController.cartviewlist;
            List<CartViewModel> cartlist = ProductController.cartviewlist;
            
            var date = DateTime.Now;
            foreach (var item in cartlist)
            {
                if (item.product.SizeCategory == "other")
                {
                    Product p1 = new Product();
                    p1 = productrepo.Get(item.product.ProductId);
                    p1.OnHand -= item.count;
                    productrepo.Update(p1);
                }
                else
                {
                    ProductSize psize = new ProductSize();
                    psize = productsizeModel.Get(item.size.ProductSizeID);
                    psize.Count = (psize.Count - item.count);
                    if (psize.Count == 0)
                    {
                        productsizeModel.Delete(psize.ProductSizeID);
                    }
                    else
                    {
                        productsizeModel.Update(psize);
                    }
                }

                TempOrder order = new TempOrder();
                order.date = date;
                order.Quantity = item.count;
                if (item.product.Sale != null)
                {
                    var p = (double)item.product.UnitPrice;
                    var v = Convert.ToDouble(item.product.Sale.Amount) / 100;
                    var c1 = (p - (p * v));
                    order.totalAmount = (decimal)(item.count * c1);
                }
                else
                {
                    order.totalAmount = (item.count * item.product.UnitPrice);
                }
                if (item.product.SizeCategory != "other")
                {
                    order.Size = item.size.SizeName;
                }

                order.PayMentMethod = paymentmethod;
                temporderrepo.Insert(order);

                TempOrderProduct orderproduct = new TempOrderProduct();
                orderproduct.CustomerID = id;
                orderproduct.TempOrderId = order.TempOrderId;
                orderproduct.ProductID = item.product.ProductId;
                temporderproductrepo.Insert(orderproduct);

                /* Profit profit = new Profit();
                 profit.ProductOrderID = orderproduct.ProductOrderID;
                 if (item.product.Sale != null)
                 {
                     var p = (double)item.product.UnitPrice;
                     var v = Convert.ToDouble(item.product.Sale.Amount) / 100;
                     var c1 = (p - (p * v));
                     profit.ProfitAmount = ((decimal)c1 - item.product.Cost) * item.count;
                 }
                 else
                 {
                     profit.ProfitAmount = (item.product.UnitPrice - item.product.Cost) * item.count;
                 }


                 profitrepo.Insert(profit);*/
            }
            
            
            ProductController.cartviewlist.Clear();

            return Ok("SuccessView");
        }
    }
}
