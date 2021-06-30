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
    public class ProductController : ApiController
    {
        
        public static List<CartViewModel> cartviewlist = new List<CartViewModel>();
        private ProductRepository product = new ProductRepository();
        private ProductOrderRepository OrderProduct = new ProductOrderRepository();
        private MainCategoryRepository MainCategoryrepo = new MainCategoryRepository();
        private ProductHistoryRepository productHistory = new ProductHistoryRepository();
        [Route("api/product/ManProductlist")]
        public IHttpActionResult Post(ProductListViewModel productListViewModel)
        {
            /*Session["reid"] = id;
            Session["catname"] = categoryname;*/
            if (productListViewModel.categoryname == "f")
            {
                return Ok(product.GetfromFinalCategory(productListViewModel.id));
            }
            else if (productListViewModel.categoryname == "m")
            {
                return Ok(product.GetfromMainCategory(productListViewModel.id));
            }
            else
            {
                return Ok(product.GetfromSubCategory(productListViewModel.id));
            }
            
        }


        [Route("api/product/WomenProductlist")]
        public IHttpActionResult PostWomenProductlist(ProductListViewModel productListViewModel)
        {
            /*Session["reid"] = id;
            Session["catname"] = categoryname;*/
            if (productListViewModel.categoryname == "f")
            {
                return Ok(product.GetfromFinalCategory(productListViewModel.id));
            }
            else if (productListViewModel.categoryname == "m")
            {
                return Ok(product.GetfromMainCategory(productListViewModel.id));
            }
            else
            {
                return Ok(product.GetfromSubCategory(productListViewModel.id));
            }

        }

        [Route("api/product/GetDetails/{id}")]
        public IHttpActionResult Get(int id)
        {
            ProductViewModel productView = new ProductViewModel();
            productView.Product_id = product.Get(id).ProductId;
            if (product.Get(id).OnHand != null)
            {
                productView.Onhand = (int)product.Get(id).OnHand;
            }

            productView.ImageFile = product.Get(id).ImageFile;
            productView.Product_name = product.Get(id).Product_name;
            productView.Description = product.Get(id).Description;
            productView.CategoryID = product.Get(id).MainCategoryId;
            if (product.Get(id).Sale != null)
            {
                var p = (double)product.Get(id).UnitPrice;
                var v = Convert.ToDouble(product.Get(id).Sale.Amount) / 100;
                var c = (p - (p * v));
                productView.UnitPrice = (decimal)c;
            }
            else
            {
                productView.UnitPrice = product.Get(id).UnitPrice;
            }

            productView.FinalSubCategoryID = product.Get(id).FinalSubCategoryID;
            productView.SubCategoryID = product.Get(id).SubCategoryID;
            productView.SizeCategory = product.Get(id).SizeCategory;
            List<string> sizename = new List<string>();
            var r = product.Get(id);
            var f = r.ProductSizes;
            foreach (var item in f)
            {
                if (item.Count == 0)
                {
                    continue;
                }
                sizename.Add(item.SizeName);
            }
            List<int> sizeid = new List<int>();
            foreach (var item in f)
            {
                if (item.Count > 0)
                {
                    sizeid.Add(item.ProductSizeID);
                }

            }

            List<int> sizecount = new List<int>();
            foreach (var item in f)
            {
                if (item.Count > 0)
                {
                    sizecount.Add(item.Count);
                }
            }
            productView.sizecount = sizecount;
            productView.sizename = sizename;
            productView.sizeid = sizeid;
            return Ok(productView);
        }

        [Route("api/product/SortedProductList")]
        public IHttpActionResult Post(string value)
        {
            string sortname = value.Split('|')[0];
            int id = Convert.ToInt32(value.Split('|')[1]);
            string categoryname = value.Split('|')[2];
            /*Session["reid"] = id;
            Session["catname"] = categoryname;*/
            List<SortViewModel> sortmodel = new List<SortViewModel>();
            if (sortname == "atoz")
            {
                if (categoryname == "f")
                {
                    var sortedproduct = product.GetfromFinalCategory(id).OrderBy(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else if (categoryname == "m")
                {
                    var sortedproduct = product.GetfromMainCategory(id).OrderBy(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else
                {
                    var sortedproduct = product.GetfromSubCategory(id).OrderBy(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
            }
            else if (sortname == "ztoa")
            {
                if (categoryname == "f")
                {
                    var sortedproduct = product.GetfromFinalCategory(id).OrderByDescending(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }

                }
                else if (categoryname == "m")
                {
                    var sortedproduct = product.GetfromMainCategory(id).OrderByDescending(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else
                {
                    var sortedproduct = product.GetfromSubCategory(id).OrderByDescending(x => x.Product_name);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
            }
            else if (sortname == "lowtohigh")
            {
                if (categoryname == "f")
                {
                    var sortedproduct = product.GetfromFinalCategory(id).OrderBy(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }

                }
                else if (categoryname == "m")
                {
                    var sortedproduct = product.GetfromMainCategory(id).OrderBy(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else
                {
                    var sortedproduct = product.GetfromSubCategory(id).OrderBy(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
            }
            else if (sortname == "hightolow")
            {
                if (categoryname == "f")
                {
                    var sortedproduct = product.GetfromFinalCategory(id).OrderByDescending(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }

                }
                else if (categoryname == "m")
                {
                    var sortedproduct = product.GetfromMainCategory(id).OrderByDescending(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else
                {
                    var sortedproduct = product.GetfromSubCategory(id).OrderByDescending(x => x.UnitPrice);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
            }
            else if (sortname == "default")
            {
                if (categoryname == "f")
                {
                    var sortedproduct = product.GetfromFinalCategory(id);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }

                }
                else if (categoryname == "m")
                {
                    var sortedproduct = product.GetfromMainCategory(id);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
                else
                {
                    var sortedproduct = product.GetfromSubCategory(id);
                    foreach (var item in sortedproduct)
                    {
                        sortmodel.Add(new SortViewModel()
                        {
                            Product_name = item.Product_name,
                            Product_id = item.ProductId,
                            UnitPrice = item.UnitPrice,
                            ImageFile = item.ImageFile
                        });
                    }
                }
            }

            return Ok(sortmodel);
        }

        [Route("api/product/getcartitem")]
        public IHttpActionResult Get()
        {
            return Ok(cartviewlist);
        }

        [Route("api/product/addcart")]
        public IHttpActionResult Post(CartMethodViewModel cartMethodViewModel)
        {
            int v = 0;
            if (cartMethodViewModel.sizename.Contains('|'))
            {
                v = Convert.ToInt32(cartMethodViewModel.sizename.Split('|')[0]);
            }
            else if (cartMethodViewModel.sizename != "")
            {
                v = Convert.ToInt32(cartMethodViewModel.sizename);
            }
            ProductSizeRepository sizeRepository = new ProductSizeRepository();
             
            for (int x = 0; x < cartviewlist.Count; x++)
            {
                if (product.Get(cartviewlist[x].product.ProductId) == null)
                {
                    cartviewlist[x].outOfStock = "Out Of Stock";
                }
                else
                {
                    cartviewlist[x].outOfStock = "";
                }
            }

            

            CartViewModel cartViewModel = new CartViewModel();
           
            Product model = product.Get(cartMethodViewModel.productid);
            var i = false;
            foreach (var item in cartviewlist)
            {
                if ((v == 0 && item.name == model.Product_name) || (v > 0 && item.name == model.Product_name && item.size.ProductID == model.ProductId))
                {
                    cartviewlist[cartviewlist.IndexOf(item)].count = cartMethodViewModel.quantity;
                    i = true;
                    break;
                }

            }
            if (i)
            {
               
                return Ok(cartviewlist);
            }
            else
            {
                cartViewModel.product = model;
                cartViewModel.name = model.Product_name;
                cartViewModel.count = cartMethodViewModel.quantity; ;
                if (v > 0)
                {
                    cartViewModel.size = sizeRepository.Get(v);
                }
                cartviewlist.Add(cartViewModel);
                
               
                return Ok(cartviewlist);
            }
        }

        [Route("api/product/cartitemdelete/{id}")]
        public IHttpActionResult Getcartitemdelete(int id)
        {

            cartviewlist.RemoveAt(id);
            if(cartviewlist.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok();
            }
            



        }

    }
}
