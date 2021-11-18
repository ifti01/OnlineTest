using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DItest.Models;
using DItest.ViewModel;

namespace DItest.Controllers
{
    public class SalesController : Controller
    {
        DItestContext context = new DItestContext();
        // GET: Sales

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaleList()
        {
            SaleListViewModel viewModel = new SaleListViewModel();

            viewModel.Products = context.Products.ToList();
            viewModel.Customers = context.Customers.ToList();

            return View(viewModel);
        }

        public ActionResult SaleInfoProduct(int saleId)
        {
            SaleInfoViewModel viewmodel = new SaleInfoViewModel();

            viewmodel.productin = context.SaleProducts.Where(s => s.SaleId == saleId).ToList();
            
            return PartialView(viewmodel);
        }

        public ActionResult SaleInfoCustomer(int customerId)
        {
            SaleInfoViewModel viewmodel = new SaleInfoViewModel();

            viewmodel.customerin = context.Sales.OrderByDescending(p => p.Id).Where(p => p.CustomerId == customerId).First();

            return PartialView(viewmodel);
        }

        public ActionResult SaleSave(int customerId)
        {
            var customerinfo = context.Customers.Find(customerId);
            
            Sale objsSale = new Sale();

            objsSale.CustomerId = customerinfo.Id;
            objsSale.DeliveryAddress = customerinfo.CustomerAddress;
            objsSale.SaleDateTime = DateTime.Now;
            objsSale.TotalAmount = 0;

            context.Sales.Add(objsSale);
            context.SaveChanges();

            return RedirectToAction("SaleInfoCustomer", new { customerId = objsSale.CustomerId });
        }

        public ActionResult SaleProductsSave(int customerId,int productId)
        {
            var productinfo = context.Products.Find(productId);
            var saleId = context.Sales.OrderByDescending(p => p.Id).Where(p => p.CustomerId == customerId).First();

            SaleProduct newsaleproduct = new SaleProduct
            {
                SaleId = saleId.Id,
                ProductId = productinfo.ProductName,
                Qty = 0,
                Rate = productinfo.Rate,
                Amount = 0
            };

            context.SaleProducts.Add(newsaleproduct);
            context.SaveChanges();

            return RedirectToAction("SaleInfoProduct", new { saleId = newsaleproduct.SaleId });

        }

        [HttpPost]
        public JsonResult TotalInfoUpdate(int customerId, int saleId, decimal totalamount, decimal qty, decimal amount)
        {
            JsonResult result = new JsonResult();
            if (ModelState.IsValid)
            {
                var saleinfo = context.Sales.OrderByDescending(p => p.Id).Where(p => p.CustomerId == customerId).First();

                saleinfo.TotalAmount = totalamount;

                var saleproductinfo = context.SaleProducts.Find(saleId);

                saleproductinfo.Qty = qty;

                saleproductinfo.Amount = amount;

                context.Entry(saleinfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                context.Entry(saleproductinfo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();


                result.Data = new { success = true };
            }
            else
            {
                result.Data = new { success = false, message = "Invalid update" };
            }
            return result;
        }



    }
}