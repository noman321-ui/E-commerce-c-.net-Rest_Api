using E_Commerce_With_Rest_Api.Attributes;
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
using System.Web.Hosting;
using System.Web.Http;

namespace E_Commerce_With_Rest_Api.Controllers
{
    public class AdminController : ApiController
    {
        private static int pid = 0;
        private static int phid = 0;
        private AdminRepository adminrepo = new AdminRepository();
        private ProductRepository productRepository = new ProductRepository();
        private ProductHistoryRepository producthistory = new ProductHistoryRepository();
        private ProductSizeHistoryRepository sizehistory = new ProductSizeHistoryRepository();
        private SubCategoryRepository SubCategory = new SubCategoryRepository();
        private FinalSubCategoryRepository FinalSub = new FinalSubCategoryRepository();
        private MainCategoryRepository mainCategoryRepository = new MainCategoryRepository();
        private ReviewRepository reviewrepo = new ReviewRepository();
        private CustomerRepository customer = new CustomerRepository();
        private ProfitRepository profitrepo = new ProfitRepository();
        private ProductOrderRepository productorder = new ProductOrderRepository();
        private ManagerRepository mrepo = new ManagerRepository();



        [Route("api/admin/mainCategories")]
        public IHttpActionResult Get()
        {
            //Session["admin"] = null;
            //Session["adminLoginID"] = null;
            //Session["adminUserName"] = null;
            //Session["paymentmethod"] = null;
            
            return Ok(mainCategoryRepository.GetAll());
        }
        [Route("api/admin/getbyproductid/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(productRepository.Get(id));
        }

        [Route("api/admin/AddProduct")]
        public IHttpActionResult Post(Product product)
        {
           
            if (product.SubCategoryID != null)
            {
                product.MainCategoryId = SubCategory.Get((int)product.SubCategoryID).MainCategoryId;
            }
            if (product.FinalSubCategoryID != null)
            {
                product.SubCategoryID = FinalSub.Get((int)product.FinalSubCategoryID).SubCategoryId;
                product.MainCategoryId = SubCategory.Get((int)product.SubCategoryID).MainCategoryId;
            }
               
          
            product.AddedDate = DateTime.Now;
            product.ImageFile = "0";
            productRepository.Insert(product);

            ProductHistory Phistory = new ProductHistory();
            Phistory.AddedDate = product.AddedDate;
            Phistory.OnHand = product.OnHand;
            Phistory.Product_name = product.Product_name;
            Phistory.UnitPrice = product.UnitPrice;
            Phistory.Description = product.Description;
            Phistory.ImageFile = product.ImageFile;
            Phistory.Cost = product.Cost;
            Phistory.MainCategoryId = product.MainCategoryId;
            Phistory.SubCategoryID = product.SubCategoryID;
            Phistory.FinalSubCategoryID = product.FinalSubCategoryID;
            Phistory.SizeCategory = product.SizeCategory;
            producthistory.Insert(Phistory);

            pid = product.ProductId;
            phid = Phistory.ProductHistoryId;
            
            return Ok(product);
            

        }

        [Route("api/admin/AddImage")]
        public HttpResponseMessage Post()
        {
            String filename = "";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                for(int i=0; i<httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/content/image/" + postedFile.FileName);
                    filename += postedFile.FileName + '|';
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }
               
                Product product = productRepository.Get(pid);
                product.ImageFile = filename.Remove(filename.Length - 1, 1);
                productRepository.Update(product);

                ProductHistory phis = producthistory.Get(phid);
                phis.ImageFile = filename.Remove(filename.Length - 1, 1);
                producthistory.Update(phis);
                result = Request.CreateResponse(HttpStatusCode.Created, product);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
                  
            return result;

        }

        [Route("api/admin/AddSize")]
        public IHttpActionResult PostAddSize(SizeListVieModel sizeListViewModel)
        {
            HttpResponseMessage result = null;
            var name = HttpContext.Current.Request;
            ProductSizeRepository productSizeRP = new ProductSizeRepository();
            ProductSize model = new ProductSize();

            
            for (int i = 0; i < sizeListViewModel.counlist.Count; i++)
            {
                model.Count = Convert.ToInt32(sizeListViewModel.counlist.ElementAt(i));
                model.ProductID = Convert.ToInt32(sizeListViewModel.id);
                model.SizeName = sizeListViewModel.sizelist.ElementAt(i);
                
                productSizeRP.Insert(model);

                ProductSizeHistory sizemodelhistory = new ProductSizeHistory();
                sizemodelhistory.Count = model.Count;
                sizemodelhistory.ProductHistoryId = sizehistory.GetByProductNameCategory(productRepository.Get(Convert.ToInt32(sizeListViewModel.id)).Product_name, productRepository.Get(Convert.ToInt32(sizeListViewModel.id)).MainCategoryId).ProductHistoryId;
                sizemodelhistory.SizeName = model.SizeName;
                sizemodelhistory.Count = model.Count;
                sizehistory.Insert(sizemodelhistory);
            }
            return StatusCode(HttpStatusCode.Created);
        }
        [Route("api/admin/AddManager")]
        public IHttpActionResult PostAddManager(Manager manager)
        {
            manager.ImageFIle = "0";
            mrepo.Insert(manager);
            return Ok(manager);
        }

        [Route("api/admin/AddImageManager/{id}")]
        public HttpResponseMessage PostAddImageManager(int id)
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
                Manager manager = mrepo.Get(id);
                manager.ImageFIle = filename;
                mrepo.Update(manager);
                result = Request.CreateResponse(HttpStatusCode.Created, manager);
            }

            return result;

        }

