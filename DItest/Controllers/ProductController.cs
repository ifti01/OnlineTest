using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DItest.Models;
using DItest.ViewModel;

namespace DItest.Controllers
{
    public class ProductController : Controller
    {
        DItestContext context = new DItestContext();

        // GET: Product
        public ActionResult Entry()
        {

            return View();
        }

        [HttpPost] 
        public ActionResult Entry(Product modelProduct)
        {
            Product obj = new Product();

            obj.ProductName = modelProduct.ProductName;
            obj.Unit = modelProduct.Unit;
            obj.Rate = modelProduct.Rate;

            context.Products.Add(obj);
            context.SaveChanges();

            return View();
        }

        public ActionResult List()
        {
            ProductViewModel model = new ProductViewModel();

            model.Products = context.Products.ToList();

            return View(model);
        }

        public ActionResult Update(int Id)
        {
            var product = context.Products.Find(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product modelProduct)
        {
            var obj = context.Products.Find(modelProduct.Id);


            
            obj.ProductName = modelProduct.ProductName;
            obj.Unit = modelProduct.Unit;
            obj.Rate = modelProduct.Rate;

            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}