        [Route("api/admin/productwithoutsize")]
        public IHttpActionResult Getproductwithoutsize()
        {
          
            double totalrevenue = 0;
            foreach (var item in profitrepo.GetAll())
            {
                totalrevenue += (double)item.ProfitAmount;
            }
            
            return Ok(productRepository.ProductsWithoutSize());
        }

        [Route("api/admin/validate"), BasicAuthentication]
        public IHttpActionResult Getvalidate()
        {
            return Ok("success");
        }

        [Route("api/admin/netprofit")]
        public IHttpActionResult Getnetprofit()
        {

            double totalrevenue = 0;
            foreach (var item in profitrepo.GetAll())
            {
                totalrevenue += (double)item.ProfitAmount;
            }

            return Ok(totalrevenue);
        }


        [Route("api/admin/ProfitReport")]
        public IHttpActionResult PostProfitReport()
        {
            var model = profitrepo.GetAll();
            var data1 = model.Where(x => x.OrderProduct.ProductHistory.MainCategory.Category_name == "Men");
            var data2 = model.Where(x => x.OrderProduct.ProductHistory.MainCategory.Category_name == "Women");
            var data3 = model.Where(x => x.OrderProduct.ProductHistory.MainCategory.Category_name == "Life Style");
            var c = data1.ElementAt(0).OrderProduct.Order.date.ToString().Split(' ')[0];
            var chartData = new object[11];
            chartData[0] = new object[]{
                   "Date",
                "Men Category",
                "Women Category",
                "LifeStyle Category"
            };
            DateTime EndDate = DateTime.Today;
            DateTime StartDate = DateTime.Today.AddDays(-10);
            int DayInterval = 1;

            List<DateTime> dateList = new List<DateTime>();
            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                StartDate = StartDate.AddDays(DayInterval);
                dateList.Add(StartDate);
            }

            int j = 0;
            foreach (var item in dateList)
            {
                var cz = item.ToString();
                double menamount = 0;
                double womenamount = 0;
                double lifestyleamount = 0;

                foreach (var item2 in data1.Where(x => (x.OrderProduct.Order.date).ToString().Split(' ')[0] == item.ToString().Split(' ')[0]))
                {
                    menamount += (double)item2.ProfitAmount;

                }
                foreach (var item2 in data2.Where(x => (x.OrderProduct.Order.date).ToString().Split(' ')[0] == item.ToString().Split(' ')[0]))
                {
                    womenamount += (double)item2.ProfitAmount;

                }
                foreach (var item2 in data3.Where(x => (x.OrderProduct.Order.date).ToString().Split(' ')[0] == item.ToString().Split(' ')[0]))
                {
                    lifestyleamount += (double)item2.ProfitAmount;

                }

                j++;
                chartData[j] = new object[] { item.ToString().Split(' ')[0], menamount, womenamount, lifestyleamount };
            }



            return Json(chartData);
        }


        [Route("api/admin/profitbyCategory")]
        public IHttpActionResult PostprofitbyCategory()
        {
            var chartData = new object[4];
            chartData[0] = new object[]{
                    "Category Type",
                    "Profit"
                };
            double ManCategory = 0;
            double WomenCategory = 0;
            double LifeStyleCategory = 0;
            var x1 = profitrepo.GetAll().Where(x => x.OrderProduct.ProductHistory.MainCategoryId == 1);
            foreach(var item in x1)
            {
                ManCategory += (double)item.ProfitAmount;
            }
            var x2 = profitrepo.GetAll().Where(x => x.OrderProduct.ProductHistory.MainCategoryId == 2);
            foreach (var item in x2)
            {
                WomenCategory += (double)item.ProfitAmount;
            }
            var x3 = profitrepo.GetAll().Where(x => x.OrderProduct.ProductHistory.MainCategoryId == 3);
            foreach (var item in x3)
            {
                LifeStyleCategory += (double)item.ProfitAmount;
            }
           
            chartData[1] = new object[] { "Man Category Profit", ManCategory };
            chartData[2] = new object[] { "Women Category Profit", WomenCategory };
            chartData[3] = new object[] { "LifeStyle Category Profit", LifeStyleCategory };

            return Json(chartData);
        }


        [Route("api/admin/profit")]
        public IHttpActionResult Getprofit()
        {
            return Ok(profitrepo.GetAll());
        }


        [Route("api/admin/ManProductlist")]
        public IHttpActionResult Post(ProductListViewModel productListViewModel)
        {
            /*Session["reid"] = id;
            Session["catname"] = categoryname;*/
            if (productListViewModel.categoryname == "f")
            {
                return Ok(productRepository.GetfromFinalCategory(productListViewModel.id));
            }
            else if (productListViewModel.categoryname == "m")
            {
                return Ok(productRepository.GetfromMainCategory(productListViewModel.id));
            }
            else
            {
                return Ok(productRepository.GetfromSubCategory(productListViewModel.id));
            }

        }

        [Route("api/admin/admins")]
        public IHttpActionResult Getadmins()
        {
            List<Admin> admins = adminrepo.GetAll();
            foreach (var item in admins)
            {
                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/AddProduct", Method = "POST", Relation = "this link is for add new product " });
                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/getbyproductid/{id}", Method = "POST", Relation = "this link is for searching product by id" });
                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/AddImage", Method = "POST", Relation = "this link is for adding image into product" });

                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/ManProductlist", Method = "POST", Relation = "this link is for getting productlist of ManCategory " });
                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/netprofit", Method = "GET", Relation = "this link is for getting net profit" });
                item.Links.Add(new Link() { Url = "http://localhost:49274/api/admin/mainCategories", Method = "GEt", Relation = "this link is for getting mancategories list" });
            }
            return Ok(admins);
        }

    }
}
